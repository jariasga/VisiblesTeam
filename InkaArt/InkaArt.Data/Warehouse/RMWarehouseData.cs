using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using InkaArt.Classes;

namespace InkaArt.Data.Warehouse
{
    public class RMWarehouseData : BD_Connector
    {
        private DataSet data;
        private DataTable table;
        private DataRow row;
        private NpgsqlDataAdapter adap;

        public RMWarehouseData()
        {
            data = new DataSet();
        }

        public NpgsqlDataAdapter rmWarehouseAdapter()
        {
            NpgsqlDataAdapter rmWarehouseAdapter = new NpgsqlDataAdapter();
            rmWarehouseAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"RawMaterial-Warehouse\"", Connection);
            return rmWarehouseAdapter;
        }
        public DataTable GetRMWarehouses(int id = -1)
        {
            adap = rmWarehouseAdapter();
            /*
            byId(adap, id);
            byName(adap, name);
            byDescription(adap, description);
            byAddress(adap, address);*/
            adap.SelectCommand.CommandText += ";";
            data.Clear();
            data = getData(adap, "RawMaterial-Warehouse");

            DataTable rmWarehouseList = new DataTable();
            rmWarehouseList = data.Tables[0];
            return rmWarehouseList;
        }

    }
}
