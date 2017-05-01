using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Model
{
    class Process
    {
        //Atributos
        public int id;
        public string name;
        public int number_of_jobs;

        //Constructor
        public Process(int id, string name, int number_of_jobs)
        {
            this.id = id;
            this.name = name;
            this.number_of_jobs = number_of_jobs;
        }

        //Métodos
        public void Print()
        {
            Console.WriteLine("Proceso #{0}: {1} (# trabajos = {2})", this.id, this.name,
                this.number_of_jobs);
        }

        public new string ToString()
        {
            return name + " (id " + id + ")";
        }
    }
}
