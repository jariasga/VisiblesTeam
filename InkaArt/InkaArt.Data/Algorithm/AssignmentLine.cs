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

        private TimeSpan start_time;
        private TimeSpan end_time;

        private int total_miniturns;
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
        public int TotalMiniturns
        {
            get { return total_miniturns; }
            set { total_miniturns = value; }
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

        public AssignmentLine(DateTime date, Worker worker, Recipe recipe, Job job, int total_miniturns)
        {
            this.date = date;
            this.worker = worker;
            this.recipe = recipe;
            this.job = job;
            this.total_miniturns = total_miniturns;
        }
    }
}
