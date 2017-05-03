using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Controller;

namespace ConsoleApplication1
{
    class Program
    {
        public static bool debugStatus = false;
        public static int test_num = 1;

        static void Main(string[] args)
        {
            for (int i = 0; i < test_num; i++)
            {
                Instance instance = new Instance("Workers.csv", "Ratios_" + i + ".csv");

                /* GRASP */
                Console.WriteLine("\tGRASP running ....");
                Grasp grasp = new Grasp("Workers.csv", "Ratios_" + i + ".csv");
                List<int[]> solutions = grasp.GraspAlgorithm();

                /* Tabu */
                Console.WriteLine("\tTABU running ....");
                List<int> initial_solution = instance.getBestSolution(solutions);
                List<int> production_grasp = instance.getProduction(initial_solution);
                instance.printProduction(production_grasp);
                TabuSearch tabu = new TabuSearch(instance);
                tabu.run(initial_solution);

                /* Genetic */
                Console.WriteLine("\tGENETIC running ....");
                GeneticAlgorithm genetic = new GeneticAlgorithm(instance);
                genetic.CreateFirstGen(solutions);
                List<int> genetic_solution = genetic.RunGenetic();
                for (int j = 0; j < genetic_solution.Count(); j++)
                    Console.Write(genetic_solution[j] + ", ");
                Console.WriteLine();
                Console.WriteLine("Fitness de la mejor solucion: " + instance.getFitness(genetic_solution));                

                instance.printResults(tabu.best_solution, genetic_solution, "Test_" + i + ".csv");
            }           

            Console.Read();
        }
    }
}
