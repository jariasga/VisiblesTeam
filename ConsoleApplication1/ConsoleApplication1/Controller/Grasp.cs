using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Model;
using System.IO;

namespace InkaArt.Controller
{
    class Grasp
    {
        //Parámetros del algoritmo
        public static double Alpha = 0.2;
        public static int Iterations = 1000;

        //Atributos
        private WorkerManager workers;
        private JobManager jobs;
        private RatioManager ratios;
        private Random random;

        public Grasp(string workers_filename, string ratios_filename)
        {
            workers = new WorkerManager();
            try
            {
                workers.Load(workers_filename);
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("Error: No se pudo encontrar el archivo "
                    + workers_filename);
                Environment.Exit(10);
            }
            jobs = new JobManager(new ProcessManager(), new ProductManager());
            ratios = new RatioManager(workers, jobs);
            try
            {
                ratios.Load(ratios_filename);
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("Error: No se pudo encontrar el archivo "
                    + ratios_filename);
                Environment.Exit(11);
            }
            random = new Random();
        }

        public Grasp(WorkerManager workers, JobManager jobs, RatioManager ratios)
        {
            this.workers = workers;
            this.jobs = jobs;
            this.ratios = ratios;
            this.random = new Random();
        }

        public List<int[]> GraspAlgorithm()
        {
            SolutionList solutions = new SolutionList(workers.NumberOfWorkers());

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
                List<Assignment> candidates = ratios.GetCandidates();

                //Generar una solución con el algoritmo y colocarla en la lista
                Solution solution = GenerateSolution(candidates);
                solutions.Add(solution);
            }
            Console.WriteLine("===================================");

            end = Environment.TickCount;
            Console.Error.WriteLine("Tiempo total de ejecución: {0}.{1} segundos",
                (end - start) / 1000, (end-start) % 1000);

            List<int[]> array_list = solutions.ToArrayList();
            solutions.PrintSolutionList(array_list);
            return array_list;
        }

        private Solution GenerateSolution(List<Assignment> candidates)
        {
            List<Assignment> solution = new List<Assignment>();
            double objective_function_value = 0;

            List<Job> current_product = new List<Job>();

            for (int construction_iteration = 0; candidates.Count > 0;
                construction_iteration++)
            {
                //Obtener una lista de los trabajadores más eficientes
                List<Assignment> rcl;
                //Si la lista current_product está vacía, estamos ante un nuevo producto
                if (current_product.Count == 0) rcl = GenerateRCL(candidates);
                //Si no está vacía, entonces para el RCL solo se considerarán los
                //ProcesosxProductos que le sigan al primer procesoxproducto escogido
                else rcl = GenerateRCL(AssignmentManager.FilterCandidates(
                    candidates, current_product));
                //Si el RCL sale vacío, hemos tenido un error en algún lado :S
                if (rcl.Count <= 0)
                {
                    solution =  AssignmentManager.RemoveLastAssignments(solution,
                        current_product, jobs);
                    break;
                }

                //Escoger un trabajador al azar e incorporarlo en la solución
                Assignment chosen = rcl[random.Next(0, rcl.Count - 1)];
                solution.Add(chosen);
                objective_function_value += chosen.cost_value;

                Console.Write("Se escogio la asignación: ");
                chosen.Print();

                //Remover los candidatos relacionados al trabajador escogido
                candidates = AssignmentManager.RemoveWorker(candidates, chosen.worker);
                //Si se agotaron los puestos de trabajo por proceso, entonces
                //quitar todos los ProcesosxProductos relacionados
                if (AssignmentManager.ExceededJobsInProcess(solution,
                    chosen.process_product.process))
                {
                    candidates = AssignmentManager.RemoveProcess(candidates,
                        chosen.process_product.process);
                }

                //Si current_product está vacío, entonces estamos ante un nuevo producto,
                //por lo que hay que agregar los procesos asociados
                if (current_product.Count == 0)
                    current_product = jobs.GetOtherProcessesByProduct(
                        current_product, chosen.process_product);
                //Si no está vacío, entonces quitamos el proceso x producto que se escogió
                //en esta iteración
                else
                    current_product.Remove(chosen.process_product);

                //Recalcular los costos para la función objetivo
                for (int k = 0; k < candidates.Count; k++)
                    candidates[k].CalculateNextCostValue(objective_function_value,
                        construction_iteration);
            }

            Solution solution_object = new Solution(solution, objective_function_value);
            solution_object.Print();
            return solution_object;
        }

        public List<Assignment> GenerateRCL(List<Assignment> candidates)
        {
            //Inicializar la RCL como vacía
            List<Assignment> rcl = new List<Assignment>();

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
            
            //AssignmentManager.PrintRCL(rcl, min, max, max_rcl);
            return rcl;
        }
    }
}
