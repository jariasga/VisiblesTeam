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
        private JobController jobs;

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
        
        public bool Delete(Simulation simulation)
        {
            if (simulation.ID > 0)
            {
                try
                {
                    NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
                    NpgsqlCommand command = new NpgsqlCommand("UPDATE inkaart.\"Simulation\" SET status = false WHERE id_simulation = :id_simulation;", connection);
                    connection.Open();
                    command.Parameters.AddWithValue("id_simulation", NpgsqlDbType.Integer, simulation.ID);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception e)
                {
                    LogHandler.WriteLine("Excepción al intentar eliminar la simulación: " + e.ToString());
                    return false;
                }                
            }
            simulations.Remove(simulation);
            return true;
        }

        public void Load(WorkerController workers, OrderController orders, RecipeController recipes, JobController jobs)
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Simulation\" WHERE status = TRUE", connection);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_simulation = int.Parse(reader["id_simulation"].ToString());
                string name = reader["name"].ToString();
                DateTime date_start = DateTime.Parse(reader["start_date"].ToString());
                DateTime date_end = DateTime.Parse(reader["end_date"].ToString());
                int number_of_days = int.Parse(reader["number_of_days"].ToString());

                double breakage_weight = double.Parse(reader["breakage_weight"].ToString());
                double time_weight = double.Parse(reader["time_weight"].ToString());
                double huaco_weight = double.Parse(reader["huaco_weight"].ToString());
                double huamanga_weight = double.Parse(reader["huamanga_weight"].ToString());
                double altarpiece_weight = double.Parse(reader["altarpiece_weight"].ToString());

                Simulation simulation = new Simulation(id_simulation, name, date_start, date_end, number_of_days, breakage_weight,
                    time_weight, huaco_weight, huamanga_weight, altarpiece_weight);
                this.simulations.Add(simulation);
            }
            reader.Close();

            for (int i = 0; i < simulations.Count; i++)
            {
                //Cargar lista de trabajadores y lista de ordenes
                this.LoadSelectedWorkers(connection, simulations[i], workers);
                this.LoadSelectedOrders(connection, simulations[i], orders);
                //Cargar asignaciones y líneas de asignaciones
                simulations[i].Assignments = Assignment.Load(connection, simulations[i], recipes, jobs);
            }

            connection.Close();
        }

        private void LoadSelectedWorkers(NpgsqlConnection connection, Simulation simulation, WorkerController workers)
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Simulation-Worker\" WHERE id_simulation = :id_simulation", connection);
            command.Parameters.AddWithValue("id_simulation", NpgsqlDbType.Integer, simulation.ID);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_worker = int.Parse(reader["id_worker"].ToString());
                Worker worker = workers.GetByID(id_worker);
                if (worker != null) simulation.SelectedWorkers.Add(worker);
            }
            reader.Close();
        }

        private void LoadSelectedOrders(NpgsqlConnection connection, Simulation simulation, OrderController orders)
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Simulation-Order\" WHERE id_simulation = :id_simulation", connection);
            command.Parameters.AddWithValue("id_simulation", NpgsqlDbType.Integer, simulation.ID);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_order = int.Parse(reader["id_order"].ToString());
                Order order = orders.GetByID(id_order);
                if (order != null) simulation.SelectedOrders.Add(order);
            }
            reader.Close();
        }

        public bool Save(Simulation simulation)
        {
            return simulation.Insert();
        }

        /****************************************************************************************************************/

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
