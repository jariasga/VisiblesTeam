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
        DataTable selectedInvoice;
        DataTable productList;
        DataTable orderLine;
        DataTable invoicedLine;
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
                selectedInvoice = orderController.GetInvoice(salesDocumentId);
                populateFields(orderObject);
                DataTable recipes = orderController.getProductRecipe(combo_product.SelectedValue);
                populateCombobox(combo_quality, recipes, "version", "idRecipe");
            }
        }

        private void populateFields(DataTable orderObject)
        {
            textbox_docid.Text = salesDocumentId.ToString();
            foreach (DataRow row in selectedInvoice.Rows)
            {
                textbox_total.Text = textbox_devtotal.Text = row["totalAmount"].ToString();
                textbox_devamount.Text = row["amount"].ToString();
                textbox_igv.Text = row["igv"].ToString();
            }


            foreach (DataRow row in orderObject.Rows)
            {
                clientId = int.Parse(row["idClient"].ToString());
                date_deliverydate.Value = Convert.ToDateTime(row["deliveryDate"]);
                string clientDoc = orderController.getClientDoc(row["idClient"].ToString()), docType = "Boleta";
                textbox_doc.Text = clientDoc;
                textbox_name.Text = orderController.getClientName(row["idClient"].ToString());
                if (clientDoc.Length == 11) docType = "Factura";
                combo_doc.Text = docType;
                orderLine = orderController.getOrderLines(row["idOrder"].ToString());
                grid_orderline.Rows.Clear();
                invoicedLine = orderController.getLineXDocument(salesDocumentId);
                foreach (DataRow orderline in orderLine.Rows)
                {
                    foreach (DataRow invoicedline in invoicedLine.Rows)
                    {
                        if (orderline["idLineItem"].ToString().Equals(invoicedline["idLineItem"].ToString()))
                        {
                            string productId = orderline["idProduct"].ToString();
                            string name = orderController.getProductName(productId);
                            if (int.Parse(invoicedline["finished"].ToString()) > 0) grid_orderline.Rows.Add(name, orderline["quality"], invoicedline["pu"], invoicedline["finished"]);
                        }
                    }
                }
            }
        }

        private void DevolutionCreate_Load(object sender, EventArgs e)
        {
            productList = orderController.GetProducts();
            populateCombobox(combo_product, productList, "name", "idProduct");
            DataTable recipes = orderController.getProductRecipe(combo_product.SelectedValue);
            populateCombobox(combo_quality, recipes, "version", "idRecipe");
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
            string messageResponse = orderController.makeValidations(textbox_doc.Text, textbox_name.Text, orderLine, "devolucion", textbox_reason.Text , date_deliverydate.Value,textbox_docid.Text);
            if (messageResponse.Equals("OK"))
            {                
                int response = orderController.AddOrder(clientId, combo_doc.SelectedIndex+1, date_deliverydate.Value, textbox_devamount.Text, textbox_igv.Text, textbox_total.Text, "registrado", 1, orderLine, "devolucion", reason: textbox_reason.Text, totalDev: textbox_devtotal.Text);
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
            int currentRowAmount = grid_orderline.RowCount;
            for (int i = currentRowAmount - 1; i > 0; i--)
            {
                DataGridViewRow row = grid_orderline.Rows[i];
                if (Convert.ToBoolean(row.Cells[deleteColumn.Index].Value) == true)
                {
                    remAmount += Math.Round((double.Parse(row.Cells[2].Value.ToString()) * double.Parse(row.Cells[3].Value.ToString())), 2);
                    grid_orderline.Rows.RemoveAt(row.Index);
                }
            }
            foreach (DataGridViewRow row in grid_orderline.Rows)
            {
                if (Convert.ToBoolean(row.Cells[deleteColumn.Index].Value) == true)
                {
                    remAmount += Math.Round((double.Parse(row.Cells[2].Value.ToString()) * double.Parse(row.Cells[3].Value.ToString())), 2);
                    grid_orderline.Rows.RemoveAt(row.Index);
                }
            }
            amount = 0;
            foreach (DataGridViewRow row in grid_orderline.Rows)
            {
                amount += Math.Round((double.Parse(row.Cells[2].Value.ToString()) * double.Parse(row.Cells[3].Value.ToString())), 2);
            }
            if (amount > 0)
            {
                textbox_devamount.Text = orderController.getPolishedAmount(amount);
                textbox_igv.Text = orderController.getPolishedIGV(amount);
                textbox_devtotal.Text = orderController.getPolishedTotal(amount);
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
            if (isProductAdded()) MessageBox.Show(this, "Este producto ya ha sido agregado.", "Producto", MessageBoxButtons.OK);
            else
            {
                string resp = isQuantityBelow();
                if (!resp.Equals("OK")) MessageBox.Show(this, resp, "Producto", MessageBoxButtons.OK);
                else
                {
                    if (productList.Rows.Count == 0) productList = orderController.GetProducts();
                    foreach (DataRow row in productList.Rows)
                    {
                        var aux = row["idProduct"];
                        string strAux = aux.ToString();
                        if (combo_product.SelectedValue.ToString().Equals(row["idProduct"].ToString()))
                        {
                            float price = getPrice(row["idProduct"].ToString());
                            amount += price * float.Parse(numeric_quantity.Value.ToString());
                            grid_orderline.Rows.Add(row["name"], combo_quality.Text, price.ToString(), numeric_quantity.Value.ToString());
                        }
                    }
                    textbox_devamount.Text = orderController.getPolishedAmount(amount);
                    textbox_igv.Text = orderController.getPolishedIGV(amount);
                    textbox_devtotal.Text = orderController.getPolishedTotal(amount);
                }
            }
        }

        private float getPrice(string productId)
        {
            foreach(DataRow row in orderLine.Rows)
            {
                if (row["idProduct"].ToString().Equals(productId))
                {
                    string idLineItem = row["idLineItem"].ToString();
                    foreach(DataRow irow in invoicedLine.Rows)
                    {
                        if (irow["idLineItem"].ToString().Equals(idLineItem))
                        {
                            return float.Parse(irow["pu"].ToString());
                        }
                    }
                }
            }
            return 0;
        }

        private string isQuantityBelow()
        {
            int quantity = int.Parse(numeric_quantity.Value.ToString());
            string selectedProduct;
            if (combo_product.SelectedItem != null) selectedProduct = combo_product.SelectedItem.ToString();
            else return "OK";
            int attemps = 0;
            string selectedVersion = combo_quality.SelectedItem.ToString();
            foreach (DataRow row in orderLine.Rows)
            {
                string cellProduct = row["idProduct"].ToString();
                string cellVersion = row["idRecipe"].ToString();
                if (selectedProduct.Contains(cellProduct))
                {
                    foreach (DataRow irow in invoicedLine.Rows)
                    {
                        if (irow["idLineItem"].Equals(row["idLineItem"]))
                        {
                            int cellQuantity = int.Parse(irow["finished"].ToString());
                            if (cellQuantity < quantity) return "No puede agregar más de lo que pidió.";
                            if (!selectedVersion.Contains(cellVersion)) return "No puede seleccionar una versión diferente de la que pidió";
                        }
                    }
                }
                else attemps++;
            }
            if (attemps == orderLine.Rows.Count) return "No puede agregar un producto que no ha pedido.";
            return "OK";
        }

        private bool isProductAdded()
        {
            string selectedProduct = combo_product.SelectedItem.ToString();
            foreach (DataGridViewRow row in grid_orderline.Rows)
            {
                string cellProduct = row.Cells[0].Value.ToString();
                if (selectedProduct.Contains(cellProduct)) return true;
            }
            return false;
        }

        private void numeric_quantity_KeyUp(object sender, KeyEventArgs e)
        {
            button_add.Enabled = numeric_quantity.Value > 0;
        }

        private void numeric_quantity_ValueChanged(object sender, EventArgs e)
        {
            button_add.Enabled = numeric_quantity.Value > 0;
        }

        private void combo_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            productList = orderController.GetProducts();
            foreach (DataRow row in productList.Rows)
            {
                if (combo_product.SelectedValue.ToString().Equals(row["idProduct"].ToString()))
                {
                    DataTable recipes = orderController.getProductRecipe(row["idProduct"]);
                    populateCombobox(combo_quality, recipes, "version", "idRecipe");
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void grid_orderline_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}