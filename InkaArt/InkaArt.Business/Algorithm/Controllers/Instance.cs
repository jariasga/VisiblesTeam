using InkaArt.Common;
using InkaArt.Data.Algorithm;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Algorithm
{

    class Instance
    {
        private WorkerController workers;
        //private RatioResumeController ratios; 
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
        private double miniturns;               
        // time
        private int start_time;                      // milisegundos
        private int limit_time;                      // 1 000 * 60 * 5 (maximo 5 miutos)

        /* gets */

        public int LimitTime
        {
            get
            {
                return limit_time;
            }
        }

        public int StartTime
        {
            get
            {
                return start_time;
            }
        }

        public double Miniturns
        {
            get
            {
                return miniturns;
            }
        }

        /* constructor */

        public Instance()
        {
            // time
            start_time = Environment.TickCount;

            // processes
            processes = new ProcessController();
            processes.Load();
            jobs = new JobController();
            jobs.Load();

            // workers y ratios
            workers = new WorkerController();
            workers.Load(); // solo filtrados
            //ratios = new RatioResumeController();
            //ratios.Load();

            // pesos de ratios y productos
            LoadParameters();
        }

        public void LoadParameters()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
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

        /* Devuelve la lista de procesos productos que existen para un proceso */
        public List<int> getProcessProducts(int i)
        {
            List<int> list = new List<int>();

            if (i == 0)
            {
                list.Add(20);       // tallado de piedras
                list.Add(30);       // tallado de retablos
            }
            else if (i == 1)
            {
                list.Add(10);       // modelado de huacos
            }
            else if (i == 2)
            {
                list.Add(12);       // horneado de huacos
            }
            else if (i == 3)
            {
                list.Add(11);       // pintado de huacos
                list.Add(31);       // pintado de retablos
            }

            return list;
        }
        
        /* Predicado de solucion */
        public static Predicate<int> byProcessProduct(int process_product_id)
        {
            return delegate (int assignment)
            {
                return assignment == process_product_id;
            };
        }

        /* Predicado de solucion */
        public static Predicate<int> byProduct(int product_id)
        {
            // ids: 0 Huacos, 1 piedras, 2 retablos
            return delegate (int assignment)
            {
                return (assignment / 10) == (product_id + 1);
            };
        }

    }
}
