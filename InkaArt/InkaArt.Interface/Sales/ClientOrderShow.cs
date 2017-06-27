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
        DataTable orderLine;
        DataTable orderLineToFac;
        private double toFacAmount;
        private int clientId;
        public ClientOrderShow(string id)
        {
            InitializeComponent();
            orderId = int.Parse(id);
            orderController = new OrderController();
            orderLine = new DataTable();
            orderLineToFac = new DataTable();
            toFacAmount = 0;
        }

        private void ClientOrderShow_Load(object sender, EventArgs e)
        {
            DataTable orderObject = orderController.GetOrders(orderId);
            populateFields(orderObject);
        }

        private void populateFields(DataTable orderObject)
        {
            foreach (DataRow row in orderObject.Rows)
            {
                int totalFinished = 0, totalInvoiced = 0;
                toFacAmount = 0;
                date_deliverydate.Value = Convert.ToDateTime(row["deliveryDate"]);
                combo_orderstatus.Text = row["orderStatus"].ToString();
                textbox_amount.Text = row["saleAmount"].ToString();
                textbox_igv.Text = row["igv"].ToString();
                textbox_total.Text = row["totalAmount"].ToString();
                clientId = int.Parse(row["idClient"].ToString());
                string clientDoc = orderController.getClientDoc(row["idClient"].ToString()), docType="Boleta";
                textbox_ruc.Text = clientDoc;
                textbox_name.Text = orderController.getClientName(row["idClient"].ToString());
                if (clientDoc.Length == 11)
                {
                    docType = "Factura";
                    label_doc.Text = "RUC";
                }
                else label_doc.Text = "DNI";
                combo_doc.Text = docType;
                orderLine = orderController.getOrderLines(row["idOrder"].ToString());
                orderLineToFac = orderLine.Clone();
                grid_orderline.Rows.Clear();
                foreach (DataRow orderline in orderLine.Rows)
                {
                    string productId = orderline["idProduct"].ToString();
                    string name = orderController.getProductName(productId), pu = orderController.getProductPU(productId,row["idClient"].ToString());
                    string curStock = orderController.getCurrentStock(productId);
                    totalFinished += int.Parse(curStock);
                    totalInvoiced += int.Parse(orderline["quantityInvoiced"].ToString());
                    if (int.Parse(orderline["quantityProduced"].ToString()) > 0) orderLineToFac.Rows.Add(orderline.ItemArray);
                    float price = float.Parse(pu.ToString());
                    toFacAmount = orderController.updateAmount(toFacAmount, price, decimal.Parse(orderline["quantityProduced"].ToString()));
                    grid_orderline.Rows.Add(name, orderline["quality"], pu, orderline["quantity"], curStock, orderline["quantityInvoiced"]);
                }
                if (totalInvoiced > 0) button_seedoc.Visible = true;
                else button_seedoc.Visible = true;
                textbox_amount_todoc.Text = orderController.getPolishedAmount(toFacAmount);
                textbox_igv_todoc.Text = orderController.getPolishedIGV(toFacAmount);
                textbox_total_todoc.Text = orderController.getPolishedTotal(toFacAmount);
            }
        }

        private DataTable parseDataGrid(DataGridView grid_orderline)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in grid_orderline.Columns)
            {
                dt.Columns.Add(col.HeaderText);
            }

            foreach (DataGridViewRow row in grid_orderline.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }
            return dt;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            List<string> order = new List<string>();
            order.Add(orderId.ToString());
            orderController.deleteOrders(order);
            DialogResult = DialogResult.OK;
            Close();
        }
        
        private void button_doc_Click(object sender, EventArgs e)
        {

        }

        private void button_fac_Click(object sender, EventArgs e)
        {
            int response = orderController.AddSaleDocument(combo_doc.SelectedIndex, textbox_amount_todoc.Text, textbox_igv_todoc.Text, textbox_total_todoc.Text, orderId, orderLineToFac, clientId);
            if (response >= 0)
            {
                MessageBox.Show(this, "Se ha generado el documento de venta exitosamente", "Documento de Venta", MessageBoxButtons.OK);
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
