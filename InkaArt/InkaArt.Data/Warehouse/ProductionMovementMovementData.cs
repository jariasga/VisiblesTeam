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
    public class ProductionMovementMovementData : BD_Connector
    {
        private DataSet data;
        private NpgsqlDataAdapter adap;

        public ProductionMovementMovementData()
        {
            data = new DataSet();
        }

        public NpgsqlDataAdapter ProductionMovementMovementDataAdapter()
        {
            NpgsqlDataAdapter productMovementAdapter = new NpgsqlDataAdapter();
            productMovementAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Movement\"", Connection);
            return productMovementAdapter;
        }

        public DataTable GetData()
        {
            connect();

            adap = ProductionMovementMovementDataAdapter();
            adap.SelectCommand.CommandText += " order by 1;";
            data.Clear();
            data = getData(adap, "Movement");

            DataTable clientList = new DataTable();
            clientList = data.Tables[0];
            return clientList;
        }
    }
}
