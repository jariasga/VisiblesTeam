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
        public int TabuIterations
        {
            get { return tabu_iterations; }
            set { tabu_iterations = value; }
        }
        public int HuacosProduced
        {
            get { return huacos_produced; }
            set { huacos_produced = value; }
        }
        public int HuamangaProduced
        {
            get { return huamanga_produced; }
            set { huamanga_produced = value; }
        }
        public int AltarpieceProduced
        {
            get { return altarpiece_produced; }
            set { altarpiece_produced = value; }
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
            this.assignment_lines = new AssignmentLine[selected_workers.NumberOfWorkers, total_miniturns];
            this.huacos_produced = 0;
            this.huamanga_produced = 0;
            this.altarpiece_produced = 0;
            this.selected_workers = selected_workers;
        }
        
        public Assignment(Assignment assignment)
        {
            this.date = assignment.date;
            this.objective_function_value = assignment.objective_function_value;
            this.selected_workers = assignment.selected_workers;
            this.assignment_lines = (AssignmentLine[,]) assignment.assignment_lines.Clone();
            this.huacos_produced = assignment.huacos_produced;
            this.huamanga_produced = assignment.huamanga_produced;
            this.altarpiece_produced = assignment.altarpiece_produced;
        }

        public int getProcessId(int worker_index, Simulation simulation)
        {
            for (int i = 0; i < simulation.TotalMiniturns; i++)
                if (assignment_lines[worker_index, i] != null) return assignment_lines[worker_index, i].Job.Process;
            return -1;
        }

        public int getProductId(int worker, int miniturn)
        {
            if (assignment_lines[worker, miniturn] != null) return assignment_lines[worker, miniturn].Job.Product;
            return -1;
        }

        public List<AssignmentLine> toList(Simulation simulation)
        {
            List<AssignmentLine> list = new List<AssignmentLine>();

            for (int worker = 0; worker < selected_workers.NumberOfWorkers; worker++)
            {
                AssignmentLine current_line = null;
                for (int miniturn = 0; miniturn < simulation.TotalMiniturns; miniturn++)
                {
                    if (current_line != null && current_line.Equals(assignment_lines[worker, miniturn])) continue;
                    list.Add(assignment_lines[worker, miniturn]);
                    current_line = assignment_lines[worker, miniturn];
                }
            }

            return list;
        }

        public void save(Simulation simulation, NpgsqlConnection connection)
        {
            NpgsqlCommand command = new NpgsqlCommand("insert into inkaart.\"Assignment\" " + 
                "(tabu_iterations, objective_function_value, huamanga_produced, huacos_produced, altarpiece_produced, date, assigned_workers) " +
                "values (:id_simulation, :tabu_iterations, :objective_function_value, :huamanga_produced, :huacos_produced, :altarpiece_produced, :date, :assigned_workers) " +
                "returning inkaart.\"Assignment\".id_assignment", connection);

            command.Parameters.Add(new NpgsqlParameter("tabu_iterations", this.tabu_iterations));
            command.Parameters.Add(new NpgsqlParameter("objective_function_value", this.objective_function_value));
            command.Parameters.Add(new NpgsqlParameter("huamanga_produced", this.huamanga_produced));
            command.Parameters.Add(new NpgsqlParameter("huacos_produced", this.huacos_produced));
            command.Parameters.Add(new NpgsqlParameter("altarpiece_produced", this.altarpiece_produced));
            command.Parameters.Add(new NpgsqlParameter("date", this.date));
            command.Parameters.Add(new NpgsqlParameter("assigned_workers", this.selected_workers.NumberOfWorkers));

            int id_assginment = int.Parse(command.ExecuteScalar().ToString());

            foreach(AssignmentLine line in this.toList(simulation))
                line.save(id_assginment,connection);
        }
    }
}
