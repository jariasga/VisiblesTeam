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
    public class TypeMovementData : BD_Connector
    {
        private DataSet data;
        private NpgsqlDataAdapter adap;

        public TypeMovementData()
        {
            data = new DataSet();
        }

        public NpgsqlDataAdapter typeMovementAdapter()
        {
            NpgsqlDataAdapter typeMovementAdapter = new NpgsqlDataAdapter();
            typeMovementAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"MovementType\"", Connection);
            return typeMovementAdapter;
        }

        public DataTable GetData(int id = -1, string name = "", string state = "")
        {
            //connect();

            adap = typeMovementAdapter();
            adap.SelectCommand.CommandText += " order by 1;";
            data.Clear();
            data = getData(adap, "MovementType");

            DataTable clientList = new DataTable();
            clientList = data.Tables[0];
            return clientList;
        }

    }
}
