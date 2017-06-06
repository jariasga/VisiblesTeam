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
            table = data.Tables["Ware"];
            row = table.NewRow();
            row["name"] = name;
            row["description"] = name;
            row["address"] = name;
            row["state"] = name;
            table.Rows.Add(row);
            int rowsAffected = insertData(data, adap, "Warehouse");
            return rowsAffected;
        }

        public DataTable GetWarehouses(string name = "", string description = "", string address = "", int state = -1)
        {
            /*connect();

            adap = warehouseAdapter();
            
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
            return clientList;*/
        }

    }
}
