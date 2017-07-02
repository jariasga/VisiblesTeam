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

        private double average_time;
        private double loss_value;

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
        public double LossValue
        {
            get { return loss_value; }
        }

        public AssignmentLine(Index index, int miniturn_start, int miniturns_used, int produced)
        {
            this.worker = index.Worker;
            this.recipe = index.Recipe;
            this.job = index.Job;
            this.average_time = index.AverageTime;
            this.loss_value = index.LossIndex;
            this.miniturn_start = miniturn_start;
            this.produced = produced;
            this.miniturns_used = miniturns_used;
        }

        public AssignmentLine(Worker worker, Job job, Recipe recipe, int produced, int miniturns_used)
        {
            this.worker = worker;
            this.job = job;
            this.recipe = recipe;
            this.produced = produced;
            this.miniturns_used = miniturns_used;
        }

        public bool Equals(AssignmentLine other)
        {
            if (this == null || other == null || this.worker == null || other.worker == null || this.job == null || other.job == null
                || this.recipe == null || other.recipe == null) return false;
            
            return (this.worker.ID == other.worker.ID && this.job.ID == other.job.ID && this.recipe.ID == other.recipe.ID &&
                this.miniturn_start == other.miniturn_start && this.miniturns_used == other.miniturns_used
                && this.produced == other.produced);
        }

        public void save(int id_assignment, NpgsqlConnection connection)
        {
            NpgsqlCommand command = new NpgsqlCommand("insert into inkaart.\"AssignmentLine\" " +
                "(id_assignment, id_worker, id_job, id_recipe, produced, total_miniturns) " +
                "values (:id_assignment, :id_worker, :id_job, :id_recipe, :produced, :total_miniturns)", connection);

            command.Parameters.Add(new NpgsqlParameter("id_assignment", id_assignment));
            command.Parameters.Add(new NpgsqlParameter("id_worker", this.Worker.ID));
            command.Parameters.Add(new NpgsqlParameter("id_job", this.Job.ID));
            command.Parameters.Add(new NpgsqlParameter("id_recipe", this.Recipe.ID));
            command.Parameters.Add(new NpgsqlParameter("produced", this.Produced));
            command.Parameters.Add(new NpgsqlParameter("total_miniturns", this.MiniturnsUsed));

            command.ExecuteNonQuery();
        }

        public void calculateProduced(int miniturn_length, double average_time, double average_breakage)
        {
            double attempts = miniturns_used * miniturn_length / average_time;
            produced = Convert.ToInt32(Math.Truncate(attempts * (1 - average_breakage)));
        }
    }
}
