using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class Index
    {
        private int id_resume;
        private int id_worker;
        private int id_job;
        private int id_recipe;
        private double average_breakage;
        private double average_time;
        private double breakage_index;
        private double time_index;

        public int ID
        {
            get { return id_resume; }
        }
        public int Worker
        {
            get { return id_worker; }
        }
        public int Job
        {
            get { return id_job; }
        }
        public int Recipe
        {
            get { return id_recipe; }
        }
        public double AverageBreakage
        {
            get { return average_breakage; }
            set { average_breakage = value; }
        }
        public double AverageTime
        {
            get { return average_time; }
            set { average_time = value; }
        }
        public double BreakageIndex
        {
            get { return breakage_index; }
            set { breakage_index = value; }
        }
        public double TimeIndex
        {
            get { return time_index; }
            set { time_index = value; }
        }

        public Index(int id_resume, int id_worker, int id_job, int id_recipe, double average_breakage,
            double average_time)
        {
            this.id_resume = id_resume;
            this.id_worker = id_worker;
            this.id_job = id_job;
            this.id_recipe = id_recipe;
            this.average_breakage = average_breakage;
            this.average_time = average_time;
        }

        public static Predicate<Index> byWorkerAndJob(Worker worker, Job job)
        {
            return delegate (Index index)
            {
                if (worker == null || job == null) return false;
                return index.id_worker.Equals(worker.ID) && index.id_job.Equals(job.ID);
            };
        }
    }
}
