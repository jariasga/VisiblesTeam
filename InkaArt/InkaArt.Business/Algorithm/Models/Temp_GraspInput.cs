using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    class Temp_GraspInput
    {
        public Worker worker;
        public Job process_product;
        public double loss_index;
        public double cost_value;

        public Temp_GraspInput(Worker worker, Job process_product, double loss_index)
        {
            this.worker = worker;
            this.process_product = process_product;
            this.loss_index = loss_index;
            this.cost_value = loss_index;
        }

        public void CalculateNextCostValue(double of_value, int iteration)
        {
            /*Console.Write("En la iteración {0} el valor del costo cambió de {1} ",
                iteration, this.cost_value);*/
            this.cost_value = (this.loss_index - of_value) / (iteration + 1);
            //Console.WriteLine("a {0}.", this.cost_value);
        }

        public void Print()
        {
            Console.WriteLine("Asignación al trabajador {0} en {1} (perdida = {2}, último " +
                "valor de costo = {3})", worker.ToString(), process_product.ToString(),
                loss_index, cost_value);
        }

        public new string ToString()
        {
            return string.Format("Asignación al trabajador {0} en {1} (perdida = {2}, último " +
                "valor de costo = {3})", worker.ToString(), process_product.ToString(),
                loss_index, cost_value);
        }
    }
}
