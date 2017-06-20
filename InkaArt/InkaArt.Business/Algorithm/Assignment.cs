using InkaArt.Data.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Algorithm
{
    public class Assignment
    {
        private DateTime date;
        private double objective_function_value;
        private AssignmentLine[,] assignment_lines;

        private int huacos_produced;
        private int huamanga_produced;
        private int altarpiece_produced;

        public DateTime Date
        {
            get { return date; }
        }
        public double ObjectiveFunction
        {
            get { return objective_function_value; }
            set { objective_function_value = value; }
        }

        public Assignment(DateTime date, int number_of_workers, int total_miniturns)
        {
            this.date = date;
            this.objective_function_value = 0;
            this.assignment_lines = new AssignmentLine[number_of_workers, total_miniturns];

            this.huacos_produced = 0;
            this.huamanga_produced = 0;
            this.altarpiece_produced = 0;
        }

        //FALTAN DOS FUNCIONES
    }
}
