using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Model
{
    class Worker
    {
        //Atributos
        public int id;
        public string name;
        public string lastname;

        //Constructor
        public Worker(int id, string name, string lastname)
        {
            this.id = id;
            this.name = name;
            this.lastname = lastname;
        }
        
        //Métodos
        public string GetFullName()
        {
            return name + " " + lastname;
        }

        public void Print()
        {
            Console.WriteLine("Trabajador #{0}: {1}", this.id, this.GetFullName());
        }

        public new string ToString()
        {
            return GetFullName() + " (id " + id + ")";
        }
    }
}
