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
        // pesos de ratios
        private double breakage_weight;              // para los indices de perdida
        private double time_weight;
        // pesos de productos
        private double huaco_weight;
        private double huamanga_stone_weight;
        private double retable_weight;

        // trabajadores filtrados
        private List<Worker> workers;
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

        public Simulation() { }

        public Simulation(string name, int days, double breakage, double time, double huaco, double huamanga, double retable)
        {
            this.name = name;
            this.days = days;
            this.breakage_weight = breakage;
            this.time_weight = time;
            this.huaco_weight = huaco;
            this.huaco_weight = huamanga;
            this.retable_weight = retable;
            this.workers = new List<Worker>();
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
    }
}
