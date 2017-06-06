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
    public class UnitOfMeasurementData : BD_Connector
    {
        private DataSet data;
        private DataTable table;
        private DataRow row;
        private NpgsqlDataAdapter adap;

        public UnitOfMeasurementData()
        {
            data = new DataSet();
        }
        public NpgsqlDataAdapter unitOfMeasurementAdapter()
        {
            NpgsqlDataAdapter unitOfMeasurementAdapter = new NpgsqlDataAdapter();
            unitOfMeasurementAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"UnitOfMeasurement\"", Connection);
            
            return unitOfMeasurementAdapter;
        }
        public DataTable GetUnits(int id = -1, string name = "", string abrev ="", string estado= "")
        {
            connect();

            adap = unitOfMeasurementAdapter();
            byId(adap, id);
            byName(adap, name);
            byAbrev(adap, abrev);
            byState(adap, estado);
            adap.SelectCommand.CommandText += ";";
            data.Clear();
            data = getData(adap, "UnitOfMeasurement");

            DataTable unitsList = new DataTable();
            unitsList = data.Tables[0];
            closeConnection();
            return unitsList;
        }
        private void byId(NpgsqlDataAdapter adap, int id)
        {
            if (id == -1) return; //If there is no id, just return dude
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "\"idUnit\" = :idUnit";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idUnit", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "idUnit";
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
        private void byAbrev(NpgsqlDataAdapter adap, string abrev)
        {
            if (abrev.Equals("")) return;
            abrev = "%" + abrev + "%";
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "abbreviature LIKE :abbreviature";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("abbreviature", DbType.AnsiStringFixedLength));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "abbreviature";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = abrev;
        }
        private void byState(NpgsqlDataAdapter adap, string state)
        {
            if(state.Equals("")) return;
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "status = :status";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("status", DbType.AnsiStringFixedLength));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "status";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = state;
        }
        public void UpdateUnit(string id, string name, string abrev, string state)
        {
            connect();
            table = data.Tables["UnitOfMeasurement"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (String.Compare(table.Rows[i]["idUnit"].ToString(), id) == 0)
                {
                    table.Rows[i]["name"] = name;
                    table.Rows[i]["abbreviature"] = abrev;
                    table.Rows[i]["status"] = state;
                    break;
                }
            }
            updateData(data, adap, "UnitOfMeasurement");
            closeConnection();
        }
        public void insertUnit(string nombre, string abreviatura, string estado)
        {
            connect();

            table = data.Tables["UnitOfMeasurement"];
            row = table.NewRow();

            row["name"] = nombre;
            row["abbreviature"] = abreviatura;
            row["status"] = estado;
            table.Rows.Add(row);

            insertData(data, adap, "UnitOfMeasurement");

            closeConnection();
        }
    }
}
