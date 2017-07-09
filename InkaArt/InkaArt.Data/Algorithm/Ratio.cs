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
        private Worker worker;
        private Job job; //Puesto de trabajo = Proceso x Producto
        private Recipe recipe;

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
        }
        public Worker Worker
        {
            get { return worker; }
        }
        public Job Job
        {
            get { return job; }
        }
        public Recipe Recipe
        {
            get { return recipe; }
        }
        public TimeSpan Start
        {
            get { return start; }
            //set { start = value; }
        }
        public TimeSpan End
        {
            get { return end; }
            //set { end = value; }
        }
        public int Broken
        {
            get { return broken; }
            //set { broken = value; }
        }
        public int Produced
        {
            get { return produced; }
            //set { produced = value; }
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
        public int FinalProduced
        {
            get { return produced-broken; }
        }

        public Ratio (Ratio old_ratio)
        {
            this.id_ratio = old_ratio.id_ratio;
            this.date = old_ratio.date;
            this.worker = old_ratio.worker;
            this.job = old_ratio.job;
            this.recipe = old_ratio.recipe;
            this.start = old_ratio.start;
            this.end = old_ratio.end;
            this.broken = old_ratio.broken;
            this.produced = old_ratio.produced;
            this.breakage = old_ratio.breakage;
            this.time = old_ratio.time;
        }


        public Ratio (int id_ratio, DateTime date, Worker worker, Job job, Recipe recipe, TimeSpan start, TimeSpan end,
            int broken, int produced, double breakage, double time)
        {
            this.id_ratio = id_ratio;
            this.date = date;
            this.worker = worker;
            this.job = job;
            this.recipe = recipe;
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
            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, worker.ID);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, job.ID);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, recipe.ID);
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
            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, this.worker.ID);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, this.job.ID);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, this.recipe.ID);
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

            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, worker.ID);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, job.ID);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, recipe.ID);
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

            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, worker.ID);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, job.ID);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, recipe.ID);
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
