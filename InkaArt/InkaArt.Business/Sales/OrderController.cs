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
        public int AddOrder(int idClient, int documentTypeId, DateTime deliveryDate, string saleAmount, string igv, string totalAmount, string orderStatus, int bdStatus, DataTable orderLines)
        {
            saleAmount = Math.Round(double.Parse(saleAmount), 2).ToString();
            igv = Math.Round(double.Parse(igv), 2).ToString();
            totalAmount = Math.Round(double.Parse(totalAmount), 2).ToString();
            int orderAdded, orderLineAdded;
            orderAdded = orderData.InsertOrder(idClient, deliveryDate, saleAmount, igv, totalAmount, orderStatus, bdStatus);
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
