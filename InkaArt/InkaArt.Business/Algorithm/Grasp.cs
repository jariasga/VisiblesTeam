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
        public int NumberOfIterations = 100;
        public double Alpha = 0.2;
        public int LimitTime;

        private Simulation simulation;
        private JobController jobs;
        private DataTable processes;
        private RecipeController recipes;
        private IndexController indexes;
        private List<Order> original_orders;

        //Variables auxiliares para el algoritmo
        private GraspAssignments day_assignments;
        private int order_line_index;
        private GraspProduct current_product;
        private List<Index> candidates;
        private Index chosen_candidate;

        /// <summary>
        /// Constructor del algoritmo GRASP.
        /// </summary>
        public Grasp(Simulation simulation, JobController jobs, RecipeController recipes, IndexController indexes)
        {
            this.simulation = simulation;
            this.jobs = jobs;
            this.recipes = recipes;
            this.indexes = indexes;

            //Parámetros de GRASP
            this.NumberOfIterations = 100;
            this.Alpha = 0.2;
            this.LimitTime = (Simulation.LimitTime * 2) / (5 * simulation.Days); //Tiempo: 120 segundos / # de días

            //Líneas de ordenes original
            this.original_orders = simulation.SelectedOrders.Orders;
            //Número de puestos de trabajo para cada proceso
            Production.ProcessController process_controller = new Production.ProcessController();
            this.processes = process_controller.getData();
        }

        /// <summary>
        /// Ejecuta el algoritmo GRASP varias veces para obtener la asignación de trabajadores para un día determinado.
        /// </summary>
        public Assignment ExecuteGraspAlgorithm(int day, ref int elapsed_time)
        {
            this.day_assignments = new GraspAssignments(this.NumberOfIterations);

            for (int iteration = 0; this.HasTime(ref elapsed_time, day) && iteration < this.NumberOfIterations; iteration++)
            {
                //Crear una COPIA PROFUNDA de la lista de órdenes
                List<Order> orders = new List<Order>();
                for (int i = 0; i < original_orders.Count; i++) orders.Add(new Order(simulation.SelectedOrders[i]));
                orders = orders.OrderBy(order => order.DeliveryDate).ThenBy(order => order.Client.Priority).ToList();

                //Obtener el índice de órdenes con el cual trabajar y la lista de líneas de orden para asignar
                if (orders.Count <= 0)
                {
                    LogHandler.WriteLine("¡Acabamos las ordenes antes de terminarse el algoritmo! :D");
                    return day_assignments.GetBestAssignment(ref this.original_orders);
                }

                //Inicializar la lista de candidatos para ser asignados
                this.candidates = new List<Index>();
                for (int i = 0; i < indexes.Count(); i++)
                    if (simulation.SelectedWorkers.GetByID(indexes[i].Worker.ID) != null) candidates.Add(indexes[i]);

                //Ejecutar la fase de construcción del algoritmo GRASP.
                Assignment assignment = this.ExecuteGraspConstructionPhase(day, iteration, orders, ref elapsed_time);

                //Si se logró minimizar la función objetivo, se reemplaza la mejor asignación del día por la nueva asignación generada
                if (this.HasTime(ref elapsed_time, day)) day_assignments.AddAssignment(assignment, orders);
            }

            return day_assignments.GetBestAssignment(ref this.original_orders);
        }

        private bool HasTime(ref int elapsed_time, int day)
        {
            return (elapsed_time < (this.LimitTime + this.LimitTime * day));
        }

        /// <summary>
        /// Ejecuta la fase de construcción del algoritmo GRASP para la asignación de trabajadores de un día determinado.
        /// </summary>
        private Assignment ExecuteGraspConstructionPhase(int day, int iteration, List<Order> orders, ref int elapsed_time)
        {
            //Inicializar las variables principales
            Assignment assignment = new Assignment(simulation.StartDate.AddDays(day), simulation.SelectedWorkers, simulation.TotalMiniturns);
            this.current_product = null;
            List<Index> current_deleted_indexes = new List<Index>();
            ProcessTuple[] remaining_processes = this.GetRemainingProcesses();

            for (int construction = 1; this.HasTime(ref elapsed_time, day) && orders.Count > 0 && candidates.Count > 0; construction++)
            {
                LogHandler.WriteLine("Iteración GRASP #{0}, current_product = {1}", construction, current_product != null);

                //Actualizar la función de costo para los candidatos restantes.
                for (int i = 0; i < candidates.Count; i++)
                {
                    double product_objective_function = (current_product == null) ? 0 : current_product.ObjectiveFunction;
                    candidates[i].NextCostValue(assignment.ObjectiveFunction, product_objective_function, construction);
                }

                PrintIndexes(candidates, "Inicio de iteración de construcción #" + construction);

                //Obtener una lista de los trabajadores más eficientes.
                List<Index> rcl = this.GenerateRestrictedCandidateList(orders);
                //Si el RCL es nulo, es porque no hemos encontrado candidatos para alguna receta, así que hay que volver a intentarlo.
                if (rcl == null && this.RemoveOrderLines(orders, current_deleted_indexes, ref construction)) continue;

                //Seleccionar al azar un candidato e incorporarlo en la solución
                AssignmentLine new_assignment_line = null;
                while (new_assignment_line == null)
                {
                    new_assignment_line = this.GetNextAssignmentLine(rcl, orders, assignment);
                    //Si new_assignment_line es nulo, es porque el trabajador seleccionado está lleno de trabajo, así que hay que eliminar
                    //los candidatos con ese trabajador y volver a seleccionar un trabajador.
                    if (new_assignment_line == null) this.RemoveWorker(rcl, chosen_candidate.Worker, current_deleted_indexes);
                }

                //Actualizamos la función objetivos
                if (current_product == null)
                {
                    current_product = new GraspProduct(chosen_candidate.Recipe, jobs);
                    bool order_line_selected = GetOrderLineIndex(orders);
                    if (!order_line_selected && this.UndoProduct(current_deleted_indexes, ref construction)) continue;
                }
                if (current_product.SetAssignmentLine(new_assignment_line, chosen_candidate.CostValue) == false)
                    MessageBox.Show("GRASP: El AssignmentLine no forma parte del producto");

                //Quitar temporalmente tanto el candidato seleccionado como los candidatos asociados a ese trabajador
                for (int i = candidates.Count - 1; i >= 0; i--)
                {
                    if (candidates[i].Worker.ID != chosen_candidate.Worker.ID) continue;
                    current_deleted_indexes.Add(candidates[i]);
                    candidates.RemoveAt(i);
                }

                //Si se terminó de fabricar el producto, ahora toca colocarlo en la matriz.
                if (current_product.IsFullyAssigned())
                {
                    bool added = this.AddAssignmentLines(assignment, remaining_processes, orders);
                    if (added == true) this.RemoveProcesses(remaining_processes, current_deleted_indexes);
                    else this.UndoProduct(current_deleted_indexes, ref construction);
                }

                //Revisar estado de la matriz
                PrintAssignmentMatrix(assignment, "Estado de la matriz al final de la iteración de construcción " + construction);
                PrintCurrentProduct(current_product, "Estado del producto actual al final de la iteración de construcción " + construction);
            }

            return assignment;
        }

        private ProcessTuple[] GetRemainingProcesses()
        {
            ProcessTuple[] remaining_processes = new ProcessTuple[processes.Rows.Count];
            for (int i = 0; i < processes.Rows.Count; i++)
            {
                int id_process = Convert.ToInt32(processes.Rows[i]["id_process"].ToString());
                int number_of_jobs = Convert.ToInt32(processes.Rows[i]["number_of_jobs"].ToString());
                remaining_processes[i] = new ProcessTuple(id_process, number_of_jobs);
            }
            return remaining_processes;
        }

        /// <summary>
        /// Genera una lista restringida de candidatos (RCL) a partir de la lista original de candidatos de la asignación de trabajadores.
        /// </summary>
        private List<Index> GenerateRestrictedCandidateList(List<Order> orders)
        {
            //Inicializar el RCL con los candidatos asociados al producto y receta a producir
            List<Index> rcl = new List<Index>();
            for (int i = 0; i < candidates.Count; i++)
            {
                //Si current_product es nulo, añadir los candidatos cuya receta esté dentro de la lista de recetas de la orden actual.
                if (current_product == null && this.LineItemsContains(orders, candidates[i].Recipe)) rcl.Add(candidates[i]);
                //Si current_product está con datos, añadir los candidatos cuyo puesto de trabajo esté dentro de la lista de puestos para el producto y cuya receta sea la misma que el producto que estamos elaborando.
                if (current_product != null && current_product.IsCandidateForRCL(candidates[i])) rcl.Add(candidates[i]);
            }

            if (rcl.Count <= 0) return null; //No se encontraron candidatos

            PrintIndexes(rcl, "RCL antes del filtrado");

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
            LogHandler.WriteLine();

            //Obtener el rango del RCL y quitar los índices del RCL que no estén en el rango
            for (int i = rcl.Count - 1; i >= 0; i--)
                if (candidates[i].CostValue < min || candidates[i].CostValue > max_rcl) rcl.RemoveAt(i);

            PrintIndexes(rcl, "RCL despues del filtrado");

            if (rcl.Count <= 0) return null; //No se encontraron candidatos
            return rcl;
        }

        private bool LineItemsContains(List<Order> orders, Recipe recipe)
        {
            for (int i = 0; i < orders[0].NumberOfLineItems; i++)
                if (orders[0][i].Recipe.ID == recipe.ID) return true;
            return false;
        }

        private bool RemoveOrderLines(List<Order> orders, List<Index> current_deleted_indexes, ref int construction)
        {
            LogHandler.WriteLine("RCL salió nulo, actualizando líneas de orden");

            //Si no se pudo encontrar ningun candidato cuya receta esté en alguna línea de orden, pasamos a la siguiente orden.
            if (this.current_product == null)
            {
                LogHandler.WriteLine("RCL: No se pudo encontrar ningun candidato cuya receta esté en alguna línea de orden,");
                LogHandler.WriteLine("así que pasamos al siguiente.");
                orders.RemoveAt(0); //Pasar a la siguiente orden
                construction--; //Continuar con el mismo número de construcción
            }
            //Si, en cambio, estábamos preparando un producto y a la mitad de prepararlo nos quedamos sin candidatos,
            //quitamos la línea de orden con la receta.
            else
            {
                LogHandler.WriteLine("RCL: Estábamos preparando un producto y a la mitad de prepararlo nos quedamos sin candidatos.");
                LogHandler.WriteLine("Entonces, se quitará la línea de orden con la receta.");
                for (int i = orders[0].NumberOfLineItems - 1; i >= 0; i--)
                    if (orders[0][i].Recipe.ID == current_product.CurrentRecipe.ID) orders[0].RemoveLineItem(i);
                //Deshacer el producto y actualizar el número de construcción
                this.UndoProduct(current_deleted_indexes, ref construction);
            }
            return true;
        }

        /// <summary>
        /// Permite al algoritmo GRASP escoger un candidato (trabajador por receta por puesto de trabajo) al azar.
        /// </summary>
        public AssignmentLine GetNextAssignmentLine(List<Index> rcl, List<Order> orders, Assignment assignment)
        {
            //Escoger un candidato al azar.
            int random_index = Randomizer.NextNumber(0, rcl.Count - 1);
            this.chosen_candidate = rcl[random_index];
            LogHandler.WriteLine("Se está intentando escoger el índice {0};{1}", random_index + 1, chosen_candidate.ToString());
            LogHandler.WriteLine("GetNextAssignmentLine();worker_index;simulation;miniturn_start;miniturns_used;products");

            //Intentar incorporar al candidato seleccionado en la lista temporal
            int worker_index = simulation.SelectedWorkers.GetIndex(chosen_candidate.Worker.ID); //Índice del trabajador
            if (worker_index < 0 || worker_index >= simulation.SelectedWorkers.NumberOfWorkers) return null;

            int miniturn_start = simulation.TotalMiniturns; //Inicio del miniturno
            while (miniturn_start > 0 && assignment[worker_index, miniturn_start - 1] == null) miniturn_start--;

            
            LogHandler.Write("Valores;{0};Total={1},Length={2};{3}", worker_index, simulation.TotalMiniturns, Simulation.MiniturnLength,
                miniturn_start);

            if (miniturn_start >= simulation.TotalMiniturns) return null;

            AssignmentLine assignment_line = new AssignmentLine(chosen_candidate, miniturn_start, Simulation.MiniturnLength,
                simulation.TotalMiniturns);

            LogHandler.WriteLine(";{0};{0}*{1}/{2:0.0000}={3:0.0000}", assignment_line.MiniturnsUsed, Simulation.MiniturnLength,
                assignment_line.AverageTime, assignment_line.Produced);
            
            if (assignment_line.Produced <= 0) return null;
            LogHandler.WriteLine("Aceptado!");
            LogHandler.WriteLine();

            return assignment_line;
        }

        private bool UndoProduct(List<Index> current_deleted_indexes, ref int construction)
        {
            //Regresar todos los candidatos eliminados a la lista de candidatos
            candidates.AddRange(current_deleted_indexes);
            current_deleted_indexes.Clear();
            //Resetear la iteración de construcción y el producto actual
            construction = construction - current_product.NumberOfFullTuples() - 1;
            current_product = null;
            return true;
        }

        private void RemoveWorker(List<Index> rcl, Worker worker, List<Index> current_deleted_indexes)
        {
            //Se eliminan los índices que contengan al trabajador, tanto del RCL como de la lista de candidatos
            for (int i = current_deleted_indexes.Count - 1; i >= 0; i--)
                if (current_deleted_indexes[i].Worker.ID == worker.ID) current_deleted_indexes.RemoveAt(i);
            for (int i = candidates.Count - 1; i >= 0; i--)
                if (candidates[i].Worker.ID == worker.ID) candidates.RemoveAt(i);
            for (int i = rcl.Count - 1; i >= 0; i--)
                if (rcl[i].Worker.ID == worker.ID) rcl.RemoveAt(i);
        }

        private bool GetOrderLineIndex(List<Order> orders)
        {
            order_line_index = 0;
            while (order_line_index < orders[0].NumberOfLineItems)
            {
                if (orders[0][order_line_index].Recipe.ID == current_product.CurrentRecipe.ID) break;
                else order_line_index++;
            }
            return (order_line_index >= 0 && order_line_index < orders[0].NumberOfLineItems);
        }

        private bool AddAssignmentLines(Assignment assignment, ProcessTuple[] remaining_processes, List<Order> orders)
        {
            LogHandler.WriteLine("Función AddAssignmentLines():");
            LogHandler.WriteLine("- La linea de orden escogida es orders[0][{1}] = {2}", order_line_index, orders[0][order_line_index].ToString());

            int quantity_needed = orders[0][order_line_index].Quantity - orders[0][order_line_index].Produced;
            LogHandler.WriteLine("- Esta linea de orden necesita que se fabriquen {0} productos.", quantity_needed);
            
            Grasp.PrintCurrentProduct(current_product, "Estado inicial de las asignaciones temporales del producto escogido");
            LogHandler.WriteLine("Cantidad requerida = {0}", quantity_needed);

            //Recalcular los tiempos de proceso (inicio de miniturno y total de miniturnos)
            quantity_needed = current_product.GetLowestQuantity(quantity_needed, simulation.TotalMiniturns);
            LogHandler.WriteLine("- Con las asignaciones seleccionadas, se fabricarán {0} productos.", quantity_needed);

            if (quantity_needed <= 0) return false;

            PrintCurrentProduct(current_product, "Producto actual justo antes de la asignación a la matriz de asignaciones");

            //Colocar en la matriz las líneas de asignación.
            for (int i = 0; i < current_product.NumberOfTuples; i++)
            {
                int worker_index = simulation.SelectedWorkers.GetIndex(current_product[i].Worker.ID);
                for (int j = 0; j < current_product[i].MiniturnsUsed; j++)
                    assignment[worker_index, current_product[i].MiniturnStart + j] = current_product[i];
            }
            //Actualizar la asignación: función objetivo y cantidad producida en el día
            LogHandler.WriteLine("Función objetivo antigua: {0}", assignment.ObjectiveFunction);
            assignment.ObjectiveFunction += current_product.ObjectiveFunction;
            LogHandler.WriteLine("Función objetivo actual: {0}", assignment.ObjectiveFunction);
            if (current_product.CurrentRecipe.Product == 1) assignment.HuacosProduced += quantity_needed;
            if (current_product.CurrentRecipe.Product == 2) assignment.HuamangaProduced += quantity_needed;
            if (current_product.CurrentRecipe.Product == 3) assignment.AltarpieceProduced += quantity_needed;

            //Actualizar las líneas de orden
            LogHandler.WriteLine("orders[0][{0}] = {1}", order_line_index, orders[0][order_line_index].Produced);
            orders[0][order_line_index].Produced += quantity_needed;
            LogHandler.WriteLine("orders[0][{0}] = {1}", order_line_index, orders[0][order_line_index].Produced);

            if (orders[0][order_line_index].Produced >= orders[0][order_line_index].Quantity) orders[0].RemoveLineItem(order_line_index);
            if (orders[0].NumberOfLineItems <= 0) orders.RemoveAt(0);
            
            for (int i = 0; i < current_product.NumberOfTuples; i++)
                for (int j = 0; j < remaining_processes.Count(); j++)
                    if (remaining_processes[i].ID == current_product[i].Job.Process) remaining_processes[i].NumberOfJobs--;

            return true;
        }

        private void RemoveProcesses(ProcessTuple[] remaining_processes, List<Index> current_deleted_indexes)
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
                for (int c = candidates.Count - 1; c >= 0; c--)
                    if (candidates[i].Worker.ID == line.Worker.ID && candidates[i].Job.ID != line.Job.ID) candidates.RemoveAt(i);
            }
            //Reiniciar el proceso en producción, para la siguiente asignación.
            current_deleted_indexes.Clear();
            current_product = null;
        }


        /*************************************** FUNCIONES DE IMPRESIÓN *******************************************/

        private void PrintIndexes(List<Index> indexes, string title)
        {
            LogHandler.WriteLine(title);
            LogHandler.WriteLine("ID;Trabajador;Receta;Puesto de trabajo;Rotura promedio;Tiempo promedio;Indice de rotura;Función de costo");

            for (int i = 0; i < indexes.Count; i++)
                LogHandler.WriteLine(indexes[i].ToString());

            LogHandler.WriteLine();
        }

        private void PrintAssignmentMatrix(Assignment assignment, string title)
        {
            LogHandler.WriteLine(title);
            LogHandler.WriteLine("Leyenda: Trabajador,Receta,Puesto de trabajo,Prom. rotura,Tiempo prom.,Índ. pérdida,Rango,Producido");

            for (int w = 0; w < simulation.SelectedWorkers.NumberOfWorkers; w++)
                LogHandler.Write("{0};", simulation.SelectedWorkers[w].FullName);
            LogHandler.WriteLine();

            for (int m = 0; m < simulation.TotalMiniturns; m++)
            {
                for (int w = 0; w < simulation.SelectedWorkers.NumberOfWorkers; w++)
                    LogHandler.Write("{0};", (assignment[w,m] == null) ? "Nada" : assignment[w, m].ToString());
                LogHandler.WriteLine();
            }

            LogHandler.WriteLine();
        }

        public static void PrintCurrentProduct(GraspProduct current_product, string title)
        {
            LogHandler.WriteLine(title);
            if (current_product == null) LogHandler.WriteLine("(null)");
            else
            {
                LogHandler.WriteLine("Receta escogida: {0}", current_product.CurrentRecipe.Version);
                LogHandler.WriteLine("Trabajador,Receta,Puesto de trabajo,Prom. rotura,Tiempo prom.,Índ. pérdida,Rango,Producido");
                for (int i = 0; i < current_product.NumberOfTuples; i++)
                    LogHandler.WriteLine("{0}", (current_product[i] == null) ? "Nada" : current_product[i].ToString());
            }
            LogHandler.WriteLine();
        }

    }
}
 