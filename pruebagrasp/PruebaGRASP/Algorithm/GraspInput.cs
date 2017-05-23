using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGRASP
{
    class GraspInput
    {
        private Worker worker;
        private Job job;
        private Product product;
        private double index_broken;
        private double index_time;
        private double index_loss;

        public GraspInput(Worker worker, Job job, Product product)
        {
            this.worker = worker;
            this.job = job;
            this.product = product;
        }
    }
}
