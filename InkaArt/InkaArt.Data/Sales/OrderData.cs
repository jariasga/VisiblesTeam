using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Classes;
using System.Data;
using Npgsql;

namespace InkaArt.Data.Sales
{
    public class OrderData : BD_Connector
    {
        private DataSet data;
        private DataTable table;
        private DataRow row;
        private NpgsqlDataAdapter adap;
        public OrderData()
        {
            data = new DataSet();
        }

        public int UpdateLineItem(string id, bool lineComplete, int finished)
        {
            NpgsqlDataAdapter myAdap = orderLineAdapter();
            DataSet myData = getData(myAdap, "LineItem");
            table = myData.Tables["LineItem"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (string.Compare(table.Rows[i]["idLineItem"].ToString(), id) == 0)
                {
                    int invoiced;
                    invoiced = int.Parse(table.Rows[i]["quantityInvoiced"].ToString());
                    table.Rows[i]["quantityInvoiced"] = invoiced + finished;
                    table.Rows[i]["quantityProduced"] = 0;
                    if (lineComplete) table.Rows[i]["lineStatus"] = "facturado";
                    else table.Rows[i]["lineStatus"] = "parcial";
                    break;
                }
            }
            return updateData(myData, myAdap, "LineItem");
        }

        public int AddLineXDocument(string idLineItem,int finished, float pu, string idSaleDocument)
        {
            NpgsqlDataAdapter myAdap = lineXDocumentAdapter();
            DataSet myData = getData(myAdap, "Line-Document");
            table = myData.Tables["Line-Document"];
            row = table.NewRow();
            row["idLineItem"] = idLineItem;
            row["finished"] = finished;
            row["pu"] = pu;
            row["idSaleDocument"] = idSaleDocument;
            table.Rows.Add(row);
            int rowsAffected = insertData(myData, myAdap, "Line-Document");
            return rowsAffected;
        }

        public DataTable GetInvoice(int salesDocumentId)
        {
            NpgsqlDataAdapter curAdap = new NpgsqlDataAdapter();
            DataSet curData = new DataSet();
            curAdap = salesDocumentAdapter();
            curAdap.SelectCommand.CommandText += " WHERE \"idSalesDocument\" = :idSalesDocument;";
            curAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("idSalesDocument", DbType.Int32));
            curAdap.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            curAdap.SelectCommand.Parameters[0].SourceColumn = "idSalesDocument";
            curAdap.SelectCommand.Parameters[0].NpgsqlValue = salesDocumentId;
            curData = getData(curAdap, "SalesDocument");
            DataTable saleDocument = new DataTable();
            saleDocument = curData.Tables[0];
            return saleDocument;
        }

