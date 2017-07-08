using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using InkaArt.Data.Warehouse;
using System.Data;

namespace InkaArt.Business.Warehouse
{
    public class MovementController
    {

        private MovementData movement_data;
        

        public MovementController()
        {
            movement_data = new MovementData();
        }

        private void insertaWhereTexto(ref string query,string fieldName, string name,ref int existeWhere)
        {
            if (name != "")
            {
                if (existeWhere == 1)
                {
                    query = query + " and \"" + fieldName + "\" = " + "'" + name + "'";
                }
                else
                {
                    query = query + " where \"" + fieldName + "\" = " + "'" + name + "'";
                    existeWhere = 1;
                }
            }
        }
        private void insertaWhereInt(ref string query, string fieldName, int entero,ref int existeWhere)
        {
            if (entero != -2)
            {
                if (existeWhere == 1)
                {
                    query = query + " and \"" + fieldName + "\" = " + entero;
                }
                else
                {
                    query = query + " where \"" + fieldName + "\" = " + entero;
                    existeWhere = 1;
                }
            }
        }
        
        public int populateComboBox(NpgsqlDataReader dr, ComboBox combobox_type)
        {
            int rowIndex = 0;
            while (dr.Read())
            {
                combobox_type.Items.Add(dr[0]);
                rowIndex++;
            }
            return rowIndex;
        }

        public NpgsqlDataReader GetWarehouseList(int idWarehouse = -2, string name = "", string address = "",int prohibitedWarehouse = 0)
        {
            int existeWhere =0;
            string query = "";
            
            if(prohibitedWarehouse == 0)
            {
                query = "select \"idWarehouse\", \"name\",\"address\", \"state\" from inkaArt.\"Warehouse\" ";
            }
            else
            {
                query = "select \"idWarehouse\", \"name\",\"address\", \"state\" from inkaArt.\"Warehouse\" where \"idWarehouse\" <> " + prohibitedWarehouse;
                existeWhere = 1;
            }            

            insertaWhereInt(ref query, "idWarehouse", idWarehouse,ref existeWhere);
            insertaWhereTexto(ref query, "name", name,ref existeWhere);
            insertaWhereTexto(ref query, "address",address,ref existeWhere);
            insertaWhereTexto(ref query, "state","Activo",ref existeWhere);
            query = query + ";";

            return movement_data.executeQueryData(query);
        }

        public NpgsqlDataReader GetTypeMovementList()
        {
            NpgsqlDataReader dr;
            string query = "";

            query = "select \"description\" from inkaArt.\"MovementType\";";
            dr = movement_data.executeQueryData(query);
            return dr;
        }

        public DataTable GetMovements(bool filters = false, string str_id = "", string str_type = "", string str_reason = "", string str_warehouse = "", string str_date = null, string str_status = "")
        {
            if (filters)
            {
                int id = str_id == ""? -1 : int.Parse(str_id);
                int type = str_type == "" ? -1 : int.Parse(str_type);
                int reason = str_reason == "" ? -1 : int.Parse(str_reason);
                int warehouse = str_warehouse == "" ? -1 : int.Parse(str_warehouse);
                int status = str_status == "" ? -1 : int.Parse(str_status);

                return movement_data.GetMovements(id, type, reason, warehouse, str_date, status);
            }

            return movement_data.GetMovements();
        }

        public string getReasonDescription(string reason_id)
        {
            int id = reason_id == "" ? -1 : int.Parse(reason_id);
            DataRow reason = movement_data.getMovementReason(id);
            return reason == null? "" : reason["description"].ToString();
        }

        public string getTypeDescription(string type_id)
        {
            int id = type_id == "" ? -1 : int.Parse(type_id);
            DataRow type = movement_data.getMovementType(id);
            return type == null? "" : type["description"].ToString();
        }

        public string getWarehouseName(string warehouse_id)
        {
            int id = warehouse_id == "" ? -1 : int.Parse(warehouse_id);
            DataRow warehouse = movement_data.getWarehouse(id);
            return warehouse == null ? "" : warehouse["name"].ToString();
        }

