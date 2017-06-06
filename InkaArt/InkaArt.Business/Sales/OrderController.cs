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
        public DataTable GetOrders()
        {
            return orderData.GetOrders();
        }
        public DataTable GetOrders(string type = "", string doc = "", string clientName = "", string orderStatus = "")
        {
            long aux, intDoc = -1;
            type = type.ToLower();
            orderStatus = orderStatus.ToLower();
            if (!doc.Equals("")) if (long.TryParse(doc, out aux)) intDoc = long.Parse(doc);
            return orderData.GetOrders(type,intDoc,clientName,orderStatus);
        }
        public int AddOrder(int idClient, int documentTypeId, DateTime deliveryDate, string saleAmount, string igv, string totalAmount, string orderStatus, int bdStatus, DataTable orderLines, string type)
        {
            saleAmount = Math.Round(double.Parse(saleAmount), 2).ToString();
            igv = Math.Round(double.Parse(igv), 2).ToString();
            totalAmount = Math.Round(double.Parse(totalAmount), 2).ToString();
            int orderAdded, orderLineAdded;
            orderAdded = orderData.InsertOrder(idClient, deliveryDate, saleAmount, igv, totalAmount, orderStatus, bdStatus, type);
            orderLineAdded = orderData.InsertOrderLines(orderLines, double.Parse(igv));
            return orderAdded + orderLineAdded;
        }
        public DataTable GetDocumentTypes()
        {
            return orderData.GetDocumentTypes();
        }
        public DataTable GetProducts()
        {
            return orderData.GetProducts();
        }
    }
}
