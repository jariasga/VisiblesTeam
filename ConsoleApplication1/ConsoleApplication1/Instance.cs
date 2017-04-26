using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Instance
    {
        public int num_workers;
        public List<Worker> workers;        
        public int num_processes;        
        public string[] processes_names;
        public int[] processes_positions;
        public int[] processes_assignments;
        public int painting_positions;
        public int baking_positions;
        public int carving_positions;

        public Instance(int painting, int baking, int carving)
        {
            num_processes = 4; // incluye al no asignado
            processes_positions = new int[num_processes];
            processes_positions[0] = carving;
            processes_positions[1] = painting;
            processes_positions[2] = baking;
            processes_assignments = new int[num_processes];
            processes_assignments[0] = 0;
            processes_assignments[1] = 0;
            processes_assignments[2] = 0;
            processes_assignments[3] = 0;
            processes_names = new string[num_processes];
            processes_names[0] = "Tallado";
            processes_names[1] = "Pintado";
            processes_names[2] = "Horneado";
            processes_names[3] = "No asignado";

            workers = Worker.read("Workers.csv");
            Worker.readRatios("Ratios.csv", workers);
            num_workers = workers.Count;
        }

        public bool isAvailable(int process)
        {
            if (process == 3) return false;
            return processes_positions[process] > processes_assignments[process];
        }

        public bool hasAvailablePositions()
        {
            return processes_positions.Sum() > processes_assignments.Sum();
        }

        public void assignWorker(int process)
        {
            processes_assignments[process]++;
        }

        public void print()
        {
            Console.WriteLine("Pintado: " + painting_positions);
            Console.WriteLine("Horneado: " + baking_positions);
            Console.WriteLine("Tallado: " + carving_positions);
            foreach (Worker worker in workers)
            {
                worker.print();
            }
            Console.WriteLine();
        }
    }
}
