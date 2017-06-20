using InkaArt.Data.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class AssignmentLine
    {
        private DateTime date;
        private Worker worker;
        private Recipe recipe;
        private Job job;         //Proceso por producto

        private int miniturn_start;
        private int total_miniturns_used;
        private int produced;    //Cantidad producida

        public Worker Worker
        {
            get { return worker; }
            set { worker = value; }
        }
        public Job Job
        {
            get { return job; }
            set { job = value; }
        }
        public Recipe Recipe
        {
            get { return recipe; }
            set { recipe = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int TotalMiniturnsUsed
        {
            get { return total_miniturns_used; }
            set { total_miniturns_used = value; }
        }
        public int Produced
        {
            get { return produced; }
            set { produced = value; }
        }

        public AssignmentLine(Worker worker, Recipe recipe, Job job)
        {
            this.Worker = worker;
            this.Recipe = recipe;
            this.Job = job;
        }

        public AssignmentLine(DateTime date, Worker worker, Recipe recipe, Job job, int miniturn_start, int total_miniturns_used)
        {
            this.date = date;
            this.worker = worker;
            this.recipe = recipe;
            this.job = job;
            this.miniturn_start = miniturn_start;
            this.total_miniturns_used = total_miniturns_used;
        }
    }
}
