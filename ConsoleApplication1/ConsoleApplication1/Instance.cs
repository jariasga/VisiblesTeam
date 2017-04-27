using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Instance
    {
        public List<Worker> workers;

        // processes
        public int processes_num;        
        public int[] processes_positions;
        
        // products
        public int product_num;
        public float[] products_weights;

        // solution
        public int[] processes_products;

        // ratios
        public int breakage_weight;
        public int time_weight;

        public Instance()
        {
            // processes
            processes_num = 4;
            processes_positions = new int[4];
            processes_positions = [10, 10, 10, 10];

            // products
            product_num = 3;
            products_weights = new float[3];
            products_weights = [1, 1, 1];

            // solution
            processes_products = new int[7];
            processes_products = [0, 10, 11, 12, 20, 21, 30];

            // ratios
            breakage_weight = 1;
            time_weight = 1;

            workers = Worker.read("Workers.csv");
            Worker.readRatios("Ratios.csv", workers);
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
