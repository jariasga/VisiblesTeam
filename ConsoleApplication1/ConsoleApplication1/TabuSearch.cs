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
        public int[] best_solution;

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
        public static int[] getInitialSolution(Instance instance)
        {
            int[] assignment = new int[instance.workers.Count];

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

        public static double getFitness(int[] solution, List<Worker> workers)
        {
            double fitness = 0;

            for(int i = 0; i < solution.Length; i++)
            {/*
                List<Ratio> ratios = workers[i].ratios.FindAll(Ratio.byProcess(solution[i]));
                double breakage = Ratio.getAverageBreakage(ratios);
                double time = Ratio.getAverageTime(ratios); */

            }

            return fitness;
        }

        public int[] getNeighbor(int[] solution)
        {
            int[] neighbor = new int[solution.Length];

            return neighbor;
        }

        public Tuple<int, int> getMove(int[] solution, int[] neighbor)
        {
            Tuple<int, int> move = new Tuple<int, int> (0, 0);
            return move;
        }

        public void run()
        {
            //// time
            //int start_time = Environment.TickCount;
            //int limit_time = 5;
            
            //// solutions
            //List<int> initial_solution = null;
            //List<int> current_solution = null;
            //List<int> next_solution = null;
            //List<int> neighbor = null;

            //// moves
            //Tuple<int, int> next_tabu = null;
            
            //// initialS = currentS
            //current_solution = getInitialSolution(instance);
            //initial_solution = new int[current_solution.Length];
            //current_solution.CopyTo(initial_solution, 0);
            
            //// fitness
            //double initial_fitness = 0;
            //double current_fitness = 0;
            //double next_fitness = 0;
            //double neighbor_fitness = 0;
            //current_fitness = getFitness(current_solution);
            //// currentFitness is the initial BestFitness (the smallest the better)
            //best_fitness = current_fitness;
            //best_solution = current_solution;

            //// tabu
            //// initialize empty tuple queue
            //Queue<Tuple<int, int>> tabuList = new Queue<Tuple<int, int>>(tabu_list_length); // se puede implementar FixedSizeQueue
            
            //// inicio
            //while (Environment.TickCount - start_time < limit_time)
            //{                
            //    int count = 0;
            //    next_solution = null;
            //    next_fitness = int.MaxValue;     // like best fitness and neightbor fitness
            //    next_tabu = null;
            //    bool success = false; // a better solution

            //    // Finding the next movement.
            //    Tuple<int, int> tabu = new Tuple<int, int>(-1, -1);
            //    Tuple<int, int> lastTabu = new Tuple<int, int>(-1, -1);

            //    while (count < neighbor_checks)
            //    {
            //        count++;
            //        neighbor = getNeighbor(current_solution); // neightbor function
            //        tabu = GetMove(current_solution, neighbor); // move
            //        if (!tabuList.Contains(tabu) && tabu != lastTabu)
            //        { // valid move: not tabu, not last(?)
            //            neighbor_fitness = getFitness(neighbor); // fitness function - objective function 
            //            if (next_fitness > neighbor_fitness)
            //            {
            //                next_solution = neighbor;
            //                next_fitness = neighbor_fitness;
            //                next_tabu = tabu;
            //                success = true;
            //            }
            //            if (current_fitness > next_fitness)
            //            { // better fitness (first improved) (si es una solucion peor que la anterior se va)
            //                break;
            //            }
            //        }
            //    }
            //    // si no se encuentra nada se regresa al inicio 
            //    if (!success)
            //    {
            //        next_solution = initial_solution;
            //        next_fitness = initial_fitness;
            //    }

            //    // Aspiration. 
            //    if (best_fitness > next_fitness)
            //    {
            //        tabuList.Clear();
            //        best_solution = next_solution;
            //        best_fitness = next_fitness;
            //    }

            //    tabuList.Enqueue(next_tabu); // si el movimiento fue bueno, se agrega a la lista tabu
            //    current_solution = next_solution;
            //    current_fitness = next_fitness;
                
            }
            
        }
    
    }
}
