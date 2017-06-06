using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Warehouse;
using System.Data;
using NpgsqlTypes;
using Npgsql;
using System.Windows.Forms;

namespace InkaArt.Business.Warehouse
{
    public class ProductionItemWarehouseMovementController
    {
        private ProductionItemWarehouseMovementData productionItemWarehouseMovementData;
        private NpgsqlDataAdapter adapt;
        private DataSet data;
        private DataTable table;
        //private DataRow row;

        public ProductionItemWarehouseMovementController()
        {
            productionItemWarehouseMovementData = new ProductionItemWarehouseMovementData();
            data = new DataSet();
        }

        public DataTable GetProductionItemWarehouseMovementList(string idWarehouse = "",string idProduct = "")
        {
            int intId = -1, intAux,intId2 = -1;

            if (!idWarehouse.Equals("")) if (int.TryParse(idWarehouse, out intAux)) intId = int.Parse(idWarehouse);
            if (!idProduct.Equals("")) if (int.TryParse(idProduct, out intAux)) intId2 = int.Parse(idProduct);

            return productionItemWarehouseMovementData.GetData(intId);
        }

        public void inserData(string proveedor, string idMovementType, string idWarehouse, string idMovementReason, DateTime date)
        {
            /*productionItemMovementData.connect();
            adapt = productionItemMovementData.ProductionItemMovementAdapter();

            data.Clear();
            data = productionItemMovementData.getData(adapt, "Product");

            table = data.Tables["PurcharseOrder"];
            row = table.NewRow();

            row["idSupplier"] = proveedor;
            row["status"] = estado;
            row["creationDate"] = creacion;
            row["deliveryDate"] = entrega;
            row["total"] = total;
            table.Rows.Add(row);

            int rowsAffected = productionItemMovementData.insertData(data, adap, "PurcharseOrder");

            productionItemMovementData.closeConnection();*/
        }

        public void updateData(string idProd, string idWarehouse, int numMov, string typeMovement)
        {
            //productionItemWarehouseMovementData.connect();
            adapt = productionItemWarehouseMovementData.ProductionItemWarehouseAdapter();

            data.Clear();
            data = productionItemWarehouseMovementData.getData(adapt, "Product-Warehouse");

            table = data.Tables["Product-Warehouse"];
            int makeUpdate = 1;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if ((String.Compare(table.Rows[i]["idProduct"].ToString(), idProd) == 0) && (String.Compare(table.Rows[i]["idWarehouse"].ToString(), idWarehouse) == 0))
                {
                    if (typeMovement == "Entrada")
                    {
                        int stockAct;//Stock físico
                        int logicStock;//Stock lógico

                        stockAct = Convert.ToInt32(table.Rows[i]["currentStock"]);
                        stockAct = stockAct + numMov;

                        logicStock = Convert.ToInt32(table.Rows[i]["virtualStock"]);
                        logicStock = logicStock + numMov;

                        table.Rows[i]["currentStock"] = stockAct;
                        table.Rows[i]["virtualStock"] = logicStock;
                        break;
                    }
                    if (typeMovement == "Salida")
                    {
                        int stockAct;//Stock físico

                        stockAct = Convert.ToInt32(table.Rows[i]["currentStock"]);
                        if (stockAct - numMov < 0)
                        {
                            MessageBox.Show("Usted solo cuenta con: " + stockAct + " items, no puede mover: " + numMov + " items.");
                            makeUpdate = -1;
                            break;
                        }
                        else
                        {
                            stockAct = stockAct - numMov;
                            table.Rows[i]["currentStock"] = stockAct;
                        }
                        break;
                    }
                }
            }
            if (makeUpdate != -1)
            {
                int rowUpdated = productionItemWarehouseMovementData.updateData(data, adapt, "Product-Warehouse");
            }
        }
    }
}
