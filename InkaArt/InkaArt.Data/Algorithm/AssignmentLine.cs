using InkaArt.Data.Algorithm;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class AssignmentLine
    {
        private Worker worker;
        private Recipe recipe;
        private Job job;         //Proceso por producto

        private int miniturn_start; //Miniturno de inicio
        private int miniturns_used; //Número de miniturnos que ocupa
        private int produced;    //Cantidad producida

        private double average_breakage;
        private double average_time;
        private double loss_index;

        public Worker Worker
        {
            get { return worker; }
            set { worker = value; }
        }

        public Job Job
        {
            get { return job; }
            set { job = value; }
        }

        public Recipe Recipe
        {
            get { return recipe; }
            set { recipe = value; }
        }

        public int MiniturnStart
        {
            get { return miniturn_start; }
            set { miniturn_start = value; }
        }

        public int MiniturnsUsed
        {
            get { return miniturns_used; }
            set { miniturns_used = value; }
        }

        public int Produced
        {
            get { return produced; }
            set { produced = value; }
        }

        public double AverageTime
        {
            get { return average_time; }
        }
        public double AverageBreakage
        {
            get { return average_breakage; }
        }
        public double LossIndex
        {
            get { return loss_index; }
        }

        /// <summary>
        /// Constructor para las líneas de asignación generadas por el algoritmo GRASP.
        /// </summary>
        public AssignmentLine(Index index, int miniturn_start, int miniturn_length, int total_miniturns)
        {
            this.worker = index.Worker;
            this.recipe = index.Recipe;
            this.job = index.Job;

            this.average_breakage = index.AverageBreakage;
            this.average_time = index.AverageTime;
            this.loss_index = index.LossIndex;

            this.miniturn_start = miniturn_start;
            this.miniturns_used = total_miniturns - miniturn_start;
            this.produced = MiniturnsToProduced(this.miniturns_used, this.average_time, miniturn_length);
        }

        /// <summary>
        /// Constructor para las líneas de asignación leídas desde la base de datos.
        /// </summary>
        public AssignmentLine(Worker worker, Job job, Recipe recipe, int miniturn_start, int miniturns_used, int produced)
        {
            this.worker = worker;
            this.job = job;
            this.recipe = recipe;

            this.average_breakage = 0;
            this.average_time = 0;
            this.loss_index = 0;

            this.miniturn_start = miniturn_start;
            this.miniturns_used = miniturns_used;
            this.produced = produced;
        }

        public int Insert(NpgsqlConnection connection)
        {
            string command_line = "INSERT INTO inkaart.\"AssignmentLine\" (id_worker, id_job, id_recipe, produced, miniturn_start, miniturns_used) ";
            command_line += "VALUES (:id_worker, :id_job, :id_recipe, :produced, :miniturn_start, :miniturns_used)";
            NpgsqlCommand command = new NpgsqlCommand(command_line, connection);

            command.Parameters.Add(new NpgsqlParameter("id_worker", this.worker.ID));
            command.Parameters.Add(new NpgsqlParameter("id_job", this.job.ID));
            command.Parameters.Add(new NpgsqlParameter("id_recipe", this.recipe.ID));
            command.Parameters.Add(new NpgsqlParameter("produced", this.produced));
            command.Parameters.Add(new NpgsqlParameter("miniturn_start", this.miniturn_start));
            command.Parameters.Add(new NpgsqlParameter("miniturns_used", this.miniturns_used));

            return command.ExecuteNonQuery();
        }
        
        /* Funciones auxiliares */

        public static int MiniturnsToProduced(int miniturns_used, double average_time, int miniturn_length)
        {
            double attempts = miniturns_used * miniturn_length / average_time;
            return Convert.ToInt32(Math.Truncate(attempts));
        }

        public static int ProducedToMiniturns(int produced, double average_time, int miniturn_length)
        {
            double miniturns = produced * average_time / miniturn_length;
            return Convert.ToInt32(Math.Ceiling(miniturns));
        }

        public override string ToString()
        {
            string worker = (this.worker == null) ? "null" : this.worker.FullName;
            string recipe = (this.recipe == null) ? "null" : this.recipe.Version;
            string job = (this.job == null) ? "null" : this.job.Name;
            return string.Format("{0},{1},{2},{3:0.0000},{4:0.0000},{5:0.0000},[{6},{7}],{8}", worker, recipe, job, average_breakage,
                average_time, loss_index, miniturn_start, miniturn_start + miniturns_used, produced);
        }
    }
}
