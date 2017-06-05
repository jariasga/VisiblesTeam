using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class TurnReportResume
    {
        private int id_resume;
        private int id_worker;
        private int id_job;
        private int id_recipe;
        private double average_breakage;
        private double average_time;

        public int ID
        {
            get { return id_resume; }
        }
        public int Worker
        {
            get { return id_worker; }
        }
        public int Job
        {
            get { return id_job; }
        }
        public int Recipe
        {
            get { return id_recipe; }
        }
        public double AverageBreakage
        {
            get { return average_breakage; }
            set { average_breakage = value; }
        }
        public double AverageTime
        {
            get { return average_time; }
            set { average_time = value; }
        }

        public TurnReportResume(int id_resume, int id_worker, int id_job, int id_recipe, double average_breakage,
            double average_time)
        {
            this.id_resume = id_resume;
            this.id_worker = id_worker;
            this.id_job = id_job;
            this.id_recipe = id_recipe;
            this.average_breakage = average_breakage;
            this.average_time = average_time;
        }

        public void Insert()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO TurnReportResume(id_worker, id_job, id_recipe, " +
                "average_breakage, average_time) VALUES (:id_worker, :id_job, :id_recipe, :average_breakage, " +
                ":average_time)", connection);

            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, id_worker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, id_job);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, id_recipe);
            command.Parameters.AddWithValue("average_breakage", NpgsqlDbType.Double, average_breakage);
            command.Parameters.AddWithValue("average_time", NpgsqlDbType.Double, average_time);

            this.id_resume = (int) command.ExecuteScalar();
            connection.Close();
        }

        public void Update(double averageBreakage, double averageTime, double breakageIndex, double timeIndex)
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("UPDATE inkaart.\"TurnReportResume\" SET " +
                "average_breakage = :average_breakage, average_time = :average_time WHERE " +
                "id_resume = :id_resume", connection);

            command.Parameters.AddWithValue("average_breakage", NpgsqlDbType.Double, average_breakage);
            command.Parameters.AddWithValue("average_time", NpgsqlDbType.Double, average_time);
            command.Parameters.AddWithValue("id_resume", NpgsqlDbType.Integer, id_resume);

            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public void Delete()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();
            
            connection.Close();
        }
    }
}
