using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Model;

namespace InkaArt.Controller
{
    class JobManager
    {
        //Atributos
        private ProcessManager processes;
        private ProductManager products;
        private List<Job> jobs;

        public JobManager(ProcessManager processes, ProductManager products)
        {
            this.processes = processes;
            this.products = products;
            jobs = new List<Job>();
            //Cargar datos en duro
            Process moldeado = processes.GetByID(1);
            Process tallado = processes.GetByID(2);
            Process horneado = processes.GetByID(3);
            Process pintado = processes.GetByID(4);
            Product huacos = products.GetByID(1);
            Product piedras = products.GetByID(2);
            Product retablos = products.GetByID(3);
            jobs.Add(new Job(10, "Moldeado de huacos", moldeado, huacos));
            jobs.Add(new Job(11, "Pintado de huacos", pintado, huacos));
            jobs.Add(new Job(12, "Horneado de huacos", horneado, huacos));
            jobs.Add(new Job(20, "Tallado de piedras", tallado, piedras));
            jobs.Add(new Job(30, "Tallado de retablos", tallado, retablos));
            jobs.Add(new Job(31, "Pintado de retablos", pintado, retablos));
        }

        public Job GetByID(int id)
        {
            for (int i = 0; i < jobs.Count; i++)
            {
                if (jobs[i].id == id) return jobs[i];
            }
            return null;
        }

        public int NumberOfProcessesProducts()
        {
            return jobs.Count;
        }

        public Job this[int index]
        {
            get { return jobs[index]; }
        }

        public void Print()
        {
            for (int i = 0; i < jobs.Count; i++)
            {
                Console.Write("Proceso por producto {0}: ", i + 1);
                jobs[i].Print();
            }
        }

        public List<Job> GetOtherProcessesByProduct(List<Job> current_list_of_jobs,
            Job current_job)
        {
            for (int i = 0; i < jobs.Count; i++)
            {
                //Obtener todos los puestos de trabajo que compartan el mismo id de producto
                //(excepto nosotros mismos, por lo que los procesos no deben ser iguales)
                if (jobs[i].product.id == current_job.product.id &&
                    jobs[i].process.id != current_job.process.id)
                    current_list_of_jobs.Add(jobs[i]);
            }
            return current_list_of_jobs;
        }
    }
}
