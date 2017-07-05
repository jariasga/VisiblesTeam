using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Algorithm
{
    public class Assignment
    {
        private int id_assignment;
        private DateTime date;
        private double objective_function_value;
        private AssignmentLine[,] assignment_lines;
        private List<AssignmentLine> assignment_lines_list; // para cuando se carga de la bd
        private int tabu_iterations;

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

        public int ID
        {
            get { return id_assignment; }
            set { id_assignment = value; }
        }

        public List<AssignmentLine> AssignmentLinesList
        {
            get { return assignment_lines_list; }
            set { assignment_lines_list = value; }
        }

        public AssignmentLine this[int worker_index, int miniturn_index]
        {
            get { return this.assignment_lines[worker_index, miniturn_index]; }
            set { this.assignment_lines[worker_index, miniturn_index] = value; }
        }
        
        /// <summary>
        /// Constructor utilizado en el algoritmo GRASP.
        /// </summary>
        public Assignment(DateTime date, WorkerController selected_workers, int total_miniturns)
        {
            this.date = date;
            this.objective_function_value = 0;

            this.assignment_lines = new AssignmentLine[selected_workers.NumberOfWorkers, total_miniturns];
            for (int i = 0; i < selected_workers.NumberOfWorkers; i++)
                for (int j = 0; j < total_miniturns; j++)
                    assignment_lines[i, j] = null;

            this.huacos_produced = 0;
            this.huamanga_produced = 0;
            this.altarpiece_produced = 0;
        }

        /// <summary>
        /// Constructor usado en el algoritmo Tabú para crear vecinos.
        /// </summary>
        public Assignment(Assignment assignment)
        {
            this.date = assignment.date;
            this.objective_function_value = assignment.objective_function_value;
            this.assignment_lines = (AssignmentLine[,]) assignment.assignment_lines.Clone();
            this.huacos_produced = assignment.huacos_produced;
            this.huamanga_produced = assignment.huamanga_produced;
            this.altarpiece_produced = assignment.altarpiece_produced;
        }

        /// <summary>
        /// Constructor usado en la carga desde base de datos.
        /// </summary>
        public Assignment(int id_assignment, DateTime date, double objective_function_value, int tabu_iterations, int huamanga_produced, int huacos_produced, int altarpiece_produced)
        {
            this.id_assignment = id_assignment;
            this.date = date;
            this.objective_function_value = objective_function_value;
            this.tabu_iterations = tabu_iterations;

            this.huamanga_produced = huamanga_produced;
            this.huacos_produced = huacos_produced;
            this.altarpiece_produced = altarpiece_produced;

            this.assignment_lines_list = new List<AssignmentLine>();
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

        /// <summary>
        /// Convierte la matriz de líneas de asignación a una lista de líneas de asignación.
        /// </summary>
        public List<AssignmentLine> MatrixToList(Simulation simulation)
        {
            List<AssignmentLine> list = new List<AssignmentLine>();

            for (int worker = 0; worker < simulation.SelectedWorkers.NumberOfWorkers; worker++)
            {
                AssignmentLine current_line = null;
                for (int miniturn = 0; miniturn < simulation.TotalMiniturns; miniturn++)
                {
                    AssignmentLine line = assignment_lines[worker, miniturn];
                    if (line == null || line == current_line) continue;
                    current_line = assignment_lines[worker, miniturn];
                    list.Add(current_line);
                }
            }

            return list;
        }

        public bool Insert(Simulation simulation, NpgsqlConnection connection)
        {
            string command_line = "INSERT inkaart.\"Assignment\" (id_simulation, date, objective_function_value, tabu_iterations, " +
                                                                "huamanga_produced, huacos_produced, altarpiece_produced, assigned_workers)";
            command_line += "VALUES (:id_simulation, :date, :objective_function_value, :tabu_iterations, " +
                                    ":huamanga_produced, :huacos_produced, :altarpiece_produced, :assigned_workers)";
            command_line += "RETURNING inkaart.\"Assignment\".id_assignment";
            NpgsqlCommand command = new NpgsqlCommand(command_line, connection);

            command.Parameters.Add(new NpgsqlParameter("date", this.date));
            command.Parameters.Add(new NpgsqlParameter("objective_function_value", this.objective_function_value));
            command.Parameters.Add(new NpgsqlParameter("tabu_iterations", this.tabu_iterations));
            command.Parameters.Add(new NpgsqlParameter("huamanga_produced", this.huamanga_produced));
            command.Parameters.Add(new NpgsqlParameter("huacos_produced", this.huacos_produced));
            command.Parameters.Add(new NpgsqlParameter("altarpiece_produced", this.altarpiece_produced));
            command.Parameters.Add(new NpgsqlParameter("assigned_workers", simulation.SelectedWorkers.NumberOfWorkers));
            
            int id_assginment = int.Parse(command.ExecuteScalar().ToString());

            List<AssignmentLine> assignment_lines = this.MatrixToList(simulation);
            for (int i = 0; i < assignment_lines.Count; i++)
                assignment_lines[i].Insert(connection);

            return true;
        }
    }
}
