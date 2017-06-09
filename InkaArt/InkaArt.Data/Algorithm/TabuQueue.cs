using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class TabuQueue
    {
        Queue<TabuMove> tabu = new Queue<TabuMove>();
        public int limit { get; set; }
        public double growth { get; set; }

        public TabuQueue(int limit, double growth)
        {
            this.limit = limit;
            this.growth = growth;
        }

        public void Enqueue(TabuMove obj)
        {
            while (tabu.Count >= limit && tabu.Count > 0)
                tabu.Dequeue();
            tabu.Enqueue(obj);
        }

        public TabuMove Dequeue()
        {
            if (tabu.Count > 0)
                return tabu.Dequeue();
            return null;
        }

        public bool Contains(TabuMove obj)
        {
            return tabu.Contains(obj);
        }

        public void Clear()
        {
            tabu.Clear();
        }

        public void Decrease()
        {
            int new_limit = (int)(limit * (1 - growth));
            // verificamos no tener un tama;o de lista negativo
            if (new_limit > 0)
            {
                // desencolamos los elementos que no entran en el nuevo limite
                while (new_limit < tabu.Count)
                    Dequeue();
                // actualizamos
                limit = (int)(limit * (1 - growth));
            }
        }

        public void Increase()
        {
            if (limit * (1 + growth) <= int.MaxValue)
            {
                // evitamos que se estanque cuando el largo es 1 y aproximamos al mayor valor
                double diff = limit * growth;
                if (diff < 1) diff = 1;
                limit = limit + (int)diff;
            }
        }

        public int Count()
        {
            return tabu.Count();
        }

        public void print()
        {
            foreach (TabuMove move in tabu)
                move.print();
        }

    }
}
