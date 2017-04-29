﻿using System;
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

            // tabu
            TabuSearch tabu = new TabuSearch(instance);
            List<int> tabu_solution = tabu.run();

            foreach(int i in tabu_solution)
            {
                Console.WriteLine(i);
            }

            Console.Read();
        }
    }
}
