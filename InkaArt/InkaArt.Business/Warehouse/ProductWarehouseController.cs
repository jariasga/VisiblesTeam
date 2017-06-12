using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Warehouse;
using InkaArt.Data.Purchases;
using System.Data;
using Npgsql;

namespace InkaArt.Business.Warehouse
{
    public class ProductWarehouseController
    {

        private PWarehouseData pWarehouse;
        private NpgsqlDataAdapter adapt;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public ProductWarehouseController()
        {
            pWarehouse = new PWarehouseData();
            data = new DataSet();
        }

        public DataTable getData()
        {
            //adapt = new NpgsqlDataAdapter();

            adapt = pWarehouse.pWarehouseAdapter();

            data.Reset();
            data = pWarehouse.getData(adapt, "Product-Warehouse");

            DataTable pWarehouseList = new DataTable();
            pWarehouseList = data.Tables[0];

            return pWarehouseList;
        }

        public int insertData(string idW, string idP, string min, string max)
        {
            adapt = pWarehouse.pWarehouseAdapter();

            data.Reset();
            data = pWarehouse.getData(adapt, "Product-Warehouse");
            table = data.Tables["Product-Warehouse"];
            row = table.NewRow();

            row["idWarehouse"] = idW;
            row["idProduct"] = idP;
            row["minimunStock"] = min;
            row["maximunStock"] = max;
            row["virtualStock"] = 0;
            row["currentStock"] = 0;
            row["state"] = "Activo";

            table.Rows.Add(row);
            int rowsAffected = pWarehouse.insertData(data, adapt, "Product-Warehouse");
            return rowsAffected;
        }

        public int deleteData(string idPW)
        {
            adapt = pWarehouse.pWarehouseAdapter();

            data.Reset();
            data = pWarehouse.getData(adapt, "Product-Warehouse");
            table = data.Tables["Product-Warehouse"];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (string.Compare(table.Rows[i]["idProductWarehouse"].ToString(), idPW) == 0)
                {
                    table.Rows[i]["state"] = "Inactivo";
                    break;
                }
            }

            return pWarehouse.updateData(data, adapt, "Product-Warehouse");
        }





    }
}
