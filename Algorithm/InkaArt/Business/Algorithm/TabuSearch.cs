using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Algorithm
{
    class TabuSearch
    {
        private Instance instance;

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
        //public List<int> best_solution;
        //public List<int> initial_solution;


        /* Se inicializan los parametros a calibrar */
        public TabuSearch(Instance instance)
        {
            // reactive tabu list
            this.tabu_list_length = 10;     // largo inicial
            this.tabu_list_growth = 0.1;    // porcentaje de crecimiento, alfa ( cuando crece: tama;o * (1 + tabu_list_growth) )
            this.max_no_growth = 3;         // numero de iteraciones maximas sin alargar la lista, superado esto se reduce el largo

            // neighbor
            this.neighbor_checks = 500;     // cantidad maxima de vecinos a evaluar

            // solutions
            this.max_iterations = 10000;    // condicion de meseta: cantidad maxima de iteraciones sin una mejora en la mejor solucion

            // instance parameters
            this.instance = instance;       // la instancia tiene datos del problema
        }

        /* Busca el ratio de cada trabajadorxprocesoxproducto, calcula el indice de perdida y lo suma 
           Indice de perdida: (peso_rotura*rotura + peso_tiempo*tiempo)/peso_producto para cada trabajadorxprocesoxproducto
        */
        public double getFitness(Assignment[][] solution)
        {
            double fitness = 0;
            int assigned_workers = 0;
            int index;
            float product_weight;

            for (int i = 0; i < solution.Length; i++)
            {
                //Ratio ratio = ratios.Find(Ratio.byWorkerAndProcessProduct(i + 1, solution[i]));

                //// si el trabajador no esta asignado (solution[i]=0) no se encontrara ratio (ratio == null)
                //if (ratio != null)
                //{
                //    assigned_workers++;
                //    // buscamos el peso del producto (producto = primer digito del procesoxproducto id)
                //    index = solution[i]/10 - 1;
                //    product_weight = products_weights[index];
                //    // sumamos el indice de perdida
                //    fitness += (ratio.breakage * breakage_weight + ratio.time * time_weight) / product_weight;
                //}
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
                worker1 = rnd.Next(solution.Length);
                worker2 = rnd.Next(solution.Length);
            }

            // guardamos movimiento
            move = new TabuMove(swap_type, neighbor, worker1, worker2);

            return neighbor;
        }

        /* Flujo del algoritmo */
        public void run(Assignment[][] initial_solution)
        {
            // soluciones
            Assignment[][] current_solution = new Assignment[initial_solution.Length][];// = new List<int>(initial_solution);
            Assignment[][] neighbor = null;
            
            best_solution = current_solution;

            // condicion de meseta: contador de iteraciones sin mejora en best_solution
            int iter_count = 0;

            // lista tabu
            //Move next_move = null;
            TabuQueue tabu_list = new TabuQueue(tabu_list_length, tabu_list_growth);
            int no_growth_count = 0;

            // fitness
            double initial_fitness = getFitness(current_solution);
            double current_fitness = initial_fitness;
            double neighbor_fitness = 0;
            best_fitness = current_fitness;

            bool improvement;

            // inicio
            // condiciones de salida: tiempo && meseta (que no se supere max_iterations sin actualizar la mejor solucion)
            while (Environment.TickCount - instance.start_time < instance.limit_time && iter_count < max_iterations)
            {
                int neighbor_count = 0;         // cuenta de vecinos evaluados
                iter_count++;                   // condicion de meseta: contara iteraciones 
                bool success = false;
                improvement = false;

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
                        neighbor_fitness = getFitness(neighbor);
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
             
            }

            Console.WriteLine("Funcion Objetivo Inicial: " + initial_fitness.ToString());
            Console.WriteLine("acabo tabu");
        }

        public void print()
        {
            
        }
    }
}
