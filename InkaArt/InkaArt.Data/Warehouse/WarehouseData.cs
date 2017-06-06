using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;
using System.Data;

namespace InkaArt.Data.Warehouse
{
    public class WarehouseData : BD_Connector
    {
        private DataSet data;
        private DataTable table;
        private DataRow row;
        private NpgsqlDataAdapter adap;

        public WarehouseData()
        {
            data = new DataSet();
        }

        public NpgsqlDataAdapter warehouseAdapter()
        {
            NpgsqlDataAdapter warehouseAdapter = new NpgsqlDataAdapter();
            warehouseAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Warehouse\"", Connection);
            return warehouseAdapter;
        }

        public int InsertWarehouse(string name, string description, string address, string state)
        {
            connect();
            adap = warehouseAdapter();
            data.Clear();
            data = getData(adap, "Warehouse");
            table = data.Tables["Warehouse"];
            row = table.NewRow();
            row["name"] = name;
            row["description"] = description;
            row["address"] = address;
            row["state"] = "Activo";
            table.Rows.Add(row);
            int rowsAffected = insertData(data, adap, "Warehouse");
            return rowsAffected;
        }

        public DataTable GetWarehouses(int id = -1, string name = "", string description = "", string address = "", string state = "")
        {
            connect();

            adap = warehouseAdapter();
            
            byId(adap, id);
            byName(adap, name);
            byDescription(adap, description);
            byAddress(adap, address);
            adap.SelectCommand.CommandText += ";";
            data.Clear();
            data = getData(adap, "Warehouse");

            DataTable warehouseList = new DataTable();
            warehouseList = data.Tables[0];
            return warehouseList;
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

        private void byDescription(NpgsqlDataAdapter adap, string description)
        {
            description = "%" + description + "%";
            if (description.Equals("")) return;
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "description LIKE :description";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("description", DbType.AnsiStringFixedLength));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "description";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = description;
        }

        private void byAddress(NpgsqlDataAdapter adap, string address)
        {
            address = "%" + address + "%";
            if (address.Equals("")) return;
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "address LIKE :address";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("address", DbType.AnsiStringFixedLength));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "address";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = address;
        }

        private void byId(NpgsqlDataAdapter adap, int id)
        {
            if (id == -1) return; //If there is no id, just return dude
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "\"idWarehouse\" = :idWarehouse";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idWarehouse", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "idWarehouse";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = id;
        }

        public int updateWarehouse(string id, string name, string description, string address, string state)
        {
            connect();
            adap = warehouseAdapter();

            data.Clear();
            data = getData(adap, "Warehouse");

            table = data.Tables["Warehouse"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (string.Compare(table.Rows[i]["idWarehouse"].ToString(), id) == 0)
                {
                    table.Rows[i]["name"] = name;
                    table.Rows[i]["description"] = description;
                    table.Rows[i]["address"] = address;
                    break;
                }
            }
            return updateData(data, adap, "Warehouse");
        }

    }
}
