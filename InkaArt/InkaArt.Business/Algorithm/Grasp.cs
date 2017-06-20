using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Business.Algorithm
{
    public class Grasp
    {
        public const int NumberOfIterations = 1000;
        public const double Alpha = 0.2;

        private WorkerController selected_workers;
        private OrderController selected_orders;
        private JobController jobs;
        private RecipeController recipes;
        private IndexController indexes;
        private Simulation simulation;

        public Grasp(Simulation simulation, JobController jobs, RecipeController recipes, IndexController indexes)
        {
            this.simulation = simulation;
            this.selected_workers = simulation.SelectedWorkers;
            this.selected_orders = new OrderController(simulation.SelectedOrders);
            this.jobs = jobs;
            this.recipes = recipes;
            this.indexes = indexes;
        }

        public Assignment ExecuteGraspAlgorithm(int day, int total_miniturns, ref int elapsed_time)
        {
            Assignment best_assignment = null;
            
            for (int iteration = 0; elapsed_time < Simulation.LimitTime && selected_orders.NumberOfOrders > 0 && iteration < Grasp.NumberOfIterations; iteration++)
            {
                Assignment assignment = new Assignment(simulation.StartDate.AddDays(day), selected_workers.NumberOfWorkers, total_miniturns);

                //Inicializar la lista de candidatos para ser asignados
                List<Index> candidates = new List<Index>();
                for (int i = 0; i < indexes.Count(); i++)
                    if (selected_workers.GetByID(indexes[i].Worker.ID) != null) candidates.Add(indexes[i]);

                //Si alguna orden no se pudo completar, sacarla de la lista.
                for (int i = 0; i < selected_orders.NumberOfOrders; i++)
                    if (selected_orders[i].DeliveryDate.Date > assignment.Date.Date && !selected_orders[i].Completed())
                    {
                        //selected_orders[i].UpdateStatus();
                        selected_orders.RemoveAt(i);
                        i--;
                   } 

                //Ejecutar la fase de construcción del algoritmo GRASP.
                this.ExecuteGraspConstructionPhase(assignment, candidates, iteration, ref elapsed_time);

                //Si se logró minimizar la función objetivo, se reemplaza la mejor asignación del día
                //por la nueva asignación generada.
                if (best_assignment == null || assignment.ObjectiveFunction < best_assignment.ObjectiveFunction)
                    best_assignment = assignment;
            }

            return best_assignment;
        }

        private void ExecuteGraspConstructionPhase(Assignment assignment, List<Index> candidates, int iteration, ref int elapsed_time)
        {
            //Inicializar las variables principales
            List<Recipe> order_recipes = GetOrderRecipes(selected_orders[0]);
            List<AssignmentLine> current_product = new List<AssignmentLine>();
            List<Job> current_product_jobs = new List<Job>();

            for (int construction = 1; elapsed_time < Simulation.LimitTime && selected_orders.NumberOfOrders > 0 && candidates.Count > 0; construction++)
            {
                //Obtener una lista de los trabajadores más eficientes
                List<Index> rcl = GenerateReleaseCandidateList(candidates, order_recipes, current_product, current_product_jobs, assignment.ObjectiveFunction, iteration);
                //Si no se pudo realizar el producto, borrar el producto y quitar las asignaciones realizadas
                if (rcl.Count() <= 0)
                {
                    current_product.Clear();
                    current_product_jobs.Clear();
                    break;
                }

                //Escoger un trabajador al azar e incorporarlo en la solución
                Index chosen = rcl[Randomizer.NextNumber(0, rcl.Count() - 1)];

                AssignmentLine assignment_line = new AssignmentLine(chosen.Worker, chosen.Recipe, chosen.Job);
                //int number_of_miniturns = Convert.ToInt32(chosen.AverageTime / Simulation.MiniturnLength);
                //Añadir línea

                assignment.ObjectiveFunction += chosen.CostValue(assignment.ObjectiveFunction, iteration);
                //if (selected_orders[0].UpdateLineItem(chosen.Recipe) == false) break;

                //Quitar los candidatos necesarios
                if (assignment.IsWorkerFull(chosen.Worker, current_product, selected_workers)) this.RemoveWorkers(candidates, chosen.Worker);
                candidates.Remove(chosen);

                //Si la orden se completó, removerla de la lista
                if (selected_orders[0].Completed()) selected_orders.RemoveAt(0);
            }
        }

        private List<Recipe> GetOrderRecipes(Order order)
        {
            List<Recipe> order_recipes = new List<Recipe>();
            for (int i = 0; i < order.NumberOfLineItems; i++)
                order_recipes.Add(recipes.GetByID(order[i].Recipe));
            return order_recipes;
        }

        private List<Index> GenerateReleaseCandidateList(List<Index> candidates, List<Recipe> order_recipes, List<AssignmentLine> current_product, List<Job> current_product_jobs,
            double objective_function, int iteration)
        {
            //Inicializar el RCL con los candidatos asociados al producto y receta a producir
            List<Index> rcl = new List<Index>();
            for (int i = 0; i < candidates.Count; i++)
            {
                //Si current_product_jobs no tiene datos (y por tanto current_product tampoco), añadir los candidatos cuya receta esté dentro de la lista de recetas de la orden actual.
                if (current_product_jobs.Count <= 0 && order_recipes.Contains(candidates[i].Recipe)) rcl.Add(candidates[i]);
                //Si current_product está con datos (y por tanto, current_product_jobs también), añadir los candidatos cuyo puesto de trabajo esté dentro de la lista de puestos para el producto
                //y cuya receta sea la misma que el producto que estamos elaborando.
                if (current_product.Count > 0 && current_product_jobs.Contains(candidates[i].Job) && candidates[i].Recipe.ID == current_product[0].Recipe.ID) rcl.Add(candidates[i]);
            }

            //Calcular el máximo y el mínimo costo de los candidatos que podrían pertenecer al RCL
            double min = double.MaxValue;
            double max = double.MinValue;
            for (int i = 0; i < rcl.Count; i++)
            {
                double cost_value = rcl[i].CostValue(objective_function, iteration);
                if (cost_value < min) min = cost_value;
                if (cost_value > max) max = cost_value;
            }

            //Obtener el rango del RCL y quitar los índices del RCL que no estén en el rango
            double max_rcl = min + Alpha * (max - min);
            for (int i = 0; i < rcl.Count;)
            {
                double cost_value = rcl[i].CostValue(objective_function, iteration);
                if (cost_value >= min && cost_value <= max_rcl) i++;
                else rcl.RemoveAt(i);
            }

            return rcl;
        }

        private void SelectJobsPerProduct(List<Job> current_product_jobs, List<Recipe> order_recipes)
        {
            Recipe recipe = order_recipes[Randomizer.NextNumber(0, order_recipes.Count - 1)];

            for (int i = 0; i < jobs.NumberOfJobs; i++)
                if (jobs[i].Product == recipe.Product) current_product_jobs.Add(jobs[i]);
        }

        private void RemoveWorkers(List<Index> candidates, Worker worker)
        {
            for (int i = 0; i < candidates.Count;)
            {
                if (candidates[i].Worker.ID == worker.ID) candidates.Remove(candidates[i]);
                else i++;
            }
        }
    }
}
 