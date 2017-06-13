using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;
using System.Data;

namespace InkaArt.Data.Purchases
{
    public class RawMaterialData : BD_Connector
    {
        private DataSet data;
        private DataTable table;
        private DataRow row;
        private NpgsqlDataAdapter adap;

        public NpgsqlDataAdapter rawMaterialAdapter()
        {
            NpgsqlDataAdapter rawMaterialAdapter = new NpgsqlDataAdapter();
            
            rawMaterialAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"RawMaterial\";", Connection);
            return rawMaterialAdapter;
        }

        public DataTable GetRM(int id = -1)
        {
            adap = rawMaterialAdapter();
            /*
            byId(adap, id);
            byName(adap, name);
            byDescription(adap, description);
            byAddress(adap, address);*/
            //adap.SelectCommand.CommandText += ";";
            data.Clear();
            data = getData(adap, "RawMaterial");

            DataTable rmWarehouseList = new DataTable();
            rmWarehouseList = data.Tables[0];
            return rmWarehouseList;
        }

    }
}
