using InkaArt.Data.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class Assignment
    {
        private Worker worker;
        private Recipe recipe;
        private Job job;         // recepy x process
        private DateTime date;
        private int minitun;

        public Worker Worker
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

        public Job Job
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

        public Recipe Recipe
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

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public int Minitun
        {
            get
            {
                return minitun;
            }

            set
            {
                minitun = value;
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
