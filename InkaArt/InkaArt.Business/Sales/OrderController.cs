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

        public int AddSaleDocument(int selectedDoc, string strAmount, string strIgv, string strTotal, int orderId, DataTable orderLines)
        {
            float amount = float.Parse(strAmount), igv = float.Parse(strIgv), total = float.Parse(strTotal);
            int responseSD, responseLI = 0;
            responseSD = orderData.InsertSaleDocument(++selectedDoc,amount,igv,total,orderId);
            string idSaleDocument = orderData.getSaleDocumentId().ToString();
            foreach (DataRow orderline in orderLines.Rows)
            {
                string idLineItem = orderline["idLineItem"].ToString();
                responseLI += orderData.UpdateLineItem(idLineItem, idSaleDocument);
            }
            return responseSD + responseLI;
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

        public DataTable GetSalesDocument()
        {
            return orderData.GetSalesDocument();
        }

        public int AddOrder(int idClient, int documentTypeId, DateTime deliveryDate, string saleAmount, string igv, string totalAmount, string orderStatus, int bdStatus, DataTable orderLines, string type, bool isClientSelected = false, int clientType = -1, string reason = "", string totalDev = "")
        {
            if (documentTypeId != -1) documentTypeId++;
            saleAmount = Math.Round(double.Parse(saleAmount), 2).ToString();
            igv = Math.Round(double.Parse(igv), 2).ToString();
            totalAmount = Math.Round(double.Parse(totalAmount), 2).ToString();
            int orderAdded, orderLineAdded;
            orderAdded = orderData.InsertOrder(idClient, deliveryDate, saleAmount, igv, totalAmount, orderStatus, bdStatus, type,reason, totalDev);
            orderLineAdded = orderData.InsertOrderLines(orderLines, double.Parse(igv), type, isClientSelected, clientType);
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

        public string makeValidations(string clientDoc, string clientName, DataTable orderLines, string type, string reason, string docId = "null")
        {
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

        public DataTable getOrderLines(string id)
        {
            return orderData.getOrderLines(int.Parse(id));
        }

        public DataTable getProductRecipe(object id)
        {
            int intId = int.Parse(id.ToString());
            return orderData.getProductRecipe(intId);
        }
    }
}
