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
    public class User : BD_Connector
    {
        private NpgsqlDataAdapter userAdapter()
        {
            NpgsqlDataAdapter userAdapter = new NpgsqlDataAdapter();

            userAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Person\"", Connection);

            //  INSERT STATEMENT - SQL QUERY FOR NPGSQL
            userAdapter.InsertCommand = new NpgsqlCommand("INSERT INTO inkaart.\"Person\" (firstName, lastName, dni) VALUES(:firstName, :lastName, :dni);", Connection);

            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("firstName", DbType.AnsiStringFixedLength));
            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("lastName", DbType.AnsiStringFixedLength));
            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("dni", DbType.Int32));

            userAdapter.InsertCommand.Parameters[0].Direction = ParameterDirection.Input;
            userAdapter.InsertCommand.Parameters[1].Direction = ParameterDirection.Input;
            userAdapter.InsertCommand.Parameters[2].Direction = ParameterDirection.Input;

            userAdapter.InsertCommand.Parameters[0].SourceColumn = "firstName";
            userAdapter.InsertCommand.Parameters[1].SourceColumn = "lastName";
            userAdapter.InsertCommand.Parameters[2].SourceColumn = "dni";

            //  UPDATE STATEMENT - SQL QUERY FOR NPGSQL
            userAdapter.UpdateCommand = new NpgsqlCommand("UPDATE inkaart.\"Person\" SET firsName = :firstName, lastName = :lastName, dni = :dni WHERE idPerson = :idPerson;", Connection);

            userAdapter.UpdateCommand.Parameters.Add(new NpgsqlParameter("idPerson", DbType.Int32));
            userAdapter.UpdateCommand.Parameters.Add(new NpgsqlParameter("firstName", DbType.AnsiStringFixedLength));
            userAdapter.UpdateCommand.Parameters.Add(new NpgsqlParameter("lastName", DbType.AnsiStringFixedLength));
            userAdapter.UpdateCommand.Parameters.Add(new NpgsqlParameter("dni", DbType.Int32));

            userAdapter.UpdateCommand.Parameters[0].Direction = ParameterDirection.Input;
            userAdapter.UpdateCommand.Parameters[1].Direction = ParameterDirection.Input;
            userAdapter.UpdateCommand.Parameters[2].Direction = ParameterDirection.Input;
            userAdapter.UpdateCommand.Parameters[3].Direction = ParameterDirection.Input;

            userAdapter.UpdateCommand.Parameters[0].SourceColumn = "idPerson";
            userAdapter.UpdateCommand.Parameters[1].SourceColumn = "firstName";
            userAdapter.UpdateCommand.Parameters[2].SourceColumn = "lastName";
            userAdapter.UpdateCommand.Parameters[3].SourceColumn = "dni";

            //  DELETE STATEMENT - SQL QUERY FOR NPGSQL
            userAdapter.DeleteCommand = new NpgsqlCommand("DELETE FROM inkaart.\"Person\" WHERE dni = :dni;", Connection);

            userAdapter.DeleteCommand.Parameters.Add(new NpgsqlParameter("idPerson", DbType.Int32));

            userAdapter.DeleteCommand.Parameters[0].Direction = ParameterDirection.Input;

            userAdapter.DeleteCommand.Parameters[0].SourceColumn = "idPerson";

            return userAdapter;
        }
    }
}
