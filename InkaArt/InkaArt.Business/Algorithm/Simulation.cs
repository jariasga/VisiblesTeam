﻿using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Algorithm
{
    public class Simulation
    {
        private string name;
        private int days;

        // pesos de ratios
        private double breakage_weight;
        private double time_weight;
        // pesos de productos
        private double huaco_weight;
        private double huamanga_stone_weight;
        private double retable_weight;

        // trabajadores filtrados
        private List<Worker> workers;
        private List<Index> indexes;
        private List<Order> orders;
        private ProcessController processes;
        private JobController jobs;

        // Parametros no configurables por el usuario
        // time
        private int start_time;                      // milisegundos
        private int limit_time = 3000000;            // 1 000 * 60 * 5 (maximo 5 miutos)
        private int miniturns = 30;

        // Resultados de asignacion
        List<Assignment[][]> assignments = null;

        public double BreakageWeight
        {
            get
            {
                return breakage_weight;
            }
        }

        public double TimeWeight
        {
            get
            {
                return time_weight;
            }
        }

        public double HuacoWeight
        {
            get
            {
                return huaco_weight;
            }
        }

        public double HuamangaStoneWeight
        {
            get
            {
                return huamanga_stone_weight;
            }
        }

        public double RetableWeight
        {
            get
            {
                return retable_weight;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }            
        }

        public List<Worker> Workers
        {
            get
            {
                return workers;
            }

            set
            {
                workers = value;
            }
        }

        public List<Index> Indexes
        {
            get
            {
                return indexes;
            }

            set
            {
                indexes = value;
            }
        }

        public int Days
        {
            get
            {
                return days;
            }

            set
            {
                days = value;
            }
        }

        public int StartTime
        {
            get
            {
                return start_time;
            }

            set
            {
                start_time = value;
            }
        }

        public int LimitTime
        {
            get
            {
                return limit_time;
            }

            set
            {
                limit_time = value;
            }
        }

        public int Miniturns
        {
            get
            {
                return miniturns;
            }

            set
            {
                miniturns = value;
            }
        }

        public List<Assignment[][]> Assignments
        {
            get
            {
                return assignments;
            }

            set
            {
                assignments = value;
            }
        }

        public List<Order> Orders
        {
            get
            {
                return orders;
            }

            set
            {
                orders = value;
            }
        }

        public Simulation() { }
        
        public Simulation(string name, string days, string breakage, string time, string huaco, string huamanga, string retable, List<Worker> workers, List<Order> orders)
        {
            this.name = name;
            this.days = int.Parse(days);
            this.breakage_weight = double.Parse(breakage);
            this.time_weight = double.Parse(time);
            this.huaco_weight = double.Parse(huaco);
            this.huamanga_stone_weight = double.Parse(huamanga);
            this.retable_weight = double.Parse(retable);
            this.workers = workers;
            this.orders = orders;

            // processes
            processes = new ProcessController();
            processes.Load();
            jobs = new JobController();
            jobs.Load();
        }

        public void Update(string name, string days, string breakage, string time, string huaco, string huamanga, string retable, List<Worker> workers, List<Order> orders)
        {
            this.name = name;
            this.days = int.Parse(days);
            this.breakage_weight = double.Parse(breakage);
            this.time_weight = double.Parse(time);
            this.huaco_weight = double.Parse(huaco);
            this.huamanga_stone_weight = double.Parse(huamanga);
            this.retable_weight = double.Parse(retable);
            this.workers = workers;
            this.orders = orders;
        }
        
        static public string Validate(string name, string days, string breakage, string time, string huaco, string huamanga, string retable, List<Worker> workers, List<Order> orders)
        {
            int aux_int;
            double aux_double;

            // campos obligatorios

            if (name.Equals("") || days.Equals("") || breakage.Equals("") || time.Equals("") || huaco.Equals("") || huamanga.Equals("") || retable.Equals(""))
                return "Por favor, complete todos los campos antes de continuar";
            if (workers.Count == 0)
                return "Por favor, considere como mínimo un empleado";
            if (orders.Count == 0)
                return "Por favor, considere como mínimo un pedido";

            // campos numericos y positivos

            if (!int.TryParse(days, out aux_int))
                return "El NÚMERO DE DÍAS debe ser numérico";
            else if (aux_int < 0)
                return "El NÚMERO DE DÍAS debe ser positivo";

            if (!double.TryParse(breakage, out aux_double))
                return "El PESO DE ROTURA debe ser numérico";
            else if (aux_double < 0)
                return "El PESO DE ROTURA debe ser positivo";

            if (!double.TryParse(time, out aux_double))
                return "El PESO DE TIEMPO debe ser numérico";
            else if (aux_double < 0)
                return "El PESO DE TIEMPO debe ser positivo";

            if (!double.TryParse(huaco, out aux_double))
                return "El PESO DE HUACO debe ser numérico";
            else if (aux_double < 0)
                return "El PESO DE HUACO debe ser positivo";

            if (!double.TryParse(huamanga, out aux_double))
                return "El PESO DE PIEDRAS DE HUAMANGA debe ser numérico";
            else if (aux_double < 0)
                return "El PESO DE PIEDRAS DE HUAMANGA debe ser positivo";

            if (!double.TryParse(retable, out aux_double))
                return "El PESO DE RETABLO debe ser numérico";
            else if (aux_double < 0)
                return "El PESO DE RETABLO debe ser positivo";

            return "OK";
        }

        public double ProductWeight(int product_id)
        {
            if (product_id == 1)
                return huaco_weight;
            if (product_id == 2)
                return huamanga_stone_weight;
            if (product_id == 3)
                return retable_weight;

            return 0;                
        }        

        public void Start()
        {
            start_time = Environment.TickCount;
            List<Assignment[][]> initial_solution = new List<Assignment[][]>(); // GRASP
            TabuSearch tabu = new TabuSearch(this, initial_solution);
            //tabu.run();

            assignments = tabu.BestSolution;
        }

        public void Save()
        {
            if (assignments == null) return;
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = BD_Connector.ConnectionString.ConnectionString;
            connection.Open();

            int miniturn;
            int days = 1;            

            foreach (Assignment[][] day in assignments)
            {
                foreach(Assignment[] worker in day)
                {
                    miniturn = 0;
                    foreach (Assignment assignment in worker)
                    {
                        assignment.Minitun = miniturn;
                        assignment.Date = DateTime.Now.AddDays(days);

                        NpgsqlCommand command = new NpgsqlCommand("insert into Assignment (id_worker, id_process_product, id_recipe, miniturn, assignment_date) values (:id_worker, :id_process_product, :id_recipe, :miniturn, :assignment_date)", connection);
                        command.Parameters.Add(new NpgsqlParameter("id_worker", assignment.Worker.ID));
                        command.Parameters.Add(new NpgsqlParameter("id_process_product", assignment.Job.ID));
                        command.Parameters.Add(new NpgsqlParameter("id_recipe", assignment.Recipe.ID));
                        command.Parameters.Add(new NpgsqlParameter("miniturn", assignment.Minitun));
                        command.Parameters.Add(new NpgsqlParameter("assignment_date", assignment.Date));

                        command.ExecuteNonQuery();
                        miniturn++;
                    }
                }
                days++;                
            }           
            
            connection.Close();
        }

        public List<Assignment> AssignmentsToList()
        {
            List<Assignment> list = new List<Assignment>();

            if (assignments == null) return list;
            foreach(Assignment[][] day in assignments)
            {
                foreach(Assignment[] worker in day)
                {
                    list.Concat(worker.ToList<Assignment>());
                }
            }
            
            return list.OrderByDescending(o => o.Minitun).OrderByDescending(o => o.Worker).OrderByDescending(o => o.Date).ToList();
        }
    }
}
