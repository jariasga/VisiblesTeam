﻿using System;
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

        public Move(List<int> solution, int worker1, int worker2)
        {
            this.worker1 = new Tuple<int, int>(worker1, solution[worker1]);
            this.worker2 = new Tuple<int, int>(worker2, solution[worker2]);
        }
    }
}
