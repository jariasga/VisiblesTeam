﻿using InkaArt.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Warehouse
{
    public class MovementTypeData : BD_Connector
    {
        private string table_name;
        private DataSet data;
        private NpgsqlDataAdapter adap;

        public MovementTypeData()
        {
            data = new DataSet();
            table_name = "MovementType";
        }

        public DataTable GetMovementTypes()
        {
            adap = movementTypeAdapter();
            adap.SelectCommand.CommandText += ";";

            data.Clear();
            data = getData(adap, table_name);
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
