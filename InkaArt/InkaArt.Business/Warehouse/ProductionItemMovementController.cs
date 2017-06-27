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
        
        public void updateData(int id, int numMov, string typeMovement)
        {
            //productionItemMovementData.connect();
            adapt = productionItemMovementData.ProductionItemMovementAdapter();

            data.Clear();
            data = productionItemMovementData.getData(adapt, "Product");

            table = data.Tables["Product"];
            int makeUpdate = 1;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["idProduct"].ToString()) == id)
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

        

        public NpgsqlDataReader getProductOrder(string idWarehouseStr = "", string idProductOrder = "")
        {
            int intId = -1, intAux, intIdOrder = -1,idWarehouse = -1;
            string query = "", queryDocument = "", insertQuery = "";

            if (!idWarehouseStr.Equals("")) if (int.TryParse(idWarehouseStr, out intAux)) intIdOrder = int.Parse(idWarehouseStr); 
            if (!idProductOrder.Equals("")) if (int.TryParse(idProductOrder, out intAux)) idWarehouse = int.Parse(idProductOrder);

            queryDocument = "select * from inkaart.\"StockDocument\" where \"documentType\" = 'PEDIDO' and \"idDocument\" = " + intIdOrder + ";";
            int cant = productionItemMovementData.WatchDocument(queryDocument);
            //if (cant == 0) //Si no existe ese documento registrado se procede a registrarlo - en este caso se registra el LOTE de producción
            //{
            //Incluso si es que el documento existe lo eliminamos y volvemos a insertar pues puede sufrir actualizaciones en el camino.
                string deleteQuery = "", insertNewTable = "";
                deleteQuery = "delete from inkaart.\"temporaryStock\" where \"documentType\" = 'Pedido' and \"idDocument\" = " + intIdOrder + ";";
                productionItemMovementData.insertData2(deleteQuery);
                insertNewTable = "insert into inkaart.\"temporaryStock\" (\"idDocument\",\"idProduct\",\"stock\",\"documentType\") select A.\"idOrder\",A.\"idProduct\", sum(A.\"quantity\"), 'Pedido'  as \"DocumentType\"  FROM inkaart.\"LineItem\" A, inkaart.\"Order\" B WHERE A.\"idOrder\" = " + intIdOrder + " and B.\"bdStatus\" = 1 and B.\"type\" = 'pedido' and A.\"idOrder\" = B.\"idOrder\" group by 1,2;";
                productionItemMovementData.insertData2(insertNewTable);

            deleteQuery = "delete from inkaart.\"StockDocument\" where \"idDocument\" = " + intIdOrder + " and \"documentType\" = 'PEDIDO';";
                productionItemMovementData.insertData2(deleteQuery);
            insertQuery = "insert into inkaart.\"StockDocument\"  (\"idDocument\", \"product_id\",\"product_stock\",\"documentType\",\"product_type\") select \"idDocument\", \"idProduct\", \"stock\", 'PEDIDO','producto' FROM inkaart.\"temporaryStock\" where \"idDocument\" = " + intIdOrder + " and \"documentType\" = 'Pedido';";
                productionItemMovementData.insertData2(insertQuery);
            //}
            
            //Revisamos si esa factura se encuentra en la tabla StockDocument, de no ser así la aumentamos
            //productionItemMovementData.GetLoteData(query);

            //Obtenemos los productos de ese lote que son admitidos por el almacén seleccionado
            query = "select A.\"idProduct\", B.name, A.stock, D.\"currentStock\", C.product_stock from inkaart.\"temporaryStock\" A,inkaart.\"Product\" B, inkaart.\"StockDocument\" C, inkaart.\"Product-Warehouse\" D where A.\"idProduct\" = B.\"idProduct\" and A.\"idDocument\" = C.\"idDocument\" and A.\"idDocument\" = " + intIdOrder + " and C.\"product_id\" = A.\"idProduct\" and C.\"documentType\" = 'PEDIDO' and D.\"idWarehouse\" = " + idWarehouse + " and D.\"idProduct\" = A.\"idProduct\" and D.\"state\" = 'Activo' and B.\"status\" = 1;";
            return productionItemMovementData.GetLoteData(query);
        }

        public NpgsqlDataReader getProductWarehouseWarehouse(string idWarehouseOrigin,string idWarehouseDestiny) {
            string query = "";
            //Obtenemos los productos de ese lote que son admitidos por el almacén seleccionado
            query = "select A.\"idProduct\", C.\"name\", 'Producto' as \"typeItem\" from inkaart.\"Product-Warehouse\" A, inkaart.\"Product-Warehouse\" B, inkaart.\"Product\" C where A.\"idWarehouse\" = " + idWarehouseOrigin + " and B.\"idWarehouse\" =" + idWarehouseDestiny + " and A.\"idProduct\" = B.\"idProduct\" and A.\"idProduct\" = C.\"idProduct\";";
            return productionItemMovementData.GetLoteData(query);
        }

        public NpgsqlDataReader getQuery(string idWarehouse)
        {
            int intAux, intIdWarehouse = -1;
            string queryDocument = "";

            if (!idWarehouse.Equals("")) if (int.TryParse(idWarehouse, out intAux)) intIdWarehouse = int.Parse(idWarehouse);
            queryDocument = "select A.\"idRawMaterial\",B.\"name\",A.\"currentStock\",A.\"minimunStock\",A.\"maximunStock\" from inkaart.\"RawMaterial-Warehouse\" A, inkaart.\"RawMaterial\" B where A.\"idWarehouse\" = " + intIdWarehouse + " and A.\"idWarehouse\" = B.\"id_raw_material\" and A.\"state\" = 'Activo' and B.\"status\" = 'Activo';";
            
            //Obtenemos los productos de ese lote que son admitidos por el almacén seleccionado
            return productionItemMovementData.GetLoteData(queryDocument);
        }

        public NpgsqlDataReader getQueryCreditNote(string idWarehouse, int idCreditNote)
        {
            int intAux, intIdWarehouse = -1;
            string queryDocument = "";

            if (!idWarehouse.Equals("")) if (int.TryParse(idWarehouse, out intAux)) intIdWarehouse = int.Parse(idWarehouse);
            queryDocument = "select B.\"idProduct\",D.\"name\",B.\"quantity\",C.\"currentStock\" from inkaart.\"Order\" A,inkaart.\"LineItem\" B, inkaart.\"Product-Warehouse\" C, inkaart.\"Product\" D where A.\"idOrder\" = " + idCreditNote + " and A.\"orderStatus\" = 'registrado' and A.\"type\" = 'devolucion' and A.\"idOrder\" = B.\"idOrder\" and B.\"idProduct\" = C.\"idProduct\" and C.\"state\" = 'Activo' and B.\"idProduct\" = D.\"idProduct\" and C.\"idWarehouse\" = " + intIdWarehouse + ";";

            //Obtenemos los productos de ese lote que son admitidos por el almacén seleccionado
            return productionItemMovementData.GetLoteData(queryDocument);
        }

        public NpgsqlDataReader getProductLote(string id = "",string idLote = "")
        {
            int intId = -1, intAux, intIdLote = -1, intIdWarehouse = -1;
            string query = "", queryDocument= "", insertQuery = "";

            if (!idLote.Equals("")) if (int.TryParse(idLote, out intAux)) intIdLote = int.Parse(idLote);
            queryDocument = "select * from inkaart.\"StockDocument\" where \"documentType\" = 'LOTE' and \"idDocument\" = " + idLote + ";";
            int cant = productionItemMovementData.WatchDocument(queryDocument);
            //if (cant == 0) //Si no existe ese documento registrado se procede a registrarlo - en este caso se registra el LOTE de producción
            //{
            insertQuery = "delete from inkaart.\"StockDocument\" where \"idDocument\" = " + intIdLote + " and \"documentType\" = 'LOTE';" ;
            productionItemMovementData.insertData2(insertQuery);
            insertQuery = "insert into inkaart.\"StockDocument\"  (\"idDocument\", \"documentType\", \"product_id\",\"product_stock\") select id_lote as idDocument, 'LOTE', id_product as product_id, produced as product_stock FROM inkaart.\"RatioPerDay\" WHERE id_lote = " + intIdLote + ";";
            productionItemMovementData.insertData2(insertQuery);
            //}

            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intIdWarehouse = int.Parse(id);

            //Revisamos si esa factura se encuentra en la tabla StockDocument, de no ser así la aumentamos
            //productionItemMovementData.GetLoteData(query);

            //Obtenemos los productos de ese lote que son admitidos por el almacén seleccionado
            query = "select A.\"id_product\", B.\"name\", A.\"produced\", D.\"currentStock\", C.\"product_stock\" from inkaart.\"RatioPerDay\" A,inkaart.\"Product\" B, inkaart.\"StockDocument\" C, inkaart.\"Product-Warehouse\" D where A.\"id_product\" = B.\"idProduct\" and A.\"id_lote\" = C.\"idDocument\" and A.\"id_lote\" = " + intIdLote + " and C.\"product_id\" = A.id_product and C.\"documentType\" = 'LOTE' and D.\"idWarehouse\" = " + intIdWarehouse + " and D.\"idProduct\" = A.\"id_product\" and D.\"state\" = 'Activo';";
            return productionItemMovementData.GetLoteData(query);
        }

        public int availableProductionOut(int idProd,int intIdWarehouse)
        {
            NpgsqlDataReader datos1, datos2;
            string queryProd, queryRawMaterial_Warehouse = "";
            int cant1 = 0, cant2 = 0;

            queryProd = "select count(*) from inkaart.\"RawMaterial\" where \"id_raw_material\" = " + idProd + " and \"state\" = 'Activo';";
            datos1 = productionItemMovementData.GetLoteData(queryProd);
            datos1.Read();
            cant1 = Convert.ToInt32(datos1[0]);

            queryRawMaterial_Warehouse = "select count(*)  from inkaart.\"RawMaterial-Warehouse\" where \"idWarehouse\" = " + intIdWarehouse + " and \"idRawMaterial\" = " + idProd + " and \"state\" = 'Activo';";
            datos2 = productionItemMovementData.GetLoteData(queryRawMaterial_Warehouse);
            datos1.Read();
            cant2 = Convert.ToInt32(datos2[0]);
            
            if ((cant1 >= 1) && (cant2 >= 1))
            {
                return 1;
            }

            return -1;
        }

        public void closeConnection()
        {
            productionItemMovementData.closeConnection();
        }
    }
}
