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

        public RatioPerDayController(JobController jobs)
        {
            this.jobs = jobs;
        }

        public string InsertOrUpdate(Ratio ratio)
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(id_ratioperday) FROM inkaart.\"RatioPerDay\" " +
                "WHERE date = :date AND id_product = :id_product", connection);

            command.Parameters.AddWithValue("date", NpgsqlDbType.Date, ratio.Date);
            command.Parameters.AddWithValue("id_product", NpgsqlDbType.Integer, ratio.Job.Product);

            int count_date = Convert.ToInt32(command.ExecuteScalar());

            //Dependiendo del valor de este contador, se insertará o actualizará la tabla RatioPerDay
            if (count_date <= 0)
            {
                // RatioPerDay
                command.CommandText = "INSERT INTO inkaart.\"RatioPerDay\"(date, id_product, produced)" +
                    "VALUES (:date, :id_product, :produced) RETURNING id_ratioperday";
                command.Parameters.AddWithValue("produced", NpgsqlDbType.Integer, ratio.FinalProduced);
                int id_ratioperday = Convert.ToInt32(command.ExecuteScalar());

                if (id_ratioperday <= 0) return "Error al intentar insertar en la tabla de ratios por día. ";

                // Obtenemos id_lote
                command.CommandText = "SELECT id_lote FROM inkaart.\"RatioPerDay\" " +
                "WHERE id_ratioperday = :id_ratioperday";
                command.Parameters.AddWithValue("id_ratioperday", NpgsqlDbType.Integer, id_ratioperday);
                int id_lote = Convert.ToInt32(command.ExecuteScalar());

                if (id_lote <= 0) return "Error al intentar consultar la tabla de ratios por día. ";

                // StockDocument                
                command.CommandText = "INSERT INTO inkaart.\"StockDocument\"  " +
                    "(\"idDocument\", \"documentType\", \"product_id\",\"product_stock\") " +
                    "VALUES (:id_lote, 'LOTE', :id_product, :produced)";
                command.Parameters.AddWithValue("id_lote", NpgsqlDbType.Integer, id_lote);
                int rows_affected = command.ExecuteNonQuery();

                connection.Close();

                if (rows_affected <= 0) return "Error al intentar insertar en la tabla de lotes. ";
                return "Se insertó la fila con éxito en la tabla de ratios por día. ";
            }
            else
            {
                // RatioPerDay
                command.CommandText = "UPDATE inkaart.\"RatioPerDay\" SET produced = produced + :produced " +
                    "WHERE date = :date AND id_product = :id_product RETURNING id_lote";
                command.Parameters.AddWithValue("produced", NpgsqlDbType.Integer, ratio.FinalProduced);
                object result = command.ExecuteScalar();

                if (result == null) return "Error al intentar actualizar en la tabla de ratios por día. ";

                // StockDocument
                int id_lote = (int) result;
                command.CommandText = "UPDATE inkaart.\"StockDocument\" SET product_stock = product_stock + :produced " +
                    "WHERE \"idDocument\" = :id_lote AND product_id = :id_product";
                command.Parameters.AddWithValue("id_lote", NpgsqlDbType.Integer, id_lote);
                int rows_affected = command.ExecuteNonQuery();

                connection.Close();

                if (rows_affected <= 0) return "Error al intentar actualizar en la tabla de lotes. ";
                return "Se actualizó la fila con éxito en la tabla de ratios por día. ";
            }
        }

        public string UpdateOrDelete(Ratio ratio)
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("UPDATE inkaart.\"RatioPerDay\" SET produced = produced - :produced " +
                    "WHERE date = :date AND id_product = :id_product RETURNING id_lote", connection);
                
            command.Parameters.AddWithValue("produced", NpgsqlDbType.Integer, ratio.FinalProduced);
            command.Parameters.AddWithValue("date", NpgsqlDbType.Date, ratio.Date);
            command.Parameters.AddWithValue("id_product", NpgsqlDbType.Integer, ratio.Job.Product);
            int id_lote = Convert.ToInt32(command.ExecuteScalar());

            if (id_lote <= 0) return "Error al intentar actualizar o eliminar en la tabla de ratios por día. ";

            command.CommandText = "UPDATE inkaart.\"StockDocument\" SET product_stock = product_stock - :produced " +
                "WHERE \"idDocument\" = :id_lote AND product_id = :id_product";
            command.Parameters.AddWithValue("id_lote", NpgsqlDbType.Integer, id_lote);
            int rows_affected = command.ExecuteNonQuery();

            connection.Close();

            if (rows_affected <= 0) return "Error al intentar actualizar o eliminar en la tabla de lotes. ";
            return "Se actualizó o eliminó (soft) la fila con éxito en la tabla de ratios por día. ";
        }
    }
}
