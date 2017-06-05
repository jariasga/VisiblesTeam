﻿using System;
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
        public void AddOrder(int idClient, int documentTypeId, DateTime deliveryDate, string saleAmount, string igv, string totalAmount, string orderStatus, int bdStatus, DataTable orderLines)
        {
            //orderData.InsertSaleDocument(documentTypeId, float.Parse(saleAmount), float.Parse(igv), float.Parse(totalAmount));
            orderData.InsertOrder(idClient, deliveryDate, saleAmount, igv, totalAmount, orderStatus, bdStatus);
            orderData.InsertOrderLines(orderLines,double.Parse(igv));
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