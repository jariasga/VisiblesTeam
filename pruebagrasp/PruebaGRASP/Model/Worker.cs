using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGRASP
{
    class Worker
    {
        private int id;
        private string name;
        private double index_time;
        private double index_broken;

        public int ID
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public Worker(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.index_time = 0;
            this.index_broken = 0;
        }

        //Metodos para el indice de tiempo y de rotura
        public double IndexTime
        {
            get { return index_time; }
            set { index_time = value; }
        }

        public double IndexBroken
        {
            get { return index_broken; }
            set { index_broken = value; }
        }
    }
}
