using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class Index
    {
        private int worker_id;
        private int job_id;
        private double breakage;
        private double time;

        public int WorkerId
        {
            get
            {
                return worker_id;
            }

            set
            {
                worker_id = value;
            }
        }

        public int JobId
        {
            get
            {
                return job_id;
            }

            set
            {
                job_id = value;
            }
        }

        public double Breakage
        {
            get
            {
                return breakage;
            }

            set
            {
                breakage = value;
            }
        }

        public double Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public static Predicate<Index> byWorkerAndJob(Worker worker, Job job)
        {
            return delegate (Index index)
            {
                if (worker == null || job == null)
                    return false;
                return index.worker_id.Equals(worker.ID) && index.job_id.Equals(job.ID);
            };
        }
    }
}