        public string getItemName(int item_type, string item_id)
        {
            int id = item_id == "" ? -1 : int.Parse(item_id);
            DataRow item = item_type == 0 ? movement_data.getRawMaterial(id) : movement_data.getProduct(id);
            return item == null ? "" : item["name"].ToString();
        }

        public void deleteMovements(List<string> ids)
        {
            movement_data.deleteMovements(ids);
        }

        public void updateOrder(int idOrder)
        {
            string query = "";
            int remainOrder = 0;
            NpgsqlDataReader dr;

            query = "select \"idDocument\", sum(\"product_stock\") as suma from inkaart.\"StockDocument\" where \"vez\" = 0 and \"idDocument\" = " + idOrder + " group by 1;";

            dr = movement_data.executeQueryData(query);
            dr.Read();
            remainOrder = Convert.ToInt32(dr[1]);

            if (remainOrder == 0)
            {
                query = "Update inkaart.\"Order\" set \"orderStatus\" = 'despachado' where \"idOrder\" = " + idOrder + " where \"orderStatus\" = 'registrado';";
                movement_data.updateData(query);
            }

        }

        private int verifyStockDocument(int idDoc, int idProd, int numMov, string stockMovement)
        {
            int cantidadPorEntregar = 0;
            string query = "";
            NpgsqlDataReader dr;

            query = "select \"product_stock\" from inkaart.\"StockDocument\" where \"idDocument\" = " + idDoc + " and \"product_id\" = " + idProd + " and \"documentType\" = '" + stockMovement + "';";
            dr = movement_data.executeQueryData(query);
            dr.Read();
            cantidadPorEntregar = Convert.ToInt32(dr[0]);

            if (cantidadPorEntregar - numMov < 0)
            {
                MessageBox.Show("Usted no puede entregar más items de los que dice el documento. Puede entregar como máximo: " + cantidadPorEntregar + ".");
                return -1;
            }

            return 1;
        }

