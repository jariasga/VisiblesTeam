using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Classes;

namespace InkaArt.Data.Algorithm
{
    public class Ratio
    {
        private int id_ratio;
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
            get { return id_ratio; }
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
        public double Breakage
        {
            get { return breakage; }
            //set { breakage = value; }
        }
        public double Time
        {
            get { return time; }
            //set { time = value; }
        }

        public Ratio (Ratio old_ratio)
        {
            this.id_ratio = old_ratio.id_ratio;
            this.date = old_ratio.date;
            this.id_worker = old_ratio.id_worker;
            this.id_job = old_ratio.id_job;
            this.id_recipe = old_ratio.id_recipe;
            this.start = old_ratio.start;
            this.end = old_ratio.end;
            this.broken = old_ratio.broken;
            this.produced = old_ratio.produced;
            this.breakage = old_ratio.breakage;
            this.time = old_ratio.time;
        }

        public Ratio (int id_ratio, DateTime date, int id_worker, int id_job, int id_recipe, TimeSpan start, TimeSpan end,
            int broken, int produced, double breakage, double time)
        {
            this.id_ratio = id_ratio;
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

        public string Insert()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = BD_Connector.ConnectionString.ConnectionString;
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO inkaart.\"Ratio\"(date, id_worker, id_job, id_recipe, " +
                "start_time, end_time, broken, produced, breakage, time) VALUES(:date, :id_worker, :id_job, :id_recipe, " +
                ":start_time, :end_time, :broken, :produced, :breakage, :time) RETURNING id_ratio", connection);

            command.Parameters.AddWithValue("date", NpgsqlDbType.Date, date);
            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, id_worker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, id_job);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, id_recipe);
            command.Parameters.AddWithValue("start_time", NpgsqlDbType.Time, start);
            command.Parameters.AddWithValue("end_time", NpgsqlDbType.Time, end);
            command.Parameters.AddWithValue("broken", NpgsqlDbType.Integer, broken);
            command.Parameters.AddWithValue("produced", NpgsqlDbType.Integer, produced);
            command.Parameters.AddWithValue("breakage", NpgsqlDbType.Double, breakage);
            command.Parameters.AddWithValue("time", NpgsqlDbType.Double, time);

            this.id_ratio = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            if (this.id_ratio <= 0) return "Hubo un error al insertar el ratio. ";
            return "Se insertó el ratio correctamente. ";
        }

        public string Update()
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("UPDATE inkaart.\"Ratio\" SET date = :date, id_worker = :id_worker, "
                + "id_job = :id_job, id_recipe = :id_recipe, start_time = :start_time, end_time = :end_time, " +
                "broken = :broken, produced = :produced, breakage = :breakage, time = :time WHERE id_ratio = :id_ratio",
                connection);
            
            command.Parameters.AddWithValue("date", NpgsqlDbType.Date, this.date);
            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, this.id_worker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, this.id_job);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, this.id_recipe);
            command.Parameters.AddWithValue("start_time", NpgsqlDbType.Time, this.start);
            command.Parameters.AddWithValue("end_time", NpgsqlDbType.Time, this.end);
            command.Parameters.AddWithValue("broken", NpgsqlDbType.Integer, this.broken);
            command.Parameters.AddWithValue("produced", NpgsqlDbType.Integer, this.produced);
            command.Parameters.AddWithValue("breakage", NpgsqlDbType.Double, this.breakage);
            command.Parameters.AddWithValue("time", NpgsqlDbType.Double, this.time);
            command.Parameters.AddWithValue("id_ratio", NpgsqlDbType.Integer, this.id_ratio);

            int rows_affected = command.ExecuteNonQuery();
            connection.Close();

            if (rows_affected <= 0) return "No se actualizó ningun ratio. ";
            if (rows_affected == 1) return "Se actualizó el ratio correctamente. ";
            return "Se encontró más de un ratio para actualizar. Hay que chequear la base de datos para verificar que " +
                "no haya sucedido nada malo. ";
        }

        public string Delete()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = BD_Connector.ConnectionString.ConnectionString;
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("UPDATE inkaart.\"Ratio\" SET status = :status " + 
                "WHERE id_ratio = :id_ratio", connection);

            command.Parameters.AddWithValue("status", NpgsqlDbType.Boolean, false);
            command.Parameters.AddWithValue("id_ratio", NpgsqlDbType.Integer, id_ratio);

            int rows_affected = command.ExecuteNonQuery();
            connection.Close();

            if (rows_affected <= 0) return "No se eliminó ningun ratio. ";
            if (rows_affected == 1) return "El ratio se eliminó correctamente. ";
            return "Se encontró más de un ratio para eliminar. Hay que chequear la base de datos para verificar que " +
                "no haya sucedido nada malo. ";
        }

        /******************************* FUNCIONES PARA INDEX CONTROLLER *******************************/

        public int CountByWorkerJobAndRecipe()
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(id_ratio) FROM inkaart.\"Ratio\" " + 
                "WHERE id_worker = :id_worker AND id_job = :id_job AND id_recipe = :id_recipe AND status = :status",
                connection);

            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, id_worker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, id_job);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, id_recipe);
            command.Parameters.AddWithValue("status", NpgsqlDbType.Boolean, true);

            int result = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return result;
        }

        public void AverageValues(out double average_breakage, out double average_time)
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT avg(breakage) FROM inkaart.\"Ratio\" " +
                "WHERE id_worker = :id_worker AND id_job = :id_job AND id_recipe = :id_recipe AND status = :status",
                connection);

            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, id_worker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, id_job);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, id_recipe);
            command.Parameters.AddWithValue("status", NpgsqlDbType.Boolean, true);

            object temp = command.ExecuteScalar();
            average_breakage = (temp == null || temp == DBNull.Value) ? -1 : (double)temp;

            command.CommandText = "SELECT avg(time) FROM inkaart.\"Ratio\" WHERE id_worker = :id_worker AND " + 
                "id_job = :id_job AND id_recipe = :id_recipe AND status = :status";

            temp = command.ExecuteScalar();
            average_time = (temp == null || temp == DBNull.Value) ? -1 : (double)temp;

            connection.Close();
        }
    }
}
