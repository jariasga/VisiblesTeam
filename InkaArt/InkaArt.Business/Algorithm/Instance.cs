using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Algorithm
{

    public class Instance
    {
        private WorkerController workers;
        private IndexController indexes; 
        private ProcessController processes;
        private JobController jobs;        

        // pesos de ratios
        private double breakage_weight;              // para los indices de perdida
        private double time_weight;

        // pesos de productos
        private double huaco_weight;
        private double huamanga_stone_weight;
        private double retable_weight;

        // numero de miniturnos        
        private double miniturns;               //debería ser int

        // time
        private int start_time;                      // milisegundos
        private int limit_time;                      // 1 000 * 60 * 5 (maximo 5 miutos)

        /* gets */

        public int LimitTime
        {
            get { return limit_time; }
        }
        public int StartTime
        {
            get { return start_time; }
        }
        public double Miniturns
        {
            get { return miniturns; }
        }

        /* constructor */

        public Instance()
        {
            // time
            start_time = Environment.TickCount;

            // processes
            this.processes = new ProcessController();
            this.processes.Load();
            this.jobs = new JobController();
            this.jobs.Load();
            this.workers = new WorkerController();
            this.workers.Load(); // solo filtrados
            this.indexes = new IndexController();
            this.indexes.Load();
            

            // pesos de ratios y productos
            LoadParameters();
        }

        public void LoadParameters()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = BD_Connector.ConnectionString.ConnectionString;
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"SimulationParameters\"", connection);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                this.breakage_weight = reader.GetDouble(0);
                this.time_weight = reader.GetDouble(1);

                this.huaco_weight = reader.GetDouble(2);
                this.huamanga_stone_weight = reader.GetDouble(3);
                this.retable_weight = reader.GetDouble(4);

                // parametros de tabu entre 7 y 13

                this.limit_time = reader.GetInt32(13);
                this.miniturns = reader.GetInt32(14);
            }

            connection.Close();
        }

        
    }
}
