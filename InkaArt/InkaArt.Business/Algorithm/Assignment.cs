﻿using InkaArt.Data.Algorithm;
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

        private int total_miniturns; //Total de miniturnos de un día

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
            this.total_miniturns = total_miniturns;
            this.assignment_lines = new AssignmentLine[number_of_workers, this.total_miniturns];
            this.huacos_produced = 0;
            this.huamanga_produced = 0;
            this.altarpiece_produced = 0;
        }

        public void AddAssignmentLines(List<AssignmentLine> assignment_lines, WorkerController selected_workers)
        {
            throw new NotImplementedException();
        }

        public bool IsWorkerFull(Worker worker, List<AssignmentLine> temp_assignment_lines, WorkerController selected_workers)
        {
            int worker_index = selected_workers.GetIndex(worker.ID), assigned_miniturns = 0;

            for (int i = 0; i < total_miniturns && assignment_lines[worker_index, i] != null; i++)
                assigned_miniturns++;
            for (int i = 0; i < temp_assignment_lines.Count; i++)
                if (temp_assignment_lines[i].Worker.ID == worker.ID) assigned_miniturns += temp_assignment_lines[i].TotalMiniturnsUsed;

            return (assigned_miniturns >= total_miniturns);
        }
    }
}