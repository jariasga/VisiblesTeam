using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ProcessProduct
    {
        public int id;
        public string name;
        public Process process;
        public int product;

        public ProcessProduct(int id, string name, Process process, int product)
        {
            this.id = id;
            this.name = name;
            this.process = process;
            this.product = product;
        }

        public void Print()
        {
            Console.WriteLine("Proceso por producto: {0} (id {1}, proceso {2}, producto {3})",
                this.name, this.id, this.process.id, this.product);
        }

        public static ProcessProduct GetByID(List<ProcessProduct> list, int id)
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i].id == id) return list[i];
            return null;
        }
    }
}