        public DataTable getLinesByIds(int[] idProd, int orderId)
        {
            NpgsqlDataAdapter curAdap = new NpgsqlDataAdapter();
            DataSet curData = new DataSet();
            curData.Clear();
            curAdap = orderLineAdapter();
            curAdap.SelectCommand.CommandText += " WHERE \"idOrder\" = :idOrder AND ";
            curAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("idOrder", DbType.Int32));
            curAdap.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            curAdap.SelectCommand.Parameters[0].SourceColumn = "idOrder";
            curAdap.SelectCommand.Parameters[0].NpgsqlValue = orderId;
            curAdap.SelectCommand.CommandText += "\"idProduct\" in (";
            for (int i = 0; i < idProd.Length; i++)
            {
                if (idProd[i] == 0) break;
                if (idProd[i+1] == 0) curAdap.SelectCommand.CommandText += ":idProduct";
                else curAdap.SelectCommand.CommandText += ":idProduct,";
                curAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("idProduct", DbType.Int32));
                curAdap.SelectCommand.Parameters[i + 1].Direction = ParameterDirection.Input;
                curAdap.SelectCommand.Parameters[i + 1].SourceColumn = "idProduct";
                curAdap.SelectCommand.Parameters[i + 1].NpgsqlValue = idProd[i];

            }
            curAdap.SelectCommand.CommandText += ");";
            curData = getData(curAdap, "LineItem");
            DataTable orderLine = new DataTable();
            orderLine = curData.Tables[0];
            return orderLine;
        }

        public void updateOrderStatus(string orderId, string orderStatus)
        {
            NpgsqlDataAdapter myAdap = orderAdapter();
            DataSet myData = getData(myAdap, "Order");
            table = myData.Tables["Order"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (string.Compare(table.Rows[i]["idOrder"].ToString(), orderId) == 0)
                {
                    table.Rows[i]["orderStatus"] = orderStatus;
                    break;
                }
            }
            updateData(myData, myAdap, "Order");
        
        }

        public string getProductId(int idLineItem)
        {
            DataSet myData = new DataSet();
            NpgsqlDataAdapter myAdap = orderLineAdapter();
            myAdap.SelectCommand.CommandText += "WHERE \"idLineItem\" = :idLineItem;";
            myAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("idLineItem", DbType.Int32));
            myAdap.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            myAdap.SelectCommand.Parameters[0].SourceColumn = "idLineItem";
            myAdap.SelectCommand.Parameters[0].NpgsqlValue = idLineItem;

            myData.Clear();
            myData = getData(myAdap, "LineItem");

            DataTable list = new DataTable();
            list = myData.Tables[0];
            string productId = list.Rows[0]["idProduct"].ToString();
            return productId;
        }

        public int getClientID(int orderId)
        {
            DataSet myData = new DataSet();
            NpgsqlDataAdapter myAdap = orderAdapter();
            myAdap.SelectCommand.CommandText += "WHERE \"idOrder\" = :idOrder;";
            myAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("idOrder", DbType.Int32));
            myAdap.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            myAdap.SelectCommand.Parameters[0].SourceColumn = "idOrder";
            myAdap.SelectCommand.Parameters[0].NpgsqlValue = orderId;

            myData.Clear();
            myData = getData(myAdap, "idOrder");

            DataTable list = new DataTable();
            list = myData.Tables[0];
            int clientId = int.Parse(list.Rows[0]["idClient"].ToString());
            return clientId;
        }

        public int InsertSaleDocument(int idDocType, float amount, float igv, float total, int orderId)
        {
            adap = salesDocumentAdapter();
            data.Clear();
            data = getData(adap, "SalesDocument");
            table = data.Tables["SalesDocument"];
            row = table.NewRow();
            row["idDocumentType"] = idDocType;
            row["amount"] = amount;
            row["igv"] = igv;
            row["totalAmount"] = total;
            row["idOrder"] = orderId;
            table.Rows.Add(row);
            int rowsAffected = insertData(data, adap, "SalesDocument");
            return rowsAffected;

        }

        public DataTable GetOrders(int id = -1, string type = "", long doc = -1, string clientName = "", string orderStatus = "", DateTime? ini = null, DateTime? end = null)
        {
            adap = orderAdapter();
            byClient(adap,doc,clientName);
            byId(adap,id);
            byType(adap,type);
            byOrderStatus(adap,orderStatus);
            byDateRange(adap, ini, end);
            adap.SelectCommand.CommandText += ";";
            data.Clear();
            data = getData(adap, "Orders");
            DataTable orderList = new DataTable();
            orderList = data.Tables[0];
            return orderList;
        }

        private void byDateRange(NpgsqlDataAdapter adap, DateTime? ini = null, DateTime? end = null)
        {
            if (!ini.HasValue || !end.HasValue) return;
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "\"deliveryDate\" >= :ini AND \"deliveryDate\" <= :end";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("ini", DbType.Date));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "ini";
            adap.SelectCommand.Parameters[numParams++].NpgsqlValue = ini;
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("end", DbType.Date));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "end";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = end;
        }

        private void byClient(NpgsqlDataAdapter adap, long doc, string clientName)
        {
            if (doc == -1 && clientName.Equals("")) return;
            int id = getClientId(doc,clientName);
            if (id != -1)
            {
                int numParams = adap.SelectCommand.Parameters.Count();
                if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
                else adap.SelectCommand.CommandText += " AND ";
                adap.SelectCommand.CommandText += "\"idClient\" = :idClient";
                adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idClient", DbType.Int32));
                adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
                adap.SelectCommand.Parameters[numParams].SourceColumn = "idClient";
                adap.SelectCommand.Parameters[numParams].NpgsqlValue = id;
            }
        }

        public DataTable GetSalesDocument(int orderId = -1)
        {
            adap = salesDocumentAdapter();
            if (orderId != -1)
            {
                adap.SelectCommand.CommandText += " WHERE \"idOrder\" = :idOrder;";
                adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idOrder", DbType.Int32));
                adap.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
                adap.SelectCommand.Parameters[0].SourceColumn = "idOrder";
                adap.SelectCommand.Parameters[0].NpgsqlValue = orderId;
            }
            data.Clear();
            data = getData(adap, "SalesDocument");
            DataTable salesDocuments = new DataTable();
            salesDocuments = data.Tables[0];
            return salesDocuments;
        }

        public void deleteOrders(List<string> selectedOrders)
        {
            adap = orderAdapter();

            data.Clear();
            data = getData(adap, "Order");

            table = data.Tables["Order"];

            foreach (string id in selectedOrders)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (string.Compare(table.Rows[i]["idOrder"].ToString(), id) == 0)
                    {
                        table.Rows[i]["bdStatus"] = 0;
                        break;
                    }
                }
            }
            updateData(data, adap, "Order");
        }

        private int getClientId(long doc, string clientName)
        {
            NpgsqlDataAdapter curAdap = new NpgsqlDataAdapter();
            DataSet curData = new DataSet();
            curAdap = clientAdapter();
            curAdap.SelectCommand.CommandText += " WHERE ";
            if (doc != -1 && !clientName.Equals(""))
            {
                clientName = "%" + clientName + "%";
                curAdap.SelectCommand.CommandText += "ruc = :ruc AND ";
                curAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("ruc", DbType.Int64));
                curAdap.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
                curAdap.SelectCommand.Parameters[0].SourceColumn = "ruc";
                curAdap.SelectCommand.Parameters[0].NpgsqlValue = doc;
                curAdap.SelectCommand.CommandText += "UPPER(name) LIKE UPPER(:name);";
                curAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("name", DbType.AnsiStringFixedLength));
                curAdap.SelectCommand.Parameters[1].Direction = ParameterDirection.Input;
                curAdap.SelectCommand.Parameters[1].SourceColumn = "name";
                curAdap.SelectCommand.Parameters[1].NpgsqlValue = clientName;
            }
            else if (doc != -1 && clientName.Equals(""))
            {
                curAdap.SelectCommand.CommandText += "ruc = :ruc;";
                curAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("ruc", DbType.Int64));
                curAdap.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
                curAdap.SelectCommand.Parameters[0].SourceColumn = "ruc";
                curAdap.SelectCommand.Parameters[0].NpgsqlValue = doc;
            }
            else if (doc == -1 && !clientName.Equals(""))
            {
                clientName = "%" + clientName + "%";
                curAdap.SelectCommand.CommandText += "UPPER(name) LIKE UPPER(:name);";
                curAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("name", DbType.AnsiStringFixedLength));
                curAdap.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
                curAdap.SelectCommand.Parameters[0].SourceColumn = "name";
                curAdap.SelectCommand.Parameters[0].NpgsqlValue = clientName;
            }
            curData.Clear();
            curData = getData(curAdap, "Client");
            DataTable client = new DataTable();
            client = curData.Tables[0];
            if (client.Rows.Count == 0) return -1;
            return int.Parse(client.Rows[0]["idClient"].ToString());
        }

        public DataTable getProductRecipe(int id)
        {
            DataSet myData = new DataSet();
            NpgsqlDataAdapter myAdap = recipeAdapter();
            myAdap.SelectCommand.CommandText += "WHERE \"idProduct\" = :idProduct AND status = 1;";
            myAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("idProduct", DbType.Int32));
            myAdap.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            myAdap.SelectCommand.Parameters[0].SourceColumn = "idProduct";
            myAdap.SelectCommand.Parameters[0].NpgsqlValue = id;

            myData.Clear();
            myData = getData(myAdap, "Recipe");

            DataTable recipeList = new DataTable();
            recipeList = myData.Tables[0];
            return recipeList;
        }

        private void byOrderStatus(NpgsqlDataAdapter adap, string orderStatus)
        {
            if (orderStatus.Equals("")) return;
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "\"orderStatus\" LIKE :orderStatus";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("orderStatus", DbType.AnsiStringFixedLength));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "orderStatus";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = orderStatus;

        }
        private void byType(NpgsqlDataAdapter adap, string type)
        {
            if (type.Equals("")) return;
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "type LIKE :type";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("type", DbType.AnsiStringFixedLength));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "type";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = type;
        }

        private void byId(NpgsqlDataAdapter adap, int id)
        {
            if (id == -1) return;
            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";
            adap.SelectCommand.CommandText += "\"idOrder\" = :idOrder";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idOrder", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "idOrder";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = id;
        }

        public NpgsqlDataAdapter orderAdapter()
        {
            NpgsqlDataAdapter orderAdapter = new NpgsqlDataAdapter();
            orderAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Order\"", Connection);
            return orderAdapter;
        }
        public NpgsqlDataAdapter salesDocumentAdapter()
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"SalesDocument\"", Connection);
            return adapter;
        }
        public NpgsqlDataAdapter orderIdAdapter()
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand("SELECT \"idOrder\" FROM inkaart.\"Order\" WHERE igv = :igv;", Connection);
            adapter.SelectCommand.Parameters.Add(new NpgsqlParameter("igv", DbType.Double));
            adapter.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters[0].SourceColumn = "igv";
            return adapter;
        }
        public NpgsqlDataAdapter documentAdapter()
        {
            NpgsqlDataAdapter documentAdapter = new NpgsqlDataAdapter();
            documentAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"DocumentType\";", Connection);
            return documentAdapter;
        }

        public int getSaleDocumentId()
        {
            adap = salesDocumentAdapter();
            data.Clear();
            data = getData(adap, "SalesDocument");
            DataTable salesDocument;
            salesDocument = data.Tables[0];
            int index = salesDocument.Rows.Count;
            DataRow rowDocument = salesDocument.Rows[index - 1];
            int saleDocumentId = int.Parse(rowDocument["idSalesDocument"].ToString());
            return saleDocumentId;
        }

        public int InsertOrderLines(DataTable orderLines, double igv, string type, bool isClientSelected, int clientNat)
        {
            adap = orderAdapter();
            data.Clear();
            data = getData(adap, "Order");
            DataTable order;
            order = data.Tables[0];
            int index = order.Rows.Count;
            DataRow rowOrder = order.Rows[index - 1];
            int orderId = int.Parse(rowOrder["idOrder"].ToString());
            adap = orderLineAdapter();
            adap.SelectCommand.CommandText += ";";
            data.Clear();
            data = getData(adap, "LineItem");
            table = data.Tables["LineItem"];
            foreach (DataRow r in orderLines.Rows)
            {
                row = table.NewRow();
                var cantColumn = r["Cantidad"];
                if (cantColumn == DBNull.Value) break;
                int cant = int.Parse(r["Cantidad"].ToString());
                string cali = r["Calidad"].ToString(), lineStatus = "registrado";
                int currentProductId = getProductId(r["Producto"].ToString()), produced = 0;
                row["quantity"] = cant;
                row["quality"] = cali;
                row["idRecipe"] = getVersionId(cali);
                row["idProduct"] = currentProductId;
                row["idOrder"] = orderId;
                if (isClientSelected)
                {
                    if (clientNat == 0)
                    {
                        updateLogicalStock(currentProductId, cant, type);
                        lineStatus = "despachado";
                        produced = cant;
                    }
                }
                row["quantityProduced"] = produced;
                row["lineStatus"] = lineStatus;
                row["quantityInvoiced"] = 0;
                table.Rows.Add(row);
            }
            int rowsAffected = insertData(data, adap, "LineItem");
            return rowsAffected;
        }

        private int updateLogicalStock(int currentProductId, int cant, string type)
        {
            DataSet myData = new DataSet();
            NpgsqlDataAdapter myAdap = productAdapter();

            myData.Clear();
            myData = getData(myAdap, "Product");

            DataTable myTable = myData.Tables["Product"];
            for (int i = 0; i < myTable.Rows.Count; i++)
            {
                if (string.Compare(myTable.Rows[i]["idProduct"].ToString(), currentProductId.ToString()) == 0)
                {
                    myTable.Rows[i]["logicalStock"] = int.Parse(myTable.Rows[i]["logicalStock"].ToString()) - cant;
                    break;
                }
            }
            return updateData(myData, myAdap, "Product");
        }

        private int getVersionId(string versionName)
        {
            DataSet myData = new DataSet();
            NpgsqlDataAdapter myAdap = recipeAdapter();
            myAdap.SelectCommand.CommandText += " WHERE version = :version";
            myAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("version", DbType.AnsiStringFixedLength));
            myAdap.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            myAdap.SelectCommand.Parameters[0].SourceColumn = "version";
            myAdap.SelectCommand.Parameters[0].NpgsqlValue = versionName;

            myData.Clear();
            myData = getData(myAdap, "Recipe");

            DataTable documentList = new DataTable();
            documentList = myData.Tables[0];
            DataRow row = documentList.Rows[0];
            int id = int.Parse(row["idRecipe"].ToString());
            return id;
        }

        private int getRecipeId(int productId)
        {
            DataSet myData = new DataSet();
            NpgsqlDataAdapter myAdap = recipeIdAdapter();
            myAdap.SelectCommand.Parameters[0].NpgsqlValue = productId;

            myData.Clear();
            myData = getData(myAdap, "Recipe");

            DataTable documentList = new DataTable();
            documentList = myData.Tables[0];
            DataRow row = documentList.Rows[0];
            int id = int.Parse(row["idRecipe"].ToString());
            return id;
        }

        private int getProductId(string productName)
        {
            DataSet myData = new DataSet();
            NpgsqlDataAdapter myAdap = productIdAdapter();
            myAdap.SelectCommand.Parameters[0].NpgsqlValue = productName;

            myData.Clear();
            myData = getData(myAdap, "Product");

            DataTable documentList = new DataTable();
            documentList = myData.Tables[0];
            DataRow row = documentList.Rows[0];
            int id = int.Parse(row["idProduct"].ToString());
            return id;
        }
        public string getProductPU(int id, int idClient)
        {
            NpgsqlDataAdapter curAdap = new NpgsqlDataAdapter();
            DataSet curData = new DataSet();
            curAdap = productAdapter();
            curAdap.SelectCommand.CommandText += " WHERE \"idProduct\" = :idProduct;";
            curAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("idProduct", DbType.Int32));
            curAdap.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            curAdap.SelectCommand.Parameters[0].SourceColumn = "idProduct";
            curAdap.SelectCommand.Parameters[0].NpgsqlValue = id;
            //curData.Clear();
            curData = getData(curAdap, "Product");
            DataTable orderLine = new DataTable();
            orderLine = curData.Tables[0];
            if (isNationalClient(idClient)) return orderLine.Rows[0]["localPrice"].ToString();
            else return orderLine.Rows[0]["exportPrice"].ToString();
        }

        public string getProductLogicalStock(int productId)
        {
            NpgsqlDataAdapter curAdap = new NpgsqlDataAdapter();
            DataSet curData = new DataSet();
            curAdap = productAdapter();
            curAdap.SelectCommand.CommandText += " WHERE \"idProduct\" = :idProduct;";
            curAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("idProduct", DbType.Int32));
            curAdap.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            curAdap.SelectCommand.Parameters[0].SourceColumn = "idProduct";
            curAdap.SelectCommand.Parameters[0].NpgsqlValue = productId;
            curData.Clear();
            curData = getData(curAdap, "Product");
            DataTable orderLine = new DataTable();
            orderLine = curData.Tables[0];
            return orderLine.Rows[0]["logicalStock"].ToString();
        }
        private bool isNationalClient(int idClient)
        {
            NpgsqlDataAdapter curAdap = new NpgsqlDataAdapter();
            DataSet curData = new DataSet();
            curAdap = clientAdapter();
            curAdap.SelectCommand.CommandText += " WHERE ";
            curAdap.SelectCommand.CommandText += "\"idClient\" = :idClient;";
            curAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("idClient", DbType.Int32));
            curAdap.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            curAdap.SelectCommand.Parameters[0].SourceColumn = "idClient";
            curAdap.SelectCommand.Parameters[0].NpgsqlValue = idClient;
            curData.Clear();
            curData = getData(curAdap, "Client");
            DataTable client = new DataTable();
            client = curData.Tables[0];
            if (client.Rows.Count == 0) return false;
            return client.Rows[0]["type"].ToString().Equals("0");
        }

        public string getProductName(int id)
        {
            NpgsqlDataAdapter curAdap = new NpgsqlDataAdapter();
            DataSet curData = new DataSet();
            curAdap = productAdapter();
            curAdap.SelectCommand.CommandText += " WHERE \"idProduct\" = :idProduct;";
            curAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("idProduct", DbType.Int32));
            curAdap.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            curAdap.SelectCommand.Parameters[0].SourceColumn = "idProduct";
            curAdap.SelectCommand.Parameters[0].NpgsqlValue = id;
            curData.Clear();
            curData = getData(curAdap, "Product");
            DataTable orderLine = new DataTable();
            orderLine = curData.Tables[0];            
            return orderLine.Rows[0]["name"].ToString();
        }
        public DataTable getOrderLines(int idOrder)
        {
            NpgsqlDataAdapter curAdapter = new NpgsqlDataAdapter();
            DataSet curData = new DataSet();
            curAdapter = orderLineAdapter();
            curAdapter.SelectCommand.CommandText += " WHERE \"idOrder\" = :idOrder;";
            curAdapter.SelectCommand.Parameters.Add(new NpgsqlParameter("idOrder", DbType.Int32));
            curAdapter.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            curAdapter.SelectCommand.Parameters[0].SourceColumn = "idOrder";
            curAdapter.SelectCommand.Parameters[0].NpgsqlValue = idOrder;
            curData.Clear();
            curData = getData(curAdapter, "LineItem");
            DataTable orderLines = new DataTable();
            orderLines = curData.Tables[0];
            return orderLines;
        }
        public NpgsqlDataAdapter productIdAdapter()
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand("SELECT \"idProduct\" FROM inkaart.\"Product\" WHERE name = :name;", Connection);
            adapter.SelectCommand.Parameters.Add(new NpgsqlParameter("name", DbType.AnsiStringFixedLength));
            adapter.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters[0].SourceColumn = "name";
            return adapter;
        }

        public NpgsqlDataAdapter recipeIdAdapter()
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand("SELECT \"idRecipe\" FROM inkaart.\"Recipe\" WHERE \"idProduct\" = :idProduct;", Connection);
            adapter.SelectCommand.Parameters.Add(new NpgsqlParameter("idProduct", DbType.Int32));
            adapter.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters[0].SourceColumn = "idProduct";
            return adapter;
        }

        public NpgsqlDataAdapter recipeAdapter()
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Recipe\"", Connection);
            return adapter;
        }

        public NpgsqlDataAdapter productAdapter()
        {
            NpgsqlDataAdapter productAdapter = new NpgsqlDataAdapter();
            productAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Product\"", Connection);
            return productAdapter;
        }
        public NpgsqlDataAdapter insertOrderAdapter()
        {
            NpgsqlDataAdapter insertOrderAdapter = new NpgsqlDataAdapter();
            insertOrderAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Order\";", Connection);
            return insertOrderAdapter;
        }
        public NpgsqlDataAdapter orderLineAdapter()
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"LineItem\"", Connection);
            return adapter;
        }

        public NpgsqlDataAdapter lineXDocumentAdapter()
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Line-Document\"", Connection);
            return adapter;
        }

        public NpgsqlDataAdapter clientAdapter()
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Client\"", Connection);
            return adapter;
        }
        public DataTable GetDocumentTypes()
        {

            adap = documentAdapter();

            data.Clear();
            data = getData(adap, "DocumentType");

            DataTable documentList = new DataTable();
            documentList = data.Tables[0];
            return documentList;
        }
        public DataTable GetProducts()
        {
            adap = productAdapter();
            adap.SelectCommand.CommandText += ";";
            data.Clear();
            data = getData(adap, "Product");

            DataTable productList = new DataTable();
            productList = data.Tables[0];
            return productList;
        }
        public DataTable getLineXDocument(int idSaleDocument)
        {
            NpgsqlDataAdapter curAdap = lineXDocumentAdapter();
            curAdap.SelectCommand.CommandText += " WHERE \"idSaleDocument\" = :idSaleDocument;";
            curAdap.SelectCommand.Parameters.Add(new NpgsqlParameter("idSaleDocument", DbType.Int32));
            curAdap.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            curAdap.SelectCommand.Parameters[0].SourceColumn = "idSaleDocument";
            curAdap.SelectCommand.Parameters[0].NpgsqlValue = idSaleDocument;
            DataSet curData = getData(curAdap, "Line-Document");

            DataTable lineList = new DataTable();
            lineList = curData.Tables[0];
            return lineList;
        }
        public int InsertOrder(int idClient, DateTime deliveryDate, string saleAmount, string igv, string totalAmount, string orderStatus, int bdStatus, string type, string reason, string totalDev)
        {
            adap = insertOrderAdapter();
            data.Clear();
            data = getData(adap, "Order");
            table = data.Tables["Order"];
            row = table.NewRow();
            if (idClient != -1) row["idClient"] = idClient;
            row["deliveryDate"] = deliveryDate;
            row["saleAmount"] = saleAmount;
            row["igv"] = igv;
            row["totalAmount"] = totalAmount;
            row["bdStatus"] = bdStatus;
            row["orderStatus"] = orderStatus;
            row["type"] = type;
            row["reason"] = reason;
            if (!totalDev.Equals("")) row["totalDev"] = totalDev;
            table.Rows.Add(row);
            int rowsAffected = insertData(data, adap, "Order");
            return rowsAffected;
        }
    }
}
