using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Business.Algorithm;

namespace InkaArt.Algorithm.Grasp
{
    class Grasp
    {
        WorkerController workers;
        JobController jobs;
        RatioController ratios;

        public Grasp()
        {
            workers = new WorkerController();
            workers.Load();
            jobs = new JobController();
            jobs.Load();
            ratios = new RatioController();
        }
    }
}
