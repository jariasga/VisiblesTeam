using InkaArt.Business.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class Simulation
    {
        private string name;
        private int days;
        // time
        private int start_time;                      // milisegundos
        private int limit_time = 3000000;            // 1 000 * 60 * 5 (maximo 5 miutos)

        // pesos de ratios
        private double breakage_weight;              // para los indices de perdida
        private double time_weight;
        // pesos de productos
        private double huaco_weight;
        private double huamanga_stone_weight;
        private double retable_weight;

        // trabajadores filtrados
        private List<Worker> workers;
        private List<Index> indexes;
        // pedidos filtrados
        //private List<Orders> orders;

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

        internal List<Worker> Workers
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

        internal List<Index> Indexes
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

        public Simulation() { }

        public Simulation(string name, int days, double breakage, double time, double huaco, double huamanga, double retable, List<Worker> workers)
        {
            this.name = name;
            this.days = days;
            this.breakage_weight = breakage;
            this.time_weight = time;
            this.huaco_weight = huaco;
            this.huaco_weight = huamanga;
            this.retable_weight = retable;
            this.workers = workers;
        }

        public Simulation(string name, string days, string breakage, string time, string huaco, string huamanga, string retable, List<Worker> workers)
        {
            this.name = name;
            this.days = int.Parse(days);
            this.breakage_weight = double.Parse(breakage);
            this.time_weight = double.Parse(time);
            this.huaco_weight = double.Parse(huaco);
            this.huaco_weight = double.Parse(huamanga);
            this.retable_weight = double.Parse(retable);
            this.workers = workers;
        }

        public void Update(string name, string days, string breakage, string time, string huaco, string huamanga, string retable, List<Worker> workers)
        {
            this.name = name;
            this.days = int.Parse(days);
            this.breakage_weight = double.Parse(breakage);
            this.time_weight = double.Parse(time);
            this.huaco_weight = double.Parse(huaco);
            this.huaco_weight = double.Parse(huamanga);
            this.retable_weight = double.Parse(retable);
            this.workers = workers;
        }

        public void Update(string name, int days, double breakage, double time, double huaco, double huamanga, double retable, List<Worker> workers)
        {
            this.name = name;
            this.days = days;
            this.breakage_weight = breakage;
            this.time_weight = time;
            this.huaco_weight = huaco;
            this.huaco_weight = huamanga;
            this.retable_weight = retable;
            this.workers = workers;
            //this.orders = orders;
        }

        static public string Validate(string name, string days, string breakage, string time, string huaco, string huamanga, string retable, List<Worker> workers)
        {
            int aux_int;
            double aux_double;

            // campos obligatorios

            if (name.Equals("") || days.Equals("") || breakage.Equals("") || time.Equals("") || huaco.Equals("") || huamanga.Equals("") || retable.Equals(""))
                return "Por favor, complete todos los campos antes de continuar";
            if (workers.Count == 0)
                return "Por favor, considere como mínimo un empleado";

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
            // grasp
            Assignment[][] initial_solution = new Assignment[workers.Count][]; // falta para varios dias
            TabuSearch tabu = new TabuSearch();
            tabu.run(this, initial_solution);
        }        
    }
}
