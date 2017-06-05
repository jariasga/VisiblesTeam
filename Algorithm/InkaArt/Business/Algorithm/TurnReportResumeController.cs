using InkaArt.Data.Algorithm;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Algorithm
{
    class TurnReportResumeController
    {
        private List<TurnReportResume> turn_report_resumes;

        public TurnReportResumeController()
        {
            turn_report_resumes = new List<TurnReportResume>();
        }

        public void Load()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"TurnReportResume\" WHERE status = 1 " +
                "ORDER BY id_resume ASC", connection);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_index = reader.GetInt32(0);
                int id_worker = reader.GetInt32(1);
                int id_job = reader.GetInt32(2);
                int id_recipe = reader.GetInt32(3);
                double average_breakage = reader.GetDouble(4);
                double average_time = reader.GetDouble(5);
                TurnReportResume turn_report_resume = new TurnReportResume(id_index, id_worker, id_job, id_recipe,
                    average_breakage, average_time);
                turn_report_resumes.Add(turn_report_resume);
            }

            connection.Close();
        }

        public TurnReportResume GetByID(int id_resume)
        {
            foreach (TurnReportResume turn_report_resume in turn_report_resumes)
                if (turn_report_resume.ID == id_resume) return turn_report_resume;
            return null;
        }

        public TurnReportResume this[int index]
        {
            get { return turn_report_resumes[index]; }
        }

    }
}
