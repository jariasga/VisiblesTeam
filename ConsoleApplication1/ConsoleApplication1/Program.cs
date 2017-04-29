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

            //  Tabu
            TabuSearch tabu = new TabuSearch(instance);

            List<int> tabu_solution = tabu.run();*/

            //  Genetic
            GeneticAlgorithm genetic = new GeneticAlgorithm(instance);
            genetic.CreateFirstGen();
            List<int> genetic = genetic.RunGenetic();

            Console.Read();
        }
    }
}
