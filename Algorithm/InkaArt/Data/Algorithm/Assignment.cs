using InkaArt.Data.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    class Assignment
    {
        private Worker worker;
        private Recipe recipe;
        private Job job;         // recepy x process
        private DateTime date;
        private int minitun;

        internal Worker Worker
        {
            get
            {
                return worker;
            }

            set
            {
                worker = value;
            }
        }

        internal Job Job
        {
            get
            {
                return job;
            }

            set
            {
                job = value;
            }
        }

        internal Recipe Recipe
        {
            get
            {
                return recipe;
            }

            set
            {
                recipe = value;
            }
        }

        public Assignment(Worker worker, Recipe recipe, Job job)
        {
            this.Worker = worker;
            this.Recipe = recipe;
            this.Job = job;
        }
    }
}
