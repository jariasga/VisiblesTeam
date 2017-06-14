using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Algorithm
{
    public class Grasp
    {
        public static int MaxIterations = 1000;
        public static double Alpha = 0.2;
        
        private WorkerController selected_workers;
        private OrderController selected_orders;
        private JobController jobs;
        private RecipeController recipes;
        private IndexController indexes;
        private Simulation simulation;

        public Grasp(Simulation simulation, WorkerController selected_workers, OrderController selected_orders,
            ProcessController processes, JobController jobs, RecipeController recipes, IndexController indexes)
        {
            this.selected_workers = selected_workers;
            this.selected_orders = new OrderController(selected_orders);
            this.jobs = jobs;
            this.recipes = recipes;
            this.indexes = indexes;
            this.simulation = simulation;
        }

        public List<Assignment> ExecuteGraspAlgorithm(WorkerController original_workers_list)
        {
            List<Assignment> assignments = new List<Assignment>();

            for (int day = 0; day < simulation.Days; day++)
            {
                Assignment selected_assignment = null;

                //Generar (Iterations) soluciones, guardando siempre la mejor
                for (int iteration = 0; iteration < MaxIterations; iteration++)
                {
                    Assignment assignment = new Assignment(simulation.StartDate.AddDays(day), selected_workers.Count(),
                        simulation.Miniturns);
                    IndexController candidates = GenerateCandidates(original_workers_list);

                    ExecuteGraspConstructionPhase(assignment, candidates, iteration);

                    //Si se logró minimizar la función objetivo, se reemplaza la mejor asignación del día
                    //por la nueva asignación generada.
                    if (assignment.ObjectiveFunction < selected_assignment.ObjectiveFunction)
                        selected_assignment = assignment;
                }

                //Añadir la mejor asignación de trabajadores de un día a la lista
                assignments.Add(selected_assignment);
            }

            return assignments;
        }

        private void ExecuteGraspConstructionPhase(Assignment assignment, IndexController candidates, int iteration)
        {
            List<Recipe> order_recipes = GetOrderRecipes(selected_orders[0]);
            List<Job> current_product_jobs = new List<Job>();

            for (int construction = 1; selected_orders.Count() > 0 && candidates.Count() > 0; construction++)
            {
                //Seleccionar el producto a fabricar si es que nos acabamos el producto
                if (current_product_jobs.Count <= 0) SelectJobsPerProduct(current_product_jobs, order_recipes);

                //Obtener una lista de los trabajadores más eficientes
                IndexController rcl = GenerateReleaseCandidateList(candidates, assignment, iteration,
                    current_product_jobs);
                if (rcl.Count() <= 0) break;

                //Escoger un trabajador al azar e incorporarlo en la solución
                Index chosen = rcl[Randomizer.NextNumber(0, rcl.Count() - 1)];

                AssignmentLine assignment_line = new AssignmentLine(selected_workers.GetByID(chosen.Worker),
                    recipes.GetByID(chosen.Recipe), jobs.GetByID(chosen.Job));
                int worker_index = selected_workers.GetIndex(chosen.Worker);
                int number_of_miniturns = Convert.ToInt32(chosen.AverageTime / simulation.MiniturnLength);
                if (assignment.AddLine(assignment_line, worker_index, number_of_miniturns) == false)
                    continue;

                assignment.ObjectiveFunction += chosen.CostValue(assignment.ObjectiveFunction, iteration);
                if (selected_orders[0].UpdateLineItem(chosen.Recipe) == false) continue;

                //Quitar los candidatos necesarios
                if (assignment.IsWorkerFull(worker_index))
                {
                    for (int i = 0; i < candidates.Count();)
                    {
                        if (candidates[i].Worker == chosen.Worker) candidates.Remove(candidates[i]);
                        else i++;
                    }
                }
                candidates.Remove(chosen);

                //Si la orden se completó, removerla de la lista
                if (selected_orders[0].Completed()) selected_orders.RemoveFirst();
            }
        }

        private List<Recipe> GetOrderRecipes(Order order)
        {
            List<Recipe> order_recipes = new List<Recipe>();
            for (int i = 0; i < order.NumberOfLineItems; i++)
                order_recipes.Add(recipes.GetByID(order[i].Recipe));
            return order_recipes;
        }

        private void SelectJobsPerProduct(List<Job> current_product_jobs, List<Recipe> order_recipes)
        {
            Recipe recipe = order_recipes[Randomizer.NextNumber(0, order_recipes.Count - 1)];
            
            for (int i = 0; i < jobs.NumberOfJobs; i++)
                if (jobs[i].Product == recipe.Product) current_product_jobs.Add(jobs[i]);
        }

        private IndexController GenerateCandidates(WorkerController original_workers_list)
        {
            IndexController candidates = new IndexController();
            for (int i = 0; i < indexes.Count(); i++)
            {
                Worker index_worker = original_workers_list.GetByID(indexes[i].Worker);
                if (selected_workers.Contains(index_worker)) candidates.Add(indexes[i]);
            }
            return candidates;
        }

        private IndexController GenerateReleaseCandidateList(IndexController candidates, Assignment assignment,
            int iteration, List<Job> current_product_jobs)
        {
            //Inicializar el RCL con los candidatos asociados al producto y receta a producir
            IndexController rcl = new IndexController();
            for (int i = 0; i < candidates.Count(); i++)
            {
                Job job = jobs.GetByID(candidates[i].Job);
                if (current_product_jobs.Contains(job)) rcl.Add(candidates[i]);
            }

            //Calcular el máximo y el mínimo costo de los candidatos que podrían pertenecer al RCL
            double min = double.MaxValue;
            double max = double.MinValue;
            for (int i = 0; i < rcl.Count(); i++)
            {
                double cost_value = rcl[i].CostValue(assignment.ObjectiveFunction, iteration);
                if (cost_value < min) min = cost_value;
                if (cost_value > max) max = cost_value;
            }

            //Obtener el rango del RCL y quitar los índices del RCL que no estén en el rango
            double max_rcl = min + Alpha * (max - min);
            for (int i = 0; i < rcl.Count();)
            {
                double cost_value = rcl[i].CostValue(assignment.ObjectiveFunction, iteration);

                if (cost_value >= min && cost_value <= max_rcl) i++;
                else rcl.RemoveFirst();
            }

            return rcl;
        }
    }
}
