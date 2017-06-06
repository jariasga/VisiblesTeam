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
    public class WarehouseMovementData : BD_Connector
    {
        private DataSet data;
        private NpgsqlDataAdapter adap;

        public WarehouseMovementData()
        {
            data = new DataSet();
        }

        public NpgsqlDataAdapter materialMovementAdapter()
        {
            NpgsqlDataAdapter materialMovementAdapter = new NpgsqlDataAdapter();
            materialMovementAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Warehouse\"", Connection);
            return materialMovementAdapter;
        }

        public DataTable GetData(int id = -1, string name = "", string state = "", string address = "")
        {
            connect();

            adap = materialMovementAdapter();
            byId(adap, id);
            byName(adap, name);
            byState(adap, state);
            byAddress(adap, address);
            adap.SelectCommand.CommandText += " order by 1;";
            data.Clear();
            data = getData(adap, "Warehouse");

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
            adap.SelectCommand.CommandText += "\"idWarehouse\" = :idWarehouse";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idWarehouse", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "idWarehouse";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = id;
        }

        private void byName(NpgsqlDataAdapter adap, string name)
        {
            name = "%" + name + "%";
            if (name.Equals("")) return;
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "name LIKE :name";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("name", DbType.AnsiStringFixedLength));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "name";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = name;
        }

        private void byState(NpgsqlDataAdapter adap, string state)
        {
            if (state.Equals("")) return;
            state = "%" + state + "%";
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "state LIKE :state";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("state", DbType.AnsiStringFixedLength));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "state";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = state;
        }

        private void byAddress(NpgsqlDataAdapter adap, string address)
        {
            address = "%" + address + "%";
            if (address.Equals("")) return;
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "address LIKE :address";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("address", DbType.AnsiStringFixedLength));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "address";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = address;
        }

    }
}
