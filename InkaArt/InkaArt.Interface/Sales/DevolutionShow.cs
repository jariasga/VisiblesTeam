﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Sales;

namespace InkaArt.Interface.Sales
{
    public partial class DevolutionShow : Form
    {
        private static int ID_NCREDIT = 6;
        private int orderId;
        private int clientId;
        OrderController orderController;
        public DevolutionShow(string id)
        {
            InitializeComponent();
            orderId = int.Parse(id);
            orderController = new OrderController();
        }

        private void DevolutionShow_Load(object sender, EventArgs e)
        {
            DataTable orderObject = orderController.GetOrders(orderId);
            populateFields(orderObject);
            clientId = orderController.getClientID(orderId);
        }

        private void populateFields(DataTable orderObject)
        {
            DataTable orderLine;
            foreach (DataRow row in orderObject.Rows)
            {
                date_deliverydate.Value = Convert.ToDateTime(row["deliveryDate"]);
                textbox_devamount.Text = row["saleAmount"].ToString();
                textbox_igv.Text = row["igv"].ToString();
                textbox_total.Text = row["totalAmount"].ToString();
                textbox_devtotal.Text = row["totalDev"].ToString();
                string clientDoc = orderController.getClientDoc(row["idClient"].ToString()), docType = "Boleta";
                textbox_doc.Text = clientDoc;
                textbox_name.Text = orderController.getClientName(row["idClient"].ToString());
                textbox_reason.Text = row["reason"].ToString();
                if (clientDoc.Length == 11) docType = "Factura";
                combo_doc.Text = docType;

                orderLine = orderController.getOrderLines(row["idOrder"].ToString());
                foreach (DataRow orderline in orderLine.Rows)
                {
                    string productId = orderline["idProduct"].ToString();
                    string name = orderController.getProductName(productId), pu = orderController.getProductPU(productId, row["idClient"].ToString());
                    grid_orderline.Rows.Add(name, orderline["quality"], pu, orderline["quantity"]);
                }
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            List<string> order = new List<string>();
            order.Add(orderId.ToString());
            orderController.deleteOrders(order);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button_fac_Click(object sender, EventArgs e)
        {
            DataTable orderLines = orderController.getOrderLines(orderId.ToString());
            int response = orderController.AddSaleDocument(ID_NCREDIT, textbox_devamount.Text, textbox_igv.Text, textbox_devtotal.Text, orderId, orderLines, clientId,1);
            if (response >= 0)
            {
                MessageBox.Show(this, "Se ha generado la nota de crédito exitosamente", "Nota de crédito", MessageBoxButtons.OK);
                DataTable orderObject = orderController.GetOrders(orderId, clientId);
                populateFields(orderObject);
            }
        }

        private void button_seedoc_Click(object sender, EventArgs e)
        {
            SaleDocumentShow form = new SaleDocumentShow(orderId, clientId);
            form.Show();
        }
    }
}
