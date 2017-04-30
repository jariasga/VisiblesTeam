using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Model
{
    class ProcessProduct
    {
        //Atributos
        public int id;
        public string name;
        public Process process;
        public Product product;

        //Constructor
        public ProcessProduct(int id, string name, Process process, Product product)
        {
            this.id = id;
            this.name = name;
            this.process = process;
            this.product = product;
        }

        //Métodos
        public void Print()
        {
            Console.WriteLine("Proceso x producto #{0}: {1} (proceso = {2}, producto = {3})",
                id, name, process.ToString(), product.ToString());
        }

        public new string ToString()
        {
            return name + " (id " + id + ")";
        }
    }
}
