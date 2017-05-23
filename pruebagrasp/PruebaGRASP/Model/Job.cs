using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGRASP
{
    class Job
    {
        private int id;
        private string job;
        private int workstations;

        public int ID
        {
            get { return id; }
        }

        public string JobName
        {
            get { return job; }
        }

        public int NumberOfWorkstations
        {
            get { return workstations; }
            set { workstations = value; }
        }

        public Job(int id, string job)
        {
            this.id = id;
            this.job = job;
            this.workstations = 0;
        }

        public Job(int id, string job, int workstations)
        {
            this.id = id;
            this.job = job;
            this.workstations = workstations;
        }
    }
}
