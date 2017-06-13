using InkaArt.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Warehouse
{
    class MovementTypeData : BD_Connector
    {
        private DataSet data;
        private DataTable table;
        private DataRow row;
        private NpgsqlDataAdapter adap;

        public MovementTypeData()
        {
            data = new DataSet();
        }

        public DataTable GetMovements()
        {
            adap = movementAdapter();
            adap.SelectCommand.CommandText += ";";

            data.Clear();
            data = getData(adap, "MovementType");
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

            adap.SelectCommand.CommandText += "\"idMovementType\" = :idMovementType";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idMovementType", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "idMovementType";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = id;
        }


        public NpgsqlDataAdapter movementAdapter()
        {
            NpgsqlDataAdapter orderAdapter = new NpgsqlDataAdapter();
            orderAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"DocumentType\"", Connection);
            return orderAdapter;
        }
    }
}
