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
        private MovementData movementData = new MovementData();
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
        
        public void updateData(int idProduct, int numMov, string typeMovement)
        {
            string query = "";
            int stockAct = 0,logicStock=0, makeUpdate=-1;
            //productionItemMovementData.connect();
            NpgsqlDataReader dr;
            query = "select \"actualStock\",\"logicalStock\" from inkaart.\"Product\" where \"idProduct\" = " + idProduct + " and \"status\" = 1;";
            dr = productionItemMovementData.GetLoteData(query);
            dr.Read();
            stockAct = Convert.ToInt32(dr[0]);
            logicStock = Convert.ToInt32(dr[1]);

            if (typeMovement == "Entrada")
            {
                stockAct = stockAct + numMov;
                logicStock = logicStock + numMov;
                makeUpdate = 1;
            }
            if (typeMovement == "Salida")
            {
                if (stockAct - numMov < 0)
                {
                    MessageBox.Show("Usted solo cuenta con: " + stockAct + " items, no puede mover: " + numMov + " items.");
                    makeUpdate = -1;
                }
                else
                {
                    stockAct = stockAct - numMov;
                    makeUpdate = 1;
                }
            }

            string updateQuery = "";
            if (makeUpdate != -1)
            {
                updateQuery = "update inkaart.\"Product\" set \"actualStock\" = " + stockAct + ", \"logicalStock\" = " + logicStock + " where \"idProduct\" = " + idProduct + " and \"status\" = 1";

                //productionItemWarehouseMovementData.updateDataExecute(updateQuery);

                ProductionItemWarehouseMovementData aux = new ProductionItemWarehouseMovementData();

                aux.updateDataExecute(updateQuery);
                
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
            queryDocument = "select A.\"idRawMaterial\",B.\"name\",A.\"currentStock\",A.\"minimunStock\",A.\"maximunStock\" from inkaart.\"RawMaterial-Warehouse\" A, inkaart.\"RawMaterial\" B where A.\"idWarehouse\" = " + intIdWarehouse + " and A.\"idRawMaterial\" = B.\"id_raw_material\" and A.\"state\" = 'Activo' and B.\"status\" = 'Activo';";
            
            //Obtenemos los productos de ese lote que son admitidos por el almacén seleccionado
            return productionItemMovementData.GetLoteData(queryDocument);
        }

        public NpgsqlDataReader getQueryProd(string idWarehouse)
        {
            int intAux, intIdWarehouse = -1;
            string queryDocument = "";

            if (!idWarehouse.Equals("")) if (int.TryParse(idWarehouse, out intAux)) intIdWarehouse = int.Parse(idWarehouse);
            queryDocument = "select A.\"idProduct\",B.\"name\",A.\"currentStock\",A.\"minimunStock\",A.\"maximunStock\" from inkaart.\"Product-Warehouse\" A, inkaart.\"Product\" B where A.\"idWarehouse\" = " + intIdWarehouse + " and A.\"idProduct\" = B.\"idProduct\" and A.\"state\" = 'Activo' and B.\"status\" = 1;";

            //Obtenemos los productos de ese lote que son admitidos por el almacén seleccionado
            return productionItemMovementData.GetLoteData(queryDocument);
        }

        public NpgsqlDataReader getQueryDevolution(int id_warehouse, string str_devolution)
        {
            int id_devolution;
            if (!int.TryParse(str_devolution, out id_devolution)) id_devolution = -1;

            string query = "select B.\"idProduct\",D.\"name\",B.\"quantity\",C.\"currentStock\",C.\"minimunStock\",C.\"maximunStock\"  " + 
                "from inkaart.\"Order\" A,inkaart.\"LineItem\" B, inkaart.\"Product-Warehouse\" C, inkaart.\"Product\" D " + 
                "where A.\"idOrder\" = " + id_devolution + " and A.\"orderStatus\" = 'registrado' and A.\"type\" = 'devolucion' and A.\"idOrder\" = B.\"idOrder\" and B.\"idProduct\" = C.\"idProduct\" and C.\"state\" = 'Activo' and B.\"idProduct\" = D.\"idProduct\" and C.\"idWarehouse\" = " + id_warehouse + " and D.\"status\" = 1;";         
         
            //Obtenemos el data reader
            return productionItemMovementData.GetLoteData(query);
        }

        int existeElementoInt(int elemento, int [] arreglo, int cantidad)
        {
            int tam = 0;

            while(tam < cantidad)
            {
                if (elemento == arreglo[tam]) return 1;
                tam++;
            }
            return -1;
        }

        public NpgsqlDataReader getProductLote(string id = "",string idLote = "")
        {
            int intId = -1, intAux, intIdLote = -1, intIdWarehouse = -1,existe = 0;
            string query = "";

            if (!idLote.Equals("")) if (int.TryParse(idLote, out intAux)) intIdLote = int.Parse(idLote);
            query = "select product_id from inkaart.\"StockDocument\" where \"documentType\" = 'LOTE' and \"idDocument\" = " + idLote + " order by 1 asc;";
            NpgsqlDataReader dr = movementData.executeQueryData(query);

            query = "select id_product, produced as \"product_stock\" FROM inkaart.\"RatioPerDay\" WHERE id_lote = " + intIdLote + " order by 1 asc;";
            NpgsqlDataReader dr2 = movementData.executeQueryData(query);
            int fin = 0, tamDr1=0,tamDr2=0;
            int[] arrDr1 = new int[500];
            int[] arrDr2 = new int[500];

            while (dr.Read())
            {
                arrDr1[tamDr1] = Convert.ToInt32(dr[0]);
                tamDr1++;
            }
            while (dr2.Read())
            {
                arrDr2[tamDr2] = Convert.ToInt32(dr2[0]);
                tamDr2++;
            }
            for (int i = 0; i < tamDr2; i++)
            {
                existe = existeElementoInt(arrDr2[i], arrDr1, tamDr1);
                if (existe == -1)//Cuando no existe el producto se agrega a la tabla
                {
                    query = "insert into inkaart.\"StockDocument\"  (\"idDocument\", \"documentType\", \"product_id\",\"product_stock\") select id_lote as idDocument, 'LOTE', id_product as product_id, produced as \"product_stock\" FROM inkaart.\"RatioPerDay\" WHERE id_lote = " + intIdLote + " and \"id_product\" = " + arrDr2[i] + ";";
                    movementData.updateData(query);
                }
            }
            for (int i = 0; i < tamDr1; i++)
            {
                existe = existeElementoInt(arrDr1[i], arrDr2, tamDr2);
                if (existe == -1)//Cuando un producto fue eliminado se borra de la tabla
                {
                    query = "delete from inkaart.\"StockDocument\" where \"idDocument\" = " + intIdLote + " and \"documentType\" = 'LOTE' and \"product_id\" = " + arrDr1[i] + ";";
                    movementData.updateData(query);
                }
            }
            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intIdWarehouse = int.Parse(id);

            //Obtenemos los productos de ese lote que son admitidos por el almacén seleccionado
            query = "select A.\"id_product\", B.\"name\", A.\"produced\", D.\"currentStock\", C.\"product_stock\" from inkaart.\"RatioPerDay\" A,inkaart.\"Product\" B, inkaart.\"StockDocument\" C, inkaart.\"Product-Warehouse\" D where A.\"id_product\" = B.\"idProduct\" and A.\"id_lote\" = C.\"idDocument\" and A.\"id_lote\" = " + intIdLote + " and C.\"product_id\" = A.id_product and C.\"documentType\" = 'LOTE' and D.\"idWarehouse\" = " + intIdWarehouse + " and D.\"idProduct\" = A.\"id_product\" and D.\"state\" = 'Activo';";
            return productionItemMovementData.GetLoteData(query);
        }

        public int availableProductionOut(int idProd,int intIdWarehouse)
        {
            NpgsqlDataReader datos1, datos2;
            string queryProd, queryRawMaterial_Warehouse = "";
            int cant1 = 0, cant2 = 0;

            queryProd = "select count(*) from inkaart.\"RawMaterial\" where \"id_raw_material\" = " + idProd + " and \"status\" = 'Activo';";
            datos1 = productionItemMovementData.GetLoteData(queryProd);
            datos1.Read();
            cant1 = Convert.ToInt32(datos1[0]);

            queryRawMaterial_Warehouse = "select count(*)  from inkaart.\"RawMaterial-Warehouse\" where \"idWarehouse\" = " + intIdWarehouse + " and \"idRawMaterial\" = " + idProd + " and \"state\" = 'Activo';";
            datos2 = productionItemMovementData.GetLoteData(queryRawMaterial_Warehouse);
            datos2.Read();
            cant2 = Convert.ToInt32(datos2[0]);
            
            if ((cant1 >= 1) && (cant2 >= 1))
            {
                return 1;
            }

            return -1;
        }

        public int availableReturn(int idProd, int intIdWarehouse)
        {
            NpgsqlDataReader datos1, datos2;
            string queryProd, queryRawMaterial_Warehouse = "";
            int cant1 = 0, cant2 = 0;

            queryProd = "select count(*) from inkaart.\"Product\" where \"idProduct\" = " + idProd + " and \"status\" = 1;";
            datos1 = productionItemMovementData.GetLoteData(queryProd);
            datos1.Read();
            cant1 = Convert.ToInt32(datos1[0]);

            queryRawMaterial_Warehouse = "select count(*)  from inkaart.\"Product-Warehouse\" where \"idWarehouse\" = " + intIdWarehouse + " and \"idProduct\" = " + idProd + " and \"state\" = 'Activo';";
            datos2 = productionItemMovementData.GetLoteData(queryRawMaterial_Warehouse);
            datos2.Read();
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
