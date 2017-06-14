using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;
using System.Data;

namespace InkaArt.Data.Production
{
    public class FinalProductData : BD_Connector
    {
        public NpgsqlDataAdapter finalProductAdapter()
        {
            NpgsqlDataAdapter finalProductAdapter = new NpgsqlDataAdapter();

            finalProductAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Product\";", Connection);

            return finalProductAdapter;
        }

        public DataTable GetProducts(int id = -1)
        {
            NpgsqlDataAdapter finalProductAdapter = new NpgsqlDataAdapter();

            finalProductAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Product\"", Connection);

            byId(finalProductAdapter, id);
            finalProductAdapter.SelectCommand.CommandText += ";";

            DataSet data = getData(finalProductAdapter, "Product");
            DataTable movement_list = new DataTable();
            movement_list = data.Tables[0];
            return movement_list;
        }

        private void byId(NpgsqlDataAdapter adap, int id)
        {
            if (id == -1) return;

            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";

            adap.SelectCommand.CommandText += "\"idProduct\" = :idProduct";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idProduct", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "idProduct";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = id;
        }
    }
}
