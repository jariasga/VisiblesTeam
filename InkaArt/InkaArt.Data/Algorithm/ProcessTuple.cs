using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class ProcessTuple
    {
        private int id_process;
        private int number_of_jobs;

        public int ID
        {
            get { return id_process; }
        }
        public int NumberOfJobs
        {
            get { return number_of_jobs; }
            set { number_of_jobs = value; }
        }

        public ProcessTuple(int id_process, int number_of_jobs)
        {
            this.id_process = id_process;
            this.number_of_jobs = number_of_jobs;
        }
    }
}
