using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using Npgsql;
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
        private int tabu_iterations;

        private int huacos_produced;
        private int huamanga_produced;
        private int altarpiece_produced;
		
        private int total_miniturns; //Total de miniturnos de un día
        private WorkerController selected_workers;
        
        public DateTime Date
        {
            get { return date; }
        }

        public double ObjectiveFunction
        {
            get { return objective_function_value; }
            set { objective_function_value = value; }
        }

        public int TotalMiniturns
        {
            get { return total_miniturns; }
        }

        public int TabuIterations
        {
            get
            {
                return tabu_iterations;
            }

            set
            {
                tabu_iterations = value;
            }
        }
        
        public int Huacos_produced
        {
            get
            {
                return huacos_produced;
            }

            set
            {
                huacos_produced = value;
            }
        }

        public int Huamanga_produced
        {
            get
            {
                return huamanga_produced;
            }

            set
            {
                huamanga_produced = value;
            }
        }

        public int Altarpiece_produced
        {
            get
            {
                return altarpiece_produced;
            }

            set
            {
                altarpiece_produced = value;
            }
        }

        public AssignmentLine this[int worker_index, int miniturn_index]
        {
            get { return this.assignment_lines[worker_index, miniturn_index]; }
            set { this.assignment_lines[worker_index, miniturn_index] = value; }
        }
        
        public Assignment(DateTime date, WorkerController selected_workers, int total_miniturns)
        {
            this.date = date;
            this.objective_function_value = 0;
            this.total_miniturns = total_miniturns;
            this.assignment_lines = new AssignmentLine[selected_workers.NumberOfWorkers, this.total_miniturns];
            this.huacos_produced = 0;
            this.huamanga_produced = 0;
            this.altarpiece_produced = 0;
            this.selected_workers = selected_workers;
        }
        
        public Assignment(Assignment assignment)
        {
            this.date = assignment.date;
            this.objective_function_value = assignment.objective_function_value;
            this.total_miniturns = assignment.total_miniturns;
            this.selected_workers = assignment.selected_workers;
            this.assignment_lines = (AssignmentLine[,]) assignment.assignment_lines.Clone();

            this.huacos_produced = assignment.huacos_produced;
            this.huamanga_produced = assignment.huamanga_produced;
            this.altarpiece_produced = assignment.altarpiece_produced;
        }

        public int getProcessId(int worker_index)
        {
            int id = -1;

            for(int i = 0; i < total_miniturns; i++)
            {
                if (assignment_lines[worker_index, i] != null)
                    return assignment_lines[worker_index, i].Job.Process;
            }

            return id;
        }

        public int getProductId(int worker, int miniturn)
        {
            int id = -1;

            if (assignment_lines[worker, miniturn] != null)
                return assignment_lines[worker, miniturn].Job.Product;

            return id;
        }

        public bool IsWorkerFull(Worker worker, List<AssignmentLine> temp_assignment_lines)
        {
            int worker_index = selected_workers.GetIndex(worker.ID), assigned_miniturns = 0;

            for (int i = 0; i < total_miniturns && assignment_lines[worker_index, i] != null; i++)
                assigned_miniturns++;
            for (int i = 0; i < temp_assignment_lines.Count; i++)
                if (temp_assignment_lines[i].Worker.ID == worker.ID) assigned_miniturns += temp_assignment_lines[i].TotalMiniturnsUsed;

            return (assigned_miniturns >= total_miniturns);
        }
		
        public AssignmentLine GetNextAssignmentLine(Index chosen_candidate)
        {
            int worker_index = selected_workers.GetIndex(chosen_candidate.Worker.ID), next_miniturn;

            for (next_miniturn = 0; next_miniturn < total_miniturns && assignment_lines[worker_index, next_miniturn] != null; next_miniturn++) ;
            if (next_miniturn >= total_miniturns) return null;

            int total_miniturns_used = total_miniturns - next_miniturn;
            int products = Convert.ToInt32(Math.Truncate(total_miniturns_used * Simulation.MiniturnLength / chosen_candidate.AverageTime));
            
            return new AssignmentLine(chosen_candidate, next_miniturn, total_miniturns_used, products);
        }

        public List<AssignmentLine> toList()
        {
            List<AssignmentLine> list = new List<AssignmentLine>();

            for(int worker = 0; worker < this.selected_workers.NumberOfWorkers; worker++)
            {
                for (int miniturn = 0; miniturn < this.total_miniturns; miniturn++)
                {
                    if (assignment_lines[worker, miniturn] == null) continue;

                    AssignmentLine assignment = assignment_lines[worker, miniturn];
                    // agrupamos
                    list.Add(assignment);
                }                    
            }

            return list;
        }

        public void save(int id_simulation, NpgsqlConnection connection)
        {
            NpgsqlCommand command = new NpgsqlCommand("insert into inkaart.\"Assignment\" " + 
                "(id_simulation, tabu_iterations, objective_function_value, huamanga_produced, huacos_produced, altarpiece_produced, date, assigned_workers) " +
                "values (:id_simulation, :tabu_iterations, :objective_function_value, :huamanga_produced, :huacos_produced, :altarpiece_produced, :date, :assigned_workers) " +
                "returning inkaart.\"Assignment\".id_assignment", connection);

            command.Parameters.Add(new NpgsqlParameter("id_simulation", id_simulation));
            command.Parameters.Add(new NpgsqlParameter("tabu_iterations", this.tabu_iterations));
            command.Parameters.Add(new NpgsqlParameter("objective_function_value", this.objective_function_value));
            command.Parameters.Add(new NpgsqlParameter("huamanga_produced", this.huamanga_produced));
            command.Parameters.Add(new NpgsqlParameter("huacos_produced", this.huacos_produced));
            command.Parameters.Add(new NpgsqlParameter("altarpiece_produced", this.altarpiece_produced));
            command.Parameters.Add(new NpgsqlParameter("date", this.date));
            command.Parameters.Add(new NpgsqlParameter("assigned_workers", this.selected_workers.NumberOfWorkers));

            int id_assginment = int.Parse(command.ExecuteScalar().ToString());

            foreach(AssignmentLine line in this.toList())
                line.save(id_assginment,connection);
        }
    }
}
