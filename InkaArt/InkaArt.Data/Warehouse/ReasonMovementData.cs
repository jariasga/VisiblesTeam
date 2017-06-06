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
    public class ReasonMovementData : BD_Connector
    {
        private DataSet data;
        private NpgsqlDataAdapter adap;

        public ReasonMovementData()
        {
            data = new DataSet();
        }

        public NpgsqlDataAdapter reasonMovementAdapter()
        {
            NpgsqlDataAdapter reasonMovementAdapter = new NpgsqlDataAdapter();
            reasonMovementAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"MovementName\"", Connection);
            return reasonMovementAdapter;
        }

        public DataTable GetData(int id = -1, string name = "", string state = "")
        {
            //connect();

            adap = reasonMovementAdapter();
            adap.SelectCommand.CommandText += " order by 1;";
            data.Clear();
            data = getData(adap, "NameType");

            DataTable clientList = new DataTable();
            clientList = data.Tables[0];
            return clientList;
        }

    }
}
