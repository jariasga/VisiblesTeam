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
    class RatioController
    {
        List<Ratio> turn_reports;

        public RatioController()
        {
            turn_reports = new List<Ratio>();
        }

        public void Load(DateTime date)
        {
            turn_reports.Clear();

            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Ratio\" WHERE date = :date "
                + "ORDER BY id_report ASC", connection);

            command.Parameters.AddWithValue("date", NpgsqlDbType.Date, date);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_report = reader.GetInt32(0);
                int id_worker = reader.GetInt32(2);
                int id_job = reader.GetInt32(3);
                int id_recipe = reader.GetInt32(4);
                TimeSpan start = reader.GetTimeSpan(5);
                TimeSpan end = reader.GetTimeSpan(6);
                int broken = reader.GetInt32(7);
                int produced = reader.GetInt32(8);
                double breakage = reader.GetDouble(9);
                double time = reader.GetDouble(10);

                turn_reports.Add(new Ratio(id_report, date, id_worker, id_job, id_recipe, start, end, broken,
                    produced, breakage, time));
            }

            connection.Close();
        }

        public void Insert(int id_worker, DateTime date, int id_job, int id_recipe, TimeSpan start, TimeSpan end,
            int broken, int produced)
        {
            Ratio turn_report = new Ratio(0, date, id_worker, id_job, id_recipe, start, end, broken, produced,
                broken / produced, (end - start).Minutes / produced);
            turn_reports.Add(turn_report);
            turn_report.Insert();

            //Actualizar resumen de reportes

        }

        public void Update(int id_report, DateTime date, int id_worker, int id_job, int id_recipe, TimeSpan start, TimeSpan end,
            int broken, int produced)
        {
            Ratio turn_report = GetById(id_report);
            turn_report.Update(date, id_worker, id_job, id_recipe, start, end, broken, produced, broken / produced,
                (end - start).Minutes / produced);

            //Actualizar resumen de reportes

        }

        public void Delete(int id_report)
        {
            Ratio turn_report = GetById(id_report);
            turn_report.Delete();

            //Actualizar resumen de reportes

        }

        public Ratio GetById(int id)
        {
            for (int i = 0; i < turn_reports.Count; i++)
                if (turn_reports[i].ID == id) return turn_reports[i];
            return null;
        }

        public Ratio this[int index]
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
