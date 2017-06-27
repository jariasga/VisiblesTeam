using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Sales;
using System.Data;
using System.Windows.Forms;

namespace InkaArt.Business.Sales
{
    public class OrderController
    {
        private OrderData orderData;
        public OrderController()
        {
            orderData = new OrderData();
        }

        public int AddSaleDocumentW(int orderId, int[] idProd, int[] quantity, int orderType = 0)
        {
            int clientId = getClientID(orderId);
            string clientDoc = getClientDoc(clientId.ToString());
            int selectedDoc = -1;
            if (orderType == 1) selectedDoc = 6;
            if (clientDoc.Length == 11) selectedDoc = 2;
            else selectedDoc = 1;
            //////////////////////////
            float amount = 0;
            if (idProd.Length != 0 && quantity.Length != 0)
            {
                for (int i = 0; i < idProd.Length; i++)
                {
                    if (idProd[i] == 0 && quantity[i] == 0) break;
                    float pu = float.Parse(getProductPU(idProd[i].ToString(), clientId.ToString()));
                    amount += pu * quantity[i];
                }
                DataTable orderLines = getLinesByIds(idProd,orderId);                
                for (int i = 0; i < quantity.Length; i++)
                {
                    if (idProd[i] == 0 && quantity[i] == 0) break;
                    foreach (DataRow row in orderLines.Rows)
                    {
                        if (row["idProduct"].ToString().Equals(idProd[i].ToString()))
                        {
                            row["quantityProduced"] = quantity[i];
                        }
                    }
                }
                string pamount = getPolishedAmount(amount);
                string igv = getPolishedIGV(amount);
                string total = getPolishedTotal(amount);
                return AddSaleDocument(selectedDoc, pamount, igv, total, orderId,orderLines, clientId, orderType);
            } else return -1;
        }

        public DataTable GetInvoice(int salesDocumentId)
        {
            return orderData.GetInvoice(salesDocumentId);
        }

        private DataTable getLinesByIds(int[] idProd, int orderId)
        {
            return orderData.getLinesByIds(idProd, orderId);
        }

        public int AddSaleDocument(int selectedDoc, string strAmount, string strIgv, string strTotal, int orderId, DataTable orderLines, int clientId, int orderType = 0)
        {
            float amount = float.Parse(strAmount), igv = float.Parse(strIgv), total = float.Parse(strTotal);
            int responseSD, responseLI = 0, invoicedNumber = 0;
            if (selectedDoc != 6) selectedDoc++;
            responseSD = orderData.InsertSaleDocument(selectedDoc,amount,igv,total,orderId);
            string idSaleDocument = orderData.getSaleDocumentId().ToString();
            foreach (DataRow orderline in orderLines.Rows)
            {
                string idLineItem = orderline["idLineItem"].ToString();
                float pu = float.Parse(getProductPU(orderline["idProduct"].ToString(), clientId.ToString()));
                int quantity = int.Parse(orderline["quantity"].ToString());
                int finished = int.Parse(orderline["quantityProduced"].ToString());
                int invoiced = int.Parse(orderline["quantityInvoiced"].ToString());
                bool lineComplete = quantity == invoiced;
                if (lineComplete) invoicedNumber++;
                int toAdd;
                if (orderType == 1) toAdd = quantity;
                else toAdd = finished;
                responseLI += orderData.AddLineXDocument(idLineItem, toAdd, pu, idSaleDocument);
                responseLI += orderData.UpdateLineItem(idLineItem, lineComplete);
            }
            if (invoicedNumber == orderLines.Rows.Count || orderType == 1) orderData.updateOrderStatus(orderId.ToString(),"facturado");
            return responseSD + responseLI;
        }

        public string getCurrentStock(string productId)
        {
            return orderData.getProductLogicalStock(int.Parse(productId));
        }

        public bool verifyStock(int natType, string strStock, string strQuantity)
        {
            if (natType == 1) return true;
            else
            {
                int stock = int.Parse(strStock), quantity = int.Parse(strQuantity);
                return stock >= quantity;
            }
        }
        public float getRightPrice(int natType, string strLocalPrice, string strExportPrice)
        {
            float localPrice = float.Parse(strLocalPrice), exportPrice = float.Parse(strExportPrice);
            return natType == 0 ? localPrice : exportPrice;
        }

        public string getProductId(string idLineItem)
        {
            return orderData.getProductId(int.Parse(idLineItem));
        }

