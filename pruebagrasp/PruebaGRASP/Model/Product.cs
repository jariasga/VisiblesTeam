using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGRASP
{
    class Product
    {
        private int id;
        private string description;
        private double current_price;
        private List<Job> jobs;

        public double CurrentPrice
        {
            get { return current_price; }
            set { current_price = value; }
        }

        public int ID
        {
            get { return id; }
        }

        public string Description
        {
            get { return description; }
        }

        public Product(int id, string description)
        {
            this.id = id;
            this.description = description;
            this.current_price = 0;
        }
    }
}
