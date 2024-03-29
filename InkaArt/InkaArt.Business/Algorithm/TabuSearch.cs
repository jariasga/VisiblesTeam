﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using Npgsql;
using System.Windows.Forms;

namespace InkaArt.Business.Algorithm
{
    public class TabuSearch
    {
        private Simulation simulation;
        private IndexController indexes;
        private int limit_day_time;
        private int start_time;

        // reactive tabu list
        private int list_length;
        private double list_growth;
        private int max_no_growth;

        // neighbor
        private int neighbor_checks;

        // solutions
        private int max_iterations;
        private double best_fitness;
        private List<Assignment> initial_solution;
        private List<Assignment> best_solution;

        public List<Assignment> BestSolution
        {
            get { return best_solution; }
            set { best_solution = value; }
        }

        public TabuSearch(Simulation simulation, IndexController indexes, List<Assignment> solution, int elapsed_time)
        {
            loadParameters();            
            this.simulation = simulation;
            this.indexes = indexes;
            this.start_time = elapsed_time;
            this.limit_day_time = (Simulation.LimitTime - elapsed_time) / simulation.Days;
            this.initial_solution = solution;
            this.best_solution = new List<Assignment>();
        }

        private void createInitialSolution()
        {
            WorkerController workers = new WorkerController();
            workers.Workers.Add(simulation.SelectedWorkers.Workers[0]);
            workers.Workers.Add(simulation.SelectedWorkers.Workers[1]);
            List<Assignment> initial_solution = new List<Assignment>();
            Assignment day = new Assignment(DateTime.Now, workers, 3);
        }

        private bool loadParameters()
        {
            bool read = false;
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = BD_Connector.ConnectionString.ConnectionString;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"TabuParameters\"", connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read() && !read)
            {
                // reactive tabu list
                this.list_length = Convert.ToInt16(reader["list_length"]);    // largo inicial
                this.list_growth = Convert.ToDouble(reader["list_growth"]);   // porcentaje de crecimiento, alfa ( cuando crece: tama;o * (1 + tabu_list_growth) )
                this.max_no_growth = Convert.ToInt16(reader["max_no_growth"]);       // numero de iteraciones maximas sin alargar la lista, superado esto se reduce el largo

                // solutions
                this.max_iterations = Convert.ToInt16(reader["max_iterations"]);      // condicion de meseta: cantidad maxima de iteraciones sin una mejora en la mejor solucion

                // neighbor
                this.neighbor_checks = Convert.ToInt16(reader["neighbor_checks"]);     // cantidad maxima de vecinos a evaluar                
                read = true; 
            }
            connection.Close();

            return read;
        }

        /// <summary>
        /// Calcula la función objetivo de la asignación promediando los índices de pérdida de cada línea de asignación.
        /// </summary>
        public double GetFitness(Assignment assignment)
        {
            /* 
             * Indice de perdida: (peso_rotura*rotura + peso_tiempo*tiempo)/peso_producto para cada trabajadorxprocesoxproducto
             */

            double fitness = 0;
            int assigned_workers = 0;

            for (int worker_index = 0; worker_index < simulation.SelectedWorkers.NumberOfWorkers; worker_index++)
            {
                AssignmentLine current_assignment_line = null;
                for (int miniturn_index = 0; miniturn_index < simulation.TotalMiniturns; miniturn_index++)
                {
                    //Leer cada línea de asignación de la matriz y ver que no esté repetida
                    AssignmentLine assignment_line = assignment[worker_index, miniturn_index];
                    if (assignment_line == null) continue;
                    if (current_assignment_line == null || !current_assignment_line.Equals(assignment_line)) current_assignment_line = assignment_line;
                    //Aumentar el fitness total y la cantidad de trabajadores asignados
                    assigned_workers++;
                    fitness += assignment_line.LossIndex;
                }
            }
            if (assigned_workers <= 0) assigned_workers = 1;

            //Dividimos lo acumulado solo entre los trabajadores asignados
            return fitness / assigned_workers;
        }
        
