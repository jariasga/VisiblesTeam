using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Data.Algorithm;

namespace InkaArt.Business.Algorithm
{
    class Temp_GraspInputManager
    {
        //Funciones para el control de listas de asignaciones

        public static void PrintRCL(List<Temp_GraspInput> rcl, double min, double max,
            double max_rcl)
        {
            Console.WriteLine("RCL: Min = {0}, Max = {1}, Rango = [{2}, {3}]", min, max,
                min, max_rcl);
            for (int i = 0; i < rcl.Count; i++)
            {
                Console.Write("Elemento del RCL {0}: ", i + 1);
                rcl[i].Print();
            }
        }

        public static List<Temp_GraspInput> RemoveWorker(List<Temp_GraspInput> candidates,
            Worker chosen_worker)
        {
            //Remueve de los candidatos todas las asignaciones cuyo trabajador sea
            //el descrito por chosen_worker.
            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].worker.ID == chosen_worker.ID)
                    candidates.Remove(candidates[i--]);
            }
            return candidates;
        }

        public static bool ExceededJobsInProcess(List<Temp_GraspInput> solution,
            Process chosen_process)
        {
            //Verifica si la cantidad de puestos de trabajo ocupadas en la solución haya
            //legado o no al límite de puestos de trabajo admitidos por cada proceso
            int number_of_jobs_occuppied = 0;
            for (int i = 0; i < solution.Count; i++)
            {
                if (solution[i].process_product.Process == chosen_process.ID)
                    number_of_jobs_occuppied++;
            }
            return number_of_jobs_occuppied >= chosen_process.NumberOfJobs;
        }

        public static List<Temp_GraspInput> RemoveProcess(List<Temp_GraspInput> candidates,
            Process chosen_process)
        {
            //Remueve de los candidatos todas las asignaciones cuyo proceso sea
            //el descrito por chosen_process.
            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].process_product.Process == chosen_process.ID)
                    candidates.Remove(candidates[i--]);
            }
            return candidates;
        }

        public static List<Temp_GraspInput> FilterCandidates(List<Temp_GraspInput> candidates,
            List<Job> processes_products)
        {
            List<Temp_GraspInput> filtered_candidates = new List<Temp_GraspInput>();

            //Filtrar los candidatos de manera que solo las asignaciones cuyo
            //proceso x producto esté en la lista para el producto a preparar
            //puedan formar parte del RCL.
            for (int i = 0; i < candidates.Count; i++)
            {
                for (int j = 0; j < processes_products.Count; j++)
                {
                    if (candidates[i].process_product.ID == processes_products[j].ID)
                        filtered_candidates.Add(candidates[i]);
                }
            }

            return filtered_candidates;
        }
        
        public static List<Temp_GraspInput> RemoveLastTemp_GraspInputs(List<Temp_GraspInput> solution,
            List<Job> current_product, JobController processes_products)
        {
            //Si la lista está vacía, no editar nada
            if (current_product.Count <= 0)
            {
                Console.WriteLine("Llegó aquí pero no hay nada en la lista :o");
                return solution;
            }

            //Obtener los procesos x productos del producto current_product.product
            //que no están en la lista current_product.
            Console.Write("El último producto fue: {0}. ",
                current_product[0].Product.ToString());
            Console.Write("Tenemos pendientes los puestos de trabajo: ");
            for (int i = 0; i < current_product.Count; i++)
            {
                Console.Write(current_product[i].ToString());
            }
            Console.WriteLine();

            List<Job> last_processes_products = new List<Job>();
            for (int i = 0; i < processes_products.Count(); i++)
            {
                if (processes_products[i].Product == current_product[0].ID)
                    last_processes_products.Add(processes_products[i]);
            }
            for (int i = 1; i < current_product.Count; i++)
            {
                last_processes_products.Remove(current_product[i]);
            }

            Console.Write("Entonces la lista restante debe tener los puestos de trabajo: ");
            for (int i = 0; i < last_processes_products.Count; i++)
            {
                Console.Write(last_processes_products[i].ToString());
            }
            Console.WriteLine();

            //Quitamos las últimas (last_processes_products) asignaciones de la solución
            for (int i = 1; i <= last_processes_products.Count; i++)
            {
                Console.WriteLine("Se quitó de la solución la asignación #{0} ({1}), " +
                    "antes teníamos {2} ", solution.Count - 1,
                    solution[solution.Count-1].ToString(), solution.Count);
                solution.RemoveAt(solution.Count - 1);
                Console.WriteLine("y ahora tenemos {0} asignaciones.", solution.Count);
            }

            return solution;
        }
    }
}
