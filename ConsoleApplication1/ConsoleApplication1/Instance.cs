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
        public int painting_positions;
        public int baking_positions;
        public int carving_positions;

        public Instance(int painting, int baking, int carving)
        {
            this.painting_positions = painting;
            this.baking_positions = baking;
            this.carving_positions = carving;

            this.workers = Worker.read("Workers.csv");
            Worker.readRatios("Ratios.csv", workers);
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