        private int verifyUpdateProduct(int idProd,string productType)
        {
            string query = "";
            NpgsqlDataReader dr;
            int existe = 0;

            //Se obtiene la query para ver los stocks máximos y mínimos
            if (productType == "Producto")
            {
                query = "select count(*) from inkaart.\"Product\" where \"idProduct\" = " + idProd + " and \"status\" = 1;";
            }
            else if (productType == "Materia Prima")
            {
                query = "select count(*) from inkaart.\"RawMaterial\" where \"id_raw_material\" = " + idProd + " and \"status\" = 'Activo';";
            }
            dr = movement_data.executeQueryData(query);
            dr.Read();
            existe = Convert.ToInt32(dr[0]);
            if (existe == 0) {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        //Todos los movimientos verifican esto
        public int verifyMovement(int idProd, int idWarehouse, int numMov, int idPedido, string typeMovement, string typeReason, string productType, string stockMovement)
        {
            //Se verifica que el stock en la relación producto-almacén no sea mayor al máximo ni menor al mínimo
            int res1 = 0;
            res1 = verifyUpdateProductWarehouse(idProd, idWarehouse, numMov, typeMovement, typeReason, productType);
            if (res1 == -1) return -1;

            //Se verifica que no se entregue más de lo que el documento permite
            if(idPedido != -1)
            {
                res1 = verifyStockDocument(idPedido, idProd, numMov, stockMovement);
                if (res1 == -1) return -1;
            }

            //Se verifica que exista el producto
            res1 = verifyUpdateProduct(idProd, productType);
            if (res1 == -1) return -1;

            //Se verifica que exista la relación producto-warehouse

            return 1;
        }

        private int verifyUpdateProductWarehouse(int idProd, int idWarehouse, int numMov, string typeMovement,string typeReason, string productType)
        {
            NpgsqlDataReader dr,dr2;
            int stockAct = -1, maxStock = -1, minStock = 9999,logicStockProd=-1, actualStockProd = -1;//Stock físico
            string query = "",query2 = "";

            //Se obtiene la query para ver los stocks máximos y mínimos
            if(productType == "Producto")
            {
                query = "select \"currentStock\",\"minimunStock\", \"maximunStock\", \"virtualStock\" from inkaart.\"Product-Warehouse\" where \"idWarehouse\" = " + idWarehouse + " and \"idProduct\" = " + idProd + " and \"state\" = 'Activo';";
                query2 = "select \"logicalStock\", \"actualStock\" from inkaart.\"Product\" where \"idProduct\" = " + idProd + " and \"status\" = 1;";
            }
            else if (productType == "Materia Prima")
            {
                query = "select \"currentStock\",\"minimunStock\", \"maximunStock\", \"virtualStock\" from inkaart.\"RawMaterial-Warehouse\" where \"idWarehouse\" = " + idWarehouse + " and \"idRawMaterial\" = " + idProd + " and \"state\" = 'Activo';";
            }
            //Se sacan los valores
            dr = movement_data.executeQueryData(query);
            dr.Read();
            //Se sacan los valores
            if(query2 != "")
            {
                dr2 = movement_data.executeQueryData(query2);
                dr2.Read();
                logicStockProd = Convert.ToInt32(dr2[0]);
                actualStockProd = Convert.ToInt32(dr2[1]);
            }
            stockAct = Convert.ToInt32(dr[0]);
            minStock = Convert.ToInt32(dr[1]);
            maxStock = Convert.ToInt32(dr[2]);

            //Verificar los stock mínimo y máximos
            if (typeMovement == "Entrada")
            {
                if (typeReason.ToUpper() == "PRODUCCIÓN")
                {
                    stockAct = stockAct + numMov;
                    actualStockProd = actualStockProd + numMov;
                    logicStockProd = logicStockProd + numMov;
                }
                if (typeReason.ToUpper() == "HALLAZGO")
                {
                    stockAct = stockAct + numMov;
                    actualStockProd = actualStockProd + numMov;
                    logicStockProd = logicStockProd + numMov;
                }
                if (typeReason.ToUpper() == "DEVOLUCION")
                {
                    stockAct = stockAct + numMov;
                    actualStockProd = actualStockProd + numMov;
                    logicStockProd = logicStockProd + numMov;
                }
            }
            if (typeMovement == "Salida")
            {
                if (typeReason.ToUpper() == "PRODUCCIÓN")
                {
                    stockAct = stockAct - numMov;
                    actualStockProd = actualStockProd - numMov;
                }
                if (typeReason.ToUpper() == "ROTURA")
                {
                    stockAct = stockAct - numMov;
                    actualStockProd = actualStockProd - numMov;
                    logicStockProd = logicStockProd - numMov;
                }
                if (typeReason.ToUpper() == "VENTA")
                {
                    stockAct = stockAct - numMov;
                    actualStockProd = actualStockProd - numMov;
                }
            }
            //Se verifica que el nuevo stock no pase del máximo
            if (stockAct > maxStock)
            {
                MessageBox.Show("No se puede tener más del stock máximo: " + maxStock + ". Para el almacén: " + idWarehouse + ".");
                return -1;
            }
            //Se verifica que el nuevo stock no sea menor al mínimo
            if (stockAct < minStock)
            {
                MessageBox.Show("No se puede tener menos del stock mínimo: " + minStock + ". Para el almacén: " + idWarehouse + ".");
                return -1;
            }
            //Verificar que el stock virtual nunca sea mayor al físico
            if (actualStockProd < logicStockProd)
            {
                MessageBox.Show("Su stock virtual será: " + logicStockProd + " y su físico será: " + stockAct + ". Su stock virtual no puede ser mayor al físico, favor de revisar");
                return -1;
            }

            return 1;
        }

        //Funcion a llamar en movimientos
        public void updateStockDocument(int idDoc, int idProd, int cantidadPorEntregar, int movement, string stockMovement)
        {
            string query = "";
            int newStock = 0, cantMoved = 0;
            NpgsqlDataReader dr;
            //la variable movementReason podrá ser 'LOTE', 'FACTURA', 'VENTA', ETC.

            //En el caso de que no exista el item en la tabla stock-document este se agregará

            newStock = cantidadPorEntregar - movement;
            query = "select \"cantmoved\" from inkaart.\"StockDocument\" where \"idDocument\" = " + idDoc + " and \"product_id\" = " + idProd + " and \"documentType\" = '" + stockMovement + "';";
            dr = movement_data.executeQueryData(query);
            dr.Read();
            cantMoved = Convert.ToInt32(dr[0]);
            cantMoved = cantMoved + movement;

            query = "update inkaart.\"StockDocument\" set \"product_stock\" = " + newStock + ", \"cantmoved\" = " + cantMoved + " where \"idDocument\" = " + idDoc + " and \"product_id\" = " + idProd + " and \"documentType\" = '" + stockMovement + "';";
            movement_data.updateData(query);
            //movement_data.closeConnection();
        }

        public void insertMovement(int idDoc, int movement_type, int idWare, int id_reason, int document_type, int idWareDestiny, int idItem, int cantMov, int productType)
        {
            //ProductionItemWarehouseMovementData cnn = new ProductionItemWarehouseMovementData();
            string query = "";
            if (idWareDestiny == -1)
            {
                query = "insert into inkaart.\"Movement\" (\"idBill\",\"idMovementType\",\"idWarehouse\",\"idMovementReason\",\"idDocumentType\",\"dateIn\",\"status\",\"idItem\",\"itemType\",\"quantity\" ) values (" + idDoc + "," + movement_type + "," + idWare + "," + id_reason + "," + document_type + ",current_date,1," + idItem + "," + productType + "," + cantMov + ");";
            }
            else
            {
                query = "insert into inkaart.\"Movement\" (\"idBill\",\"idMovementType\",\"idWarehouse\",\"idMovementReason\",\"idDocumentType\",\"dateIn\",\"status\",\"idWarehouseDestiny\",\"idItem\",\"itemType\",\"quantity\") values (" + idDoc + "," + movement_type + "," + idWare + "," + id_reason + "," + document_type + ",current_date,1," + idWareDestiny + "," + idItem + "," + productType + "," + cantMov + ");";
            }
            movement_data.updateData(query);
        }

        //Función a llamar en movimientos
        public void updateProductStock(int idProduct, int numMov, string typeMovement, string typeReason)
        {
            string query = "";
            int stockAct = 0, logicStock = 0, makeUpdate = -1;

            //Se obtiene el stock físico y lógico para proseguir
            NpgsqlDataReader dr;
            query = "select \"actualStock\",\"logicalStock\" from inkaart.\"Product\" where \"idProduct\" = " + idProduct + " and \"status\" = 1;";
            dr = movement_data.executeQueryData(query);
            dr.Read();
            stockAct = Convert.ToInt32(dr[0]);
            logicStock = Convert.ToInt32(dr[1]);

            if (typeMovement == "Entrada")
            {
                if(typeReason == "Producción")
                {
                    stockAct = stockAct + numMov;
                    logicStock = logicStock + numMov;
                    makeUpdate = 1;
                }
                if (typeReason == "Hallazgo")
                {
                    stockAct = stockAct + numMov;
                    logicStock = logicStock + numMov;
                    makeUpdate = 1;
                }
                if (typeReason == "Devolucion")
                {
                    stockAct = stockAct + numMov;
                    logicStock = logicStock + numMov;
                    makeUpdate = 1;
                }
            }
            if (typeMovement == "Salida")
            {
                if (typeReason == "Producción")
                {
                    stockAct = stockAct - numMov;
                    makeUpdate = 1;
                }
                if (typeReason == "Rotura")
                {
                    stockAct = stockAct - numMov;
                    logicStock = logicStock - numMov;
                    makeUpdate = 1;
                }
                if (typeReason == "Venta")
                {
                    stockAct = stockAct - numMov;
                    makeUpdate = 1;
                }
            }

            if (makeUpdate != -1)
            {
                query = "update inkaart.\"Product\" set \"actualStock\" = " + stockAct + ", \"logicalStock\" = " + logicStock + " where \"idProduct\" = " + idProduct + " and \"status\" = 1";
                
                movement_data.updateData(query);

            }
        }

        private int getNewStock(int idProd, int idWarehouse, int numMov, string typeMovement, string productType,ref int stockAct)
        {
            NpgsqlDataReader dr;
            int maxStock = -1, minStock = 9999;//Stock físico
            string query = "";

            //Se obtiene la query para ver los stocks máximos y mínimos
            if (productType == "Producto")
            {
                query = "select \"currentStock\",\"minimunStock\", \"maximunStock\", \"virtualStock\" from inkaart.\"Product-Warehouse\" where \"idWarehouse\" = " + idWarehouse + " and \"idProduct\" = " + idProd + " and \"state\" = 'Activo';";
            }
            else if (productType == "Materia Prima")
            {
                query = "select \"currentStock\",\"minimunStock\", \"maximunStock\", \"virtualStock\" from inkaart.\"RawMaterial-Warehouse\" where \"idWarehouse\" = " + idWarehouse + " and \"idRawMaterial\" = " + idProd + " and \"state\" = 'Activo';";
            }
            //Se sacan los valores
            dr = movement_data.executeQueryData(query);
            dr.Read();
            stockAct = Convert.ToInt32(dr[0]);
            minStock = Convert.ToInt32(dr[1]);
            maxStock = Convert.ToInt32(dr[2]);

            //Para la entrada se verifica que no se pase del stock máximo
            if (typeMovement == "Entrada")
            {
                stockAct = stockAct + numMov;
                if (stockAct > maxStock)
                {
                    MessageBox.Show("No se puede tener más del stock máximo: " + maxStock + ". Para el almacén: " + idWarehouse + ".");
                    return -1;
                }
            }//Para la salida se verifica que no tenga menos del stock mínimo
            else if (typeMovement == "Salida")
            {
                stockAct = stockAct - numMov;
                if (stockAct < minStock)
                {
                    MessageBox.Show("No se puede tener menos del stock mínimo: " + minStock + ". Para el almacén: " + idWarehouse + ".");
                    return -1;
                }
            }
            return 1;
        }

        //Función a llamar en movimientos
        public int updateProductWarehouse(int idProd, int idWarehouse, int numMov, string typeMovement, string productType = "")
        {
            int stockAct = -1;//Stock físico
            int filModified = 0;
            //ProductType = "Producto" o "Materia Prima"

            filModified = getNewStock(idProd, idWarehouse, numMov, typeMovement, productType,ref stockAct);
            
            string updateQuery = "";
            if (filModified > 0)
            {
                if (productType == "Producto")
                {
                    updateQuery = "update inkaart.\"Product-Warehouse\" set \"currentStock\" = " + stockAct + ", \"virtualStock\" = " + stockAct + " where \"idWarehouse\"= " + idWarehouse + " and \"idProduct\" = " + idProd + " and \"state\" = 'Activo';";
                    movement_data.updateData(updateQuery);
                }
                if (productType == "Materia Prima")
                {
                    updateQuery = "update inkaart.\"RawMaterial-Warehouse\" set \"currentStock\" = " + stockAct + ", \"virtualStock\" = " + stockAct + " where \"idWarehouse\"= " + idWarehouse + " and \"idRawMaterial\" = " + idProd + " and \"state\" = 'Activo';";
                    movement_data.updateData(updateQuery);
                }
            }
            
            return 1;
        }

        private int existeElementoInt(int elemento, int[] arreglo, int cantidad)
        {
            int tam = 0;

            while (tam < cantidad)
            {
                if (elemento == arreglo[tam]) return 1;
                tam++;
            }
            return -1;
        }

        public NpgsqlDataReader getProductStockSales(string id_warehouse = "", string id_order = "")
        {
            int intAux, int_order = -1, int_warehouse = -1, existe = 0;
            string query = "";

            int.TryParse(id_order, out int_order);

            query = "SELECT product_id FROM inkaart.\"StockDocument\" " + 
                "WHERE \"documentType\" = 'VENTA' AND \"idDocument\" = " + id_order + " ORDER BY 1 asc;";
            NpgsqlDataReader dr_stock = movement_data.executeQueryData(query);

            query = "SELECT B.\"idProduct\", sum(\"quantity\") as \"product_stock\" " + 
                "FROM inkaart.\"Order\" A, inkaart.\"LineItem\" B " + 
                "WHERE A.\"idOrder\" = " + int_order + " AND A.\"idOrder\" = B.\"idOrder\" AND A.\"bdStatus\" = 1 " + 
                "GROUP BY B.\"idProduct\" ORDER BY 1 asc;";
            NpgsqlDataReader dr_lines = movement_data.executeQueryData(query);

            int tam_stock = 0, tam_lines = 0;
            int[] arr_stock = new int[500];
            int[] arr_lines = new int[500];

            while (dr_stock.Read())
            {
                arr_stock[tam_stock] = Convert.ToInt32(dr_stock[0]);
                tam_stock++;
            }
            while (dr_lines.Read())
            {
                arr_lines[tam_lines] = Convert.ToInt32(dr_lines[0]);
                tam_lines++;
            }
            for (int i = 0; i < tam_lines; i++)
            {
                existe = existeElementoInt(arr_lines[i], arr_stock, tam_stock);
                if (existe == -1)//Cuando no existe el producto se agrega a la tabla
                {
                    query = "INSERT INTO inkaart.\"StockDocument\" " + 
                        "(\"idDocument\", \"documentType\", \"product_id\",\"product_stock\") " +
                        "SELECT B.\"idOrder\", 'VENTA', B.\"idProduct\", sum(B.\"quantity\") " +
                        "FROM inkaart.\"LineItem\" B " +
                        "WHERE B.\"idOrder\" = " + int_order + " AND B.\"idProduct\" = " + arr_lines[i] +
                        "GROUP BY B.\"idOrder\", B.\"idProduct\";";
                    movement_data.updateData(query);
                }
            }
            for (int i = 0; i < tam_stock; i++)
            {
                existe = existeElementoInt(arr_stock[i], arr_lines, tam_lines);
                if (existe == -1)//Cuando un producto fue eliminado se borra de la tabla
                {
                    query = "DELETE FROM inkaart.\"StockDocument\" " +
                        "WHERE \"idDocument\" = " + int_order + " AND \"documentType\" = 'VENTA' AND \"product_id\" = " + arr_stock[i] + ";";
                    movement_data.updateData(query);
                }
            }
            if (!id_warehouse.Equals("")) if (int.TryParse(id_warehouse, out intAux)) int_warehouse = int.Parse(id_warehouse);

            //Obtenemos los productos de ese lote que son admitidos por el almacén seleccionado

            query = "WITH table_lines " +
                "AS (" +
                    "SELECT li.\"idOrder\", p.name, li.\"idProduct\", pw.\"currentStock\", sum(\"quantity\") AS \"quantity\" " +
                    "FROM inkaart.\"Order\" o, inkaart.\"LineItem\" li, inkaart.\"Product-Warehouse\" pw, inkaart.\"Product\" p " +
                    "WHERE " +
                        "o.\"type\" = 'pedido' AND o.\"bdStatus\" = 1 AND o.\"idOrder\" = " + id_order +" AND " +
                        "pw.state = 'Activo' AND pw.\"idWarehouse\" = " + id_warehouse + " AND " +
                        "o.\"idOrder\" = li.\"idOrder\" AND li.\"lineStatus\" != 'facturado' AND " +
                        "pw.\"idProduct\" = li.\"idProduct\" AND pw.\"idProduct\" = p.\"idProduct\" " +
                    "GROUP BY li.\"idOrder\", p.name, li.\"idProduct\", pw.\"currentStock\" " +
                    "ORDER BY 1 ASC " +
                ") " +
                "SELECT tl.\"idProduct\", tl.name, tl.quantity, tl.\"currentStock\", sd.product_stock " +
                    "FROM table_lines tl, inkaart.\"StockDocument\" sd " +
                    "WHERE tl.\"idOrder\" = sd.\"idDocument\" AND tl.\"idProduct\" = sd.product_id; ";
            //query = "select A.\"idProduct\", E.\"name\", A.\"quantity\", D.\"currentStock\", C.\"product_stock\" from inkaart.\"LineItem\" A,inkaart.\"Order\" B, inkaart.\"StockDocument\" C, inkaart.\"Product-Warehouse\" D, inkaart.\"Product\" E where A.\"idOrder\" = B.\"idOrder\" and A.\"idProduct\" = E.\"idProduct\" and A.\"idOrder\" = C.\"idDocument\" and A.\"idOrder\" = " + int_order + " and C.\"product_id\" = A.\"idProduct\" and C.\"documentType\" = 'VENTA' and D.\"idWarehouse\" = " + int_warehouse + " and D.\"idProduct\" = A.\"idProduct\" and D.\"state\" = 'Activo';";
            return movement_data.executeQueryData(query);
        }

        public NpgsqlDataReader getProductWarehouse(string idWarehouseOrigin, string idWarehouseDestiny)
        {
            string query = "";
            //Obtenemos los productos de ese lote que son admitidos por el almacén seleccionado
            query = "select A.\"idProduct\", C.\"name\", 'Producto' as \"typeItem\" from inkaart.\"Product-Warehouse\" A, inkaart.\"Product-Warehouse\" B, inkaart.\"Product\" C where A.\"idWarehouse\" = " + idWarehouseOrigin + " and B.\"idWarehouse\" =" + idWarehouseDestiny + " and A.\"idProduct\" = B.\"idProduct\" and A.\"idProduct\" = C.\"idProduct\" and C.\"status\" = 1 and A.\"state\" = 'Activo' and B.\"state\" =  'Activo';";
            return movement_data.executeQueryData(query);
        }

        public NpgsqlDataReader getRawMaterialWarehouse(string idWarehouseOrigin, string idWarehouseDestiny)
        {
            string query = "";
            //Obtenemos los productos de ese lote que son admitidos por el almacén seleccionado
            query = "select A.\"idRawMaterial\", C.\"name\", 'Materia Prima' as \"typeItem\" from inkaart.\"RawMaterial-Warehouse\" A, inkaart.\"RawMaterial-Warehouse\" B, inkaart.\"RawMaterial\" C where A.\"idWarehouse\" = " + idWarehouseOrigin + " and B.\"idWarehouse\" =" + idWarehouseDestiny + " and A.\"idRawMaterial\" = B.\"idRawMaterial\" and A.\"idRawMaterial\" = C.\"id_raw_material\" and C.\"status\" = 'Activo' and A.\"state\" = 'Activo' and B.\"state\" =  'Activo';";
            return movement_data.executeQueryData(query);
        }

        public NpgsqlDataReader getProductStock(string id = "", string idLote = "")
        {
            int intAux, intIdLote = -1, intIdWarehouse = -1, existe = 0;
            string query = "";

            if (!idLote.Equals("")) if (int.TryParse(idLote, out intAux)) intIdLote = int.Parse(idLote);
            query = "select product_id from inkaart.\"StockDocument\" where \"documentType\" = 'LOTE' and \"idDocument\" = " + idLote + " order by 1 asc;";
            NpgsqlDataReader dr = movement_data.executeQueryData(query);

            query = "select id_product, produced as \"product_stock\" FROM inkaart.\"RatioPerDay\" WHERE id_lote = " + intIdLote + " order by 1 asc;";
            NpgsqlDataReader dr2 = movement_data.executeQueryData(query);
            int tamDr1 = 0, tamDr2 = 0;
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
                    movement_data.updateData(query);
                }
            }
            for (int i = 0; i < tamDr1; i++)
            {
                existe = existeElementoInt(arrDr1[i], arrDr2, tamDr2);
                if (existe == -1)//Cuando un producto fue eliminado se borra de la tabla
                {
                    query = "delete from inkaart.\"StockDocument\" where \"idDocument\" = " + intIdLote + " and \"documentType\" = 'LOTE' and \"product_id\" = " + arrDr1[i] + ";";
                    movement_data.updateData(query);
                }
            }
            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intIdWarehouse = int.Parse(id);

            //Obtenemos los productos de ese lote que son admitidos por el almacén seleccionado
            query = "select A.\"id_lote\", A.\"id_product\", B.\"name\", A.\"produced\", D.\"currentStock\", C.\"product_stock\" from inkaart.\"RatioPerDay\" A,inkaart.\"Product\" B, inkaart.\"StockDocument\" C, inkaart.\"Product-Warehouse\" D where A.\"id_product\" = B.\"idProduct\" and A.\"id_lote\" = C.\"idDocument\" and A.\"id_lote\" = " + intIdLote + " and C.\"product_id\" = A.id_product and C.\"documentType\" = 'LOTE' and D.\"idWarehouse\" = " + intIdWarehouse + " and D.\"idProduct\" = A.\"id_product\" and D.\"state\" = 'Activo';";
            return movement_data.executeQueryData(query);
        }

    }
}
