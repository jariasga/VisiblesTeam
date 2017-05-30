using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;
using System.Data;

namespace InkaArt.Data.Sales
{
    public class ClientData : BD_Connector
    {
        public int InsertClient(int personType, string name, int ruc, int dni, int priority, int type, int state, string address, int phone, string contact, string email)
        {
            try
            {
                NpgsqlDataAdapter clientAdapter = new NpgsqlDataAdapter();
                clientAdapter.InsertCommand = new NpgsqlCommand("INSERT INTO inkaart.\"Client\" VALUES(default, @clientType, @name, @ruc, @dni, @priority, @type, @state, @address, @phone, @contactName, @email)", Connection);
                clientAdapter.InsertCommand.CommandType = CommandType.Text;
                clientAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("@clientType", personType));
                clientAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("@name", name));
                clientAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("@ruc", ruc));
                clientAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("@dni", dni));
                clientAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("@priority", priority));
                clientAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("@type", type));
                clientAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("@state", state));
                clientAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("@address", address));
                clientAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("@phone", phone));
                clientAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("@contactName", contact));
                clientAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("@email", email));
                clientAdapter.InsertCommand.ExecuteNonQuery();
                clientAdapter.InsertCommand.Dispose();
                Connection.Close();
                return 0;
            }
            catch(Exception ex)
            {
                return 1;
            }
        }
    }
}
