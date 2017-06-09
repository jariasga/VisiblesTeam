using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    class TabuMove
    {
        // cada tupla contiene: <worker_id, item_id>
        // tipo de movimiento (de esto dependera que el item sea producto o proceso)
        //  = 0: proceso
        //  > 0: producto
        private int type; // 
        private Tuple<int, int> worker1;
        private Tuple<int, int> worker2;

        public TabuMove()
        {
            this.worker1 = null;
            this.worker2 = null;
        }

        public TabuMove(int type, Assignment[][] solution, int worker1, int worker2)
        {
            this.type = type;
            // process
            if (type == 0)
            {
                this.worker1 = new Tuple<int, int>(worker1, solution[worker1][0].Job.Process);
                this.worker2 = new Tuple<int, int>(worker2, solution[worker2][0].Job.Process);
            }
            // product 
            else
            {
                this.worker1 = new Tuple<int, int>(worker1, solution[worker1][type].Recipe.Product);
                this.worker2 = new Tuple<int, int>(worker2, solution[worker2][type].Recipe.Product);
            }

        }

        public void print()
        {
            Console.WriteLine("Move!");
            Console.WriteLine("worker1: " + worker1.Item1.ToString() + " - " + worker1.Item2.ToString());
            Console.WriteLine("worker2: " + worker2.Item1.ToString() + " - " + worker2.Item2.ToString());
        }
    }
}
