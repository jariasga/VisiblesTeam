using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Data.Algorithm;

namespace InkaArt.Business.Algorithm
{
    class Temp_SolutionList
    {
        private List<Temp_Solution> solutions;
        private int number_of_workers;

        public Temp_SolutionList(int number_of_workers)
        {
            this.solutions = new List<Temp_Solution>();
            this.number_of_workers = number_of_workers;
        }

        public void Add(Temp_Solution solution)
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

        public void PrintTemp_SolutionList(List<int[]> solution_list)
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

                /*for (int j = 1; j <= 3; j++)
                {
                    int sum = solution_list[i].Count(value => (value >= 10*j) &&
                    ( value < (10+10*j)));
                    int quotient = sum / ((j == 1) ? 3 : (j == 2) ? 1 : 2);
                    int residue = sum % ((j == 1) ? 3 : (j == 2) ? 1 : 2);
                    Console.WriteLine("Producto {0} tiene en total {1} procesos, de los cuales "
                        + "{2} están terminados y {3} sin terminar.", j, sum, quotient, residue);
                }*/

                PrintProcessesCount(solution_list[i]);
            }
        }

        private void PrintProcessesCount(int[] array_list)
        {
            int moldeado = 0, tallado = 0, pintado = 0, horneado = 0, not_assigned = 0;
            for (int i = 0; i < number_of_workers; i++)
            {
                if (array_list[i] == 0) not_assigned++;
                if (array_list[i] == 10) moldeado++;
                if (array_list[i] == 20 || array_list[i] == 30) tallado++;
                if (array_list[i] == 11 || array_list[i] == 31) pintado++;
                if (array_list[i] == 12) horneado++;
            }
            Console.WriteLine("Procesos ocupados: moldeado = {0}, tallado = {1}, pintado "
                + "= {2}, horneado = {3}, sin asignar = {4}.", moldeado, tallado, pintado,
                horneado, not_assigned);
        }

    }
}
