using InkaArt.Business.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Sales
{
    public partial class ClientOrderShow : Form
    {
        int orderId;
        OrderController orderController;
        public ClientOrderShow(string id)
        {
            InitializeComponent();
            orderId = int.Parse(id);
            orderController = new OrderController();
        }

        private void ClientOrderShow_Load(object sender, EventArgs e)
        {
            DataTable orderObject = orderController.GetOrders(orderId);
            populateFields(orderObject);
        }

        private void populateFields(DataTable orderObject)
        {
            DataTable orderLine;
            foreach (DataRow row in orderObject.Rows)
            {
                date_deliverydate.Value = Convert.ToDateTime(row["deliveryDate"]);
                combo_orderstatus.Text = row["orderStatus"].ToString();
                textbox_amount.Text = row["saleAmount"].ToString();
                textbox_igv.Text = row["igv"].ToString();
                textbox_total.Text = row["totalAmount"].ToString();
                string clientDoc = orderController.getClientDoc(row["idClient"].ToString()), docType="Boleta";
                textbox_ruc.Text = clientDoc;
                textbox_name.Text = orderController.getClientName(row["idClient"].ToString());
                if (clientDoc.Length == 11) docType = "Factura";
                combo_doc.Text = docType;
                
                orderLine = orderController.getOrderLines(row["idOrder"].ToString());
                foreach (DataRow orderline in orderLine.Rows)
                {
                    string productId = orderline["idProduct"].ToString();
                    string name = orderController.getProductName(productId), pu = orderController.getProductPU(productId);
                    grid_orderline.Rows.Add(name, orderline["quality"], pu, orderline["quantity"]);
                }
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {

        }
        
        private void button_doc_Click(object sender, EventArgs e)
        {

        }
    }
}
