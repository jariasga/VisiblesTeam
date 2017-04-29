using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class TabuSearch
    {
        public Instance instance;

        // reactive tabu list
        public int tabu_list_length;
        public double tabu_list_growth;
        public int max_no_growth;

        // neighbor
        public int neighbor_checks;

        // solutions
        public int max_iterations;
        public double best_fitness;
        public List<int> best_solution;

        /* Se inicializan los parametros a calibrar */
        public TabuSearch(Instance instance)
        {
            // reactive tabu list
            this.tabu_list_length = 10; // largo inicial
            this.tabu_list_growth = 10; // porcentaje de crecimiento, alfa
            this.max_no_growth = 10;    // numero de iteraciones maximas sin alargar la lista, superado esto se reduce el largo

            // neighbor
            this.neighbor_checks = 10;  // cantidad maxima de vecinos a evaluar

            // solutions
            this.max_iterations = 10;   // cantidad maxima de iteraciones sin una mejora en la mejor solucion

            // instance parameters
            this.instance = instance;   // la instancia tiene datos del problema
        }
        
        /* Encontrara dos trabajadores aleatoriamente e intercambiara sus trabajos */
        public List<int> getNeighbor(List<int> solution, Move move)
        {
            List<int> neighbor = new List<int>(solution);
            Random rnd = new Random();

            // buscamos trabajadores
            int worker1 = rnd.Next(solution.Count);             
            int worker2 = rnd.Next(solution.Count);
            // nos aseguramos de que sean distintos, a menos que solo se tenga un trabajador en la empresa
            while (solution.Count > 1 && worker1 == worker2)    
                worker2 = rnd.Next(solution.Count);
            // intercambiamos valores
            neighbor[worker1] = solution[worker2];
            neighbor[worker2] = solution[worker1];
            // guardamos movimiento
            move = new Move(neighbor, worker1, worker2);
            
            return neighbor;
        }

        public List<int> run()
        {
            // time
            int start_time = Environment.TickCount; // milisegundos
            int limit_time = 300000;                // 1 000 * 60 * 5 (maximo 5 miutos)

            // soluciones
            List<int> initial_solution = null;
            List<int> current_solution = null;
            List<int> next_solution = null;
            List<int> neighbor = null;
            current_solution = instance.getInitialSolution();
            initial_solution = new List<int>(current_solution);
            best_solution = current_solution;

            // condicion de meseta: contador de iteraciones sin mejora en best_solution
            int iter_count = 0;

            // lista tabu
            Move next_move = null;
            //Queue<Move> tabu_list = new Queue<Move>(tabu_list_length);  // se puede implementar FixedSizeQueue
            TabuQueue tabu_list = new TabuQueue(tabu_list_length);
            int no_growth_count = 0;
            
            // fitness
            double initial_fitness = 0;
            double current_fitness = instance.getFitness(current_solution);
            double next_fitness = 0;
            double neighbor_fitness = 0;
            best_fitness = current_fitness;            

            // inicio
            // condiciones de salida: tiempo || meseta (que no se supere max_iterations sin actualizar la mejor solucion)
            while (Environment.TickCount - start_time < limit_time || iter_count < max_iterations)
            {
                int neighbor_count = 0;                  // cuenta de vecinos evaluados
                iter_count++;                   // condicion de meseta: contara iteraciones 
                next_solution = null;
                next_fitness = int.MaxValue;    
                next_move = null;
                bool success = false;

                // variables para movimientos
                Move move = new Move();
                Move last_move = new Move();

                // Busqueda local: buscaremos un numero maximo de vecinos por eficiencia
                while (neighbor_count < neighbor_checks)
                {
                    neighbor_count++;
                    neighbor = getNeighbor(current_solution, move);     // se crea un vecino con un intercambio aleatorio y se guarda el movimiento
                    // el movimiento no puede estar en la lista tabu y el vecino debe ser distinto de la solucion
                    if (!tabu_list.Contains(move) && move != last_move) 
                    {
                        // evalua el vecindario con la funcion objetivo
                        neighbor_fitness = instance.getFitness(neighbor);
                        if (next_fitness > neighbor_fitness)
                        {
                            next_solution = neighbor;
                            next_fitness = neighbor_fitness;
                            next_move = move;
                            success = true;
                        }
                        // best improved: a penas encuentre un vecino que supere a la solucion actual, salimos
                        if (current_fitness > next_fitness)
                            break;
                    }
                }
                
                if (!success)
                {
                    next_solution = initial_solution;
                    next_fitness = initial_fitness;
                }
                
                if (best_fitness > next_fitness)
                {
                    // se limpia la lista si se mejoro la solucion
                    tabu_list.Clear();
                    best_solution = next_solution;
                    best_fitness = next_fitness;
                    // condicion de meseta: como se mejoro la mejor solucion, se reinicia la cuenta
                    iter_count = 0;

                    // reactive tabu: como es una buena solucion, no se agranda la lista
                    no_growth_count++;
                }
                else
                {
                    // reactive tabu: si no se supera la mejor solucion, se incrementa el tama;o de la lista
                    // incrementar el tama;o de la lista tabu
                    tabu_list.Limit = (int)((double)tabu_list.Limit * (1 + tabu_list_growth));
                    no_growth_count = 0;
                }

                // reactive tabu: si se super max_no_growth sin que el tama;o se increimente, se reduce
                if (no_growth_count >= max_no_growth)
                {
                    // decrementar el tama;o de la lista tabu
                    tabu_list.Limit = (int)((double)tabu_list.Limit * (1 - tabu_list_growth));
                }
                tabu_list.Enqueue(next_move);

                current_solution = next_solution;
                current_fitness = next_fitness;                
            }

            return best_solution;
        }
    }
}
