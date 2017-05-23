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
            userAdapter.SelectCommand.Parameters[0].SourceColumn = "username";

            /*
             *
             * TEST PHASE - QUERIES UPDATE / DELETE / INSERTED HAVE NOT BEEN TESTED - USE AT YOUR OWN RISK
             * 
             */
            //  INSERT STATEMENT - SQL QUERY FOR NPGSQL
            userAdapter.InsertCommand = new NpgsqlCommand("INSERT INTO inkaart.\"User\" (description, status, username, password) VALUES(:description, :status, :username, :password);", Connection);

            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("description", DbType.AnsiStringFixedLength));
            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("status", DbType.Int32));
            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("username", DbType.AnsiStringFixedLength));
            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("password", DbType.AnsiStringFixedLength));

            userAdapter.InsertCommand.Parameters[0].Direction = ParameterDirection.Input;
            userAdapter.InsertCommand.Parameters[1].Direction = ParameterDirection.Input;
            userAdapter.InsertCommand.Parameters[2].Direction = ParameterDirection.Input;
            userAdapter.InsertCommand.Parameters[3].Direction = ParameterDirection.Input;

            userAdapter.InsertCommand.Parameters[0].SourceColumn = "description";
            userAdapter.InsertCommand.Parameters[1].SourceColumn = "status";
            userAdapter.InsertCommand.Parameters[2].SourceColumn = "username";
            userAdapter.InsertCommand.Parameters[3].SourceColumn = "password";

            //  UPDATE STATEMENT - SQL QUERY FOR NPGSQL
            userAdapter.UpdateCommand = new NpgsqlCommand("UPDATE inkaart.\"User\" SET description = :description, status = :status, username = :username, password = :password WHERE idUser = :idUser;", Connection);

            userAdapter.UpdateCommand.Parameters.Add(new NpgsqlParameter("description", DbType.AnsiStringFixedLength));
            userAdapter.UpdateCommand.Parameters.Add(new NpgsqlParameter("status", DbType.Int32));
            userAdapter.UpdateCommand.Parameters.Add(new NpgsqlParameter("username", DbType.AnsiStringFixedLength));
            userAdapter.UpdateCommand.Parameters.Add(new NpgsqlParameter("password", DbType.AnsiStringFixedLength));

            userAdapter.UpdateCommand.Parameters[0].Direction = ParameterDirection.Input;
            userAdapter.UpdateCommand.Parameters[1].Direction = ParameterDirection.Input;
            userAdapter.UpdateCommand.Parameters[2].Direction = ParameterDirection.Input;
            userAdapter.UpdateCommand.Parameters[3].Direction = ParameterDirection.Input;

            userAdapter.UpdateCommand.Parameters[0].SourceColumn = "description";
            userAdapter.UpdateCommand.Parameters[1].SourceColumn = "status";
            userAdapter.UpdateCommand.Parameters[2].SourceColumn = "username";
            userAdapter.UpdateCommand.Parameters[3].SourceColumn = "password";

            //  DELETE STATEMENT - SQL QUERY FOR NPGSQL
            userAdapter.DeleteCommand = new NpgsqlCommand("DELETE FROM inkaart.\"User\" WHERE idUser = :idUser;", Connection);

            userAdapter.DeleteCommand.Parameters.Add(new NpgsqlParameter("idUser", DbType.Int32));

            userAdapter.DeleteCommand.Parameters[0].Direction = ParameterDirection.Input;

            userAdapter.DeleteCommand.Parameters[0].SourceColumn = "idUser";

            return userAdapter;
        }
    }
}
