using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Model
{
    class Worker
    {
        public int id;
        public string name;
        public string lastname;

        public Worker(int id, string name, string lastname)
        {
            this.id = id;
            this.name = name;
            this.lastname = lastname;
        }
        
        public string GetFullName()
        {
            return name + " " + lastname;
        }

        public void Print()
        {
            Console.WriteLine("{0} (id {1})", this.GetFullName(), this.id);
        }
    }
}
