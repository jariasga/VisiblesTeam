using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ESTO NO VA EN LA VERSIÓN FINAL
using System.IO;
using InkaArt.Controller;

namespace InkaArt.Model
{
    class Ratio
    {
        //Parámetros de la función objetivo
        public static double BreakageWeight = 0.6;
        public static double TimeWeight = 0.6;

        //Atributos
        public Worker worker;
        public ProcessProduct process_product;
        public double breakage_index;
        public double time_index;
        public double loss_index;

        //Constructor
        public Ratio(Worker worker, ProcessProduct process_product, double breakage_index,
            double time_index)
        {
            this.worker = worker;
            this.process_product = process_product;
            this.breakage_index = breakage_index;
            this.time_index = time_index;
            this.loss_index = BreakageWeight * breakage_index + TimeWeight * time_index;
        }

        //Métodos
        public void Print()
        {
            Console.WriteLine("Trabajador {0} en {1}: rotura = {2}, tiempo = {3}, " +
                "pérdida = {4}", worker.ToString(), process_product.ToString(),
                breakage_index, time_index, loss_index);
        }

        public new string ToString()
        {
            return worker.GetFullName() + " con proc. por prod. " + process_product.id;
        }
    }
}
