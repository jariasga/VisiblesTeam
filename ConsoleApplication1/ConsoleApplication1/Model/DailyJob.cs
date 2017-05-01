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
        public Worker Worker {
            get { return worker; }
            //set { worker = value; }
        }
        private Job job;
        public Job Job {
            get { return job; }
            //set { job = value; }
        }
        private DateTime date;
        public DateTime Date {
            get { return date; }
            //set { date = value; }
        }
        
        //Datos de entrada
        private int amount_produced;
        public int AmountProduced {
            get { return amount_produced; }
            //set { amount_produced = value; }
        }

        private int amount_broken;
        public int AmountBroken {
            get { return amount_broken; }
            //set { amount_broken = value; }
        }

        private int total_time;
        public int TotalTime {
            get { return total_time; }
            //set { total_time = value; }
        }

        //Datos derivados

        private double breakage;
        public double Breakage {
            get { return breakage; }
            //set { breakage = value; }
        }

        private double time_product;
        public double TimePerProduct {
            get { return time_product; }
            //set { time_product = value; }
        }

        //Constructores

        public DailyJob(Worker worker, Job job, DateTime date, int amount_produced,
            int amount_broken, int total_time)
        {
            this.worker = worker;
            this.job = job;
            this.date = date;
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
                worker.GetFullName(), job.ToString(), amount_produced, amount_broken, total_time);
            Console.WriteLine("Rotura = {0}, Tiempo por producto = {1}.", breakage, time_product);
        }
    }
}
