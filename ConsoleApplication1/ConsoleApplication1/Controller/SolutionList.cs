using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Model;

namespace InkaArt.Controller
{
    class SolutionList
    {
        private List<Solution> solutions;
        private int number_of_workers;

        public SolutionList(int number_of_workers)
        {
            this.solutions = new List<Solution>();
            this.number_of_workers = number_of_workers;
        }

        public void Add(Solution solution)
        {
            this.solutions.Add(solution);
        }

        public List<int[]> ToArrayList()
        {
            List<int[]> array_list = new List<int[]>();
            for (int i = 0; i < solutions.Count; i++)
            {
                array_list.Add(solutions[i].ToArray(number_of_workers));
            }
            return array_list;
        }

        public void PrintSolutionList(List<int[]> solution_list)
        {
            for (int i = 0; i < solution_list.Count; i++)
            {
                Console.WriteLine("Solución GRASP #{0}: F.O. = {1}", i + 1,
                    solutions[i].ObjectiveFunctionValue);
                for (int j = 0; j < number_of_workers; j++)
                {
                    Console.Write("{0,2} ", j + 1);
                }
                Console.WriteLine();
                for (int j = 0; j < number_of_workers; j++)
                {
                    Console.Write("{0,2} ", solution_list[i][j]);
                }
                Console.WriteLine();
                for (int j = 1; j <= 3; j++)
                {
                    int sum = solution_list[i].Count(value => (value >= 10*j) &&
                    ( value < (10+10*j)));
                    Console.WriteLine("Producto {0} tiene en total {1} procesos", j, sum);
                }

            }
        }

    }
}
