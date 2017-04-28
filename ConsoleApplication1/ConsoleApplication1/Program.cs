using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Instance instance = new Instance();

            int[] l = new int[3];
            Console.WriteLine(l[0]);
            Console.WriteLine("no");

            // tabu
            TabuSearch tabu = new TabuSearch(instance);
            tabu.run();

            Console.Read();
        }
    }
}
