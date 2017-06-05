using InkaArt.Data.Production;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Production
{
    class TurnReportController
    {
        List<TurnReport> turn_reports;

        public TurnReportController()
        {
            turn_reports = new List<TurnReport>();
        }

        public void Load(DateTime date)
        {
            turn_reports.Clear();

            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"TurnReport2\" WHERE date = :date "
                + "ORDER BY idreport ASC", connection);

            command.Parameters.AddWithValue("date", NpgsqlDbType.Date, date);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int idReport = reader.GetInt32(0);
                int idWorker = reader.GetInt32(2);
                int id_job = reader.GetInt32(3);
                int idRecipe = reader.GetInt32(4);
                TimeSpan start = reader.GetTimeSpan(5);
                TimeSpan end = reader.GetTimeSpan(6);
                int broken = reader.GetInt32(7);
                int produced = reader.GetInt32(8);
                double breakage = reader.GetDouble(9);
                double time = reader.GetDouble(10);

                turn_reports.Add(new TurnReport(idReport, date, idWorker, id_job, idRecipe, start, end, broken,
                    produced, breakage, time));
            }

            connection.Close();
        }

        public void Insert(int idWorker, DateTime date, int id_job, int idRecipe, TimeSpan start, TimeSpan end,
            int broken, int produced)
        {
            TurnReport turn_report = new TurnReport(0, date, idWorker, id_job, idRecipe, start, end, broken, produced,
                broken / produced, (end - start).Minutes / produced);
            turn_reports.Add(turn_report);
            turn_report.Insert();

            //Actualizar resumen de reportes

        }

        public void Update(int idReport, DateTime date, int idWorker, int id_job, int idRecipe, TimeSpan start, TimeSpan end,
            int broken, int produced)
        {
            TurnReport turn_report = GetById(idReport);
            turn_report.Update(date, idWorker, id_job, idRecipe, start, end, broken, produced, broken / produced,
                (end - start).Minutes / produced);

            //Actualizar resumen de reportes

        }

        public void Delete(int idReport)
        {
            TurnReport turn_report = GetById(idReport);
            turn_report.Delete();

            //Actualizar resumen de reportes

        }

        public TurnReport GetById(int id)
        {
            for (int i = 0; i < turn_reports.Count; i++)
                if (turn_reports[i].ID == id) return turn_reports[i];
            return null;
        }

        public TurnReport this[int index]
        {
            get { return turn_reports[index]; }
            //set { turn_reports[index] = value; }
        }

        public int Count()
        {
            return turn_reports.Count();
        }
    }
}
