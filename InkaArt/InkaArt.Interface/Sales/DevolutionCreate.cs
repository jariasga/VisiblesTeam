using System;
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
    public partial class DevolutionCreate : Form
    {
        private int orderId;
        private int salesDocumentId;
        private int clientId;
        private double amount;
        DataTable saleDocumentList;
        DataTable productList;
        OrderController orderController = new OrderController();
        public DevolutionCreate()
        {
            InitializeComponent();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DocumentSearch form = new DocumentSearch();
            var response = form.ShowDialog();
            if (response == DialogResult.OK)
            {
                orderId = form.SelectedOrderId;
                salesDocumentId = form.SelectedDocumentId;
                DataTable orderObject = orderController.GetOrders(orderId);
                populateFields(orderObject);
            }
        }

        private void populateFields(DataTable orderObject)
        {
            DataTable orderLine;
            foreach (DataRow row in orderObject.Rows)
            {
                clientId = int.Parse(row["idClient"].ToString());
                date_deliverydate.Value = Convert.ToDateTime(row["deliveryDate"]);
                textbox_devamount.Text = row["saleAmount"].ToString();
                textbox_docid.Text = salesDocumentId.ToString();
                textbox_igv.Text = row["igv"].ToString();
                textbox_total.Text = row["totalAmount"].ToString();
                string clientDoc = orderController.getClientDoc(row["idClient"].ToString()), docType = "Boleta";
                textbox_doc.Text = clientDoc;
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

        private void DevolutionCreate_Load(object sender, EventArgs e)
        {
            productList = orderController.GetProducts();
            populateCombobox(combo_product, productList, "name", "idProduct");
        }

        private void populateCombobox(ComboBox combo, DataTable dataSource, string displayParam, string valueParam)
        {
            var dp = displayParam;
            var vp = valueParam;
            Dictionary<string, string> obj = new Dictionary<string, string>();
            foreach (DataRow row in dataSource.Rows)
            {
                obj.Add(row[dp].ToString(), row[vp].ToString());
            }
            combo.DataSource = new BindingSource(obj, null);
            combo.DisplayMember = "Key";
            combo.ValueMember = "Value";
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            DataTable orderLine = parseDataGrid(grid_orderline);
            string messageResponse = orderController.makeValidations(textbox_doc.Text, textbox_name.Text, orderLine, "devolucion", "",textbox_docid.Text);
            if (messageResponse.Equals("OK"))
            {                
                int response = orderController.AddOrder(clientId, combo_doc.SelectedIndex+1, date_deliverydate.Value, textbox_devamount.Text, textbox_igv.Text, textbox_total.Text, "registrado", 1, orderLine, "devolucion", textbox_reason.Text, textbox_devtotal.Text);
                if (response >= 0)
                {
                    MessageBox.Show(this, "La devolución ha sido registrada con éxito.", "Registrar Devolución", MessageBoxButtons.OK);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                MessageBox.Show(this, messageResponse, "Error", MessageBoxButtons.OK);
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
            double remAmount = 0;
            foreach (DataGridViewRow row in grid_orderline.Rows)
            {
                if (Convert.ToBoolean(row.Cells[deleteColumn.Index].Value) == true)
                {
                    remAmount += Math.Round((double.Parse(row.Cells[2].Value.ToString()) * double.Parse(row.Cells[3].Value.ToString())), 2);
                    grid_orderline.Rows.RemoveAt(row.Index);
                }
            }
            amount -= remAmount;
            if (amount > 0)
            {
                textbox_devamount.Text = Math.Round(amount, 2).ToString();
                textbox_igv.Text = Math.Round((0.18 * amount), 2).ToString();
                textbox_devtotal.Text = Math.Round((1.18 * amount), 2).ToString();
            }
            else
            {
                amount = 0;
                textbox_devamount.Text = textbox_igv.Text = textbox_devtotal.Text = "S/. 0.00";
            }
            if (grid_orderline.RowCount == 0) textbox_devamount.Text = textbox_igv.Text = textbox_devtotal.Text = "S/. 0.00";
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (productList.Rows.Count == 0) productList = orderController.GetProducts();
            foreach (DataRow row in productList.Rows)
            {
                var aux = row["idProduct"];
                string strAux = aux.ToString();
                if (combo_product.SelectedValue.ToString().Equals(row["idProduct"].ToString()))
                {
                    float price = float.Parse(row["localPrice"].ToString()) + float.Parse(row["basePrice"].ToString());
                    amount += price * float.Parse(numeric_quantity.Value.ToString());
                    grid_orderline.Rows.Add(row["name"], combo_quality.Text, price.ToString(), numeric_quantity.Value.ToString());
                }
            }
            textbox_devamount.Text = Math.Round(amount, 2).ToString();
            textbox_igv.Text = Math.Round((0.18 * amount), 2).ToString();
            textbox_devtotal.Text = Math.Round((1.18 * amount), 2).ToString();
        }

        private void numeric_quantity_KeyUp(object sender, KeyEventArgs e)
        {
            button_add.Enabled = numeric_quantity.Value > 0;
        }

        private void numeric_quantity_ValueChanged(object sender, EventArgs e)
        {
            button_add.Enabled = numeric_quantity.Value > 0;
        }
    }
}