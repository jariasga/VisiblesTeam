using Npgsql;
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
        private List<RatioResume> turn_report_resumes;

        public RatioResumeController()
        {
            turn_report_resumes = new List<RatioResume>();
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
                turn_report_resumes.Add(turn_report_resume);
            }

            connection.Close();
        }

        public RatioResume GetByID(int id_resume)
        {
            foreach (RatioResume turn_report_resume in turn_report_resumes)
                if (turn_report_resume.ID == id_resume) return turn_report_resume;
            return null;
        }

        public RatioResume this[int index]
        {
            get { return turn_report_resumes[index]; }
        }

    }
}
