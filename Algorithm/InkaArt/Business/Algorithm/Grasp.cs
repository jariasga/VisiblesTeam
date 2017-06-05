using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Business.Production;

namespace InkaArt.Algorithm.Grasp
{
    class Grasp
    {
        WorkerController workers;
        JobController jobs;
        TurnReportController turn_reports;

        public Grasp()
        {
            workers = new WorkerController();
            workers.Load();
            jobs = new JobController();
            jobs.Load();
            turn_reports = new TurnReportController();
        }
    }
}
