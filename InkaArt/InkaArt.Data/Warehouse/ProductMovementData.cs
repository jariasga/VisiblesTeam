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
    public class ProductMovementData : BD_Connector
    {
        private DataSet data;
        private NpgsqlDataAdapter adap;
        public ProductMovementData()
        {
            data = new DataSet();
        }

        public NpgsqlDataAdapter productMovementAdapter()
        {
            NpgsqlDataAdapter productMovementAdapter = new NpgsqlDataAdapter();
            productMovementAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Product\"", Connection);
            return productMovementAdapter;
        }

        public DataTable GetData(int id = -1, string name = "", int state = -1)
        {
            connect();

            adap = productMovementAdapter();
            byId(adap, id);
            byName(adap, name);
            byState(adap, state);
            adap.SelectCommand.CommandText += " order by 1;";
            data.Clear();
            data = getData(adap, "Product");

            DataTable clientList = new DataTable();
            clientList = data.Tables[0];
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

        private void byName(NpgsqlDataAdapter adap, string name)
        {
            if (name.Equals("")) return;
            name = "%" + name + "%";
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "name LIKE :name";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("name", DbType.AnsiStringFixedLength));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "name";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = name;
        }

        private void byState(NpgsqlDataAdapter adap, int status)
        {
            if (status == -1) return; //If there is no id, just return dude
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "\"status\" = :status";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("status", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "status";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = status;
        }
    }
}
