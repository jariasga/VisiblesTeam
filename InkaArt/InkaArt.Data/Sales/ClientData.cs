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
        private DataSet data;
        private DataTable table;
        private DataRow row;
        private NpgsqlDataAdapter adap;
        public ClientData()
        {
            data = new DataSet();
        }

        public NpgsqlDataAdapter clientAdapter()
        {
            NpgsqlDataAdapter clientAdapter = new NpgsqlDataAdapter();
            clientAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Client\"", Connection);
            return clientAdapter;
        }
        
        public NpgsqlDataAdapter clientUpdateAdapter()
        {
            NpgsqlDataAdapter clientUpdateAdapter = new NpgsqlDataAdapter();
            clientUpdateAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Client\" WHERE \"idClient\" = :idClient;", Connection);
            clientUpdateAdapter.SelectCommand.Parameters.Add(new NpgsqlParameter("idClient", DbType.Int32));
            clientUpdateAdapter.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            clientUpdateAdapter.SelectCommand.Parameters[0].SourceColumn = "idClient";
            return clientUpdateAdapter;
        }

        public int InsertClient(int personType, string name, long ruc, long dni, int priority, int type, int state, string address, int phone, string contact, string email)
        {
            adap = clientAdapter();
            data.Clear();
            data = getData(adap, "Client");
            table = data.Tables["Client"];
            row = table.NewRow();
            row["clientType"] = personType;
            row["name"] = name;
            row["ruc"] = ruc;
            row["dni"] = dni;
            row["priority"] = priority;
            row["type"] = type;
            row["status"] = state;
            row["address"] = address;
            row["phone"] = phone;
            row["contactName"] = contact;
            row["email"] = email;
            table.Rows.Add(row);
            int rowsAffected = insertData(data, adap, "Client");
            return rowsAffected;
        }

        public DataTable GetClients(int id = -1, long ruc = -1, long dni = -1, string name = "", int state = -1, int priority = -1)
        {

            adap = clientAdapter();
            byId(adap, id);
            byName(adap, name);
            byDoc(adap, ruc);
            byState(adap, state);
            byPriority(adap, priority);
            adap.SelectCommand.CommandText += ";";
            data.Clear();
            data = getData(adap, "Client");

            DataTable clientList = new DataTable();
            clientList = data.Tables[0];
            return clientList;
        }

        private void byPriority(NpgsqlDataAdapter adap, int priority)
        {
            if (priority == -1) return;
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "priority = :priority";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("priority", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "priority";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = priority;
        }

        private void byState(NpgsqlDataAdapter adap, int state)
        {
            if (state == -1) return;
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "status = :status";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("status", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "status";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = state;
        }

        private void byDoc(NpgsqlDataAdapter adap, long doc)
        {
            if (doc == -1) return;
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "ruc = :ruc";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("ruc", DbType.Int64));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "ruc";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = doc;
        }

        private void byName(NpgsqlDataAdapter adap, string name)
        {
            name = "%" + name + "%";
            if (name.Equals("")) return;
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "name LIKE :name";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("name", DbType.AnsiStringFixedLength));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "name";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = name;
        }

        private void byId(NpgsqlDataAdapter adap, int id)
        {
            if (id == -1) return; //If there is no id, just return dude
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "\"idClient\" = :idClient";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idClient", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "idClient";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = id;
        }

        public int UpdateClient(string id, int personType, string name, int ruc, int dni, int priority, int type, int state, string address, int phone, string contact, string email)
        {
            adap = clientAdapter();

            data.Clear();
            data = getData(adap, "Client");

            table = data.Tables["Client"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (string.Compare(table.Rows[i]["idClient"].ToString(), id) == 0)
                {
                    table.Rows[i]["clientType"] = personType;
                    table.Rows[i]["name"] = name;
                    table.Rows[i]["ruc"] = ruc;
                    table.Rows[i]["dni"] = dni;
                    table.Rows[i]["priority"] = priority;
                    table.Rows[i]["type"] = type;
                    table.Rows[i]["status"] = state;
                    table.Rows[i]["address"] = address;
                    table.Rows[i]["phone"] = phone;
                    table.Rows[i]["contactName"] = contact;
                    table.Rows[i]["email"] = email;
                    break;
                }
            }
            return updateData(data, adap, "Client");
        }
    }
}