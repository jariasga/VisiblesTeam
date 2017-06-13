using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Algorithm
{
    public class RatioPerDayController
    {
        private JobController jobs;

        public RatioPerDayController()
        {
            this.jobs = new JobController();
            this.jobs.Load();
        }

        public string InsertOrUpdate(Ratio ratio)
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(id_ratioperday) FROM inkaart.\"RatioPerDay\" " +
                "WHERE date = :date AND id_product = :id_product", connection);

            command.Parameters.AddWithValue("date", NpgsqlDbType.Date, ratio.Date);
            command.Parameters.AddWithValue("id_product", NpgsqlDbType.Integer, jobs.GetByID(ratio.Job).Product);

            int count_date = Convert.ToInt32(command.ExecuteScalar());

            //Dependiendo del valor de este contador, se insertará o actualizará la tabla RatioPerDay
            if (count_date <= 0)
            {
                command.CommandText = "INSERT INTO inkaart.\"RatioPerDay\"(date, id_product, produced)" +
                    "VALUES (:date, :id_product, :produced)";
                command.Parameters.AddWithValue("produced", NpgsqlDbType.Integer, ratio.Produced);

                int rows_affected = command.ExecuteNonQuery();
                connection.Close();

                if (rows_affected <= 0) return "Error al intentar insertar en la tabla de ratios por día. ";
                return "Se insertó la fila con éxito en la tabla de ratios por día. ";
            }
            else
            {
                command.CommandText = "UPDATE inkaart.\"RatioPerDay\" SET produced = produced + :produced " +
                    "WHERE date = :date AND id_product = :id_product";
                command.Parameters.AddWithValue("produced", NpgsqlDbType.Integer, ratio.Produced);

                int rows_affected = command.ExecuteNonQuery();
                connection.Close();

                if (rows_affected <= 0) return "Error al intentar actualizar en la tabla de ratios por día. ";
                return "Se actualizó la fila con éxito en la tabla de ratios por día. ";
            }
        }

        public string UpdateOrDelete(Ratio ratio)
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("UPDATE inkaart.\"RatioPerDay\" SET produced = produced - :produced " +
                    "WHERE date = :date AND id_product = :id_product", connection);

            command.Parameters.AddWithValue("produced", NpgsqlDbType.Integer, ratio.Produced);
            command.Parameters.AddWithValue("date", NpgsqlDbType.Date, ratio.Date);
            command.Parameters.AddWithValue("id_product", NpgsqlDbType.Integer, jobs.GetByID(ratio.Job).Product);

            int rows_affected = command.ExecuteNonQuery();
            connection.Close();

            if (rows_affected <= 0) return "Error al intentar actualizar o eliminar en la tabla de ratios por día. ";
            return "Se actualizó o eliminó (soft) la fila con éxito en la tabla de ratios por día. ";
        }
    }
}
