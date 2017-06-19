using InkaArt.Classes;
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

        //Trabajadores y pedidos filtrados 
        private WorkerController selected_workers;
        private OrderController selected_orders;

        private int miniturns = 30;             //30 * 10 = 300 minutos = 5 h como turno ( esto debería calcularse :' )

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
        public int Miniturns
        {
            get { return miniturns; }
            //set { miniturns = value; }
        }
        public List<Assignment> Assignments
        {
            get { return assignments; }
            //set { assignments = value; }
        }

        /********** Constructor para nueva simulación de asignación de trabajadores **********/

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
        }

        /********** Constructor para lectura de base de datos **********/

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
            this.selected_workers = null;
            this.selected_orders = null;
        }

        public double ProductWeight(int product_id)
        {
            if (product_id == 1) return huaco_weight;
            if (product_id == 2) return huamanga_stone_weight;
            if (product_id == 3) return retable_weight;
            return 1;                
        }

        /******************* GUARDADO EN BASE DE DATOS *******************/

        public void Save()
        {
            //if (assignments == null) return;
            //NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            //connection.Open();

            //int miniturn;
            //int days = 1;            

            //foreach (AssignmentLine[][] day in assignments)
            //{
            //    foreach(AssignmentLine[] worker in day)
            //    {
            //        miniturn = 0;
            //        foreach (AssignmentLine assignment in worker)
            //        {
            //            //assignment.Miniturn = miniturn;
            //            assignment.Date = DateTime.Now.AddDays(days);

            //            NpgsqlCommand command = new NpgsqlCommand("insert into Assignment (id_worker, id_process_product, id_recipe, miniturn, assignment_date) values (:id_worker, :id_process_product, :id_recipe, :miniturn, :assignment_date)", connection);
            //            command.Parameters.Add(new NpgsqlParameter("id_worker", assignment.Worker.ID));
            //            command.Parameters.Add(new NpgsqlParameter("id_process_product", assignment.Job.ID));
            //            command.Parameters.Add(new NpgsqlParameter("id_recipe", assignment.Recipe.ID));
            //            //command.Parameters.Add(new NpgsqlParameter("miniturn", assignment.Miniturn));
            //            command.Parameters.Add(new NpgsqlParameter("assignment_date", assignment.Date));

            //            command.ExecuteNonQuery();
            //            miniturn++;
            //        }
            //    }
            //    days++;                
            //}           
            
            //connection.Close();
        }

        public string UpdateName()
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

        //public List<AssignmentLine> AssignmentsToList()
        //{
        //    //List<AssignmentLine> list = new List<AssignmentLine>();

        //    //if (assignments == null) return list;
        //    //foreach(AssignmentLine[][] day in assignments)
        //    //{
        //    //    foreach(AssignmentLine[] worker in day)
        //    //    {
        //    //        list.Concat(worker.ToList<AssignmentLine>());
        //    //    }
        //    //}
            
        //    //return list.OrderByDescending(o => o.TotalMiniturns).OrderByDescending(o => o.Worker).OrderByDescending(o => o.Date).ToList();
        //}
    }
}
