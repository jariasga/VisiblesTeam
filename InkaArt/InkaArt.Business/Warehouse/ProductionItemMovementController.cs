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
    public class ProductionItemMovementController
    {
        private ProductionItemMovementData productionItemMovementData;
        private NpgsqlDataAdapter adapt;
        private DataSet data;
        private DataTable table;
        //private DataRow row;

        public ProductionItemMovementController()
        {
            productionItemMovementData = new ProductionItemMovementData();
            data = new DataSet();
        }

        public DataTable GetMaterialMovementList(string id = "")
        {
            int intId = -1, intAux;

            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intId = int.Parse(id);
            return productionItemMovementData.GetData(intId);
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

        public void updateData(string id, int numMov, string typeMovement)
        {
            productionItemMovementData.connect();
            adapt = productionItemMovementData.ProductionItemMovementAdapter();

            data.Clear();
            data = productionItemMovementData.getData(adapt, "Product");

            table = data.Tables["Product"];
            int makeUpdate = 1;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (String.Compare(table.Rows[i]["idProduct"].ToString(), id) == 0)
                {
                    if (typeMovement == "Entrada")
                    {
                        int stockAct;//Stock físico
                        int logicStock;//Stock lógico

                        stockAct = Convert.ToInt32(table.Rows[i]["actualStock"]);
                        stockAct = stockAct + numMov;

                        logicStock = Convert.ToInt32(table.Rows[i]["logicalStock"]);
                        logicStock = logicStock + numMov;

                        table.Rows[i]["actualStock"] = stockAct;
                        table.Rows[i]["logicalStock"] = logicStock;
                        break;
                    }
                    if (typeMovement == "Salida")
                    {
                        int stockAct;//Stock físico

                        stockAct = Convert.ToInt32(table.Rows[i]["actualStock"]);
                        if(stockAct - numMov < 0)
                        {
                            MessageBox.Show("Usted solo cuenta con: " + stockAct + " items, no puede mover: " + numMov + " items.");
                            makeUpdate = -1;
                            break;
                        }
                        else
                        {
                            stockAct = stockAct - numMov;
                            table.Rows[i]["actualStock"] = stockAct;
                        }
                        break;
                    }
                }
            }
            if (makeUpdate != -1)
            {
                int rowUpdated = productionItemMovementData.updateData(data, adapt, "Product");
            }            
        }
    }
}
