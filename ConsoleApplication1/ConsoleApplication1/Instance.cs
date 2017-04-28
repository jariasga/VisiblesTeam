using System;
using System.Collections.Generic;
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
        public List<float>  products_weights;       // pesos de productos para la funcion objetivo

        // processes x products
        public int processes_products_num;
        public List<int> processes_products;        // los ids de procesos productos

        // ratios
        public int breakage_weight;                 // para los indices de perdida
        public int time_weight;

        public Instance()
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
            breakage_weight = 1;
            time_weight = 1;

            workers = Worker.read("Workers.csv");
            ratios = Ratio.read("Ratios.csv", workers);
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

        /* devuelve la lista de procesos productos que existen para un proceso */
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

        /* Busca el ratio de cada trabajadorxprocesoxproducto, lo multiplica por los pesos y lo suma */
        public double getFitness(List<int> solution)
        {
            double fitness = 0;
            int assigned_workers = 0;

            for (int i = 0; i < solution.Count; i++)
            {
                Ratio ratio = ratios.Find(Ratio.byWorkerAndProcessProduct(i, solution[i]));
                // si el trabajador no esta asignado (solution[i]=0) no se encontrara ratio (ratio == null)
                if (ratio != null)
                {
                    assigned_workers++;
                    fitness += (ratio.breakage * breakage_weight + ratio.time * time_weight);
                    // agregar pesos de producto
                    // int index = (int)(solution[i]/10);
                    // float product_weight = instance.products_weights[index];
                    // fitness += product_weight * (ratio.breakage * instance.breakage_weight + ratio.time * instance.time_weight);
                }
            }

            return fitness / assigned_workers;
        }


    }
}