        private Assignment getNeighbor(Assignment solution, TabuMove move)
        {
            /* Creara una nueva solucion por medio de un swap aleatorio, intercambiando dias o miniturnos */

            Assignment neighbor = new Assignment(solution);
            int num_workers = simulation.SelectedWorkers.Count();

            // move attributes
            int swap_type = Randomizer.NextNumber(0, 1);
            int worker1_index;
            int worker2_index;

            // workers
            worker1_index = Randomizer.NextNumber(0, num_workers - 1);
            worker2_index = Randomizer.NextNumber(0, num_workers - 1);
            while (num_workers > 1 && worker1_index == worker2_index)
                worker2_index = Randomizer.NextNumber(0, num_workers - 1);

            // tipo 0: intercambiar el dia entero
            if (swap_type == 0)
            {
                swapDays(neighbor, worker1_index, worker2_index);
            }
            // tipo 1: intercambiar miniturnos
            else
            {
                int miniturn_index = Randomizer.NextNumber(0, simulation.TotalMiniturns - 1);
                swapMiniturns(solution, worker1_index, worker2_index, miniturn_index);
            }

            // guardamos movimiento
            move = saveMove(swap_type, neighbor, worker1_index, worker2_index);

            return neighbor;
        }

        private void swapDays(Assignment solution, int worker1_index, int worker2_index)
        {
            Worker worker1 = simulation.SelectedWorkers[worker1_index];
            Worker worker2 = simulation.SelectedWorkers[worker2_index];
            AssignmentLine assignment1, assignment2;

            for (int miniturn = 0; miniturn < simulation.TotalMiniturns; miniturn++)
            {
                assignment1 = solution[worker1_index, miniturn];                
                assignment2 = solution[worker2_index, miniturn];                                
                solution[worker2_index, miniturn] = updateMiniturn(assignment1, worker2);
                solution[worker1_index, miniturn] = updateMiniturn(assignment2, worker1);
            }
        }

        private void swapMiniturns(Assignment solution, int worker1_index, int worker2_index, int miniturn_index)
        {
            Worker worker1 = simulation.SelectedWorkers[worker1_index];
            Worker worker2 = simulation.SelectedWorkers[worker2_index];
            AssignmentLine assignment1 = solution[worker1_index, miniturn_index];
            AssignmentLine assignment2 = solution[worker2_index, miniturn_index];
            AssignmentLine assignment;

            // actualizamos todo lo anterior
            for (int i = 0; i < simulation.TotalMiniturns; i++)
            {
                assignment = solution[worker1_index, i];
                decreaseMiniturn(assignment1, assignment, miniturn_index, i);
                assignment = solution[worker2_index, i];
                decreaseMiniturn(assignment2, assignment, miniturn_index, i);
            }

            // intercambiamos
            assignment1 = solution[worker1_index, miniturn_index];
            assignment2 = solution[worker2_index, miniturn_index];
            solution[worker2_index, miniturn_index] = updateMiniturn(assignment1, worker2);
            solution[worker1_index, miniturn_index] = updateMiniturn(assignment2, worker1);
        }

        private void decreaseMiniturn(AssignmentLine assignment_pivot, AssignmentLine assignment, int miniturn_pivot, int miniturn)
        {            
            // dividimos bloques de miniturnos y actualizamos sus valores
            if (assignment_pivot != null && assignment != null && assignment.Equals(assignment_pivot))
            {                
                if (miniturn_pivot == miniturn) return;

                Index index = indexes.FindByAssignment(assignment_pivot);
                // minuturnos anteriores
                if (miniturn_pivot > miniturn)
                    assignment.MiniturnsUsed = miniturn - assignment.MiniturnStart;
                // miniturnos posteriores
                else
                {
                    assignment.MiniturnsUsed -= miniturn_pivot - assignment.MiniturnStart;
                    assignment.MiniturnStart = miniturn_pivot + 1;                    
                }
                assignment.Produced = AssignmentLine.MiniturnsToProduced(assignment.MiniturnsUsed, assignment.AverageTime, Simulation.MiniturnLength);
            }
        }

        private AssignmentLine updateMiniturn(AssignmentLine assignment, Worker worker)
        {
            if (assignment != null)
                assignment.Produced = AssignmentLine.MiniturnsToProduced(assignment.MiniturnsUsed, assignment.AverageTime, Simulation.MiniturnLength);
            return assignment;
        }

        private TabuMove saveMove(int type, Assignment solution, int worker1, int worker2)
        {
            TabuMove move;
            int item1, item2;

            // process
            if (type == 0)
            {
                item1 = solution.getProcessId(worker1, simulation);
                item2 = solution.getProcessId(worker2, simulation);
            }
            // product 
            else
            {
                item1 = solution.getProductId(worker1, type);
                item2 = solution.getProductId(worker2, type);
            }
            move = new TabuMove(type, worker1, item1, worker2, item2);

            return move;
        }

