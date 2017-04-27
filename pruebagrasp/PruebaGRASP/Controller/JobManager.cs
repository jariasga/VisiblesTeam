using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGRASP.Controller
{
    class JobManager
    {
        private List<Job> jobs;

        public JobManager()
        {
            jobs = new List<Job>();
            //Colocar por mientras en duro los datos
            jobs.Add(new Job(1, "Moldeado"));
            jobs.Add(new Job(2, "Tallado"));
            jobs.Add(new Job(3, "Pintado"));
            jobs.Add(new Job(4, "Horneado"));
        }

        public Job GetJob(int id)
        {
            for (int i = 0; i < jobs.Count; i++) {
                if (jobs[i].ID == id) return jobs[i];
            }
            return null;
        }
        
        public int NumberOfJobs()
        {
            return jobs.Count;
        }

        public Job this[int index]
        {
            get { return jobs[index]; }
        }
    }
}
