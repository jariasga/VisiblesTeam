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
        private List<AssignmentLine> assignment_lines;
        private int number_of_workers;

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

        public Assignment(DateTime date)
        {
            this.date = date;
            this.objective_function_value = 0;
            this.assignment_lines = new List<AssignmentLine>();

            this.huacos_produced = 0;
            this.huamanga_produced = 0;
            this.altarpiece_produced = 0;
        }

        public void AddAssignmentLine(List<AssignmentLine> new_assignment_lines)
        {
            foreach (AssignmentLine assignment_line in new_assignment_lines)
            {
                this.assignment_lines.Add(assignment_line);
                //Si se terminó el producto, entonces colocarlo en la asignación
                if (assignment_line.Job.ID == 3) this.huacos_produced += assignment_line.Produced;
                if (assignment_line.Job.ID == 4) this.huamanga_produced += assignment_line.Produced;
                if (assignment_line.Job.ID == 6) this.altarpiece_produced += assignment_line.Produced;
            }
        }

        public bool IsWorkerFull(Worker worker)
        {
            int total_miniturns = 0;
            foreach (AssignmentLine assignment_line in assignment_lines)
                if (assignment_line.Worker.ID == worker.ID) total_miniturns += assignment_line.TotalMiniturns;

            return (total_miniturns > (worker.Turn.TotalMinutes / Simulation.MiniturnLength));
        }
    }
}
