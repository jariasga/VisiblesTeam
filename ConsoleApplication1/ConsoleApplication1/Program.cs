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
        static void Main(string[] args)
        {
            /* todo esto debe repetirse 30 veces con 30 entradas distintas*/
            // for(int i = 0; i < 30; i++){

            Instance instance = new Instance("Workers_60.csv", "Ratios_60.csv");

            /* GRASP */
            Console.WriteLine("  GRASP running ....");
            Grasp grasp = new Grasp("Workers_60.csv", "Ratios_60.csv");
            List<int[]> solutions = grasp.GraspAlgorithm();

            /* Tabu */
            //List<int> initial_solution = instance.getBestSolution(solutions);
            Console.WriteLine("  TABU running ....");
            List<int> initial_solution = instance.getInitialSolution();
            TabuSearch tabu = new TabuSearch(instance);

            tabu.run(initial_solution);

            tabu.print();                
            List<int> production = instance.getProduction(tabu.best_solution);
            instance.printProduction(production);
            
            /* Genetic */
            Console.WriteLine("  GENETIC running ....");
            GeneticAlgorithm genetic = new GeneticAlgorithm(instance);
            genetic.CreateFirstGen(solutions);
            List<int> genetic_solution = genetic.RunGenetic();
            for (int i = 0; i < genetic_solution.Count(); i++)
                Console.Write(genetic_solution[i] + ", ");
            Console.WriteLine();
            Console.WriteLine("Fitness de la mejor solucion: " + instance.getFitness(genetic_solution));

            //List<int> production = instance.getProduction(genetic_solution);
            //instance.printProduction(production);

            Console.Read();
        }
    }
}
