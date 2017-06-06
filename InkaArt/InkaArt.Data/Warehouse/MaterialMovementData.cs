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
    public class MaterialMovementData : BD_Connector
    {
        private DataSet data;
        private NpgsqlDataAdapter adap;

        public MaterialMovementData()
        {
            data = new DataSet();
        }

        public NpgsqlDataAdapter materialMovementAdapter()
        {
            NpgsqlDataAdapter productMovementAdapter = new NpgsqlDataAdapter();
            productMovementAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"RawMaterial\"", Connection);
            return productMovementAdapter;
        }

        public DataTable GetData(int id = -1, string name = "", string state = "")
        {
            connect();

            adap = materialMovementAdapter();
            byId(adap, id);
            byName(adap, name);
            byState(adap, state);
            adap.SelectCommand.CommandText += " order by 1;";
            data.Clear();
            data = getData(adap, "RawMaterial");

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
            adap.SelectCommand.CommandText += "\"idRawMaterial\" = :idRawMaterial";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idRawMaterial", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "idRawMaterial";
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

        private void byState(NpgsqlDataAdapter adap, string status)
        {
            if (status.Equals("")) return;
            status = "%" + status + "%";
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "status LIKE :status";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("status", DbType.AnsiStringFixedLength));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "status";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = status;
        }
    }
}
