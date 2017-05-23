using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGRASP
{
    class GraspOutput
    {
        public Worker worker;
        public Job job;

        public GraspOutput(Worker worker)
        {
            this.worker = worker;
            this.job = null;
        }

        public GraspOutput(Worker worker, Job job)
        {
            this.worker = worker;
            this.job = job;
        }
    }
}
