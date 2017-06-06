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

        public Simulation() { }

        public Simulation(string name, double breakage, double time, double huaco, double huamanga, double retable)
        {
            this.name = name;
            this.breakage_weight = breakage;
            this.time_weight = time;
            this.huaco_weight = huaco;
            this.huaco_weight = huamanga;
            this.retable_weight = retable;
            this.workers = new List<Worker>();
        }

        public void Update(string name = null, double breakage = -1, double time = -1, double huaco = -1, double huamanga = -1, double retable = -1, List<Worker> workers = null)
        {
            if (name != null)       this.name = name;
            if (breakage >= 0)      this.breakage_weight = breakage;
            if (time >= 0)          this.time_weight = time;
            if (huaco>= 0)          this.huaco_weight = huaco;
            if (huamanga >= 0)      this.huaco_weight = huamanga;
            if (retable >= 0)       this.retable_weight = retable;
            if (workers != null)    this.workers = workers;
        }
    }
}