        public void SwapWorkers(Assignment solution, int worker1_index, int worker2_index)
        {
            Worker worker1 = simulation.SelectedWorkers[worker1_index];
            Worker worker2 = simulation.SelectedWorkers[worker2_index];

            for (int miniturn = 0; miniturn < simulation.TotalMiniturns; miniturn++)
            {
                AssignmentLine assignment1, assignment2;

                assignment1 = solution[worker1_index, miniturn];
                assignment2 = solution[worker2_index, miniturn];

                if (assignment1 != null) assignment1.Worker = worker2;
                solution[worker2_index, miniturn] = assignment1;
                if (assignment2 != null) assignment2.Worker = worker1;
                solution[worker1_index, miniturn] = assignment2;                
            }
        }

        public List<Assignment> BestSolutionToList()
        {
            if (best_solution == null || best_solution.Count <= 0) best_solution = initial_solution;
            for (int i = 0; i < best_solution.Count; i++)
                if (best_solution[i] != null) best_solution[i].AssignmentLinesList = best_solution[i].MatrixToList(simulation);

            return best_solution;
        }

        /* Flujo del algoritmo */
        public void run(ref int elapsed_time, int day)
        {
            // soluciones
            Assignment current_solution = new Assignment(initial_solution[day]);
            Assignment best_day_solution = new Assignment(initial_solution[day]);
            Assignment neighbor = null;

            // condicion de meseta: contador de iteraciones sin mejora en best_solution
            int iter_count = 0;

            // lista tabu
            TabuQueue tabu_list = new TabuQueue(list_length, list_growth);
            int no_growth_count = 0;

            // fitness
            double initial_fitness = GetFitness(current_solution);
            double current_fitness = initial_fitness;
            double neighbor_fitness = 0;
            best_fitness = current_fitness;

            // inicio
            // condiciones de salida: tiempo && meseta (que no se supere max_iterations sin actualizar la mejor solucion)
            while (elapsed_time < start_time + (day + 1) * limit_day_time && iter_count < max_iterations)
            {
                int neighbor_count = 0;         // cuenta de vecinos evaluados
                iter_count++;                   // condicion de meseta: contara iteraciones 
                bool success = false;

                // variables para movimientos
                TabuMove move = new TabuMove();
                TabuMove last_move = new TabuMove();

                // Busqueda local: buscaremos un numero maximo de vecinos por eficiencia
                while (neighbor_count < neighbor_checks)
                {
                    neighbor_count++;
                    neighbor = getNeighbor(current_solution, move);     // se crea un vecino con un intercambio aleatorio y se guarda el movimiento
                                                                        // el movimiento no puede estar en la lista tabu y el vecino debe ser distinto de la solucion
                    if (!tabu_list.Contains(move) && move != last_move)
                    {
                        success = true;
                        // evalua el vecindario con la funcion objetivo
                        neighbor_fitness = GetFitness(neighbor);
                        // best improved: a penas encuentre un vecino que supere a la solucion actual, salimos
                        if (current_fitness > neighbor_fitness)
                            break;
                    }
                }

                // Evaluamos lo encontrado:

                // si no encontro un vecino
                if (!success)
                {
                    // cambia el espacio de busqueda si no encuentra buenas soluciones
                    neighbor = initial_solution[day];
                    neighbor_fitness = initial_fitness;
                }

                // si se encontro un vecino
                else
                {
                    // si encontro un vecino superior al best_fitness actual
                    if (best_fitness > neighbor_fitness)
                    {
                        // actualizamos
                        best_day_solution = neighbor;
                        best_fitness = neighbor_fitness;
                        // condicion de meseta: como se mejoro la mejor solucion, se reinicia la cuenta
                        iter_count = 0;
                        // reactive tabu: como es una buena solucion, no se agranda la lista
                        no_growth_count++;
                    }

                    // si encontro un vecino menor al best_fitness y la lista tabu no ha crecido                
                    // reactive tabu: si no se supera la mejor solucion, se incrementa el tama;o de la lista
                    else
                    {
                        tabu_list.Increase();
                        no_growth_count = 0;
                    }
                }

                // reactive tabu: si se supero max_no_growth sin que el tama;o se increimente, se reduce
                if (no_growth_count >= max_no_growth)
                {
                    tabu_list.Decrease();
                    no_growth_count = 0;
                }

                // guardamos el movimiento
                tabu_list.Enqueue(move);

                // siguiente iteracion
                current_solution = neighbor;
                current_fitness = neighbor_fitness;
            }

            best_day_solution.TabuIterations = iter_count;
            best_solution.Add(best_day_solution);            
        }
        
    }
}
