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
    public class RawMaterialData: BD_Connector
    {
        public NpgsqlDataAdapter rawMaterialAdapter()
        {
            NpgsqlDataAdapter rawMaterialAdapter = new NpgsqlDataAdapter();
            rawMaterialAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM \"inkaart\".\"RawMaterial\";", Connection);

            return rawMaterialAdapter;
        }

        public DataTable GetRawMaterial(int id = -1)
        {
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter();

            adap.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"RawMaterial\"", Connection);

            byId(adap, id);
            adap.SelectCommand.CommandText += ";";

            DataSet data = getData(adap, "RawMaterial");
            DataTable list = new DataTable();
            list = data.Tables[0];
            return list;
        }

        private void byId(NpgsqlDataAdapter adap, int id)
        {
            if (id == -1) return;

            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";

            adap.SelectCommand.CommandText += "\"id_raw_material\" = :id_raw_material";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("id_raw_material", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "id_raw_material";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = id;
        }
    }

}
