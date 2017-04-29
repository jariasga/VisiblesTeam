using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Grasp
    {
        //Parámetros del algoritmo
        private static double Alpha = 0.2;
        private static int Iterations = 10;

        //Atributos
        private List<Worker> workers;
        private List<Ratio> ratios;
        private Random random;
        private List<ProcessProduct> process_product;

        //Constantes de otros lados
        private int num_processes = 4;

        public Grasp(Instance instance)
        {
            this.workers = instance.workers;
            //workers.OrderBy(worker => worker.id);
            this.ratios = instance.ratios;
            //ratios.OrderBy(ratio => ratio.worker.id).ThenBy(ratio => ratio.process_product_id);
            this.random = new Random();

            //instance.processes_products.CopyTo(jobs_per_process);

            //Revisar después
            Process tallado = new Process(1, "Tallado", 10);
            Process modelado = new Process(2, "Modelado", 10);
            Process horneado = new Process(3, "Horneado", 10);
            Process pintado = new Process(4, "Pintado", 10);
            process_product = new List<ProcessProduct>();
            process_product.Add(new ProcessProduct(10, "Modelado de huacos", modelado, 0));
            process_product.Add(new ProcessProduct(11, "Pintado de huacos", pintado, 0));
            process_product.Add(new ProcessProduct(12, "Horneado de huacos", horneado, 0));
            process_product.Add(new ProcessProduct(20, "Tallado de piedras", tallado, 1));
            process_product.Add(new ProcessProduct(30, "Tallado de retablos", tallado, 2));
            process_product.Add(new ProcessProduct(31, "Pintado de retablos", pintado, 2));

            //ESTO YA SE TENÍA QUE HACER EN RATIO!!!
            for (int i = 0; i < ratios.Count; i++)
            {
                ratios[i].loss_index = instance.breakage_weight * ratios[i].breakage
                    + instance.time_weight * ratios[i].time;
                //Console.WriteLine("---------------- RATIO # {0} ---------------", i + 1);
                //ratios[i].Print();
            }
            //Console.WriteLine("------------------------------------------");
        }

        public List<int[]> GraspAlgorithm()
        {
            //Inicializar conjunto de soluciones como vacío
            List<GraspOutput> solution_list = new List<GraspOutput>();

            for (int i = 0; i < Iterations; i++)
            {
                //Obtener la lista de candidatos y calcular la función de costo para cada trabajador
                List<Assignment> candidates = this.ratios.ConvertAll(ratio =>
                    new Assignment(ratio.worker, ratio.process_product_id, ratio.loss_index));

                //Obtener solución y colocarla en la lista
                solution_list.Add(GenerateSolution(candidates));

                Console.WriteLine("Iteración {0} completada.", i);
            }

            //Convertir lista a soluciones
            List<int[]> solution_list_array = new List<int[]>();
            for (int i = 0; i < solution_list.Count; i++)
            {
                int[] solution = GraspOutput.ToArray(solution_list[i], workers.Count);
                solution_list_array.Add(solution);

                Console.WriteLine("Solución {0} de GRASP:", i + 1);
                Console.Write("Trabajador  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20 ");
                Console.Write("21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 ");
                Console.WriteLine("41 42 43 44 45 46 47 48 49 50");
                Console.Write("ProcXProd. ");
                for (int k = 0; k < workers.Count; k++)
                    Console.Write("{0} ", solution[k]);
                Console.WriteLine();
            }

            return solution_list_array;
        }

        private GraspOutput GenerateSolution(List<Assignment> candidates)
        {
            //Inicializar solución como vacía y el valor de la F.O. en la máxima
            List<Assignment> solution = new List<Assignment>();
            double value_o_f = 0;

            int[] control_product = { 0, 0, 0, 0 };

            for (int iteration_construction = 1; candidates.Count > 0; iteration_construction++)
            {
                //Obtener una lista de los trabajadores más eficientes
                int sum = ControlProductSum(control_product);
                List<Assignment> rcl = null;
                if (sum == 0)
                    rcl = GenerateRCL(candidates);
                else
                {
                    List<Assignment> filtered_candidates = FilterCandidates(candidates,
                        control_product);
                    rcl = GenerateRCL(filtered_candidates);
                }

                //Escoger un trabajador al azar e incorporarlo en la solución
                Assignment chosen = rcl[random.Next(0, rcl.Count)];
                solution.Add(chosen);
                value_o_f += chosen.Cost;

                //Remover todos los candidatos que involucren al trabajador
                candidates.RemoveAll(Assignment.byWorker(chosen.Worker));
                //Si se agotaron los puestos de trabajo por proceso, quitar todos los relacionados
                if (Assignment.NumberOfProcessProducts(solution, chosen.ProcessProduct) >=
                    ProcessProduct.GetByID(process_product, chosen.ProcessProduct).process.number_jobs)
                {
                    for (int i = 0; i < num_processes; i++)
                    {
                        if (control_product[i] != 0)
                            candidates.RemoveAll(Assignment.byProcessProductId(
                                control_product[i]));
                    }
                }

                //Indicamos que ya hicimos 
                sum = ControlProductSum(control_product);
                //Si la suma es cero, quiere decir que terminamos el producto anterior y
                //comenzaremos otro. Entonces, debemos controlar que este se termine. 
                if (sum == 0) control_product = getProcesses(chosen.ProcessProduct);

                //Recalcular los costos para la función objetivo
                for (int k = 0; k < candidates.Count; k++)
                    candidates[k].NextCost(value_o_f, iteration_construction);
            }

            return new GraspOutput(solution, value_o_f);
        }

        public List<Assignment> GenerateRCL(List<Assignment> candidates)
        {
            //Inicializar la RCL como vacía
            List <Assignment> rcl = new List<Assignment>();

            //Calculo el máximo y el mínimo costo de los candidatos
            double min = double.MaxValue;
            double max = double.MinValue;
            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].Cost < min) min = candidates[i].Cost;
                if (candidates[i].Cost > max) max = candidates[i].Cost;
            }

            //Obtener el rango del RCL y agregar los valores
            double max_rcl = min + Alpha * (max - min);
            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].Cost >= min && candidates[i].Cost <= max_rcl)
                    rcl.Add(candidates[i]);
            }

            //Imprimir
            Console.WriteLine("=========== RCL ===========");
            Console.WriteLine("Min = {0}, Max = {1}, Rango = [{2}, {3}]", min, max,
                min, max_rcl);
            for (int i = 0; i < rcl.Count; i++)
            {
                Console.WriteLine("------------------------");
                rcl[i].Print();
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Cantidad de elementos en el RCL: " + rcl.Count);

            return rcl;
        }

        public List<Assignment> FilterCandidates(List<Assignment> candidates,
            int[] control_product)
        {
            List<Assignment> filtered_candidates = new List<Assignment>();
            for (int i = 0; i < candidates.Count; i++)
            {
                for (int j = 0; j < num_processes; j++)
                {
                    if (control_product[j] == 0) continue;
                    if (control_product[j] == candidates[i].ProcessProduct)
                        filtered_candidates.Add(candidates[i]);
                }
            }
            return filtered_candidates;
        }

        //Funciones auxiliares

        public int ControlProductSum(int[] control_product)
        {
            int sum = 0;
            for (int i = 0; i < num_processes; i++)
                sum += control_product[i];
            return sum;
        }

        public int ControlProductChangeSum(int[] control_product, Assignment chosen)
        {
            int sum = 0;
            for (int i = 0; i < num_processes; i++)
            {
                //Indicamos que hemos hecho el producto
                if (control_product[i] == chosen.ProcessProduct)
                    control_product[i] = 0;
                //Sumar el valor
                sum += control_product[i];
            }
            return sum;
        }
        public int[] getProcesses(int process_product_id)
        {
            int[] altarpiece = { 0, 30, 0, 31 };
            if (process_product_id >= 30) return altarpiece;
            int[] huamanga_stones = { 0, 20, 0, 0};
            if (process_product_id >= 20) return huamanga_stones;
            int[] huaco = { 10, 0, 11, 12 };
            if (process_product_id >= 10) return huaco;
            int[] nothing = { 0, 0, 0, 0 };
            return nothing;
        }
    }
}