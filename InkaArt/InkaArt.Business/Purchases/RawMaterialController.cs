using InkaArt.Data.Purchases;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;

namespace InkaArt.Business.Purchases
{
    public class RawMaterialController
    {
        private RawMaterialData rawMaterial;
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public DataTable getData()
        {
            rawMaterial = new RawMaterialData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();

            rawMaterial.connect();
            adap = rawMaterial.rawMaterialAdapter();

            data.Reset();
            data = rawMaterial.getData(adap, "RawMaterial");

            DataTable rawMaterialList = new DataTable();
            rawMaterialList = data.Tables[0];

            return rawMaterialList;
        }

        public void insertData()
        {
            rawMaterial.connect();

            table = data.Tables["RawMaterial"];

            NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(adap);

            adap.UpdateCommand = builder.GetUpdateCommand();
            adap.InsertCommand = builder.GetInsertCommand();
            adap.DeleteCommand = builder.GetDeleteCommand();

            row = table.NewRow();

            row["name"] = "test1";
            row["description"] = "descrip1";
            row["unit"] = 1;
            row["status"] = "Activo";
            row["averagePrice"] =1.5;

            table.Rows.Add(row);

            int rowsAffected = adap.Update(data, "RawMaterial");

            rawMaterial.closeConnection();
        }
    }
}