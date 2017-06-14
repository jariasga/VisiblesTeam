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
        private int miniturn;
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
        public int Miniturn
        {
            get { return miniturn; }
            set { miniturn = value; }
        }

        public AssignmentLine(Worker worker, Recipe recipe, Job job)
        {
            this.Worker = worker;
            this.Recipe = recipe;
            this.Job = job;
        }

    }
}
