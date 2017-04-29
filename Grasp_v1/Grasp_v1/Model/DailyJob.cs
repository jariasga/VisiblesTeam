using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Model
{
    class DailyJob
    {
        //Atributos principales
        private Worker worker;
        private int process_product_id;
        public int ProcessProduct {
            get { return process_product_id; }
        }
        private DateTime date;
        
        //Datos de entrada
        private int amount_produced;
        private int amount_broken;
        private int total_time;

        //Datos derivados

        private double breakage;
        public double Breakage {
            get { return breakage; }
        }

        private double time_product;
        public double TimePerProduct
        {
            get { return time_product; }
        }

        //Constructores

        public DailyJob(Worker worker, int process_product_id, int amount_produced,
            int amount_broken, int total_time)
        {
            this.worker = worker;
            this.process_product_id = process_product_id;
            this.amount_produced = amount_produced;
            this.amount_broken = amount_broken;
            this.total_time = total_time;
            this.breakage = amount_broken / amount_produced;
            this.time_product = total_time / amount_produced;
        }

        //Métodos
        
        public void Print()
        {
            Console.WriteLine("Trabajador {0} en {1}: producido = {2}, roto = {3}, tiempo total = {4}.",
                worker.GetFullName(), process_product_id, amount_produced, amount_broken, total_time);
            Console.WriteLine("Rotura = {0}, Tiempo por producto = {1}.", breakage, time_product);
        }
    }
}
