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
        public WorkerController workers;
        //public List<Index> ratios; 
        public double shift_duration;               // minutos en un turno

        // time
        public int start_time;                      // milisegundos
        public int limit_time;                      // 1 000 * 60 * 5 (maximo 5 miutos)

        // processes
        public int processes_num;
        public List<int> processes_positions;       // puestos de trabajo por proceso

        // processes x products
        public JobController jobs;
        
        // pesos

        // de ratios
        private double breakage_weight;              // para los indices de perdida
        private double time_weight;
        // de productos
        private double huaco_weight;
        private double huamanga_stone_weight;
        private double retable_weight;

        public Instance()
        {
            // Tabla 

            // time
            start_time = Environment.TickCount;
            limit_time = 300000;                    // 1 000 * 60 * 5 (maximo 5 miutos)            

            // processes
            processes_num = 4;
            processes_positions = new List<int>(4);
            processes_positions.Add(10);            // tallado
            processes_positions.Add(10);            // modelado
            processes_positions.Add(10);            // horneado
            processes_positions.Add(10);            // pintado

            // processes products
            jobs = new JobController();
            jobs.Load();

            // pesos de ratios y productos
            LoadWeights();

            // from database
            workers = new WorkerController();
            workers.Load();
            
        }

        public void LoadProcess()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Process\"", connection);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                this.breakage_weight = reader.GetDouble(0);
                this.time_weight = reader.GetDouble(1);

                this.huaco_weight = reader.GetDouble(2);
                this.huamanga_stone_weight = reader.GetDouble(3);
                this.retable_weight = reader.GetDouble(4);
            }

            connection.Close();
        }

        public void LoadWeights()
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

        public List<int> getBestSolution(List<int[]> solutions)
        {
            int best_fitness = int.MaxValue;
            List<int> temp;
            List<int> best = new List<int>();

            foreach(int[] solution in solutions)
            {
                //temp = new List<int>(solution);
                //if (best_fitness > getFitness(temp))
                //    best = temp;
            }

            return best;
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
