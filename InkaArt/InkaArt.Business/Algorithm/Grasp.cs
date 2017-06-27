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

        private Simulation simulation;
        private JobController jobs;
        private RecipeController recipes;
        private IndexController indexes;
        private List<Order> orders;

        public Grasp(Simulation simulation, JobController jobs, RecipeController recipes, IndexController indexes)
        {
            this.simulation = simulation;
            this.jobs = jobs;
            this.recipes = recipes;
            this.indexes = indexes;
            //Líneas de ordenes
            this.orders = simulation.SelectedOrders.Orders;
            this.orders = this.orders.OrderBy(order => order.DeliveryDate).ThenBy(order => order.Client.Priority).ToList();
        }

        public Assignment ExecuteGraspAlgorithm(int day, int total_miniturns, ref int elapsed_time)
        {
            Assignment best_assignment = null;
            LogHandler.WriteLine("============================= EJECUCIÓN DEL ALGORITMO GRASP ================================");
            LogHandler.WriteLine();

            for (int iteration = 0; elapsed_time < Simulation.LimitTime && iteration < Grasp.NumberOfIterations; iteration++)
            {
                Assignment assignment = new Assignment(simulation.StartDate.AddDays(day), simulation.SelectedWorkers, total_miniturns);

                int order_index = 0;
                while (order_index < orders.Count && assignment.Date.Date > orders[order_index].DeliveryDate.Date && orders[order_index].IsCompleted()) order_index++;
                if (order_index >= orders.Count)
                {
                    LogHandler.WriteLine("¡Acabamos las ordenes antes de terminarse el algoritmo! :D");
                    return (best_assignment == null) ? assignment : best_assignment;
                }

                //Inicializar la lista de candidatos para ser asignados
                List<Index> candidates = new List<Index>();
                for (int i = 0; i < indexes.Count(); i++)
                    if (simulation.SelectedWorkers.GetByID(indexes[i].Worker.ID) != null) candidates.Add(indexes[i]);

                ///////////////////////////////////////////////////////////////////////////
                LogHandler.WriteLine("Lista de candidatos: ");
                for (int i = 0; i < candidates.Count; i++)
                    LogHandler.WriteLine("- Candidato {0}: {1}", i + 1, candidates[i].ToString());
                if (candidates.Count <= 0) LogHandler.WriteLine("- No se encontraron candidatos.");

                LogHandler.WriteLine("Seleccionados {0} trabajadores, {1} órdenes, {2} indices y {3} candidatos.",
                    simulation.SelectedWorkers.Count(), orders.Count, indexes.Count(), candidates.Count);
                ///////////////////////////////////////////////////////////////////////////

                //Ejecutar la fase de construcción del algoritmo GRASP.
                this.ExecuteGraspConstructionPhase(assignment, iteration, order_index, candidates, ref elapsed_time);

                //Si se logró minimizar la función objetivo, se reemplaza la mejor asignación del día
                //por la nueva asignación generada.
                LogHandler.WriteLine("Función objetivo anterior: {0}", (best_assignment == null) ? "No existe" : best_assignment.ObjectiveFunction.ToString());
                if (best_assignment == null || assignment.ObjectiveFunction < best_assignment.ObjectiveFunction)
                    best_assignment = assignment;
                LogHandler.WriteLine("Función objetvo calculada: {0}. Nueva función objetivo: {1}", assignment.ObjectiveFunction, best_assignment.ObjectiveFunction);
            }

            return best_assignment;
        }

        private void ExecuteGraspConstructionPhase(Assignment assignment, int iteration, int order_index, List<Index> candidates,
            ref int elapsed_time)
        {
            //Inicializar las variables principales
            List<OrderLineItem> current_line_items = new List<OrderLineItem>(orders[order_index].OrderLineItems);
            GraspProduct current_product = null;
            List<Index> current_deleted_indexes = new List<Index>();

            for (int construction = 1; elapsed_time < Simulation.LimitTime && order_index < orders.Count && candidates.Count > 0; construction++)
            {
                //Actualizar la función de costo para los candidatos restantes
                for (int i = 0; i < candidates.Count; i++)
                    candidates[i].NextCostValue(assignment.ObjectiveFunction, iteration - 1);

                LogHandler.WriteLine("ITERACIÓN DE CONSTRUCCIÓN #" + construction);
                LogHandler.WriteLine();

                //Obtener una lista de los trabajadores más eficientes. Si no se pudo realizar el producto, borrar el producto y quitar las asignaciones realizadas
                List<Index> rcl = GenerateReleaseCandidateList(candidates, current_line_items, order_index, current_product);
                //Si el RCL es nulo, es porque no hemos encontrado candidatos para alguna receta, así que hay que volver a intentarlo.
                if (rcl == null)
                {
                    LogHandler.WriteLine("RCL salió nulo, actualizando líneas de orden");
                    if (!this.RemoveOrderLines(ref current_line_items, ref order_index, current_product))
                        UndoProduct(ref current_product, candidates, current_deleted_indexes);
                    continue;
                }

                //Escoger un candidato (trabajador x receta x puesto de trabajo) al azar
                int random_index = Randomizer.NextNumber(0, rcl.Count - 1);
                Index chosen_candidate = rcl[random_index];
                LogHandler.WriteLine("Se escogió el índice {0}: {1}", random_index + 1, chosen_candidate.ToString());
                if (current_product == null) current_product = new GraspProduct(chosen_candidate.Recipe, jobs);

                //Incorporar al candidato seleccionado en la solución
                AssignmentLine new_assignment_line = this.GetNextAssignmentLine(assignment, chosen_candidate, current_product);
                //Si new_assignment_line es nulo, es porque el trabajador está lleno de trabajo, así que hay que eliminar los candidatos con ese trabajador y volver a intentarlo.
                if (new_assignment_line == null && this.RemoveWorkers(chosen_candidate.Worker, candidates, current_deleted_indexes, ref current_product)) continue;

                //Actualizamos la función objetivo y quitamos el candidato seleccionado
                current_product.SetAssignmentLine(new_assignment_line, chosen_candidate.Job);
                assignment.ObjectiveFunction += chosen_candidate.CostValue;
                current_deleted_indexes.Add(new Index(chosen_candidate));
                candidates.Remove(chosen_candidate);

                //Si se terminó de fabricar el producto, ahora toca colocarlo en la matriz.
                if (current_product.IsFull() && !this.AddAssignmentLines(assignment, current_product, order_index, current_line_items))
                {
                    LogHandler.WriteLine("EXCEPCIÓN: Se estuvo haciendo una receta que ni siquiera esta en la lista :(");
                    this.UndoProduct(ref current_product, candidates, current_deleted_indexes);
                    continue;
                }

                //REVISAR ESTADO
                LogHandler.WriteLine("Nueva lista de candidatos antes de la siguiente iteracion: ");
                for (int i = 0; i < candidates.Count; i++)
                    LogHandler.WriteLine("- Candidato {0}: {1}", i + 1, candidates[i].ToString());
                if (candidates.Count <= 0) LogHandler.WriteLine("- No se encontraron candidatos.");
            }
        }

        private List<Index> GenerateReleaseCandidateList(List<Index> candidates, List<OrderLineItem> current_line_items, int order_index,
            GraspProduct current_product)
        {
            //Inicializar el RCL con los candidatos asociados al producto y receta a producir
            List<Index> rcl = new List<Index>();
            for (int i = 0; i < candidates.Count; i++)
            {
                //Si current_product es nulo, añadir los candidatos cuya receta esté dentro de la lista de recetas de la orden actual.
                if (current_product == null && current_line_items.Find(order => order.Recipe.ID == candidates[i].Recipe.ID) != null) rcl.Add(candidates[i]);
                //Si current_product está con datos, añadir los candidatos cuyo puesto de trabajo esté dentro de la lista de puestos para el producto y cuya receta sea la misma que el producto que estamos elaborando.
                if (current_product != null && current_product.ContainsJob(candidates[i].Job) && candidates[i].Recipe.ID == current_product.CurrentRecipe.ID) rcl.Add(candidates[i]);
            }

            if (rcl.Count <= 0) return null; //No se encontraron candidatos

            ///////////////////////////////////////////////////////////////////////////////
            LogHandler.WriteLine("-------------- RCL antes del filtrado ------------");
            for (int i = 0; i < rcl.Count; i++)
                LogHandler.WriteLine("Item del RCL #{0:000}: {1}", i + 1, rcl[i].ToString());
            ///////////////////////////////////////////////////////////////////////////////

            //Calcular el máximo y el mínimo costo de los candidatos que podrían pertenecer al RCL
            double min = rcl.Min(candidate => candidate.CostValue);
            double max = rcl.Max(candidate => candidate.CostValue);
            double max_rcl = min + Alpha * (max - min);
            LogHandler.WriteLine("Minimo = {0}, Maximo = {1}, Rango = [{0}, {2}]", min, max, max_rcl);

            //Obtener el rango del RCL y quitar los índices del RCL que no estén en el rango
            rcl.RemoveAll(candidate => candidate.CostValue < min || candidate.CostValue > max_rcl);

            ///////////////////////////////////////////////////////////////////////////////
            LogHandler.WriteLine("-------------- RCL despues del filtrado ------------");
            for (int i = 0; i < rcl.Count; i++)
                LogHandler.WriteLine("Item del RCL #{0:000}: {1}", i + 1, rcl[i].ToString());
            ///////////////////////////////////////////////////////////////////////////////

            return rcl;
        }

        public AssignmentLine GetNextAssignmentLine(Assignment assignment, Index chosen_candidate, GraspProduct current_product)
        {
            int worker_index = simulation.SelectedWorkers.GetIndex(chosen_candidate.Worker.ID); 
            LogHandler.WriteLine("Función GetNextAssignmentLine():\n- WorkerIndex = {0}", worker_index);

            int next_miniturn = simulation.TotalMiniturns;
            while (next_miniturn > 0 && assignment[worker_index, next_miniturn - 1] == null) next_miniturn--;
            LogHandler.WriteLine("- next_miniturn al recorrer la matriz: {0}.", next_miniturn);
            if (next_miniturn >= simulation.TotalMiniturns) return null;

            next_miniturn = current_product.NextMiniturn(chosen_candidate.Worker, next_miniturn);
            LogHandler.WriteLine("- next_miniturn al recorrer la matriz de miniturnos y las lineas temporales de asignacion: " + next_miniturn);
            if (next_miniturn >= simulation.TotalMiniturns) return null;

            int total_miniturns_used = simulation.TotalMiniturns - next_miniturn;
            int maximum_products = Convert.ToInt32(Math.Truncate(total_miniturns_used * Simulation.MiniturnLength / chosen_candidate.AverageTime));
            LogHandler.WriteLine("- total_miniturns_used: {0}.", total_miniturns_used);
            LogHandler.WriteLine("- products: {0}*{1}/{2} = {3}.", total_miniturns_used, Simulation.MiniturnLength, chosen_candidate.AverageTime, maximum_products);

            return new AssignmentLine(chosen_candidate, next_miniturn, total_miniturns_used, maximum_products);
        }

        private bool RemoveOrderLines(ref List<OrderLineItem> current_line_items, ref int order_index, GraspProduct current_product)
        {
            //Si no se pudo encontrar ningun candidato cuya receta esté en alguna línea de orden, pasamos a la siguiente orden.
            if (current_product == null)
            {
                LogHandler.WriteLine("RCL: No se pudo encontrar ningun candidato cuya receta esté en alguna línea de orden, así que pasamos al siguiente.");
                order_index++;
                if (order_index < orders.Count) current_line_items = new List<OrderLineItem>(orders[order_index].OrderLineItems);
                return true;
            }
            //Si, en cambio, estábamos preparando un producto y a la mitad de prepararlo nos quedamos sin candidatos, quitamos la línea de orden con la receta.
            else
            {
                LogHandler.WriteLine("RCL: Estábamos preparando un producto y a la mitad de prepararlo nos quedamos sin candidatos. Entonces, se quitará la línea de orden con la receta.");
                int id_recipe = current_product.CurrentRecipe.ID;
                current_line_items.RemoveAll(line_item => line_item.Recipe.ID == id_recipe);
                return false;
            }
        }

        private void UndoProduct(ref GraspProduct current_product, List<Index> candidates, List<Index> current_deleted_indexes)
        {
            candidates.AddRange(current_deleted_indexes);
            current_deleted_indexes.Clear();
            current_product = null;
        }

        private bool RemoveWorkers(Worker worker, List<Index> candidates, List<Index> current_deleted_indexes, ref GraspProduct current_product)
        {
            LogHandler.WriteLine("No se pudo encontrar un tiempo para asignar una línea.");

            //Se regresan los candidatos eliminados durante la preparación del producto, y se vuelve a empezar.
            candidates.AddRange(current_deleted_indexes);
            current_deleted_indexes.Clear();
            candidates.RemoveAll(index => index.Worker.ID == worker.ID);
            current_product = null;
            return true;
        }

        private bool AddAssignmentLines(Assignment assignment, GraspProduct current_product, int order_index, List<OrderLineItem> current_line_items)
        {
            int order_line_index = 0;
            while (order_line_index < current_line_items.Count && current_line_items[order_line_index].Recipe.ID != current_product.CurrentRecipe.ID) order_line_index++;
            if (order_line_index >= current_line_items.Count) return false;

            throw new NotImplementedException();

            /* int produced = selected_orders[order_index][order_line_index].Quantity - selected_orders[0][order_line_index].Produced;
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
                    assignment[simulation.SelectedWorkers.GetIndex(current_product[i].Worker.ID), current_product[i].MiniturnStart + j] = current_product[i];
            }
            return produced; */
        }
    }
}
 