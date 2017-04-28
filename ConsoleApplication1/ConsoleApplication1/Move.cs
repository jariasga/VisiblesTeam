using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Move
    {
        public Tuple<int, int> worker1;
        public Tuple<int, int> worker2;

        public Move()
        {
            this.worker1 = null;
            this.worker2 = null;
        }

        public void setWorker(int worker_num, int worker_id, int worker_pp)
        {
            if (worker_num == 1) 
                this.worker1 = new Tuple<int, int>(worker_id, worker_pp);
            else if (worker_num == 2)
                this.worker2 = new Tuple<int, int>(worker_id, worker_pp);
        }

    }
}
