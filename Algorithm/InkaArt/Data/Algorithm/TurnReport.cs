using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Production
{
    class TurnReport
    {
        private int idReport;
        private DateTime date;
        private int idWorker;
        private int id_job; //Puesto de trabajo = Proceso x Producto
        private int idRecipe;
        private TimeSpan start;
        private TimeSpan end;
        private int broken;
        private int produced;
        private double breakage;
        private double time;

        public int ID
        {
            get { return idReport; }
        }
        public DateTime Date
        {
            get { return date; }
            //set { date = value; }
        }
        public int Worker
        {
            get { return idWorker; }
            //set { idWorker = value; }
        }
        public int Job
        {
            get { return id_job; }
            //set { id_job = value; }
        }
        public int Recipe
        {
            get { return idRecipe; }
            //set { idRecipe = value; }
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

        public TurnReport(int idReport, DateTime date, int idWorker, int id_job, int idRecipe, TimeSpan start, TimeSpan end,
            int broken, int produced, double breakage, double time)
        {
            this.idReport = idReport;
            this.date = date;
            this.idWorker = idWorker;
            this.id_job = id_job;
            this.idRecipe = idRecipe;
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

            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO TurnReport2(date, idWorker, id_job, idRecipe, " +
                "start, end, broken, produced, breakage, time) VALUES(:date, :idWorker, :id_job, :idRecipe, " +
                ":start, :end, :broken, :produced, :breakage, :time)", connection);

            command.Parameters.AddWithValue("date", NpgsqlDbType.Date, date);
            command.Parameters.AddWithValue("idWorker", NpgsqlDbType.Integer, idWorker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, id_job);
            command.Parameters.AddWithValue("idRecipe", NpgsqlDbType.Integer, idRecipe);
            command.Parameters.AddWithValue("start", NpgsqlDbType.Time, start);
            command.Parameters.AddWithValue("end", NpgsqlDbType.Time, end);
            command.Parameters.AddWithValue("broken", NpgsqlDbType.Integer, broken);
            command.Parameters.AddWithValue("produced", NpgsqlDbType.Integer, produced);
            command.Parameters.AddWithValue("breakage", NpgsqlDbType.Double, breakage);
            command.Parameters.AddWithValue("time", NpgsqlDbType.Double, time);
            command.Prepare();

            this.idReport = (int)command.ExecuteScalar();
            connection.Close();
        }

        public void Update(DateTime date, int idWorker, int id_job, int idRecipe, TimeSpan start, TimeSpan end,
            int broken, int produced, double breakage, double time)
        {
            this.idWorker = idWorker;
            this.id_job = id_job;
            this.idRecipe = idRecipe;
            this.start = start;
            this.end = end;
            this.broken = broken;
            this.produced = produced;
            this.breakage = breakage;
            this.time = time;

            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("UPDATE TurnReport2 SET date = :date, idWorker = :idWorker, "
                + "id_job = :id_job, idRecipe = :idRecipe, start = :start, end = :end, broken = :broken, " +
                "produced = :produced WHERE idReport = :idReport", connection);

            command.Parameters.AddWithValue("date", NpgsqlDbType.Date, date);
            command.Parameters.AddWithValue("idWorker", NpgsqlDbType.Integer, idWorker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, id_job);
            command.Parameters.AddWithValue("idRecipe", NpgsqlDbType.Integer, idRecipe);
            command.Parameters.AddWithValue("start", NpgsqlDbType.Time, start);
            command.Parameters.AddWithValue("end", NpgsqlDbType.Time, end);
            command.Parameters.AddWithValue("broken", NpgsqlDbType.Integer, broken);
            command.Parameters.AddWithValue("produced", NpgsqlDbType.Integer, produced);
            command.Parameters.AddWithValue("breakage", NpgsqlDbType.Double, breakage);
            command.Parameters.AddWithValue("time", NpgsqlDbType.Double, time);
            command.Parameters.AddWithValue("idReport", NpgsqlDbType.Integer, idReport);  

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("DELETE FROM TurnReport2 WHERE idReport = :idReport", connection);

            command.Parameters.AddWithValue("idReport", NpgsqlDbType.Integer, idReport);

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
