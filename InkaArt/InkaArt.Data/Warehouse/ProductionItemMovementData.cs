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
    public class ProductionItemMovementData : BD_Connector
    {
        private DataSet data;
        private NpgsqlDataAdapter adap;

        public ProductionItemMovementData()
        {
            data = new DataSet();
        }

        public NpgsqlDataAdapter ProductionItemMovementAdapter()
        {
            NpgsqlDataAdapter productionItemMovementAdapter = new NpgsqlDataAdapter();
            productionItemMovementAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Product\"", Connection);
            return productionItemMovementAdapter;
        }

        public DataTable GetData(int id = -1)
        {
            //connect();

            adap = ProductionItemMovementAdapter();
            byId(adap, id);
            adap.SelectCommand.CommandText += " order by 1;";
            data.Clear();
            data = getData(adap, "Product");

            DataTable clientList;// = new DataTable();
            clientList = data.Tables["Product"];
            return clientList;
        }

        private void byId(NpgsqlDataAdapter adap, int id)
        {
            if (id == -1) return; //If there is no id, just return dude
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "\"idProduct\" = :idProduct";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idProduct", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "idProduct";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = id;
        }

        public int WatchDocument(string query)
        {
            connect();
            NpgsqlDataAdapter userAdapter = new NpgsqlDataAdapter();

            //query = "Select * from inkaart.\"Warehouse\"";
            NpgsqlCommand command = new NpgsqlCommand(query, Connection);
            NpgsqlDataReader dr = command.ExecuteReader();

            int rowIndex=0;

            while (dr.Read())
            {                
                rowIndex++;
            }
            closeConnection();
            return rowIndex;
        }        

        public NpgsqlDataReader GetLoteData(string query)
        {
            connect();
            NpgsqlDataAdapter userAdapter = new NpgsqlDataAdapter();

            //query = "Select * from inkaart.\"Warehouse\"";
            NpgsqlCommand command = new NpgsqlCommand(query, Connection);
            NpgsqlDataReader dr = command.ExecuteReader();

            //closeConnection();
            return dr;
        }

        public void insertData2(string query="")
        {
            execute(query);
        }

    }
}
