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

        public double ObjectiveFunction
        {
            get { return objective_function_value; }
            set { objective_function_value = value; }
        }

        public Assignment(DateTime date, int number_of_workers, int miniturns)
        {
            this.date = date;
            this.objective_function_value = 0;
            this.assignment_lines = new AssignmentLine[number_of_workers, miniturns];
        }


    }
}
