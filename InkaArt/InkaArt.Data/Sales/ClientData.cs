using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Classes;
using Npgsql;
using System.Data;

namespace InkaArt.Data.Sales
{
    public class ClientData : BD_Connector
    {
        public NpgsqlDataAdapter userAdapter()
        {
            NpgsqlDataAdapter userAdapter = new NpgsqlDataAdapter();

            userAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Cliente\" WHERE \"idCliente\" = :idCliente;", Connection);
            userAdapter.SelectCommand.Parameters.Add(new NpgsqlParameter("idCliente", DbType.AnsiStringFixedLength));
            userAdapter.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            userAdapter.SelectCommand.Parameters[0].SourceColumn = "idCliente";

            /*
             *
             * TEST PHASE - QUERIES UPDATE / DELETE / INSERTED HAVE NOT BEEN TESTED - USE AT YOUR OWN RISK
             * 
             */
            //  INSERT STATEMENT - SQL QUERY FOR NPGSQL
            userAdapter.InsertCommand = new NpgsqlCommand("INSERT INTO inkaart.\"Cliente\" (\"tipoPersona\", nombre, ruc, dni, prioridad, tipo, estado, direccion, telefono, \"nombreContacto\", correo) VALUES(:personType, :name, :ruc, :dni, :priority, :type, :state, :address, :phone, :contact, :email);", Connection);

            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("personType", DbType.Int32));
            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("name", DbType.Int32));
            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("ruc", DbType.Int32));
            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("dni", DbType.Int32));
            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("priority", DbType.Int32));
            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("type", DbType.Int32));
            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("state", DbType.Int32));
            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("address", DbType.AnsiStringFixedLength));
            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("phone", DbType.Int32));
            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("contact", DbType.AnsiStringFixedLength));
            userAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("email", DbType.AnsiStringFixedLength));

            userAdapter.InsertCommand.Parameters[0].Direction = ParameterDirection.Input;
            userAdapter.InsertCommand.Parameters[1].Direction = ParameterDirection.Input;
            userAdapter.InsertCommand.Parameters[2].Direction = ParameterDirection.Input;
            userAdapter.InsertCommand.Parameters[3].Direction = ParameterDirection.Input;
            userAdapter.InsertCommand.Parameters[4].Direction = ParameterDirection.Input;
            userAdapter.InsertCommand.Parameters[5].Direction = ParameterDirection.Input;
            userAdapter.InsertCommand.Parameters[6].Direction = ParameterDirection.Input;
            userAdapter.InsertCommand.Parameters[7].Direction = ParameterDirection.Input;
            userAdapter.InsertCommand.Parameters[8].Direction = ParameterDirection.Input;
            userAdapter.InsertCommand.Parameters[9].Direction = ParameterDirection.Input;
            userAdapter.InsertCommand.Parameters[10].Direction = ParameterDirection.Input;

            userAdapter.InsertCommand.Parameters[0].SourceColumn = "personType";
            userAdapter.InsertCommand.Parameters[1].SourceColumn = "name";
            userAdapter.InsertCommand.Parameters[2].SourceColumn = "ruc";
            userAdapter.InsertCommand.Parameters[3].SourceColumn = "dni";
            userAdapter.InsertCommand.Parameters[4].SourceColumn = "priority";
            userAdapter.InsertCommand.Parameters[5].SourceColumn = "type";
            userAdapter.InsertCommand.Parameters[6].SourceColumn = "state";
            userAdapter.InsertCommand.Parameters[7].SourceColumn = "address";
            userAdapter.InsertCommand.Parameters[8].SourceColumn = "phone";
            userAdapter.InsertCommand.Parameters[9].SourceColumn = "contact";
            userAdapter.InsertCommand.Parameters[10].SourceColumn = "email";

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
            userAdapter.DeleteCommand = new NpgsqlCommand("DELETE FROM inkaart.\"Cliente\" WHERE \"idCliente\" = :idCliente;", Connection);

            userAdapter.DeleteCommand.Parameters.Add(new NpgsqlParameter("idCliente", DbType.Int32));

            userAdapter.DeleteCommand.Parameters[0].Direction = ParameterDirection.Input;

            userAdapter.DeleteCommand.Parameters[0].SourceColumn = "idCliente";

            return userAdapter;
        }
    }
}
