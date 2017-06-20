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

        

        public NpgsqlDataReader getProductOrder(string id = "", string idProductOrder = "")
        {
            int intId = -1, intAux, intIdOrder = -1;
            string query = "", queryDocument = "", insertQuery = "";

            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intIdOrder = int.Parse(idProductOrder);
            queryDocument = "select * from inkaart.\"StockDocument\" where \"documentType\" = 'PEDIDO' and \"idDocument\" = " + idProductOrder + ";";
            int cant = productionItemMovementData.WatchDocument(queryDocument);
            //if (cant == 0) //Si no existe ese documento registrado se procede a registrarlo - en este caso se registra el LOTE de producción
            //{
            //Incluso si es que el documento existe lo eliminamos y volvemos a insertar pues puede sufrir actualizaciones en el camino.
                string deleteQuery = "", insertNewTable = "";
                deleteQuery = "delete from inkaart.\"temporaryStock\" where \"documentType\" = 'PEDIDO' and \"idDocument\" = " + idProductOrder + ";";
                productionItemMovementData.insertData2(deleteQuery);
                insertNewTable = "insert into inkaart.\"temporaryStock\" (\"idDocument\",\"idProduct\",\"stock\") select \"idOrder\",\"idProduct\", sum(\"quantity\") FROM inkaart.\"LineItem\" WHERE \"idOrder\" = " + intIdOrder + " group by 1,2;";
                productionItemMovementData.insertData2(insertNewTable);
                insertQuery = "insert into inkaart.\"StockDocument\"  (\"idDocument\", \"product_id\",\"product_stock\",\"documentType\",\"product_type\") select \"idDocument\", \"idProduct\", \"stock\", 'PEDIDO','producto' FROM inkaart.\"temporaryStock\";";
                productionItemMovementData.insertData2(insertQuery);
            //}

            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intId = int.Parse(id);

            //Revisamos si esa factura se encuentra en la tabla StockDocument, de no ser así la aumentamos
            //productionItemMovementData.GetLoteData(query);

            //Obtenemos los productos de ese lote que son admitidos por el almacén seleccionado
            query = "select A.\"idProduct\", B.name, A.stock, C.product_stock from inkaart.\"temporaryStock\" A,inkaart.\"Product\" B, inkaart.\"StockDocument\" C where A.\"idProduct\" = B.\"idProduct\" and A.\"idDocument\" = C.\"idDocument\" and A.\"idDocument\" = " + intId + " and C.\"product_id\" = A.\"idProduct\" and C.\"documentType\" = 'PEDIDO';";
            return productionItemMovementData.GetLoteData(query);
        }

        public NpgsqlDataReader getProductLote(string id = "",string idLote = "")
        {
            int intId = -1, intAux, intIdLote = -1;
            string query = "", queryDocument= "", insertQuery = "";

            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intId = int.Parse(idLote);
            queryDocument = "select * from inkaart.\"StockDocument\" where \"documentType\" = 'LOTE' and \"idDocument\" = " + idLote + ";";
            int cant = productionItemMovementData.WatchDocument(queryDocument);
            if (cant == 0) //Si no existe ese documento registrado se procede a registrarlo - en este caso se registra el LOTE de producción
            {
                insertQuery = "insert into inkaart.\"StockDocument\"  (\"idDocument\", \"documentType\", \"product_id\",\"product_stock\") select id_lote as idDocument, 'LOTE', id_product as product_id, produced as product_stock FROM inkaart.\"RatioPerDay\" WHERE id_lote = " + intIdLote + ";";
                productionItemMovementData.insertData2(insertQuery);
            }

            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intId = int.Parse(id);

            //Revisamos si esa factura se encuentra en la tabla StockDocument, de no ser así la aumentamos
            //productionItemMovementData.GetLoteData(query);

            //Obtenemos los productos de ese lote que son admitidos por el almacén seleccionado
            query = "select A.id_product, B.name, A.produced, C.product_stock from inkaart.\"RatioPerDay\" A,inkaart.\"Product\" B, inkaart.\"StockDocument\" C where A.id_product = B.\"idProduct\" and A.id_lote = C.\"idDocument\" and A.id_lote = " + intId + " and C.\"product_id\" = A.id_product and C.\"documentType\" = 'LOTE';";
            return productionItemMovementData.GetLoteData(query);
        }

        public void closeConnection()
        {
            productionItemMovementData.closeConnection();
        }
    }
}
