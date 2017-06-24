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
        public const int NumberOfIterations = 1;
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
            LogHandler.WriteLine("============================= EJECUCIÓN DEL ALGORITMO GRASP ================================");
            LogHandler.WriteLine();
            for (int iteration = 0; elapsed_time < Simulation.LimitTime && selected_orders.NumberOfOrders > 0 && iteration < Grasp.NumberOfIterations; iteration++)
            {
                Assignment assignment = new Assignment(simulation.StartDate.AddDays(day), selected_workers, total_miniturns);
                selected_orders.RemoveAll(order => order.DeliveryDate.Date < assignment.Date.Date);
                if (selected_orders.NumberOfOrders <= 0) return best_assignment;

                //Inicializar la lista de candidatos para ser asignados
                List<Index> candidates = new List<Index>();
                for (int i = 0; i < indexes.Count(); i++)
                    if (selected_workers.GetByID(indexes[i].Worker.ID) != null) candidates.Add(indexes[i]);

                LogHandler.WriteLine("Seleccionados {0} trabajadores y {1} ordenes. Se tienen {2} indices y {3} candidatos.",
                    selected_workers.Count(), selected_orders.NumberOfOrders, indexes.Count(), candidates.Count);

                //Ejecutar la fase de construcción del algoritmo GRASP.
                this.ExecuteGraspConstructionPhase(assignment, candidates, iteration, ref elapsed_time);

                //Si se logró minimizar la función objetivo, se reemplaza la mejor asignación del día
                //por la nueva asignación generada.
                LogHandler.WriteLine("Función objetivo anterior: {0}", (best_assignment == null) ? "No existe" : best_assignment.ObjectiveFunction.ToString());
                if (best_assignment == null || assignment.ObjectiveFunction < best_assignment.ObjectiveFunction)
                    best_assignment = assignment;
                LogHandler.WriteLine("Función objetvo calculada: {0}. Nueva función objetivo: {1}", assignment.ObjectiveFunction, best_assignment.ObjectiveFunction);
            }

            return best_assignment;
        }

        private void ExecuteGraspConstructionPhase(Assignment assignment, List<Index> candidates, int iteration, ref int elapsed_time)
        {
            //Inicializar las variables principales
            List<Recipe> order_recipes = GetOrderRecipes(selected_orders[0]);
            LogHandler.WriteLine("Orden de compra {0}: {1}", selected_orders[0].ID, selected_orders[0].Description);
            for (int i = 0; i < order_recipes.Count; i++)
                LogHandler.WriteLine("Receta {0}: {1}", i+1, order_recipes[i].Description + " " + order_recipes[i].Version);
            List<AssignmentLine> current_product = new List<AssignmentLine>();
            List<Job> current_product_jobs = new List<Job>();
            List<Index> current_deleted_indexes = new List<Index>();

            for (int construction = 1; elapsed_time < Simulation.LimitTime && selected_orders.NumberOfOrders > 0 && candidates.Count > 0; construction++)
            {
                //Obtener una lista de los trabajadores más eficientes. Si no se pudo realizar el producto, borrar el producto y quitar las asignaciones realizadas
                List<Index> rcl = GenerateReleaseCandidateList(candidates, order_recipes, current_product, current_product_jobs, assignment.ObjectiveFunction, iteration);
                if (rcl.Count() <= 0)
                {
                    current_product.Clear();
                    current_product_jobs.Clear();
                    break;
                }

                //Escoger un trabajador al azar e incorporarlo en la solución
                int random_index = Randomizer.NextNumber(0, rcl.Count - 1);
                Index chosen_candidate = rcl[random_index];
                LogHandler.WriteLine("Se escogió el índice {0}: {1}", random_index + 1, chosen_candidate.ToString());

                AssignmentLine new_assignment_line = assignment.GetNextAssignmentLine(chosen_candidate);
                if (new_assignment_line == null)
                {
                    LogHandler.WriteLine("No se pudo encontrar un tiempo para asignar una línea.");
                    LogHandler.WriteLine("RCL count = {0}, Current_Jobs count = {1}, Current_Product = {2}", rcl.Count, current_product_jobs.Count, current_product.Count);
                    //this.RemoveWorkers(candidates, chosen_candidate.Worker, current_deleted_indexes);
                    break;
                }
                current_product.Add(new_assignment_line);
                if (current_product_jobs.Count <= 0) current_product_jobs = jobs.GetJobsByProduct(chosen_candidate.Recipe.Product);
                assignment.ObjectiveFunction += chosen_candidate.CostValue(assignment.ObjectiveFunction, iteration);
                current_product_jobs.Remove(chosen_candidate.Job);

                //Actualizar las variables y quitar los candidatos necesarios
                if (assignment.IsWorkerFull(chosen_candidate.Worker, current_product)) this.RemoveWorkers(candidates, chosen_candidate.Worker, current_deleted_indexes);
                current_deleted_indexes.Add(new Index(chosen_candidate));
                candidates.Remove(chosen_candidate);

                if (current_product_jobs.Count <= 0)
                {
                    int order_line_index = GetOrderLineItemIndex(chosen_candidate);
                    if (order_line_index < 0) break;
                    int produced = this.AddAssignmentLines(assignment, current_product, order_line_index);
                    current_product.Clear();
                    if (selected_orders[0][order_line_index].Produced >= selected_orders[0][order_line_index].Quantity)
                        order_recipes.RemoveAll(recipe => recipe.ID == chosen_candidate.Recipe.ID);
                    else break;
                }

                //Si la orden se completó, removerla de la lista y actualizar la lista de recetas
                if (selected_orders[0].Completed())
                {
                    selected_orders.RemoveAt(0);
                    order_recipes = GetOrderRecipes(selected_orders[0]);
                }
            }
        }

        private List<Recipe> GetOrderRecipes(Order order)
        {
            List<Recipe> order_recipes = new List<Recipe>();
            for (int i = 0; i < order.NumberOfLineItems; i++)
                order_recipes.Add(order[i].Recipe);
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
                if (current_product_jobs.Count <= 0 && order_recipes.Contains(candidates[i].Recipe))
                    rcl.Add(candidates[i]);
                //Si current_product está con datos (y por tanto, current_product_jobs también), añadir los candidatos cuyo puesto de trabajo esté dentro de la lista de puestos para el producto
                //y cuya receta sea la misma que el producto que estamos elaborando.
                if (current_product.Count > 0 && current_product_jobs.Contains(candidates[i].Job) && candidates[i].Recipe.ID == current_product[0].Recipe.ID)
                    rcl.Add(candidates[i]);
            }

            LogHandler.WriteLine("================= RCL: CurrentProductJobs count = {0}, current_product count = {1}. Deberian ser iguales ===============",
                current_product_jobs.Count, current_product.Count);

            LogHandler.WriteLine("-------------- RCL antes del filtrado ------------");
            for (int i = 0; i < rcl.Count; i++)
                LogHandler.WriteLine("Item del RCL #{0:000}: {1}", i + 1, rcl[i].ToString());

            //Calcular el máximo y el mínimo costo de los candidatos que podrían pertenecer al RCL
            double min = double.MaxValue;
            double max = double.MinValue;
            for (int i = 0; i < rcl.Count; i++)
            {
                double cost_value = rcl[i].CostValue(objective_function, iteration);
                if (cost_value > max) max = cost_value;
                if (cost_value < min) min = cost_value; 
            }

            //Obtener el rango del RCL y quitar los índices del RCL que no estén en el rango
            double max_rcl = min + Alpha * (max - min); 
            LogHandler.WriteLine("Minimo = {0}, Maximo = {1}, Rango = [{0}, {2}]", min, max, max_rcl);
            for (int i = rcl.Count - 1; i >= 0; i--)
            {
                double cost_value = rcl[i].CostValue(objective_function, iteration);
                if (cost_value < min || cost_value > max_rcl) rcl.RemoveAt(i);
            }

            LogHandler.WriteLine("-------------- RCL despues del filtrado ------------");
            for (int i = 0; i < rcl.Count; i++)
                LogHandler.WriteLine("Item del RCL #{0:000}: {1}", i + 1, rcl[i].ToString());

            return rcl;
        }

        private int GetOrderLineItemIndex(Index chosen_candidate)
        {
            for (int i = 0; i < selected_orders[0].NumberOfLineItems; i++)
                if (selected_orders[0][i].Recipe.ID == chosen_candidate.Recipe.ID) return i;
            return -1;
        }

        private int AddAssignmentLines(Assignment assignment, List<AssignmentLine> current_product, int order_line_index)
        {
            int produced = selected_orders[0][order_line_index].Quantity - selected_orders[0][order_line_index].Produced;
            current_product.OrderBy(line => line.Job.Order);

            for (int i = 0; i < current_product.Count; i++)
            {
                if (current_product[i].Produced < produced) produced = current_product[i].Produced;
                //RECALCULAR TIEMPOS: FALTA
            }
            for (int i = 0; i < current_product.Count; i++)
            {
                current_product[i].Produced = produced;
                for (int j = 0; j < current_product[i].TotalMiniturnsUsed; j++)
                    assignment[selected_workers.GetIndex(current_product[i].Worker.ID), current_product[i].MiniturnStart + j] = current_product[i];
            }
            return produced;
        }

        private void RemoveWorkers(List<Index> candidates, Worker worker, List<Index> current_deleted_indexes)
        {
            for (int i = candidates.Count - 1; i >= 0; i--)
                if (candidates[i].Worker.ID == worker.ID)
                {
                    current_deleted_indexes.Add(candidates[i]);
                    candidates.Remove(candidates[i]);
                }
        }

    }
}
 