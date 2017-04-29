using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Assignment
    {
        private Worker worker;
        public Worker Worker {
            get { return worker; }
        }
        private int process_product_id;
        public int ProcessProduct {
            get { return process_product_id; }
        }
        private double index_loss;
        private double cost;
        public double Cost {
            get { return cost; }
        }

        public Assignment(Worker worker, int process_product_id, double index_loss)
        {
            this.worker = worker;
            this.process_product_id = process_product_id;
            this.index_loss = index_loss;
            this.cost = index_loss;
        }

        public void NextCost(double value_o_f, int iteration)
        {
            this.cost = (index_loss - value_o_f) / (iteration + 1);
        }

        public static int NumberOfProcessProducts(List<Assignment> solution, int process_product)
        {
            int number_of_jobs = 0;
            for (int i = 0; i < solution.Count; i++)
            {
                if (solution[i].process_product_id == process_product) number_of_jobs++;
            }
            return number_of_jobs;
        }

        public void Print()
        {
            this.worker.Print();
            Console.WriteLine("Proceso por producto: id {0}", this.process_product_id);
            Console.WriteLine("Indice de pérdida = {0}, costo actual = {1}", index_loss, cost);
        }

        //Funciones de comparación

        public static Predicate<Assignment> byWorker(Worker worker)
        {
            return delegate (Assignment assignment)
            {
                return assignment.worker.id == worker.id;
            };
        }

        public static Predicate<Assignment> byProcessProductId(int process_product)
        {
            return delegate (Assignment assignment)
            {
                return assignment.process_product_id == process_product;
            };
        }

        public static int GetProcessProductByWorker(List<Assignment> assignments, int id)
        {
            for (int i = 0; i < assignments.Count; i++)
            {
                if (assignments[i].worker.id == id) return assignments[i].process_product_id;
            }
            return 0;
        }
    }
}
