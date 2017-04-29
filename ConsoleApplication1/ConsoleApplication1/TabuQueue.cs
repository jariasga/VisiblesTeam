using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class TabuQueue
    {
        Queue<Move> tabu = new Queue<Move>();

        public int Limit { get; set; }

        public TabuQueue(int limit)
        {
            Limit = limit;
        }

        public void Enqueue(Move obj)
        {
            while (tabu.Count > Limit && tabu.Count > 0)
                tabu.Dequeue();
            tabu.Enqueue(obj);
        }

        public Move Dequeue()
        {
            return tabu.Dequeue();
        }

        public bool Contains(Move obj)
        {
            return tabu.Contains(obj);
        }

        public void Clear()
        {
            tabu.Clear();
        }
    }
}
