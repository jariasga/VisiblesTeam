using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Business.Algorithm
{
    public class SimulationController
    {
        private BindingList<Simulation> simulations;
        JobController jobs;

        public SimulationController()
        {
            simulations = new BindingList<Simulation>();
            jobs = new JobController();
            jobs.Load();
        }        
        
        public Simulation this[int index]
        {
            get { return simulations[index]; }
        }

        public int Count()
        {
            return simulations.Count;
        }

        public void Add(Simulation simulation)
        {
            simulations.Add(simulation);
        }
        
        public void Delete(Simulation simulation)
        {
            if(simulation.ID > 0)
            {
                NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
                NpgsqlCommand command = new NpgsqlCommand("UPDATE inkaart.\"Simulation\" SET status = false WHERE id_simulation = :id_simulation;", connection);
                connection.Open();
                command.Parameters.AddWithValue("id_simulation", NpgsqlDbType.Integer, simulation.ID);
                command.ExecuteNonQuery();
                connection.Close();               
            }
            simulations.Remove(simulation);
        }

        public void Load(WorkerController workers, OrderController orders, RecipeController recipes)
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);

            connection.Open();
            loadSimulations(connection);
            List<Assignment> all_assignments = loadAssignments(connection);
            loadAssignmentLines(connection, all_assignments, workers, recipes);
            loadSelectedWorkers(connection, workers);
            loadSelectedOrders(connection, orders);
            connection.Close();
        }

        private void loadSelectedWorkers(NpgsqlConnection connection, WorkerController workers)
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Simulation-Worker\" WHERE id_simulation IN (" + simulationIdsToString() + ")", connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id_simulation = int.Parse(reader["id_simulation"].ToString());
                int id_worker = int.Parse(reader["id_worker"].ToString());
                
                Simulation simulation = simulations.Where(s => s.ID.Equals(id_simulation)).ToList().First();
                Worker worker = workers.GetByID(id_worker);
                simulation.SelectedWorkers.Add(worker);
            }
            reader.Close();
        }

        private void loadSelectedOrders(NpgsqlConnection connection, OrderController orders)
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Simulation-Order\" WHERE id_simulation IN (" + simulationIdsToString() + ")", connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id_simulation = int.Parse(reader["id_simulation"].ToString());
                int id_order = int.Parse(reader["id_order"].ToString());

                Simulation simulation = simulations.Where(s => s.ID.Equals(id_simulation)).ToList().First();
                Order order = orders.GetByID(id_order);
                simulation.SelectedOrders.Add(order);
            }
            reader.Close();
        }

        private void loadAssignmentLines(NpgsqlConnection connection, List<Assignment> all_assignments, WorkerController workers, RecipeController recipes)
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT al.* FROM inkaart.\"AssignmentLine\" al, inkaart.\"Assignment\" a " +
                "WHERE a.id_assignment = al.id_assignment AND a.id_assignment in (" + assignmentIdsToString(all_assignments) + ")", connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id_assignment = int.Parse(reader["id_assignment"].ToString());
                int id_worker = int.Parse(reader["id_worker"].ToString());
                int id_job = int.Parse(reader["id_job"].ToString());
                int id_recipe = int.Parse(reader["id_recipe"].ToString());
                int produced = int.Parse(reader["produced"].ToString());
                int total_miniturns = int.Parse(reader["total_miniturns"].ToString());

                Worker worker = workers.GetByID(id_worker);
                Recipe recipe = recipes.GetByID(id_recipe);
                Job job = jobs.GetByID(id_job);
                AssignmentLine line = new AssignmentLine(worker, job, recipe, produced, total_miniturns);

                Assignment assignment = all_assignments.Where(ass => ass.ID.Equals(id_assignment)).ToList().First();
                assignment.AssignmentLinesList.Add(line);
            }
            reader.Close();
        }

        private List<Assignment> loadAssignments(NpgsqlConnection connection)
        {
            List<Assignment> list = new List<Assignment>();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Assignment\" WHERE id_simulation IN (" + simulationIdsToString() + ")", connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id_simulation = int.Parse(reader["id_simulation"].ToString());
                int id_assignment = int.Parse(reader["id_assignment"].ToString());
                int tabu_iterations = int.Parse(reader["tabu_iterations"].ToString());
                double objective_function_value = double.Parse(reader["objective_function_value"].ToString());
                int huamanga_produced = int.Parse(reader["huamanga_produced"].ToString());
                int huacos_produced = int.Parse(reader["huacos_produced"].ToString());
                int altarpiece_produced = int.Parse(reader["altarpiece_produced"].ToString());
                DateTime date = DateTime.Parse(reader["date"].ToString());
                int assigned_workers = int.Parse(reader["assigned_workers"].ToString());

                Assignment assignment = new Assignment(id_assignment, id_simulation, tabu_iterations, objective_function_value, huamanga_produced, huacos_produced, altarpiece_produced, date, assigned_workers);
                Simulation simulation = simulations.Where(s => s.ID.Equals(id_simulation)).ToList().First();
                simulation.Assignments.Add(assignment);
                list.Add(assignment);
            }
            reader.Close();

            return list;
        }

        private void loadSimulations(NpgsqlConnection connection)
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Simulation\" WHERE status = :status", connection);
            command.Parameters.AddWithValue("status", NpgsqlDbType.Boolean, true);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id_simulation = int.Parse(reader["id_simulation"].ToString());
                string name = reader["name"].ToString();
                DateTime date_start = DateTime.Parse(reader["start_date"].ToString());
                DateTime date_end = DateTime.Parse(reader["end_date"].ToString());
                int number_of_days = int.Parse(reader["number_of_days"].ToString());
                int limit_time = int.Parse(reader["limit_time"].ToString());

                double breakage_weight = double.Parse(reader["breakage_weight"].ToString());
                double time_weight = double.Parse(reader["time_weight"].ToString());
                double huaco_weight = double.Parse(reader["huaco_weight"].ToString());
                double huamanga_weight = double.Parse(reader["huamanga_weight"].ToString());
                double altarpiece_weight = double.Parse(reader["altarpiece_weight"].ToString());

                Simulation simulation = new Simulation(id_simulation, name, date_start, date_end, number_of_days, limit_time, breakage_weight,
                    time_weight, huaco_weight, huamanga_weight, altarpiece_weight);
                Add(simulation);                
            }
            reader.Close();
        }

        private string simulationIdsToString()
        {
            List<int> ids = simulations.Select(simulation => simulation.ID).ToList();
            return string.Join(",", ids);
        }

        private string assignmentIdsToString(List<Assignment> all_assignments)
        {
            List<int> ids = all_assignments.Select(assignment => assignment.ID).ToList();
            return string.Join(",", ids);
        }

        public Simulation Validate(string name, DateTime date_start, DateTime date_end, decimal breakage, decimal time,
            decimal huaco, decimal huamanga, decimal altarpiece, WorkerController workers, WorkerController selected_workers,
            OrderController orders, OrderController selected_orders)
        {
            //Comprobar los campos obligatorios
            if (name == null || name == "")
                throw new Exception("Por favor, ingrese un nombre válido.");
            if (selected_workers == null || selected_workers.NumberOfWorkers <= 0)
                throw new Exception("Por favor, considere como mínimo un empleado.");
            if (selected_orders == null || selected_orders.NumberOfOrders <= 0)
                throw new Exception("Por favor, considere como mínimo un pedido.");

            //Fechas de inicio y final
            date_start = date_start.Date;
            date_end = date_end.Date;
            if (date_start > date_end)
                throw new Exception("La fecha de inicio debe ser menor o igual a la fecha final.");
            int days;
            try
            {
                days = Convert.ToInt32(Math.Ceiling((date_end - date_start).TotalDays)) + 1;
            }
            catch (Exception)
            {
                throw new Exception("No se pudo obtener el número de días a partir de las fechas de inicio y fin. "
                    + "Por favor, revise que haya ingresado las fechas correctamente.");
            }
            if (days <= 0) throw new Exception("La fecha de inicio debe ser menor o igual a la fecha final.");

            //Campos numéricos
            if (breakage < 0 || breakage > 100) throw new Exception("El peso de rotura debe estar entre 0% y 100%.");
            double breakage_weight = Convert.ToDouble(breakage) / 100;

            if (time < 0 || time > 100) throw new Exception("El peso del tiempo debe estar entre 0% y 100%.");
            double time_weight = Convert.ToDouble(time) / 100;

            if (huaco < 0 || huaco > 100)
                throw new Exception("El peso para los huacos precolombinos debe estar entre 0% y 100%.");
            double huaco_weight = Convert.ToDouble(huaco) / 100;

            if (huamanga < 0 || huamanga > 100)
                throw new Exception("El peso para las piedras de Huamanga debe estar entre 0% y 100%.");
            double huamanga_weight = Convert.ToDouble(huamanga) / 100;

            if (altarpiece < 0 || altarpiece > 100)
                throw new Exception("El peso para los retablos debe estar entre 0% y 100%.");
            double altarpiece_weight = Convert.ToDouble(altarpiece) / 100;
            
            return new Simulation(name, date_start.Date, date_end.Date, days, breakage_weight, time_weight, huaco_weight,
                    huamanga_weight, altarpiece_weight, selected_workers, selected_orders);
        }

        //public List<Simulation> List()
        //{
        //    return simulations;
        //}

        public BindingList<Simulation> BindingList()
        {
            return new BindingList<Simulation>(simulations);
        }

    }
}
