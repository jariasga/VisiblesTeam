using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Model;

namespace InkaArt.Controller
{
    class ProcessProductManager
    {
        //Atributos
        private ProcessManager processes;
        private ProductManager products;
        private List<ProcessProduct> processes_products;

        public ProcessProductManager(ProcessManager processes, ProductManager products)
        {
            this.processes = processes;
            this.products = products;
            processes_products = new List<ProcessProduct>();
            //Cargar datos en duro
            Process moldeado = processes.GetByID(1);
            Process tallado = processes.GetByID(2);
            Process horneado = processes.GetByID(3);
            Process pintado = processes.GetByID(4);
            Product huacos = products.GetByID(1);
            Product piedras = products.GetByID(2);
            Product retablos = products.GetByID(3);
            processes_products.Add(new ProcessProduct(10, "Moldeado de huacos",
                moldeado, huacos));
            processes_products.Add(new ProcessProduct(11, "Pintado de huacos",
                pintado, huacos));
            processes_products.Add(new ProcessProduct(12, "Horneado de huacos",
                horneado, huacos));
            processes_products.Add(new ProcessProduct(20, "Tallado de piedras",
                tallado, piedras));
            processes_products.Add(new ProcessProduct(30, "Tallado de retablos",
                tallado, retablos));
            processes_products.Add(new ProcessProduct(31, "Pintado de retablos",
                pintado, retablos));
        }

        public ProcessProduct GetByID(int id)
        {
            for (int i = 0; i < processes_products.Count; i++)
            {
                if (processes_products[i].id == id) return processes_products[i];
            }
            return null;
        }

        public int NumberOfProcessesProducts()
        {
            return processes_products.Count;
        }

        public ProcessProduct this[int index]
        {
            get { return processes_products[index]; }
        }

        public void Print()
        {
            for (int i = 0; i < processes_products.Count; i++)
            {
                Console.Write("Proceso por producto {0}: ", i + 1);
                processes_products[i].Print();
            }
        }

        public List<ProcessProduct> GetOtherProcessesByProduct(List<ProcessProduct> list,
            ProcessProduct process_product)
        {
            for (int i = 0; i < processes_products.Count; i++)
            {
                //Obtener todos los procesosxproducto que compartan el mismo id de producto
                //(excepto nosotros mismos, por lo que los procesos no deben ser iguales)
                if (processes_products[i].product.id == process_product.product.id &&
                    processes_products[i].process.id != process_product.process.id)
                    list.Add(processes_products[i]);
            }
            return list;
        }
    }
}
