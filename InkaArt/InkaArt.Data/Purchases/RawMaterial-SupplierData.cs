﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;
using System.Data;

namespace InkaArt.Data.Purchases
{
    public class RawMaterial_SupplierData : BD_Connector
    {
        private DataSet data;
        private DataTable table;
        private DataRow row;
        private NpgsqlDataAdapter adap;
        public RawMaterial_SupplierData()
        {
            data = new DataSet();
        }
        
        public NpgsqlDataAdapter rawMaterial_SupplierAdapter()
        {
            NpgsqlDataAdapter rawMaterial_SupplierAdapter = new NpgsqlDataAdapter();
            rawMaterial_SupplierAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"RawMaterial-Supplier\"", Connection);
            return rawMaterial_SupplierAdapter;
            
        }
        public DataTable GetRmSup(int id_rm = -1, int id_sup = -1)
        {
            adap = rawMaterial_SupplierAdapter();
            byIdRm(adap, id_rm);
            byIdSup(adap, id_sup);
            adap.SelectCommand.CommandText += ";";
            data.Clear();
            data = getData(adap, "RawMaterial-Supplier");

            DataTable rawMaterial_suppliersList = new DataTable();
            rawMaterial_suppliersList = data.Tables[0];
            return rawMaterial_suppliersList;

        }
        private void byIdRm(NpgsqlDataAdapter adap, int raw_material)
        {
            if (raw_material == -1) return; //If there is no id, just return dude
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "\"id_raw_material\" = :id_raw_material";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("id_raw_material", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "id_raw_material";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = raw_material;
        }
        private void byIdSup(NpgsqlDataAdapter adap, int supplier)
        {
            if (supplier == -1) return; //If there is no id, just return dude
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "\"id_supplier\" = :id_supplier";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("id_supplier", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "id_supplier";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = supplier;
        }
        public void UpdateRM_Sup(string idMat, string idSup, double precio)
        {
            table = data.Tables["RawMaterial-Supplier"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if ((String.Compare(table.Rows[i]["id_raw_material"].ToString(), idMat) == 0)&&(String.Compare(table.Rows[i]["id_supplier"].ToString(), idSup) == 0))
                {
                    table.Rows[i]["price"] = precio;
                    break;
                }
            }

            updateData(data, adap, "RawMaterial-Supplier");
        }
        public void InsertRM_Sup(int idMat,int idSup,double precio)
        {
            table = data.Tables["RawMaterial-Supplier"];
            row = table.NewRow();

            row["id_raw_material"] = idMat;
            row["id_supplier"] = idSup;
            row["price"] = precio;
            table.Rows.Add(row);

            insertData(data, adap, "RawMaterial-Supplier");
        }
    }
}
