using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Common;
using InkaArt.Data.Algorithm;

namespace InkaArt.Business.Algorithm
{
    class RatioResumeController
    {
        private List<RatioResume> resumes;

        public RatioResumeController()
        {
            resumes = new List<RatioResume>();
        }

        public void Load()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"RatioResume\" WHERE status = 1 " +
                "ORDER BY id_resume ASC", connection);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_resume = reader.GetInt32(0);
                int id_worker = reader.GetInt32(1);
                int id_job = reader.GetInt32(2);
                int id_recipe = reader.GetInt32(3);
                double average_breakage = reader.GetDouble(4);
                double average_time = reader.GetDouble(5);
                RatioResume turn_report_resume = new RatioResume(id_resume, id_worker, id_job, id_recipe,
                    average_breakage, average_time);
                resumes.Add(turn_report_resume);
            }

            connection.Close();
        }

        public void Insert(Ratio ratio)
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO inkaart.\"RatioResume\"(id_worker, id_job, "
                    + "id_recipe, average_breakage, average_time) VALUES(:id_worker, :id_job, :id_recipe, "
                    + ":average_breakage, :average_time)", connection);

            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, ratio.Worker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, ratio.Job);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, ratio.Recipe);
            command.Parameters.AddWithValue("average_breakage", NpgsqlDbType.Double, ratio.Breakage);
            command.Parameters.AddWithValue("average_time", NpgsqlDbType.Double, ratio.Time);

            command.ExecuteScalar();
            connection.Close();
        }

        public void Update(Ratio ratio, double average_breakage, double average_time)
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("UPDATE inkaart.\"RatioResume\" SET " +
                "average_breakage = :average_breakage, average_time = :average_time WHERE " +
                "id_worker = :id_worker, id_job = :id_job, id_recipe = :id_recipe", connection);

            command.Parameters.AddWithValue("average_breakage", NpgsqlDbType.Double, ratio.Breakage);
            command.Parameters.AddWithValue("average_time", NpgsqlDbType.Double, ratio.Time);
            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, ratio.Worker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, ratio.Job);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, ratio.Recipe);

            command.ExecuteScalar();
            connection.Close();
        }


        public RatioResume GetByID(int id_resume)
        {
            foreach (RatioResume resume in resumes)
                if (resume.ID == id_resume) return resume;
            return null;
        }

        public RatioResume this[int index]
        {
            get { return resumes[index]; }
        }
    }
}
