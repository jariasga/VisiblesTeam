using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Data.Algorithm;
using Npgsql;
using InkaArt.Common;

namespace InkaArt.Business.Algorithm
{
    class TabuSearch
    {

        // reactive tabu list
        private int tabu_list_length;
        private double tabu_list_growth;
        private int max_no_growth;

        // neighbor
        private int neighbor_checks;

        // solutions
        private int max_iterations;
        private double best_fitness;
        private Assignment[][] initial_solution;
        private Assignment[][] best_solution;

        /* Se inicializan los parametros a calibrar */
        public TabuSearch()
        {
            LoadParameters();
        }

        public void LoadParameters()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"TabuParameters\"", connection);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                // reactive tabu list
                this.tabu_list_length = reader.GetInt32(0);     // largo inicial
                this.tabu_list_growth = reader.GetDouble(1);    // porcentaje de crecimiento, alfa ( cuando crece: tama;o * (1 + tabu_list_growth) )
                this.max_no_growth = reader.GetInt32(2);       // numero de iteraciones maximas sin alargar la lista, superado esto se reduce el largo

                // solutions
                this.max_iterations = reader.GetInt32(3);      // condicion de meseta: cantidad maxima de iteraciones sin una mejora en la mejor solucion

                // neighbor
                this.neighbor_checks = reader.GetInt32(4);     // cantidad maxima de vecinos a evaluar                
            }

            connection.Close();
        }

        /* Busca el indice de cada trabajadorxprocesoxproducto, calcula el indice de perdida y lo suma 
           Indice de perdida: (peso_rotura*rotura + peso_tiempo*tiempo)/peso_producto para cada trabajadorxprocesoxproducto
        */
        public double getFitness(Simulation simulation, Assignment[][] solution)
        {
            double fitness = 0;
            int assigned_workers = 0;
            double product_weight;

            for (int i = 0; i < solution.Length; i++)
            {
                foreach(Assignment assignment in solution[i])
                {
                    Index index = simulation.Indexes.Find(Index.byWorkerAndJob(assignment.Worker, assignment.Job));
                    // si el trabajador no esta asignado (solution[i]=0) no se encontrara ratio (ratio == null)
                    if (index != null)
                    {
                        assigned_workers++;
                        // buscamos el peso del producto (producto = primer digito del procesoxproducto id)
                        
                        product_weight = simulation.ProductWeight(assignment.Job.Product);
                        // sumamos el indice de perdida
                        fitness += (index.Breakage * simulation.BreakageWeight + index.Time * simulation.TimeWeight) / product_weight;
                    }
                }
            }

            // dividimos lo acumulado solo entre los trabajadores asignados
            return fitness / assigned_workers;
        }

        /* Encontrara dos trabajadores aleatoriamente e intercambiara sus trabajos */
        public Assignment[][] getNeighbor(Assignment[][] solution, TabuMove move)
        {
            Assignment[][] neighbor= new Assignment[solution.Length][];
            Random rnd = new Random();

            // move attributes
            int swap_type = rnd.Next(1);
            int worker1;
            int worker2;

            // hay 2 tipos de swap
            //  0: intercambiar listas
            //  1: intercambiar productos
            if (swap_type == 0)
            {
                // buscamos trabajadores
                worker1 = rnd.Next(solution.Length);
                worker2 = rnd.Next(solution.Length);
                // nos aseguramos de que sean distintos, a menos que solo se tenga un trabajador en la empresa
                while (solution.Length > 1 && worker1 == worker2)
                    worker2 = rnd.Next(solution.Length);
                // intercambiamos valores
                neighbor[worker1] = solution[worker2];
                neighbor[worker2] = solution[worker1];
            }
            else
            {
                // FALTA EL SEGUNDO MODO
                worker1 = rnd.Next(solution.Length);
                worker2 = rnd.Next(solution.Length);
                // nos aseguramos de que sean distintos, a menos que solo se tenga un trabajador en la empresa
                while (solution.Length > 1 && worker1 == worker2)
                    worker2 = rnd.Next(solution.Length);
                // intercambiamos valores
                neighbor[worker1] = solution[worker2];
                neighbor[worker2] = solution[worker1];
            }

            // guardamos movimiento
            move = new TabuMove(swap_type, neighbor, worker1, worker2);

            return neighbor;
        }

        /* Flujo del algoritmo */
        public void run(Simulation simulation, Assignment[][] initial_solution)
        {
            for(int day = 0; day < simulation.Days; day++)
            {
                // soluciones
                Assignment[][] current_solution = new Assignment[initial_solution.Length][];
                Assignment[][] neighbor = null;
                initial_solution.CopyTo(current_solution, 0);
                best_solution = current_solution;

                // condicion de meseta: contador de iteraciones sin mejora en best_solution
                int iter_count = 0;

                // lista tabu
                //Move next_move = null;
                TabuQueue tabu_list = new TabuQueue(tabu_list_length, tabu_list_growth);
                int no_growth_count = 0;

                // fitness
                double initial_fitness = getFitness(simulation, current_solution);
                double current_fitness = initial_fitness;
                double neighbor_fitness = 0;
                best_fitness = current_fitness;

                // inicio
                // condiciones de salida: tiempo && meseta (que no se supere max_iterations sin actualizar la mejor solucion)
                while (Environment.TickCount - simulation.StartTime < simulation.LimitTime && iter_count < max_iterations)
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
                            neighbor_fitness = getFitness(simulation, neighbor);
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
                        neighbor = initial_solution;
                        neighbor_fitness = initial_fitness;
                    }

                    // si se encontro un vecino
                    else
                    {

                        // si encontro un vecino superior al best_fitness actual
                        if (best_fitness > neighbor_fitness)
                        {
                            // actualizamos
                            best_solution = neighbor;
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
            }            
        }
        
    }
}
