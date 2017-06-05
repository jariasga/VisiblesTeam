using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    class Ratio
    {
        private int id_report;
        private DateTime date;
        private int id_worker;
        private int id_job; //Puesto de trabajo = Proceso x Producto
        private int id_recipe;
        private TimeSpan start;
        private TimeSpan end;
        private int broken;
        private int produced;
        private double breakage;
        private double time;

        public int ID
        {
            get { return id_report; }
        }
        public DateTime Date
        {
            get { return date; }
            //set { date = value; }
        }
        public int Worker
        {
            get { return id_worker; }
            //set { id_worker = value; }
        }
        public int Job
        {
            get { return id_job; }
            //set { id_job = value; }
        }
        public int Recipe
        {
            get { return id_recipe; }
            //set { id_recipe = value; }
        }
        public TimeSpan Start
        {
            get { return start; }
            set { start = value; }
        }
        public TimeSpan End
        {
            get { return end; }
            set { end = value; }
        }
        public int Broken
        {
            get { return broken; }
            set { broken = value; }
        }
        public int Produced
        {
            get { return produced; }
            set { produced = value; }
        }
        private double Breakage
        {
            get { return breakage; }
            set { breakage = value; }
        }
        private double Time
        {
            get { return time; }
            set { time = value; }
        }

        public Ratio(int id_report, DateTime date, int id_worker, int id_job, int id_recipe, TimeSpan start, TimeSpan end,
            int broken, int produced, double breakage, double time)
        {
            this.id_report = id_report;
            this.date = date;
            this.id_worker = id_worker;
            this.id_job = id_job;
            this.id_recipe = id_recipe;
            this.start = start;
            this.end = end;
            this.broken = broken;
            this.produced = produced;
            this.breakage = breakage;
            this.time = time;
        }

        public void Insert()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO inkaart.\"Ratio\"(date, id_worker, id_job, id_recipe, " +
                "start, end, broken, produced, breakage, time) VALUES(:date, :id_worker, :id_job, :id_recipe, " +
                ":start, :end, :broken, :produced, :breakage, :time)", connection);

            command.Parameters.AddWithValue("date", NpgsqlDbType.Date, date);
            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, id_worker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, id_job);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, id_recipe);
            command.Parameters.AddWithValue("start", NpgsqlDbType.Time, start);
            command.Parameters.AddWithValue("end", NpgsqlDbType.Time, end);
            command.Parameters.AddWithValue("broken", NpgsqlDbType.Integer, broken);
            command.Parameters.AddWithValue("produced", NpgsqlDbType.Integer, produced);
            command.Parameters.AddWithValue("breakage", NpgsqlDbType.Double, breakage);
            command.Parameters.AddWithValue("time", NpgsqlDbType.Double, time);
            command.Prepare();

            this.id_report = (int)command.ExecuteScalar();
            connection.Close();
        }

        public void Update(DateTime date, int id_worker, int id_job, int id_recipe, TimeSpan start, TimeSpan end,
            int broken, int produced, double breakage, double time)
        {
            this.id_worker = id_worker;
            this.id_job = id_job;
            this.id_recipe = id_recipe;
            this.start = start;
            this.end = end;
            this.broken = broken;
            this.produced = produced;
            this.breakage = breakage;
            this.time = time;

            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("UPDATE inkaart.\"Ratio\" SET date = :date, id_worker = :id_worker, "
                + "id_job = :id_job, id_recipe = :id_recipe, start = :start, end = :end, broken = :broken, " +
                "produced = :produced WHERE id_report = :id_report", connection);

            command.Parameters.AddWithValue("date", NpgsqlDbType.Date, date);
            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, id_worker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, id_job);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, id_recipe);
            command.Parameters.AddWithValue("start", NpgsqlDbType.Time, start);
            command.Parameters.AddWithValue("end", NpgsqlDbType.Time, end);
            command.Parameters.AddWithValue("broken", NpgsqlDbType.Integer, broken);
            command.Parameters.AddWithValue("produced", NpgsqlDbType.Integer, produced);
            command.Parameters.AddWithValue("breakage", NpgsqlDbType.Double, breakage);
            command.Parameters.AddWithValue("time", NpgsqlDbType.Double, time);
            command.Parameters.AddWithValue("id_report", NpgsqlDbType.Integer, id_report);  

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("UPDATE inkaart.\"Ratio\" SET status = :status " + 
                "WHERE id_report = :id_report", connection);

            command.Parameters.AddWithValue("status", NpgsqlDbType.Boolean, false);
            command.Parameters.AddWithValue("id_report", NpgsqlDbType.Integer, id_report);

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
