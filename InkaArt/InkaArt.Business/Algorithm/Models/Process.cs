using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    class Process
    {
        private int id_process;
        private string description;
        private int position_count;
        private int number_of_jobs;

        public int ID
        {
            get { return id_process; }
        }
        public string Description
        {
            get { return description; }
        }
        public int PositionCount
        {
            get { return position_count; }
        }
        public int NumberOfJobs
        {
            get { return number_of_jobs; }
        }

        public Process(int id_process, string description, int position_count)
        {
            this.id_process = id_process;
            this.description = description;
            this.position_count = position_count;
        }
    }
}
