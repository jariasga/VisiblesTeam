using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Process
    {
        public int id;
        public string name;
        public int number_jobs; 

        public Process(int id, string name, int number_jobs)
        {
            this.id = id;
            this.name = name;
            this.number_jobs = number_jobs;
        }
    }
}
