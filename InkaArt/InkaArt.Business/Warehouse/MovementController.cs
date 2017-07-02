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

        private void insertaWhereTexto(string query,string fieldName, string name,int existeWhere)
        {
            if (name != "")
            {
                if (existeWhere == 1)
                {
                    query = query + " and \"" + fieldName + "\" = " + name;
                }
                else
                {
                    query = query + " where \"" + fieldName + "\" = " + name;
                    existeWhere = 1;
                }
            }
        }
        private void insertaWhereInt(string query, string fieldName, int entero, int existeWhere)
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

        public NpgsqlDataReader GetWarehouseList(int idWarehouse = -2, string name = "", string address = "")
        {
            int existeWhere =0;
            string query = "";
            
            query = "select \"idWarehouse\", \"name\",\"address\", \"state\" from inkaArt.\"Warehouse\" ";

            insertaWhereInt(query, "idWarehouse", idWarehouse, existeWhere);
            insertaWhereTexto(query, "name", name, existeWhere);
            insertaWhereTexto(query, "address",address, existeWhere);
            insertaWhereTexto(query, "state","Activo", existeWhere);
            query = query + ";";

            return movement_data.executeQueryData(query);
        }

        public NpgsqlDataReader GetTypeMovementList()
        {
            NpgsqlDataReader dr;
            string query = "";

            query = "select \"description\" from inkaArt.\"MovementName\";";
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

            query = "select \"cantmoved\" from inkaart.\"StockDocument\" where \"idDocument\" = " + idDoc + " and \"product_id\" = " + idProd + " and \"documentType\" = '" + stockMovement + "';";

            if (cantidadPorEntregar - numMov < 0)
            {
                MessageBox.Show("Usted no puede entregar más items de los que dice el documento. Puede entregar como máximo: " + cantidadPorEntregar + ".");
                return -1;
            }

            return 1;
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

            return 1;
        }

        private int verifyUpdateProductWarehouse(int idProd, int idWarehouse, int numMov, string typeMovement,string typeReason, string productType)
        {
            NpgsqlDataReader dr;
            int stockAct = -1, maxStock = -1, minStock = 9999,logicStock=-1;//Stock físico
            string query = "";

            //Se obtiene la query para ver los stocks máximos y mínimos
            if(productType == "Producto")
            {
                query = "select \"currentStock\",\"minimunStock\", \"maximunStock\", \"virtualStock\" from inkaart.\"Product-Warehouse\" where \"idWarehouse\" = " + idWarehouse + " and \"idProduct\" = " + idProd + " and \"state\" = 'Activo';";
            }else if (productType == "Materia Prima")
            {
                query = "select \"currentStock\",\"minimunStock\", \"maximunStock\", \"virtualStock\" from inkaart.\"RawMaterial-Warehouse\" where \"idWarehouse\" = " + idWarehouse + " and \"idProduct\" = " + idProd + " and \"state\" = 'Activo';";
            }
            //Se sacan los valores
            dr = movement_data.executeQueryData(query);
            stockAct = Convert.ToInt32(dr[0]);
            minStock = Convert.ToInt32(dr[1]);
            maxStock = Convert.ToInt32(dr[2]);
            logicStock = Convert.ToInt32(dr[3]);

            //Verificar los stock mínimo y máximos
            if (typeMovement == "Entrada")
            {
                if (typeReason == "Produccion")
                {
                    stockAct = stockAct + numMov;
                    logicStock = logicStock + numMov;
                }
                if (typeReason == "Hallazgo")
                {
                    stockAct = stockAct + numMov;
                    logicStock = logicStock + numMov;
                }
                if (typeReason == "Devolucion")
                {
                    stockAct = stockAct + numMov;
                    logicStock = logicStock + numMov;
                }
            }
            if (typeMovement == "Salida")
            {
                if (typeReason == "Produccion")
                {
                    stockAct = stockAct - numMov;
                }
                if (typeReason == "Rotura")
                {
                    stockAct = stockAct - numMov;
                    logicStock = logicStock - numMov;
                }
                if (typeReason == "Venta")
                {
                    stockAct = stockAct - numMov;
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
            if (stockAct < logicStock)
            {
                MessageBox.Show("Su stock virtual es: " + logicStock + " y su físico es: " + stockAct + ". Su stock virtual no puede ser mayor al físico, favor de revisar");
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
                if(typeReason == "Produccion")
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
                if (typeReason == "Produccion")
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

        private int getNewStock(int idProd, int idWarehouse, int numMov, string typeMovement, string productType, int stockAct)
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
                query = "select \"currentStock\",\"minimunStock\", \"maximunStock\", \"virtualStock\" from inkaart.\"RawMaterial-Warehouse\" where \"idWarehouse\" = " + idWarehouse + " and \"idProduct\" = " + idProd + " and \"state\" = 'Activo';";
            }
            //Se sacan los valores
            dr = movement_data.executeQueryData(query);
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

            filModified = getNewStock(idProd, idWarehouse, numMov, typeMovement, productType, stockAct);
            
            string updateQuery = "";
            if (filModified > 0)
            {
                updateQuery = "update inkaart.\"Product-Warehouse\" set \"currentStock\" = " + stockAct + " where \"idWarehouse\"= " + idWarehouse + " and \"idProduct\" = " + idProd + " ;";
                movement_data.updateData(updateQuery);
            }
            
            return 1;
        }

    }
}
