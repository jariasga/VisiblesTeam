using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Worker
    {
        public string name;
        public string lastname;
        public List<Ratio> ratios;

        public Worker(string name, string lastname)
        {
            ratios = new List<Ratio>();
            this.name = name;
            this.lastname = lastname;
        }

        public string getFullName()
        {
            return name + " " + lastname;
        }
        
    }
}
