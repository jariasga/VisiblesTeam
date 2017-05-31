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

        public void insertData(string nombre,string descripcion,string unidad,string estado,double precioPromedio)
        {
            rawMaterial.connect();

            table = data.Tables["RawMaterial"];
            row = table.NewRow();

            row["name"] = nombre;
            row["description"] = descripcion;
            row["unit"] = unidad;
            row["status"] = estado;
            row["averagePrice"] = precioPromedio;

            table.Rows.Add(row);

            int rowsAffected = rawMaterial.insertData(data, adap, "RawMaterial");

            rawMaterial.closeConnection();
        }
        public void updateData(string id, string nombre, string descripcion, string unidad, string estado, double precioPromedio)
        {
            rawMaterial.connect();
            table = data.Tables["RawMaterial"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (String.Compare(table.Rows[i]["idRawMaterial"].ToString(), id) == 0)
                {
                    table.Rows[i]["name"] = nombre;
                    table.Rows[i]["description"] = descripcion;
                    table.Rows[i]["unit"] = unidad;
                    table.Rows[i]["status"] = estado;
                    table.Rows[i]["averagePrice"] = precioPromedio;
                    break;
                }
            }
            rawMaterial.updateData(data, adap, "RawMaterial");
            rawMaterial.closeConnection();
        }
    }
}