﻿using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Business.Algorithm
{
    public class Simulation
    {
        public const int LimitTime = 300;      //60 segundos * 5 minutos como máximo
        public const int MiniturnLength = 10;       //Un miniturno dura 10 minutos, pero debería leerse de SimulationParameters

        private int id_simulation;
        private string name;
        private DateTime date_start;
        private DateTime date_end;
        private int days;
        //Pesos de ratios
        private double breakage_weight;
        private double time_weight;
        //Pesos de productos
        private double huaco_weight;
        private double huamanga_stone_weight;
        private double retable_weight;
        private double time;
        private int total_miniturns;

        //Trabajadores y pedidos filtrados 
        private WorkerController selected_workers;
        private OrderController selected_orders;

        private List<Assignment> assignments;

        /*************************** SETS Y GETS ***************************/

        public int ID
        {
            get { return id_simulation; }
            //set { id_simulation = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime StartDate
        {
            get { return date_start; }
        }

        public DateTime EndDate
        {
            get { return date_end; }
        }

        public int Days
        {
            get { return days; }
            //set { days = value; }
        }

        public WorkerController SelectedWorkers
        {
            get { return selected_workers; }
            //set { selected_workers = value; }
        }

        public OrderController SelectedOrders
        {
            get { return selected_orders; }
            //set { selected_orders = value; }
        }

        public double BreakageWeight
        {
            get { return breakage_weight; }
        }

        public double TimeWeight
        {
            get { return time_weight; }
        }

        public double HuacoWeight
        {
            get { return huaco_weight; }
        }

        public double HuamangaStoneWeight
        {
            get { return huamanga_stone_weight; }
        }

        public double RetableWeight
        {
            get { return retable_weight; }
        }
        public List<Assignment> Assignments
        {
            get { return assignments; }
            set { assignments = value; }
        }

        public double Time
        {
            get { return time; }
            set { time = value; }
        }
        public int TotalMiniturns
        {
            get { return total_miniturns; }
            set { total_miniturns = value; }
        }
        
        /// <summary>
        /// Constructor para una nueva simulación de asignación de trabajadores.
        /// </summary>
        public Simulation(string name, DateTime date_start, DateTime date_end, int days, double breakage_weight,
            double time_weight, double huaco_weight, double huamanga_weight, double retable_weight, WorkerController selected_workers,
            OrderController selected_orders)
        {
            this.id_simulation = 0;
            this.name = name;
            this.date_start = date_start;
            this.date_end = date_end;
            this.days = days;
            this.breakage_weight = breakage_weight;
            this.time_weight = time_weight;
            this.huaco_weight = huaco_weight;
            this.huamanga_stone_weight = huamanga_weight;
            this.retable_weight = retable_weight;
            this.selected_workers = selected_workers;
            this.selected_orders = selected_orders;
            this.assignments = new List<Assignment>();
        }

        /// <summary>
        /// Constructor para lectura de base de datos.
        /// </summary>
        public Simulation(int id_simulation, string name, DateTime date_start, DateTime date_end, int number_of_days,
            double breakage_weight, double time_weight, double huaco_weight, double huamanga_weight, double retable_weight)
        {
            this.id_simulation = id_simulation;
            this.name = name;
            this.date_start = date_start;
            this.date_end = date_end;
            this.days = number_of_days;

            this.breakage_weight = breakage_weight;
            this.time_weight = time_weight;
            this.huaco_weight = huaco_weight;
            this.huamanga_stone_weight = huamanga_weight;
            this.retable_weight = retable_weight;

            this.assignments = new List<Assignment>();
            this.selected_workers = new WorkerController();
            this.selected_orders = new OrderController();
        }        
        
        public double ProductWeight(int product_id)
        {
            if (product_id == 1) return huaco_weight;
            if (product_id == 2) return huamanga_stone_weight;
            if (product_id == 3) return retable_weight;
            return 1; //Por defecto
        }

        /******************* GUARDADO EN BASE DE DATOS *******************/

        public bool Insert()
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
                connection.Open();

                string command_line = "INSERT INTO inkaart.\"Simulation\"(name, start_date, end_date, number_of_days, breakage_weight, " +
                                      "time_weight, huaco_weight, huamanga_weight, altarpiece_weight) ";
                command_line += "VALUES (:name, :start_date, :end_date, :number_of_days, :breakage_weight, :time_weight, " +
                                ":huaco_weight, :huamanga_weight, :altarpiece_weight)";
                command_line += "RETURNING inkaart.\"Simulation\".id_simulation";
                NpgsqlCommand command = new NpgsqlCommand(command_line, connection);
                
                command.Parameters.Add(new NpgsqlParameter("name", name));
                command.Parameters.Add(new NpgsqlParameter("start_date", date_start));
                command.Parameters.Add(new NpgsqlParameter("end_date", date_end));
                command.Parameters.Add(new NpgsqlParameter("number_of_days", days));
                command.Parameters.Add(new NpgsqlParameter("breakage_weight", breakage_weight));
                command.Parameters.Add(new NpgsqlParameter("time_weight", time_weight));
                command.Parameters.Add(new NpgsqlParameter("huaco_weight", huaco_weight));
                command.Parameters.Add(new NpgsqlParameter("huamanga_weight", huamanga_stone_weight));
                command.Parameters.Add(new NpgsqlParameter("altarpiece_weight", retable_weight));

                object result = command.ExecuteScalar();
                this.id_simulation = Convert.ToInt32(result);

                bool save_workers = this.SaveSelectedWorkers(connection);
                bool save_orders = this.SaveSelectedOrders(connection);

                bool save_assignments = true;
                for (int i = 0; i < assignments.Count; i++)
                    save_assignments &= assignments[i].Insert(this, connection);

                connection.Close();
                return save_workers && save_orders && save_assignments;
            }
            catch (Exception e)
            {
                LogHandler.WriteLine("Excepción al intentar guardar la simulación: " + e.ToString());
                return false;
            }
        }

        private bool SaveSelectedOrders(NpgsqlConnection connection)
        {
            try
            {
                for (int i = 0; i < selected_orders.NumberOfOrders; i++)
                {
                    string command_line = "INSERT INTO inkaart.\"Simulation-Order\" (id_simulation, id_order) VALUES (:id_simulation, :id_order)";
                    NpgsqlCommand command = new NpgsqlCommand(command_line, connection);

                    command.Parameters.Add(new NpgsqlParameter("id_simulation", id_simulation));
                    command.Parameters.Add(new NpgsqlParameter("id_order", selected_orders[i].ID));

                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                LogHandler.WriteLine("Excepción al intentar guardar las órdenes seleccionadas para la simulación: " + e.ToString());
                return false;
            }
        }

        private bool SaveSelectedWorkers(NpgsqlConnection connection)
        {
            try
            {
                for (int i = 0; i < selected_workers.NumberOfWorkers; i++)
                {
                    string command_line = "INSERT INTO inkaart.\"Simulation-Worker\" (id_simulation, id_worker) VALUES (:id_simulation, :id_worker)";
                    NpgsqlCommand command = new NpgsqlCommand(command_line, connection);

                    command.Parameters.Add(new NpgsqlParameter("id_simulation", id_simulation));
                    command.Parameters.Add(new NpgsqlParameter("id_worker", selected_workers[i].ID));

                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                LogHandler.WriteLine("Excepción al intentar guardar los trabajadores seleccionados para la simulación: " + e.ToString());
                return false;
            }
        }

        public string updateName()
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand("UPDATE inkaart.\"Simulation\" SET name = :name " +
                    "WHERE id_simulation = :id_simulation", connection);

                command.Parameters.AddWithValue("name", NpgsqlDbType.Text, this.name);
                command.Parameters.AddWithValue("id_simulation", NpgsqlDbType.Integer, this.id_simulation);

                int rows_affected = command.ExecuteNonQuery();
                connection.Close();

                if (rows_affected <= 0) return "No se actualizó ninguna simulación.";
                if (rows_affected == 1) return null;
                return "Se actualizó más de una simulación. Hay que chequear la base de datos para verificar que " +
                    "no haya pasado algo malo.";
            }
            catch (Exception e)
            {
                LogHandler.WriteLine("Excepción al intentar actualizar la simulación: " + e.ToString());
                return "Ocurrió una excepción al intentar actualizar la simulación: " + e.Message;
            }
        }
        
    }
}
