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

        public void insertMovement(int idLote, int movement_type, int idWare, int id_reason, int document_type,int idWareDestiny, int idItem, int cantMov, int itemType)
        {
            //ProductionItemWarehouseMovementData cnn = new ProductionItemWarehouseMovementData();
            string query = "";
            if (idWareDestiny == -1)
            {
                query = "insert into inkaart.\"Movement\" (\"idBill\",\"idMovementType\",\"idWarehouse\",\"idMovementReason\",\"idDocumentType\",\"dateIn\",\"status\",\"idItem\",\"itemType\",\"quantity\" ) values (" + idLote + "," + movement_type + "," + idWare + "," + id_reason + "," + document_type + ",current_date,1,"+ idItem+","+cantMov+","+itemType+");";
            }
            else
            {
                query = "insert into inkaart.\"Movement\" (\"idBill\",\"idMovementType\",\"idWarehouse\",\"idMovementReason\",\"idDocumentType\",\"dateIn\",\"status\",\"idWarehouseDestiny\",\"idItem\",\"itemType\",\"quantity\") values (" + idLote + "," + movement_type + "," + idWare + "," + id_reason + "," + document_type + ",current_date,1," + idWareDestiny + "," + idItem + "," + cantMov + "," + itemType + ");";
            }
            productionItemWarehouseMovementData.updateDataExecute(query);
        }

        public void updateStockDocument(int idLote, int idProd, int currentStock,int movement, string typeMovement)
        {
            string query = "";
            int newStock = 0;

            if(typeMovement == "Entrada")
            {
                newStock = currentStock - movement;
            }
            else //Movimiento por salida de producto de almacén
            {
                newStock = currentStock - movement;
            }

            query = "update inkaart.\"StockDocument\" set \"product_stock\" = " + newStock + "where \"idDocument\" = " + idLote + " and \"product_id\" = " + idProd + " and \"product_type\" = 'producto';";
            productionItemWarehouseMovementData.updateDataExecute(query);
            productionItemWarehouseMovementData.closeConnection();
        }

        public int updateData(int idProd, int idWarehouse, int numMov, string typeMovement,string stateItem = "")
        {
            //productionItemWarehouseMovementData.connect();
            adapt = productionItemWarehouseMovementData.ProductionItemWarehouseAdapter();

            data.Clear();
            data = productionItemWarehouseMovementData.getData(adapt, "Product-Warehouse");

            table = data.Tables["Product-Warehouse"];
            int makeUpdate = 1;
            int stockAct = -1,maxStock = -1, minStock=9999;//Stock físico
            int logicStock = -1;//Stock lógico
            int filModified = 0,filModified2=0;
            
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if ((Convert.ToInt32(table.Rows[i]["idProduct"].ToString()) == idProd) && (Convert.ToInt32(table.Rows[i]["idWarehouse"].ToString()) == idWarehouse))
                {
                    if (stateItem == "OK")
                    {
                        if (typeMovement == "Entrada")
                        {
                            stockAct = Convert.ToInt32(table.Rows[i]["currentStock"]);
                            maxStock = Convert.ToInt32(table.Rows[i]["maximunStock"]);
                            stockAct = stockAct + numMov;

                            if (stockAct > maxStock)
                            {
                                MessageBox.Show("Error: El límite máximo de stock es: " + maxStock + ".");
                                return -2;
                            }

                            logicStock = Convert.ToInt32(table.Rows[i]["virtualStock"]);
                            logicStock = logicStock + numMov;

                            table.Rows[i]["currentStock"] = stockAct;
                            table.Rows[i]["virtualStock"] = logicStock;

                            filModified++;

                            break;
                        }
                        else
                        {
                            if (typeMovement == "Salida")
                            {
                                stockAct = Convert.ToInt32(table.Rows[i]["currentStock"]);
                                minStock = Convert.ToInt32(table.Rows[i]["minimunStock"]);

                                logicStock = Convert.ToInt32(table.Rows[i]["virtualStock"]);

                                if (stockAct - numMov < 0)
                                {
                                    MessageBox.Show("Usted solo cuenta con: " + stockAct + " items, no puede mover: " + numMov + " items.");
                                    return -2;
                                }
                                else
                                {
                                    stockAct = stockAct - numMov;
                                    if (stockAct < minStock)
                                    {
                                        MessageBox.Show("No se puede tener menos del mínimo stock: " + minStock);
                                        return -2;
                                    }
                                    table.Rows[i]["currentStock"] = stockAct;
                                }
                                filModified++;
                                break;
                            }
                            else
                            {
                                /*DEFINIR LA ENTRADA Y SALIDA DE PRODUCTOS*/
                                stockAct = 1;
                                logicStock = 1;
                            }
                            filModified++;
                        }
                    }
                    else
                    {
                        if (typeMovement == "Entrada")
                        {
                            stockAct = Convert.ToInt32(table.Rows[i]["breaks"]);
                            maxStock = Convert.ToInt32(table.Rows[i]["maximunStock"]);
                            stockAct = stockAct + numMov;

                            if (stockAct > maxStock)
                            {
                                MessageBox.Show("Error: El límite máximo de stock es: " + maxStock + ".");
                                return -2;
                            }

                            logicStock = Convert.ToInt32(table.Rows[i]["virtualStock"]);

                            table.Rows[i]["currentStock"] = stockAct;

                            filModified2++;

                            break;
                        }
                        else
                        {
                            if (typeMovement == "Salida")
                            {
                                stockAct = Convert.ToInt32(table.Rows[i]["breaks"]);
                                minStock = Convert.ToInt32(table.Rows[i]["minimunStock"]);

                                logicStock = Convert.ToInt32(table.Rows[i]["virtualStock"]);

                                if (stockAct - numMov < 0)
                                {
                                    MessageBox.Show("Usted solo cuenta con: " + stockAct + " items, no puede mover: " + numMov + " items.");
                                    return -2;
                                }
                                else
                                {
                                    stockAct = stockAct - numMov;
                                    if (stockAct < minStock)
                                    {
                                        MessageBox.Show("No se puede tener menos del mínimo stock: " + minStock);
                                        return -2;
                                    }
                                    table.Rows[i]["currentStock"] = stockAct;
                                }
                                filModified2++;
                                break;
                            }
                            else
                            {
                                /*DEFINIR LA ENTRADA Y SALIDA DE PRODUCTOS*/
                                stockAct = 1;
                                logicStock = 1;
                            }
                            filModified2++;
                        }
                    }
                }
            }
            if (filModified == 0 && filModified2 == 0)
            {
                return -1;
            }
            if (makeUpdate != -1)
            {
                //int rowUpdated = productionItemWarehouseMovementData.updateData(data, adapt, "Product-Warehouse");
                //update inkaart."Product-Warehouse" set "currentStock" = 10, "virtualStock" = 10 where "idWarehouse" = 31 and "idProduct" = 1;
                string updateQuery="";
                if (filModified > 0)
                {
                    updateQuery = "update inkaart.\"Product-Warehouse\" set \"currentStock\" = " + stockAct + ", \"virtualStock\" = " + logicStock + " where \"idWarehouse\"= " + idWarehouse + " and \"idProduct\" = " + idProd + " ;";
                }
                if (filModified2 > 0)
                {
                    updateQuery = "update inkaart.\"Product-Warehouse\" set \"breaks\" = " + stockAct + ", \"virtualStock\" = " + logicStock + " where \"idWarehouse\"= " + idWarehouse + " and \"idProduct\" = " + idProd + " ;";
                }
                productionItemWarehouseMovementData.updateDataExecute(updateQuery);
            }
            return 1;
        }
    }
}
