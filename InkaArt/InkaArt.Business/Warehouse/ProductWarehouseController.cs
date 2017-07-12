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
            row["breaks"] = 0;

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


        public void updateMinMax(string idPW,int min,int max)
        {
            adapt = pWarehouse.pWarehouseAdapter();

            string updateQuery;
            string minS = min.ToString();
            string maxS = max.ToString();
            table = getData();
            updateQuery = "UPDATE inkaart.\"Product-Warehouse\" SET ";
            updateQuery = updateQuery + "\"minimunStock\"= " + minS + ", ";
            updateQuery = updateQuery + "\"maximunStock\" = " + maxS;
            updateQuery = updateQuery + " WHERE \"idProductWarehouse\"= " + idPW + " ;";
            pWarehouse.execute(updateQuery);
        }

        public void updateStock(string idWh, string idRm, int logico, int fisico)
        {
            adapt = pWarehouse.pWarehouseAdapter();

            string updateQuery;
            string logStr = logico.ToString();
            string fidStr = fisico.ToString();
            table = getData();
            updateQuery = "UPDATE inkaart.\"Product-Warehouse\" SET ";
            updateQuery = updateQuery + "\"currentStock\"= " + fidStr + ", ";
            updateQuery = updateQuery + "\"virtualStock\" = " + logStr;
            updateQuery = updateQuery + " WHERE \"idWarehouse\"= " + idWh + " AND \"idProduct\"= " + idRm + " AND state = 'Activo'" + " ;";
            pWarehouse.execute(updateQuery);
        }

        public void updateWarehouseStock(string id_warehouse, string id_product, int quantity)
        {
            adapt = pWarehouse.pWarehouseAdapter();

            string updateQuery;
            table = getData();
            updateQuery = "UPDATE inkaart.\"Product-Warehouse\" SET " +
                "\"currentStock\" = \"currentStock\" + " + quantity + ", \"virtualStock\" = \"virtualStock\" + " + quantity +
                " WHERE \"idWarehouse\" = " + id_warehouse + " AND \"idProduct\" = " + id_product + " AND state = 'Activo';";
            pWarehouse.execute(updateQuery);
        }





    }
}
