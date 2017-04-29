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

            //GRASP
            Grasp grasp = new Grasp(instance);
            grasp.GraspAlgorithm();

            // tabu
            TabuSearch tabu = new TabuSearch(instance);
            tabu.run();

            Console.Read();
        }
    }
}
