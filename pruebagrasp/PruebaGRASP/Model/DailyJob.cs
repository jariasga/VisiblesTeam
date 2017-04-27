using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGRASP
{
    class DailyJob
    {
        private Worker worker;
        private Job job;
        private Product product;
        private DateTime date;
        private int amount_produced;
        private int amount_broken;
        private int total_time; //Tiempo total para todos los productos, en minutos
        private double index_broken;
        private double index_time;

        public Worker Worker
        {
            get { return worker; }
        }

        public Job Job
        {
            get { return job; }
        }

        public Product Product
        {
            get { return product; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int AmountProduced
        {
            get { return amount_produced; }
        }

        public int AmountBroken
        {
            get { return amount_broken; }
        }

        public int TotalTime
        {
            get { return total_time; }
        }

        public DailyJob(Worker worker, Job job, Product product, DateTime date)
        {
            this.worker = worker;
            this.job = job;
            this.product = product;
            this.date = date;
            this.amount_produced = 0;
            this.amount_broken = 0;
            this.total_time = 0;
        } 

        public DailyJob(Worker worker, Job job, Product product, DateTime date, int amount_produced,
            int amount_broken, int total_time)
        {
            this.worker = worker;
            this.job = job;
            this.product = product;
            this.date = date;
            this.amount_produced = amount_produced;
            this.amount_broken = amount_broken;
            this.total_time = total_time;
            this.index_broken = this.amount_broken / this.amount_produced;
            this.index_time = this.total_time / this.amount_produced;
        }

        public void InsertDailyJob(int amount_produced, int amount_broken, int total_time)
        {
            this.amount_produced = amount_produced;
            this.amount_broken = amount_broken;
            this.total_time = total_time;
            this.index_broken = this.amount_broken / this.amount_produced;
            this.index_time = this.total_time / this.amount_produced;
        }
    }
}
