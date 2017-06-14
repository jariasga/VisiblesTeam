using InkaArt.Classes;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class Index
    {
        private int id_index;
        private int id_worker;
        private int id_job;
        private int id_recipe;
        private double average_breakage;
        private double average_time;
        private double breakage_index;
        private double time_index;
        private double loss_index;

        public int ID
        {
            get { return id_index; }
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
        public double BreakageIndex
        {
            get { return breakage_index; }
            set { breakage_index = value; }
        }
        public double TimeIndex
        {
            get { return time_index; }
            set { time_index = value; }
        }
        public double LossIndex
        {
            get { return loss_index; }
            set { time_index = value; }
        }

        public Index(int id_index, int id_worker, int id_job, int id_recipe, double average_breakage,
            double average_time)
        {
            this.id_index = id_index;
            this.id_worker = id_worker;
            this.id_job = id_job;
            this.id_recipe = id_recipe;
            this.average_breakage = average_breakage;
            this.average_time = average_time;
        }

        public static string Insert(Ratio ratio)
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand(
                "INSERT INTO inkaart.\"Index\"(id_worker, id_job, id_recipe, average_breakage, average_time) " +
                "VALUES(:id_worker, :id_job, :id_recipe, :average_breakage, :average_time) RETURNING id_index",
                connection);

            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, ratio.Worker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, ratio.Job);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, ratio.Recipe);
            command.Parameters.AddWithValue("average_breakage", NpgsqlDbType.Double, ratio.Breakage);
            command.Parameters.AddWithValue("average_time", NpgsqlDbType.Double, ratio.Time);

            int id_index = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            if (id_index <= 0) return "Hubo un error al insertar el índice. ";
            return "Se insertó el índice correctamente. ";
        }

        /****************************** FUNCIONES PARA INDEX CONTROLLER ******************************/

        public static string Update(Ratio ratio, double average_breakage, double average_time)
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand(
                "UPDATE inkaart.\"Index\" SET average_breakage = :average_breakage, average_time = :average_time " +
                "WHERE id_worker = :id_worker AND id_job = :id_job AND id_recipe = :id_recipe", connection);

            command.Parameters.AddWithValue("average_breakage", NpgsqlDbType.Double, average_breakage);
            command.Parameters.AddWithValue("average_time", NpgsqlDbType.Double, average_time);
            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, ratio.Worker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, ratio.Job);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, ratio.Recipe);

            int rows_affected = command.ExecuteNonQuery();
            connection.Close();

            if (rows_affected <= 0) return "No se actualizó ningun índice. ";
            if (rows_affected == 1) return "Se actualizó el índice correctamente. ";
            return "Se encontró más de un índice para actualizar. Hay que chequear la base de datos para verificar que " +
                "no haya sucedido nada malo. ";
        }

        public static string Delete(Ratio ratio)
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("UPDATE inkaart.\"Index\" SET status = :status " +
                "WHERE id_worker = :id_worker AND id_job = :id_job AND id_recipe = :id_recipe", connection);

            command.Parameters.AddWithValue("status", NpgsqlDbType.Boolean, false);
            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, ratio.Worker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, ratio.Job);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, ratio.Recipe);

            int rows_affected = command.ExecuteNonQuery();
            connection.Close();

            if (rows_affected <= 0) return "No se eliminó ningun índice. ";
            if (rows_affected == 1) return "El índice se eliminó correctamente. ";
            return "Se encontró más de un índice para eliminar. Hay que chequear la base de datos para verificar que " +
                "no haya sucedido nada malo. ";
        }

        /*********************************** ASIGNACIÓN DE TRABAJADORES ***********************************/

        public void CalculateIndexes(double average_breakage_mean, double average_time_mean, double breakage_weight,
            double time_weight, double product_weight)
        {
            breakage_index = average_breakage / average_breakage_mean;
            time_index = average_time / average_time_mean;
            loss_index = (breakage_index * breakage_weight + time_index * time_weight) / product_weight;
        }

        public double CostValue(double objective_function_value, int iteration)
        {
            return (this.loss_index - objective_function_value) / (iteration + 1);
        }
    }
}
