using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Data.Algorithm;
using InkaArt.Business.Algorithm;

namespace InkaArt.Algorithm.Grasp
{
    class Grasp
    {
        public static double Alpha = 0.2;
        public static int Iterations = 3;

        private List<Worker> selected_workers;
        private List<Order> selected_orders;

        private ProcessController processes;
        private JobController jobs;
        private RecipeController recipes;
        private IndexController indexes;
        private Random random;

        public Grasp(List<Worker> selected_workers, List<Order> selected_orders, Random random)
        {
            this.selected_workers = selected_workers;
            this.selected_orders = selected_orders;
            this.random = random;

            processes = new ProcessController();
            processes.Load();
            jobs = new JobController();
            jobs.Load();
            recipes = new RecipeController();
            recipes.Load();

            indexes = new IndexController();
            indexes.Load();
            indexes.CalculateIndexes(jobs, recipes);
        }

        public List<int[]> GraspAlgorithm()
        {
            Temp_SolutionList solutions = new Temp_SolutionList(selected_workers.Count());

            //Controlar tiempo
            int start = Environment.TickCount;
            int end = start;
            int max_time_value = 5 * 60 * 1000; //5 min = 5*60 sec = 5*60*1000 miliseconds

            for (int i = 0; (((end = Environment.TickCount) - start) <= max_time_value)
                && i < Iterations; i++)
            {
                Console.WriteLine("========= Iteración GRASP #{0} =========", i + 1);

                //Obtener la lista de candidatos y calcular la función de costo para
                //cada trabajador
                List<Temp_GraspInput> candidates = indexes.GetCandidates(selected_workers, jobs);

                //Generar una solución con el algoritmo y colocarla en la lista
                Temp_Solution solution = GenerateTemp_Solution(candidates);
                solutions.Add(solution);
            }
            Console.WriteLine("===================================");

            end = Environment.TickCount;
            Console.Error.WriteLine("Tiempo total de ejecución: {0}.{1} segundos",
                (end - start) / 1000, (end - start) % 1000);

            List<int[]> array_list = solutions.ToArrayList();
            solutions.PrintTemp_SolutionList(array_list);
            return array_list;
        }

        private Temp_Solution GenerateTemp_Solution(List<Temp_GraspInput> candidates)
        {
            List<Temp_GraspInput> solution = new List<Temp_GraspInput>();
            double objective_function_value = 0;

            //List<Job> current_product = new List<Job>();

            for (int construction_iteration = 1; candidates.Count > 0;
                construction_iteration++)
            {
                //Obtener una lista de los trabajadores más eficientes
                List<Temp_GraspInput> rcl = GenerateRCL(candidates);

                /*

                //Si la lista current_product está vacía, estamos ante un nuevo producto
                if (current_product.Count == 0) rcl = GenerateRCL(candidates);
                //Si no está vacía, entonces para el RCL solo se considerarán los
                //ProcesosxProductos que le sigan al primer procesoxproducto escogido
                else rcl = GenerateRCL(Temp_GraspInputManager.FilterCandidates(
                    candidates, current_product));
                //Si el RCL sale vacío, hemos tenido un error en algún lado :S
                if (rcl.Count <= 0)
                {
                    Console.Error.WriteLine("El RCL llegó a cero en la iteración {0}.",
                        construction_iteration);
                    solution = Temp_GraspInputManager.RemoveLastTemp_GraspInputs(solution,
                        current_product, jobs);
                    break;
                }

                */

                //Escoger un trabajador al azar e incorporarlo en la solución
                Temp_GraspInput chosen = rcl[random.Next(0, rcl.Count - 1)];
                solution.Add(chosen);
                objective_function_value += chosen.cost_value;

                Console.Write("En la iteración {0} se escogio la asignación: ",
                    construction_iteration);

                //Remover los candidatos relacionados al trabajador escogido
                candidates = Temp_GraspInputManager.RemoveWorker(candidates, chosen.worker);
                //Si se agotaron los puestos de trabajo por proceso, entonces
                //quitar todos los ProcesosxProductos relacionados
                if (Temp_GraspInputManager.ExceededJobsInProcess(solution,
                    processes.GetByID(chosen.process_product.Process)))
                {
                    candidates = Temp_GraspInputManager.RemoveProcess(candidates,
                        processes.GetByID(chosen.process_product.Process));
                }

                //Si current_product está vacío, entonces estamos ante un nuevo producto,
                //por lo que hay que agregar los procesos asociados
                /* if (current_product.Count == 0)
                    current_product = jobs.GetOtherProcessesByProduct(
                        current_product, chosen.process_product);
                //Si no está vacío, entonces quitamos el proceso x producto que se escogió
                //en esta iteración
                else current_product.Remove(chosen.process_product); */

                //Recalcular los costos para la función objetivo
                for (int k = 0; k < candidates.Count; k++)
                {
                    candidates[k].CalculateNextCostValue(objective_function_value,
                        construction_iteration);
                }

                /* if (candidates.Count <= 0)
                {
                    Console.Error.WriteLine("La lista de candidatos llegó a cero en la "
                        + "iteración {0}.", construction_iteration);
                    solution = Temp_GraspInputManager.RemoveLastTemp_GraspInputs(solution,
                        current_product, jobs);
                    break;
                } */

                Console.WriteLine("Fin de la iteración {0}. Nos quedamos con {1} candidatos "
                    + "del set original de {2}.", construction_iteration, candidates.Count,
                    indexes.Count());
            }

            Temp_Solution solution_object = new Temp_Solution(solution, objective_function_value);
            solution_object.Print();
            return solution_object;
        }

        public List<Temp_GraspInput> GenerateRCL(List<Temp_GraspInput> candidates)
        {
            //Inicializar la RCL como vacía
            List<Temp_GraspInput> rcl = new List<Temp_GraspInput>();

            //Calculo el máximo y el mínimo costo de los candidatos
            double min = double.MaxValue;
            double max = double.MinValue;
            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].cost_value < min) min = candidates[i].cost_value;
                if (candidates[i].cost_value > max) max = candidates[i].cost_value;
            }

            //Obtener el rango del RCL y agregar los valores
            double max_rcl = min + Alpha * (max - min);
            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].cost_value >= min && candidates[i].cost_value <= max_rcl)
                    rcl.Add(candidates[i]);
            }

            //Temp_GraspInputManager.PrintRCL(rcl, min, max, max_rcl);
            return rcl;
        }
    }
}
