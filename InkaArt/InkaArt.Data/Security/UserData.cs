using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;
using System.Data;

namespace InkaArt.Data.Security
{
    public class UserData : BD_Connector
    {        
        public NpgsqlDataAdapter userAdapter()
        {
            NpgsqlDataAdapter userAdapter = new NpgsqlDataAdapter();

            userAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"User\" WHERE username = :user;", Connection);
            userAdapter.SelectCommand.Parameters.Add(new NpgsqlParameter("user", DbType.AnsiStringFixedLength));
            userAdapter.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            
            return userAdapter;
        }

        public int insertPhoto(System.Byte[] photo, int userID)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("UPDATE \"inkaart\".\"User\" " +
                "SET photo = @photo " +
                "WHERE id_user = @id_user");
            cmd.Parameters.Add(new NpgsqlParameter("photo", NpgsqlTypes.NpgsqlDbType.Bytea));
            cmd.Parameters.Add(new NpgsqlParameter("id_user", NpgsqlTypes.NpgsqlDbType.Integer));
            cmd.Parameters[0].Direction = ParameterDirection.Input;
            cmd.Parameters[1].Direction = ParameterDirection.Input;
            cmd.Parameters[0].NpgsqlValue = photo;
            cmd.Parameters[1].NpgsqlValue = userID;
            cmd.Connection = Connection;
            try
            {
                cmd.Connection.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                closeConnection();
            }
            return 0;
        }
    }
}
