using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Instance
    {
        public List<Worker> workers;
        public List<Ratio> ratios;

        // processes
        public int processes_num;
        public List<int> processes_positions;       // puestos de trabajo por proceso

        // products
        public int products_num;
        public List<float> products_weights;        // pesos de productos para la funcion objetivo

        // processes x products
        public int processes_products_num;
        public List<int> processes_products;        // los ids de procesos productos

        // ratios
        public double breakage_weight;              // para los indices de perdida
        public double time_weight;

        public Instance(string workers_filename, string ratios_filename)
        {
            // processes
            processes_num = 4;
            processes_positions = new List<int>(4);
            processes_positions.Add(10);            // tallado
            processes_positions.Add(10);            // modelado
            processes_positions.Add(10);            // horneado
            processes_positions.Add(10);            // pintado

            // products
            products_num = 3;
            products_weights = new List<float>(products_num);
            products_weights.Add(1);                // huacos
            products_weights.Add(1);                // piedras
            products_weights.Add(1);                // retablos

            // processes products
            processes_products_num = 7;
            processes_products = new List<int>(processes_products_num);
            processes_products.Add(0);              // no asignado
            processes_products.Add(10);             // modelado de huacos
            processes_products.Add(11);             // pintado de huacos
            processes_products.Add(12);             // horneado de huacos
            processes_products.Add(20);             // tallado de piedras
            processes_products.Add(30);             // tallado de retablos
            processes_products.Add(31);             // pintado de retablos

            // ratios
            breakage_weight = 0.5;
            time_weight = 0.5;

            try {
                workers = Worker.read(workers_filename);
                ratios = Ratio.read(ratios_filename, workers);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: No se pudieron encontrar los archivos.");
                Environment.Exit(1);
            }
        }

        /* Solucion inicial aleatoria (temporal) */
        public List<int> getInitialSolution()
        {
            int[] solution_temp = new int[workers.Count]; // todos los trabajadores inician en 0
            Random rnd = new Random();
            int worker_id;
            int processproduct_id;
            int positions_count;

            // para cada proceso (tallado, modelado, horneado, pintado)
            for (int i = 0; i < processes_positions.Count; i++)
            {
                positions_count = 0;
                // para cada posicion disponible en el proceso i (processes_positions[i])
                while (positions_count < processes_positions[i])
                {
                    // obtenemos un trabajador no asignado, es decir, que tenga valor 0
                    worker_id = rnd.Next(workers.Count);
                    while (solution_temp[worker_id] > 0) // si ya no espacios
                        worker_id = rnd.Next(workers.Count);
                    // obtenemos un id procesoxproducto del proceso i (ej. si es pintado eligiriamos de [pintado de huacos, pintado de retablos])
                    List<int> processproducts = getProcessProducts(i);
                    processproduct_id = rnd.Next(processproducts.Count);
                    // asignamos
                    solution_temp[worker_id] = processproducts[processproduct_id];
                    positions_count++;
                }
            }
            List<int> solution = new List<int>(solution_temp);

            return solution;
        }

        /* Devuelve la lista de procesos productos que existen para un proceso */
        public List<int> getProcessProducts(int i)
        {
            List<int> list = new List<int>();

            if (i == 0)
            {
                list.Add(20);       // tallado de piedras
                list.Add(30);       // tallado de retablos
            }
            else if (i == 1)
            {
                list.Add(10);       // modelado de huacos
            }
            else if (i == 2)
            {
                list.Add(12);       // horneado de huacos
            }
            else if (i == 3)
            {
                list.Add(11);       // pintado de huacos
                list.Add(31);       // pintado de retablos
            }

            return list;
        }

        /* Busca el ratio de cada trabajadorxprocesoxproducto, calcula el indice de perdida y lo suma 
           Indice de perdida: (peso_rotura*rotura + peso_tiempo*tiempo)/peso_producto para cada trabajadorxprocesoxproducto
        */
        public double getFitness(List<int> solution)
        {
            double fitness = 0;
            int assigned_workers = 0;
            int index;
            float product_weight;

            for (int i = 0; i < solution.Count; i++)
            {

                Ratio ratio = ratios.Find(Ratio.byWorkerAndProcessProduct(i + 1, solution[i]));

                // si el trabajador no esta asignado (solution[i]=0) no se encontrara ratio (ratio == null)
                if (ratio != null)
                {
                    assigned_workers++;
                    // buscamos el peso del producto (producto = primer digito del procesoxproducto id)
                    index = solution[i]/10 - 1;
                    product_weight = products_weights[index];
                    // sumamos el indice de perdida
                    fitness += (ratio.breakage * breakage_weight + ratio.time * time_weight) / product_weight;
                }
            }

            // dividimos lo acumulado solo entre los trabajadores asignados
            return fitness / assigned_workers;
        }

        public List<int> getBestSolution(List<int[]> solutions)
        {
            int best_fitness = int.MaxValue;
            List<int> temp;
            List<int> best = new List<int>();

            foreach(int[] solution in solutions)
            {
                temp = new List<int>(solution);
                if (best_fitness > getFitness(temp))
                    best = temp;
            }

            return best;
        }

        /* Predicado de solucion */
        public static Predicate<int> byProcessProduct(int process_product_id)
        {
            return delegate (int assignment)
            {
                return assignment == process_product_id;
            };
        }

        /* Predicado de solucion */
        public static Predicate<int> byProduct(int product_id)
        {
            // ids: 0 Huacos, 1 piedras, 2 retablos
            return delegate (int assignment)
            {
                return (assignment / 10) == (product_id + 1);
            };
        }

        /* obtener la produccion de acuerdo  una asignacion de trabajadores */
        public List<int> getProduction(List<int> solution)
        {
            // produccion por cada trabajador
            List<int> workers_production = new List<int>(solution);
            
            for (int i = 0; i < solution.Count; i++)
            {
                Ratio ratio = ratios.Find(Ratio.byWorkerAndProcessProduct(i + 1, solution[i]));
                // si el trabajador no esta asignado (solution[i]=0) no se encontrara ratio (ratio == null)
                if (ratio != null)
                {
                    // obtenemos la produccion
                    // produced = tiempo_turno/tiempo_promedio_trabajador - rotura_promedio_trabajador   para ese proceso producto
                    // 8 horas/ 5 minutos por huaco - 3 huacos rotos en un turno
                    // produced = turn_time/ratio.time_avg - ratio.breakage_avg
                    workers_production[i] = ratio.production;
                }
            }

            // produccion en cada proceso producto
            List<int> processes_products_production = new List<int>(processes_products);

            for (int i = 0; i < processes_products.Count; i++)
            {
                processes_products_production[i] = 0;
                List<int> process_product = solution.FindAll(byProcessProduct(processes_products[i]));
                foreach(int assignment in process_product)
                {
                    int worker_index = solution.IndexOf(assignment);
                    processes_products_production[i] += workers_production[worker_index];
                }
            }

            // produccion en cada producto: sera igual al minimo producido en la linea de produccion de cada producto
            List<int> products_production = new List<int>(products_num);

            for (int i = 0; i < products_num; i++)
            {
                List<int> processes = processes_products.FindAll(byProduct(i));
                int min = int.MaxValue;
                foreach(int process in processes)
                {
                    int process_index = processes_products.IndexOf(process);
                    min = Math.Min(processes_products_production[process_index], min);
                }
                products_production.Add(min);
            }

            return products_production;
        }

        public void printProduction(List<int> production)
        {
            Console.WriteLine("Huacos, Piedras, Retablos: ");
            foreach (int i in production)
                Console.Write(i + ", ");
            Console.WriteLine();
        }

        public void printResults(List<int> tabu, List<int> genetic, string path)
        {
            using (var w = new StreamWriter(path))
            {
                foreach (Worker worker in workers)
                {
                    string tabu_name =  "No asignado";
                    Ratio tabu_ratio = ratios.Find(Ratio.byProcessProductId(tabu[worker.id]));
                    if (tabu_ratio != null) tabu_name = tabu_ratio.process_product_name;

                    string genetic_name = "No asignado";
                    Ratio genetic_ratio = ratios.Find(Ratio.byProcessProductId(genetic[worker.id]));                    
                    if (genetic_ratio != null) genetic_name = genetic_ratio.process_product_name;

                    var line = string.Format("{0};{1};{3}", worker.id, tabu_name, genetic_name);
                    w.WriteLine(line);
                    w.Flush();
                }
                // fitness
                var line_fitness = string.Format("Funcion Objetivo;{0};{1}",getFitness(tabu), getFitness(genetic));
                w.WriteLine(line_fitness);
                // production                
                // losses
            }
        }
    }
}
