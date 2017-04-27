using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Ratio
    {
        public string process;
        public string product;
        public double breakage;
        public double time;

        public Ratio(string type, string process, string product, double breakage, double time)
        {
            this.process = process;
            this.product = product;
            this.breakage = breakage;
            this.time = time;
        }

        public void print()
        {
            Console.WriteLine(type + " - " + process + " - " + product + " - " + value.ToString());
        }
    }
}
