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
        public int limit { get; set; }
        public double growth { get; set; }

        public TabuQueue(int limit, double growth)
        {
            this.limit = limit;
            this.growth = growth;
        }

        public void Enqueue(Move obj)
        {
            while (tabu.Count >= limit && tabu.Count > 0)
                tabu.Dequeue();
            tabu.Enqueue(obj);
        }

        public Move Dequeue()
        {
            if (tabu.Count > 0)
                return tabu.Dequeue();
            return null;
        }

        public bool Contains(Move obj)
        {
            return tabu.Contains(obj);
        }

        public void Clear()
        {
            tabu.Clear();
        }

        public void Decrease()
        {
            if (ConsoleApplication1.Program.debugStatus) Console.Write("Down! " + limit.ToString());
            int new_limit = (int) (limit * (1 - growth));
            // verificamos no tener un tama;o de lista negativo
            if (new_limit > 0)
            {
                // desencolamos los elementos que no entran en el nuevo limite
                while (new_limit < tabu.Count)
                    Dequeue();
                // actualizamos
                limit = (int)(limit * (1 - growth));
                if (ConsoleApplication1.Program.debugStatus) Console.Write(" " + limit);
            }
            if (ConsoleApplication1.Program.debugStatus) Console.WriteLine();
        }

        public void Increase()
        {
            if (ConsoleApplication1.Program.debugStatus) Console.Write("Up! " + limit.ToString());
            if (limit * (1 + growth) <= int.MaxValue)
            {
                // evitamos que se estanque cuando el largo es 1 y aproximamos al mayor valor
                double diff = limit*growth;
                if (diff < 1) diff = 1;
                limit = limit + (int) diff;
                if (ConsoleApplication1.Program.debugStatus) Console.Write(" " + limit);                
            }
            if (ConsoleApplication1.Program.debugStatus) Console.WriteLine();
        }

        public int Count()
        {
            return tabu.Count();
        }

        public void print()
        {
            foreach (Move move in tabu)
                move.print();
        }
    }
}
