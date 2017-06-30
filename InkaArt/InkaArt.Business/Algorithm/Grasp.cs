using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Business.Algorithm
{
    public class Grasp
    {
        public const int NumberOfIterations = 100;
        public const double Alpha = 0.2;
        public static int LimitTime = Simulation.LimitTime * 2 / 5; //120 segundos = Un minuto y medio

        private Simulation simulation;
        private JobController jobs;
        private DataTable processes;
        private RecipeController recipes;
        private IndexController indexes;
        private List<Order> orders;

        public Grasp(Simulation simulation, JobController jobs, RecipeController recipes, IndexController indexes)
        {
            this.simulation = simulation;
            this.jobs = jobs;
            this.recipes = recipes;
            this.indexes = indexes;
            //Líneas de ordenes: DEBE SER UNA COPIA PROFUNDA, ORDENADA POR FECHA Y LUEGO POR PRIORIDAD DEL CLIENTE.
            this.orders = new List<Order>();
            for (int i = 0; i < simulation.SelectedOrders.NumberOfOrders; i++)
                this.orders.Add(new Order(simulation.SelectedOrders[i]));
            this.orders = this.orders.OrderBy(order => order.DeliveryDate).ThenBy(order => order.Client.Priority).ToList();
            //Número de puestos de trabajo para cada proceso
            Production.ProcessController process_controller = new Production.ProcessController();
            processes = process_controller.getData();
        }

        public Assignment ExecuteGraspAlgorithm(int day, ref int elapsed_time)
        {
            Assignment best_assignment = null;
            LogHandler.WriteLine("============================= EJECUCIÓN DEL ALGORITMO GRASP ================================");
            LogHandler.WriteLine();

            for (int iteration = 0; elapsed_time < Grasp.LimitTime && iteration < Grasp.NumberOfIterations; iteration++)
            {
                Assignment assignment = new Assignment(simulation.StartDate.AddDays(day), simulation.SelectedWorkers, simulation.TotalMiniturns);

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

            //Lista de procesos
            ProcessTuple[] remaining_processes = new ProcessTuple[processes.Rows.Count];
            for (int i = 0; i < processes.Rows.Count; i++)
            {
                int id_process = Convert.ToInt32(processes.Rows[i]["id_process"].ToString());
                int number_of_jobs = Convert.ToInt32(processes.Rows[i]["number_of_jobs"].ToString());
                remaining_processes[i] = new ProcessTuple(id_process, number_of_jobs);
            }

            for (int construction = 1; elapsed_time < Grasp.LimitTime && order_index < orders.Count && candidates.Count > 0; construction++)
            {
                LogHandler.WriteLine("ITERACIÓN DE CONSTRUCCIÓN #" + construction);
                LogHandler.WriteLine();

                //Actualizar la función de costo para los candidatos restantes
                for (int i = 0; i < candidates.Count; i++)
                    candidates[i].NextCostValue(assignment.ObjectiveFunction, construction);

                for (int i = 0; i < candidates.Count; i++)
                    LogHandler.WriteLine("- Indice {0}: {1}, CostValue={2}", i + 1, candidates[i].ToString(), candidates[i].CostValue);
                LogHandler.WriteLine();

                //Obtener una lista de los trabajadores más eficientes. Si no se pudo realizar el producto, borrar el producto y quitar las asignaciones realizadas
                List<Index> rcl = GenerateReleaseCandidateList(candidates, current_line_items, order_index, current_product);
                //Si el RCL es nulo, es porque no hemos encontrado candidatos para alguna receta, así que hay que volver a intentarlo.
                if (rcl == null)
                {
                    LogHandler.WriteLine("RCL salió nulo, actualizando líneas de orden");
                    if (!RemoveOrderLines(ref current_line_items, ref order_index, current_product))
                        UndoProduct(ref current_product, candidates, current_deleted_indexes);
                    else construction--;
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
                if (current_product.SetAssignmentLine(new_assignment_line, chosen_candidate.Job) == false)
                    throw new Exception("Hice un assignment line que no forma parte del producto.");
                assignment.ObjectiveFunction += chosen_candidate.CostValue;
                current_deleted_indexes.Add(new Index(chosen_candidate));
                candidates.Remove(chosen_candidate);

                //Si se terminó de fabricar el producto, ahora toca colocarlo en la matriz.
                if (current_product.IsFull())
                {
                    if (this.AddAssignmentLines(assignment, current_product, order_index, current_line_items, remaining_processes))
                        this.RemoveProcesses(remaining_processes, candidates, current_deleted_indexes, ref current_product);
                    else
                        throw new Exception("Se estuvo haciendo una receta que ni siquiera esta en la lista :(");
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
                if (current_product == null)
                {
                    for (int j = 0; j < current_line_items.Count; j++)
                        if (candidates[i].Recipe.ID == current_line_items[j].Recipe.ID) { rcl.Add(candidates[i]); break; }
                }
                //Si current_product está con datos, añadir los candidatos cuyo puesto de trabajo esté dentro de la lista de puestos para el producto y cuya receta sea la misma que el producto que estamos elaborando.
                if (current_product != null && current_product.ContainsJob(candidates[i].Job) && candidates[i].Recipe.ID == current_product.CurrentRecipe.ID) rcl.Add(candidates[i]);
            }

            if (rcl.Count <= 0) return null; //No se encontraron candidatos

            ///////////////////////////////////////////////////////////////////////////////
            LogHandler.WriteLine("-------------- RCL antes del filtrado ------------");
            for (int i = 0; i < rcl.Count; i++)
                LogHandler.WriteLine("Item del RCL #{0:000}: {1}, CostValue={2}", i + 1, rcl[i].ToString(), rcl[i].CostValue);
            ///////////////////////////////////////////////////////////////////////////////

            //Calcular el máximo y el mínimo costo de los candidatos que podrían pertenecer al RCL
            double min = double.MaxValue;
            double max = double.MinValue;
            for (int i = 0; i < rcl.Count; i++)
            {
                if (candidates[i].CostValue < min) min = candidates[i].CostValue;
                if (candidates[i].CostValue > max) max = candidates[i].CostValue;
            }
            double max_rcl = min + Alpha * (max - min);
            LogHandler.WriteLine("Minimo = {0}, Maximo = {1}, Rango = [{0}, {2}]", min, max, max_rcl);

            //Obtener el rango del RCL y quitar los índices del RCL que no estén en el rango
            for (int i = rcl.Count - 1; i >= 0; i--)
                if (candidates[i].CostValue < min || candidates[i].CostValue > max_rcl) rcl.RemoveAt(i);

            ///////////////////////////////////////////////////////////////////////////////
            LogHandler.WriteLine("-------------- RCL despues del filtrado ------------");
            for (int i = 0; i < rcl.Count; i++)
                LogHandler.WriteLine("Item del RCL #{0:000}: {1}, CostValue={2}", i + 1, rcl[i].ToString(), rcl[i].CostValue);
            ///////////////////////////////////////////////////////////////////////////////

            if (rcl.Count <= 0) return null; //No se encontraron candidatos
            return rcl;
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
                for (int i = current_line_items.Count - 1; i >= 0; i--)
                    if (current_line_items[i].Recipe.ID == id_recipe) current_line_items.RemoveAt(i);
                return false;
            }
        }

        public AssignmentLine GetNextAssignmentLine(Assignment assignment, Index chosen_candidate, GraspProduct current_product)
        {
            int worker_index = simulation.SelectedWorkers.GetIndex(chosen_candidate.Worker.ID);
            LogHandler.WriteLine("Función GetNextAssignmentLine():");
            LogHandler.WriteLine("- WorkerIndex = {0}", worker_index);

            int next_miniturn = simulation.TotalMiniturns;
            while (next_miniturn > 0 && assignment[worker_index, next_miniturn - 1] == null) next_miniturn--;
            LogHandler.WriteLine("- next_miniturn al recorrer la matriz: {0} (total_miniturns={1}).", next_miniturn, simulation.TotalMiniturns);
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

        private bool AddAssignmentLines(Assignment assignment, GraspProduct current_product, int order_index, List<OrderLineItem> current_line_items, ProcessTuple[] remaining_processes)
        {
            int order_line_index = 0;
            while (order_line_index < orders[order_index].NumberOfLineItems && orders[order_index][order_line_index].Recipe.ID != current_product.CurrentRecipe.ID) order_line_index++;
            if (order_line_index >= orders[order_index].NumberOfLineItems) return false;

            LogHandler.WriteLine("Ahorita la linea de orden escogida es orders[{0}][{1}] = {2}", order_index, order_line_index, orders[order_index][order_line_index].ToString());

            int quantity_needed = orders[order_index][order_line_index].Quantity - orders[order_index][order_line_index].Produced;
            LogHandler.WriteLine("Esta linea de orden necesita que se fabriquen {0} productos.", quantity_needed);
            quantity_needed = current_product.GetLowestQuantity(quantity_needed);
            LogHandler.WriteLine("Esta linea de orden necesita que se fabriquen {0} productos.", quantity_needed);

            //Recalcular los tiempos de proceso (inicio de miniturno y total de miniturnos)

            //COPIAR LO DE GETASSIGNMENT BLA BLA BLA, POR ESO SE CAE. ES UN TORMENTO GGWP

            /*current_product[0].MiniturnsUsed = Convert.ToInt32(Math.Ceiling(current_product[0].AverageTime * quantity_needed / Simulation.MiniturnLength));
            for (int i = 1; i < current_product.NumberOfTuples; i++)
            {
                //Espero que funcione :(
                current_product[i].MiniturnStart = current_product[i - 1].MiniturnStart + Convert.ToInt32(Math.Ceiling(current_product[0].AverageTime / Simulation.MiniturnLength));
                LogHandler.WriteLine("current_product[{0}].MiniturnStart = {1} + {2} (debería ser menor a {3}", i, current_product[i - 1].MiniturnStart, current_product[i - 1].MiniturnsUsed, simulation.TotalMiniturns);
                if (current_product[i].MiniturnStart >= simulation.TotalMiniturns) throw new Exception("Al recalcular los tiempos de proceso el inicio del miniturno fue mayor al numero total de miniturnos.");

                current_product[i].MiniturnsUsed = Convert.ToInt32(Math.Ceiling(current_product[i].AverageTime * quantity_needed / Simulation.MiniturnLength));
                LogHandler.WriteLine("current_product[{0}].MiniturnsUsed = RedondearParaArriba({1}*{2}/{3}) = {4} (debería ser menor a {5}", i, current_product[i].AverageTime, quantity_needed, Simulation.MiniturnLength, current_product[i].MiniturnsUsed, simulation.TotalMiniturns);
                if (current_product[i].MiniturnStart >= simulation.TotalMiniturns) throw new Exception("Al recalcular los tiempos de proceso el nuevo numero de miniturnos ocupados fue mayor al numero total de miniturnos.");
            }*/

            //Colocar en la matriz las líneas de asignación.
            for (int i = 0; i < current_product.NumberOfTuples; i++)
            {
                current_product[i].Produced = quantity_needed;
                int worker_index = simulation.SelectedWorkers.GetIndex(current_product[i].Worker.ID);
                for (int j = 0; j < current_product[i].MiniturnsUsed; j++)
                    assignment[worker_index, current_product[i].MiniturnStart + j] = current_product[i];
            }

            //Actualizar las líneas de orden
            LogHandler.WriteLine("orders[{0}][{1}] = {2} = {3} = current_line_items[{1}]", order_index, order_line_index, orders[order_index][order_line_index].Produced, current_line_items[order_line_index].Produced);
            orders[order_index][order_line_index].Produced += quantity_needed;
            //current_line_items[order_line_index].Produced += quantity_needed;
            LogHandler.WriteLine("orders[{0}][{1}] = {2} = {3} = current_line_items[{1}]", order_index, order_line_index, orders[order_index][order_line_index].Produced, current_line_items[order_line_index].Produced);
            
            for (int i = 0; i < current_product.NumberOfTuples; i++)
            {
                //Espero que funcione :(
                int id_process = current_product[i].Job.Process;
                for (int j = 0; j < remaining_processes.Count(); j++)
                    if (remaining_processes[i].ID == id_process) remaining_processes[i].NumberOfJobs--;
            }

            return true;
        }

        private void RemoveProcesses(ProcessTuple[] remaining_processes, List<Index> candidates, List<Index> current_deleted_indexes, ref GraspProduct current_product)
        {
            //Eliminar los procesos que ya se agotaron
            for (int process = 0; process < remaining_processes.Count(); process++)
            {
                if (remaining_processes[process].NumberOfJobs > 0) continue;
                for (int index = candidates.Count - 1; index >= 0; index--)
                    if (candidates[index].Job.Process == remaining_processes[process].ID) candidates.RemoveAt(index);
            }
            //Eliminar para un trabajador el resto de procesos para que siempre se quede en un proceso
            for (int i = 0; i < current_product.NumberOfTuples; i++)
            {
                AssignmentLine line = current_product[i];
                if (line == null || line.Worker == null || line.Job == null) continue;
                candidates.RemoveAll(index => index.Worker.ID == line.Worker.ID && index.Job.ID != line.Job.ID);
            }
            //Reiniciar el proceso en producción, para la siguiente asignación.
            current_deleted_indexes.Clear();
            current_product = null;
        }
    }
}
 