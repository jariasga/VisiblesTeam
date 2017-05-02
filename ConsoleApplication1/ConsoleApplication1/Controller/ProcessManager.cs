using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Model;

namespace InkaArt.Controller
{
    class ProcessManager
    {
        private List<Process> processes;

        public ProcessManager()
        {
            processes = new List<Process>();
            //Carga en duro
            processes.Add(new Process(1, "Moldeado", 10));
            processes.Add(new Process(2, "Tallado", 10));
            processes.Add(new Process(3, "Horneado", 10));
            processes.Add(new Process(4, "Pintado", 10));
        }

        public Process GetByID(int id)
        {
            for (int i = 0; i < processes.Count; i++)
            {
                if (processes[i].id == id) return processes[i];
            }
            return null;
        }

        public int NumberOfProcesses()
        {
            return processes.Count;
        }

        public Process this[int index]
        {
            get { return processes[index]; }
        }

        public void Print()
        {
            for (int i = 0; i < processes.Count; i++)
            {
                Console.Write("Proceso {0}: ", i + 1);
                processes[i].Print();
            }
        }
    }
}
