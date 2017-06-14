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
    public class ProductionItemWarehouseMovementData : BD_Connector
    {
        private DataSet data;
        private NpgsqlDataAdapter adap;

        public ProductionItemWarehouseMovementData()
        {
            data = new DataSet();
        }

        public NpgsqlDataAdapter ProductionItemWarehouseAdapter()
        {
            NpgsqlDataAdapter productMovementAdapter = new NpgsqlDataAdapter();
            productMovementAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Product-Warehouse\"", Connection);
            return productMovementAdapter;
        }

        public int selectQuery(string query)
        {
            connect();
            NpgsqlDataAdapter userAdapter = new NpgsqlDataAdapter();

            //query = "Select * from inkaart.\"Warehouse\"";
            NpgsqlCommand command = new NpgsqlCommand(query, Connection);
            NpgsqlDataReader dr = command.ExecuteReader();

            int rowIndex = 0;
            try
            {
                dr.Read();

                rowIndex = Convert.ToInt32(dr[1]);

            }
            catch
            {
                return -1;
            }
            
            closeConnection();
            return rowIndex;
        }

        public int updateDataExecute(string queryUpdate)
        {
            int a = 5;
            execute(queryUpdate);
            return a;
        }

        public DataTable GetData(int id = -1)
        {
            //connect();

            adap = ProductionItemWarehouseAdapter();
            adap.SelectCommand.CommandText += " order by 1;";
            data.Clear();
            data = getData(adap, "Product-Warehouse");

            DataTable clientList;// = new DataTable();
            clientList = data.Tables[0];
            return clientList;
        }
    }
}
