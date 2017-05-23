using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class TabuSearch
    {
<<<<<<< HEAD
=======
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

        /* Solucion inicial aleatoria (temporal) */
        public static List<int> getInitialSolution(Instance instance)
        {
            List<int> assignment = new List<int>(instance.workers.Count);

            for (int worker_index = 0; worker_index < instance.workers.Count; worker_index++)
            {
                // process
                Random rnd = new Random();
                int process_index = rnd.Next(instance.processes_num);
                //while (instance.hasAvailablePositions() && !instance.isAvailable(process_index))
                //{
                //    process_index = rnd.Next(instance.processes_num);
                //}
                //if (!instance.hasAvailablePositions()) process_index = instance.processes_num;
                
                //// assign
                //assignment[worker_index] = process_index;
                //instance.assignWorker(process_index);
            }

            return assignment;
        }

        /* Busca el ratio de cada trabajadorxprocesoxproducto, lo multiplica por los pesos y lo suma */
        public double getFitness(List<int> solution)
        {
            double fitness = 0;
            int assigned_workers = 0;

            for(int i = 0; i < solution.Count; i++)
            {
                Ratio ratio = instance.ratios.Find(Ratio.byWorkerAndProcessProduct(i, solution[i]));
                // si el trabajador no esta asignado (solution[i]=0) no se encontrara ratio (ratio == null)
                if (ratio != null)       
                {
                    assigned_workers++;
                    fitness += (ratio.breakage * instance.breakage_weight + ratio.time * instance.time_weight);
                    // agregar pesos de producto
                    // int index = (int)(solution[i]/10);
                    // float w = instance.products_weights[index];
                }
            }

            return fitness/assigned_workers;
        }

        /* Encontrara dos trabajadores aleatoriamente e intercambiara sus trabajos */
        public List<int> getNeighbor(List<int> solution)
        {
            List<int> neighbor = new List<int>(solution);
            Random rnd = new Random();

            int worker1 = rnd.Next(solution.Count);
            int worker2 = rnd.Next(solution.Count);
            while (worker1 == worker2)
            {
                worker2 = rnd.Next(solution.Count);
            }
            int temp = solution[worker1];
            solution[worker1] = solution[worker2];
            solution[worker2] = temp;

            return neighbor;
        }

        /* Obtiene el intercambio de trabajadores */
        public Move getMove(List<int> solution, List<int> neighbor)
        {
            Move move = new Move();
            int worker_num = 0;

            for (int i = 0; i < solution.Count; i++)
            {
                if (solution[i] != neighbor[i])
                {
                    worker_num++;
                    move.setWorker(worker_num, i, neighbor[i]);     // i = worker_id, neighbor[i] = procesoxproducto
                    if (worker_num == 2) break;                     // siempre se intercambian dos trabajadores
                }
            }

            return move;
        }

        public void run()
        {
            // time
            int start_time = Environment.TickCount;
            int limit_time = 5;

            // solutions
            List<int> initial_solution = null;
            List<int> current_solution = null;
            List<int> next_solution = null;
            List<int> neighbor = null;
            current_solution = getInitialSolution(instance);
            initial_solution = new List<int>(current_solution);
            int iter_count = 0;

            // tabu
            Move next_move = null;
            Queue<Move> tabu_list = new Queue<Move>(tabu_list_length); // se puede implementar FixedSizeQueue
            int no_growth_count = 0;
            
            // fitness
            double initial_fitness = 0;
            double current_fitness = 0;
            double next_fitness = 0;
            double neighbor_fitness = 0;
            current_fitness = getFitness(current_solution);
            best_fitness = current_fitness;
            best_solution = current_solution;

            // inicio
            // condiciones de salida: tiempo && meseta
            while (Environment.TickCount - start_time < limit_time && iter_count < max_iterations)
            {
                int count = 0;
                iter_count++;                   // condicion de meseta
                next_solution = null;
                next_fitness = int.MaxValue;
                next_move = null;
                bool success = false;

                // Finding the next movement.
                Move move = new Move();
                Move last_move = new Move();

                while (count < neighbor_checks)
                {
                    count++;
                    neighbor = getNeighbor(current_solution);
                    move = getMove(current_solution, neighbor);
                    if (!tabu_list.Contains(move) && move != last_move)
                    {
                        neighbor_fitness = getFitness(neighbor);
                        if (next_fitness > neighbor_fitness)
                        {
                            next_solution = neighbor;
                            next_fitness = neighbor_fitness;
                            next_move = move;
                            success = true;
                        }
                        if (current_fitness > next_fitness)
                        {
                            break;
                        }
                    }
                }
                
                if (!success)
                {
                    next_solution = initial_solution;
                    next_fitness = initial_fitness;
                }
                
                if (best_fitness > next_fitness)
                {
                    tabu_list.Clear();
                    best_solution = next_solution;
                    best_fitness = next_fitness;

                    // condicion de meseta: se reinicia si se mejora el fitness global
                    iter_count = 0;

                    // reactive tabu 
                    no_growth_count++;
                }
                else
                {
                    // incrementar el tama;o de la lista tabu
                    no_growth_count = 0;
                }

                if (no_growth_count >= max_no_growth)
                {
                    // decrementar el tama;o de la lista tabu
                }
                tabu_list.Enqueue(next_move);

                current_solution = next_solution;
                current_fitness = next_fitness;                
            }

        }

>>>>>>> 92598514377fd1d5448cca76b1d5482221e68e1e
    }
}
