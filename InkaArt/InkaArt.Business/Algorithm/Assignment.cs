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
            this.assignment_lines = (AssignmentLine[,])assignment.assignment_lines.Clone();
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

        /// <summary>
        /// Inserta una asignación de una simulación de asignaciones de trabajadores en la base de datos.
        /// </summary>
        public bool Insert(Simulation simulation, NpgsqlConnection connection)
        {
            string command_line = "INSERT INTO inkaart.\"Assignment\" (id_simulation, date, objective_function_value, tabu_iterations, " +
                                  "huamanga_produced, huacos_produced, altarpiece_produced, assigned_workers)";
            command_line += "VALUES (:id_simulation, :date, :objective_function_value, :tabu_iterations, " +
                                    ":huamanga_produced, :huacos_produced, :altarpiece_produced, :assigned_workers)";
            command_line += "RETURNING inkaart.\"Assignment\".id_assignment";
            NpgsqlCommand command = new NpgsqlCommand(command_line, connection);

            command.Parameters.AddWithValue("id_simulation", NpgsqlDbType.Integer, simulation.ID);
            command.Parameters.AddWithValue("date", NpgsqlDbType.Date, date);
            command.Parameters.AddWithValue("objective_function_value", NpgsqlDbType.Double, this.objective_function_value);
            command.Parameters.AddWithValue("tabu_iterations", NpgsqlDbType.Integer, this.tabu_iterations);
            command.Parameters.AddWithValue("huamanga_produced", NpgsqlDbType.Integer, this.huamanga_produced);
            command.Parameters.AddWithValue("huacos_produced", NpgsqlDbType.Integer, this.huacos_produced);
            command.Parameters.AddWithValue("altarpiece_produced", NpgsqlDbType.Integer, this.altarpiece_produced);
            command.Parameters.AddWithValue("assigned_workers", NpgsqlDbType.Integer, simulation.SelectedWorkers.NumberOfWorkers);

            object result = command.ExecuteScalar();
            this.id_assignment = Convert.ToInt32(result);

            List<AssignmentLine> assignment_lines = this.MatrixToList(simulation);
            for (int i = 0; i < assignment_lines.Count; i++)
                if (assignment_lines[i].Insert(connection, this.id_assignment) <= 0) return false;

            return true;
        }

        /// <summary>
        /// Obtiene una lista de asignaciones desde base de datos para una simulación específica.
        /// </summary>
        public static List<Assignment> Load(NpgsqlConnection connection, Simulation simulation, RecipeController recipes, JobController jobs)
        {
            List<Assignment> assignments = new List<Assignment>();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Assignment\" WHERE id_simulation = :id_simulation", connection);
            command.Parameters.AddWithValue("id_simulation", NpgsqlDbType.Integer, simulation.ID);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id_assignment = int.Parse(reader["id_assignment"].ToString());
                DateTime date = Convert.ToDateTime(reader["date"]);
                double objective_function_value = double.Parse(reader["objective_function_value"].ToString());
                int tabu_iterations = int.Parse(reader["tabu_iterations"].ToString());
                int huamanga_produced = int.Parse(reader["huamanga_produced"].ToString());
                int huacos_produced = int.Parse(reader["huacos_produced"].ToString());
                int altarpiece_produced = int.Parse(reader["altarpiece_produced"].ToString());

                Assignment assignment = new Assignment(id_assignment, date, objective_function_value, tabu_iterations, huamanga_produced,
                    huacos_produced, altarpiece_produced);

                assignments.Add(assignment);
            }
            reader.Close();

            for (int i = 0; i < assignments.Count; i++)
                assignments[i].AssignmentLinesList = LoadAssignmentLines(connection, simulation, assignments[i], recipes, jobs);

            return assignments;
        }

        private static List<AssignmentLine> LoadAssignmentLines(NpgsqlConnection connection, Simulation simulation, Assignment assignment,
            RecipeController recipes, JobController jobs)
        {
            List<AssignmentLine> assignment_lines = new List<AssignmentLine>();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"AssignmentLine\" WHERE id_assignment = :id_assignment", connection);
            command.Parameters.AddWithValue("id_assignment", NpgsqlDbType.Integer, assignment.ID);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_assignment = int.Parse(reader["id_assignment"].ToString());
                int id_worker = int.Parse(reader["id_worker"].ToString());
                int id_job = int.Parse(reader["id_job"].ToString());
                int id_recipe = int.Parse(reader["id_recipe"].ToString());
                int miniturn_start = int.Parse(reader["miniturn_start"].ToString());
                int miniturns_used = int.Parse(reader["miniturns_used"].ToString());
                int produced = int.Parse(reader["produced"].ToString());

                Worker worker = simulation.SelectedWorkers.GetByID(id_worker);
                Recipe recipe = recipes.GetByID(id_recipe);
                Job job = jobs.GetByID(id_job);
                if (worker == null || recipe == null || job == null) continue;
                AssignmentLine line = new AssignmentLine(worker, job, recipe, miniturn_start, miniturns_used, produced);
                assignment_lines.Add(line);
            }
            reader.Close();

            return assignment_lines;
        }
    }
}
