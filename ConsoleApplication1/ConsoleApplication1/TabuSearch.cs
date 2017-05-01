using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class TabuSearch { }
    /*

    
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
            this.tabu_list_length = 10;     // largo inicial
            this.tabu_list_growth = 0.1;    // porcentaje de crecimiento, alfa ( cuando crece: tama;o * (1 + tabu_list_growth) )
            this.max_no_growth = 3;         // numero de iteraciones maximas sin alargar la lista, superado esto se reduce el largo

            // neighbor
            this.neighbor_checks = 500;      // cantidad maxima de vecinos a evaluar

            // solutions
            this.max_iterations = 10000;    // condicion de meseta: cantidad maxima de iteraciones sin una mejora en la mejor solucion

            // instance parameters
            this.instance = instance;       // la instancia tiene datos del problema
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

        /* Flujo del algoritmo */
        public void run(List<int> initial_solution)
        {
            // time
            int start_time = Environment.TickCount; // milisegundos
            int limit_time = 300000;                // 1 000 * 60 * 5 (maximo 5 miutos)

            // soluciones
            List<int> current_solution = null;
            List<int> neighbor = null;
            current_solution = instance.getInitialSolution();
            initial_solution = new List<int>(current_solution);
            best_solution = current_solution;

            // condicion de meseta: contador de iteraciones sin mejora en best_solution
            int iter_count = 0;

            // lista tabu
            //Move next_move = null;
            TabuQueue tabu_list = new TabuQueue(tabu_list_length, tabu_list_growth);
            int no_growth_count = 0;
            
            // fitness
            double initial_fitness = instance.getFitness(current_solution);
            double current_fitness = initial_fitness;
            double neighbor_fitness = 0;
            best_fitness = current_fitness;

            bool improvement;

            // inicio
            // condiciones de salida: tiempo && meseta (que no se supere max_iterations sin actualizar la mejor solucion)
            while (Environment.TickCount - start_time < limit_time && iter_count < max_iterations)
            {
                int neighbor_count = 0;         // cuenta de vecinos evaluados
                iter_count++;                   // condicion de meseta: contara iteraciones 
                bool success = false;
                improvement = false;

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
                        success = true;
                        // evalua el vecindario con la funcion objetivo
                        neighbor_fitness = instance.getFitness(neighbor);
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
                else {                    

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

                        improvement = true;
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
                
                Console.WriteLine("Funcion Objetivo: " + best_fitness.ToString() + " " + improvement.ToString() + " Lista Tabu: " + tabu_list.limit.ToString() + " " + tabu_list.Count());
            }

            Console.WriteLine("Funcion Objetivo Inicial: " + initial_fitness.ToString());
            Console.WriteLine("acabo tabu");
        }

        public void print()
        {
            foreach (int i in best_solution)
                Console.Write(i + ", ");
            Console.WriteLine();
            Console.WriteLine("Funcion Objetivo Final: " + best_fitness.ToString());
        }
    }

    */


}
