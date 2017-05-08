using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Ratio
    {
        public string type; // time or roture
        public string process;
        public string product;
        public double value;

        public Ratio(string type, string process, string product, double value)
        {
            this.type = type;
            this.process = process;
            this.product = product;
            this.value = value;
        }

        public void print()
        {
            Console.WriteLine(type + " - " + process + " - " + product + " - " + value.ToString());
        }
    }
}
