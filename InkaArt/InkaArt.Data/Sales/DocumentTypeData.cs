using InkaArt.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Sales
{
    public class DocumentTypeData : BD_Connector
    {
        private string table_name;
        private DataSet data;
        private NpgsqlDataAdapter adap;

        public DocumentTypeData()
        {
            data = new DataSet();
            table_name = "DocumentType";
        }

        public DataTable GetDocumentTypes(int id = -1)
        {
            adap = movementTypeAdapter();
            byId(adap, id);
            adap.SelectCommand.CommandText += ";";

            data.Clear();
            data = getData(adap);
            DataTable movement_list = new DataTable();
            movement_list = data.Tables[0];
            return movement_list;
        }

        public void byId(NpgsqlDataAdapter adap, int id)
        {
            if (id == -1) return;

            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";

            adap.SelectCommand.CommandText += "\"idTipoDocumento\" = :idTipoDocumento";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idTipoDocumento", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "idTipoDocumento";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = id;
        }

        public NpgsqlDataAdapter movementTypeAdapter()
        {
            NpgsqlDataAdapter orderAdapter = new NpgsqlDataAdapter();
            orderAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"" + table_name + "\"", Connection);
            return orderAdapter;
        }

        public DataSet getData(NpgsqlDataAdapter adapter)
        {
            return getData(adapter, table_name);
        }
    }
}
