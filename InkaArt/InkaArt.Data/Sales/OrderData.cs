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
            clientAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Client\";", Connection);
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
        public int InsertClient(int personType, string name, long ruc, int dni, int priority, int type, int state, string address, int phone, string contact, string email)
        {
            connect();
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
        public DataTable GetClients()
        {
            connect();

            adap = clientAdapter();

            data.Clear();
            data = getData(adap, "Client");

            DataTable clientList = new DataTable();
            clientList = data.Tables[0];
            return clientList;
        }
        public DataTable GetClients(int id)
        {
            connect();

            adap = clientUpdateAdapter();
            adap.SelectCommand.Parameters[0].NpgsqlValue = id;

            data.Clear();
            data = getData(adap, "Client");

            DataTable clientList = new DataTable();
            clientList = data.Tables[0];
            return clientList;
        }
        public DataTable GetClients(int id = -1, int ruc = -1, int dni = -1, string name = "", int state = -1, int priority = -1)
        {
            connect();

            adap = clientUpdateAdapter();
            if (id != -1) adap.SelectCommand.Parameters[0].NpgsqlValue = id;
            if (!name.Equals("")) adap.SelectCommand.Parameters[1].NpgsqlValue = name;
            if (ruc != -1) adap.SelectCommand.Parameters[2].NpgsqlValue = ruc;
            if (dni != -1) adap.SelectCommand.Parameters[3].NpgsqlValue = dni;
            if (state != -1) adap.SelectCommand.Parameters[4].NpgsqlValue = state;
            if (priority != -1) adap.SelectCommand.Parameters[5].NpgsqlValue = priority;

            data.Clear();
            data = getData(adap, "Client");

            DataTable clientList = new DataTable();
            clientList = data.Tables[0];
            return clientList;
        }
        public int UpdateClient(string id, int personType, string name, int ruc, int dni, int priority, int type, int state, string address, int phone, string contact, string email)
        {
            connect();
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
