using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class Assignment
    {
        private DateTime date;
        private double objective_function_value;
        //private int tabu_iterations;
        //private int assigned_workers;
        private AssignmentLine[,] assignment_lines;
        private int[] assigned_miniturns;

        private int number_of_workers;
        private int miniturns;

        public double ObjectiveFunction
        {
            get { return objective_function_value; }
            set { objective_function_value = value; }
        }

        public Assignment(DateTime date, int number_of_workers, int miniturns)
        {
            this.date = date;
            this.objective_function_value = 0;

            this.number_of_workers = number_of_workers;
            this.miniturns = miniturns;
            this.assignment_lines = new AssignmentLine[number_of_workers, miniturns];
            this.assigned_miniturns = new int[number_of_workers];
        }

        public bool AddLine(AssignmentLine line, int worker_index, int number_of_miniturns)
        {
            for (int i = 0; i < miniturns; i++)
            {
                if (assignment_lines[worker_index, i] != null) continue;
                for (int j = i; j < number_of_miniturns; j++)
                    assignment_lines[worker_index, j] = line;
                assigned_miniturns[worker_index] += number_of_miniturns;
                return true;
            }
            return false;
        }

        public bool IsWorkerFull(int worker_index)
        {
            return (assigned_miniturns[worker_index] >= miniturns);
        }
    }
}
