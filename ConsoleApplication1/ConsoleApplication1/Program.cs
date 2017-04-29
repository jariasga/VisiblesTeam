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

            /* tabu
            TabuSearch tabu = new TabuSearch(instance);
            List<int> tabu_solution = tabu.run();*/

            /*genetic*/
            GeneticAlgorithm genetic = new GeneticAlgorithm(instance);
            genetic.CreateFirstGen();
            List<int> genetic_solution = genetic.RunGenetic();
            for (int i = 0; i < genetic_solution.Count(); i++)
                Console.Write(genetic_solution[i] + ", ");
            Console.WriteLine();

            double fitness = instance.getFitness(genetic_solution);
            Console.WriteLine("Fitness de la solucion final " + fitness);

            Console.Read();
        }
    }
}