        public DataTable GetOrders(int id = -1, object type = null, string doc = "", string clientName = "", object orderStatus = null, DateTime? ini = null, DateTime? end = null)
        {
            long aux, intDoc = -1;
            string strType = "", strOrderStatus = "";
            if (type != null) strType = type.ToString();
            if (orderStatus != null) strOrderStatus = orderStatus.ToString();
            strType = strType.ToLower();
            strOrderStatus = strOrderStatus.ToLower();
            if (!doc.Equals("")) if (long.TryParse(doc, out aux)) intDoc = long.Parse(doc);
            return orderData.GetOrders(id, strType, intDoc,clientName, strOrderStatus,ini, end);
        }

        public int getClientID(int orderId)
        {
            return orderData.getClientID(orderId);
        }

        public DataTable GetSalesDocument(int orderId=-1)
        {
            return orderData.GetSalesDocument(orderId);
        }

        public int AddOrder(int idClient, int documentTypeId, DateTime deliveryDate, string saleAmount, string igv, string totalAmount, string orderStatus, int bdStatus, DataTable orderLines, string type, bool isClientSelected = false, int clientNat = -1, string reason = "", string totalDev = "")
        {
            if (documentTypeId != -1) documentTypeId++;
            saleAmount = Math.Round(double.Parse(saleAmount), 2).ToString();
            igv = Math.Round(double.Parse(igv), 2).ToString(); 
            totalAmount = Math.Round(double.Parse(totalAmount), 2).ToString();
            int orderAdded, orderLineAdded;
            orderAdded = orderData.InsertOrder(idClient, deliveryDate, saleAmount, igv, totalAmount, orderStatus, bdStatus, type,reason, totalDev);
            orderLineAdded = orderData.InsertOrderLines(orderLines, double.Parse(igv), type, isClientSelected, clientNat);
            return orderAdded + orderLineAdded;
        }

        public void deleteOrders(List<string> selectedOrders)
        {
            orderData.deleteOrders(selectedOrders);
        }

        public string getClientName(string v)
        {
            if (v.Equals("-1")) return "Inka Art";
            ClientController cc = new ClientController();
            DataTable info = new DataTable();
            info = cc.GetClients(v);
            return info.Rows[0]["name"].ToString();
        }

        public string getClientDoc(string v)
        {
            if (v.Equals("-1")) return "23021804923";
            ClientController cc = new ClientController();
            DataTable info = new DataTable();
            info = cc.GetClients(v);
            return info.Rows[0]["ruc"].ToString();
        }

        public float getRightTotalAmount(DataRow row)
        {
            if (row["type"].ToString().Equals("pedido")) return float.Parse(row["totalAmount"].ToString());
            else return float.Parse(row["totalDev"].ToString());
        }

        public DataTable GetDocumentTypes()
        {
            return orderData.GetDocumentTypes();
        }
        public DataTable GetProducts()
        {
            return orderData.GetProducts();
        }
        public string getProductPU(string id, string idClient)
        {
            int parsedID = int.Parse(id);
            int parsedIdClient = int.Parse(idClient);
            return orderData.getProductPU(parsedID, parsedIdClient);
        }        

        public string makeValidations(string clientDoc, string clientName, DataTable orderLines, string type, string reason, DateTime selectedDate, string docId = "null")
        {
            if(type.Equals("pedido")) if (!isMoreThanToday(selectedDate)) return "La fecha de emisión que ha ingresado no es válida";
            if (type.Equals("devolucion")) if (docId.Equals("")) return "Debe seleccionar un pedido antes de continuar.";
            if (orderLines.Rows.Count == 0) return "Debe añadir productos para realizar un pedido.";
            if (type.Equals("devolucion") && reason.Equals("")) return "Debe ingresar un motivo para continuar.";
            if (type.Equals("devolucion") && docId.Equals("")) return "Debe seleccionar un documento de venta para continuar.";
            return "OK";
        }

        public string getProductName(string id)
        {
            int parsedID = int.Parse(id);
            return orderData.getProductName(parsedID);
        }

        public DataTable getOrderLines(string orderId)
        {
            return orderData.getOrderLines(int.Parse(orderId));
        }

        public DataTable getProductRecipe(object id)
        {
            int intId = int.Parse(id.ToString());
            return orderData.getProductRecipe(intId);
        }

        public bool isMoreThanToday(DateTime value)
        {
            return value > DateTime.Now;
        }

        public double updateAmount(double amount, float price, decimal decQuantity)
        {
            double quantity = double.Parse(decQuantity.ToString());
            return amount + (price * quantity);
        }

        public string getPolishedAmount(double amount)
        {
            return Math.Round(amount, 2).ToString();
        }

        public string getPolishedIGV(double amount)
        {
            return Math.Round((0.18 * amount), 2).ToString();
        }

        public string getPolishedTotal(double amount)
        {
            return Math.Round((1.18 * amount), 2).ToString();
        }

        public DataTable getLineXDocument(int idSaleDocument)
        {
            return orderData.getLineXDocument(idSaleDocument);
        }
    }
}
