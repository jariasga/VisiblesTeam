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
    public partial class ClientOrderCreate : Form
    {
        OrderController orderController = new OrderController();
        DataTable saleDocumentList;
        DataTable productList;
        private int currentClientId, currentClientType, currentClientNat;
        private double amount;
        public ClientOrderCreate()
        {
            InitializeComponent();
            amount = 0;
        }

        public ClientOrderCreate(string text)
        {
            InitializeComponent();
            Text = text;
        }

        private void clients_index_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ClientOrderCreate_Load(object sender, EventArgs e)
        {
            productList = orderController.GetProducts();
            populateCombobox(combo_product, productList, "name", "idProduct");
            label_stock.Visible = label_stockLabel.Visible = false;
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

        private void button_back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            int docTypeId = textbox_doctype.Text.Equals("Boleta") ? 1 : 2;         
            DataTable orderLine = parseDataGrid(grid_orderline);
            string messageResponse = orderController.makeValidations(textbox_doc.Text,textbox_name.Text, orderLine, "pedido", "");
            if (messageResponse.Equals("OK"))
            {
                int response = orderController.AddOrder(currentClientId, docTypeId, date_delivery.Value, textbox_amount.Text, textbox_igv.Text, textbox_total.Text, "registrado", 1, orderLine, "pedido");
                if (response >= 0)
                {
                    MessageBox.Show(this, "El pedido ha sido registrado con éxito.", "Registrar Pedido", MessageBoxButtons.OK);
                    ClearFields();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }else
            {
                MessageBox.Show(this, messageResponse, "Error", MessageBoxButtons.OK);
            }
        }

        private void ClearFields()
        {
            amount = 0;
            currentClientId = -1;
            date_delivery.Value = DateTime.Now;
            textbox_doc.Clear();
            textbox_name.Clear();
            numeric_quantity.Value = 0;
            grid_orderline.Rows.Clear();
            textbox_amount.Text = textbox_igv.Text = textbox_total.Text = "S/. 0.00";
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

        private void button_create_Click(object sender, EventArgs e)
        {
            Form client_form = new ClientCreate();
            client_form.Show();
        }
        private void button_search_Click(object sender, EventArgs e)
        {
            var form = new ClientSearch();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentClientId = form.SelectedClientId;
                textbox_doc.Text = form.SelectedClientDoc.ToString();
                textbox_name.Text = form.SelectedClientName;
                currentClientType = form.SelectedClientType;
                currentClientNat = form.SelectedClientTypeNat;
                if (currentClientType == 0)
                {
                    clientIdentifierLabel.Text = "DNI";
                    textbox_doctype.Text = "Boleta";
                }
                else
                {
                    clientIdentifierLabel.Text = "RUC";
                    textbox_doctype.Text = "Factura";
                }
                if (currentClientNat == 0)
                {
                    label_stock.Visible = label_stockLabel.Visible = true;
                    foreach (DataRow row in productList.Rows)
                    {
                        if (combo_product.SelectedValue.ToString().Equals(row["idProduct"].ToString()))
                        {
                            label_stock.Text = row["logicalStock"].ToString();
                        }
                    }
                }
                else
                    label_stock.Visible = label_stockLabel.Visible = false;
            }
        }

        private void ClientOrderCreate_Shown(object sender, EventArgs e)
        {

        }

        private void numeric_quantity_ValueChanged(object sender, EventArgs e)
        {
            button_add.Enabled = numeric_quantity.Value > 0;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textbox_doc.Text.Equals("") || textbox_name.Text.Equals(""))
            {
                MessageBox.Show(this, "Primero debe seleccionar un cliente", "Agregar productos", MessageBoxButtons.OK);
            }
            else
            {
                if (isProductAdded()) MessageBox.Show(this, "Este producto ya ha sido agregado.", "Producto", MessageBoxButtons.OK);
                else
                {
                    bool canAdd;
                    if (productList.Rows.Count == 0) productList = orderController.GetProducts();
                    foreach (DataRow row in productList.Rows)
                    {
                        var aux = row["idProduct"];
                        string strAux = aux.ToString();
                        if (combo_product.SelectedValue.ToString().Equals(row["idProduct"].ToString()))
                        {
                            canAdd = orderController.verifyStock(currentClientNat, row["logicalStock"].ToString(), numeric_quantity.Value.ToString());
                            if (canAdd)
                            {
                                float price = orderController.getRightPrice(currentClientNat, row["localPrice"].ToString(), row["exportPrice"].ToString());
                                amount += price * float.Parse(numeric_quantity.Value.ToString());
                                grid_orderline.Rows.Add(row["name"], combo_quality.Text, price.ToString(), numeric_quantity.Value.ToString());
                            }
                            else MessageBox.Show(this, "La cantidad supera al stock disponible", "Stock", MessageBoxButtons.OK);
                        }
                    }
                    textbox_amount.Text = Math.Round(amount, 2).ToString();
                    textbox_igv.Text = Math.Round((0.18 * amount), 2).ToString();
                    textbox_total.Text = Math.Round((1.18 * amount), 2).ToString();
                }
            }
        }

        private bool isProductAdded()
        {
            string selectedProduct = combo_product.SelectedItem.ToString();
            foreach(DataGridViewRow row in grid_orderline.Rows)
            {
                string cellProduct = row.Cells[0].Value.ToString();
                if (selectedProduct.Contains(cellProduct)) return true;
            }
            return false;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void combo_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow row in productList.Rows)
            {
                if (combo_product.SelectedValue.ToString().Equals(row["idProduct"].ToString()))
                {
                    label_stock.Text = row["logicalStock"].ToString();
                }
            }
        }

        private void numeric_quantity_KeyUp(object sender, KeyEventArgs e)
        {
            button_add.Enabled = numeric_quantity.Value > 0;
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
                    remAmount += Math.Round((double.Parse(row.Cells[2].Value.ToString()) * double.Parse(row.Cells[3].Value.ToString())),2);
                    grid_orderline.Rows.RemoveAt(row.Index);
                }
            }
            amount -= remAmount;
            if (amount > 0)
            {
                textbox_amount.Text = Math.Round(amount, 2).ToString();
                textbox_igv.Text = Math.Round((0.18 * amount), 2).ToString();
                textbox_total.Text = Math.Round((1.18 * amount), 2).ToString();
            }
            else
            {
                amount = 0;
                textbox_amount.Text = textbox_igv.Text = textbox_total.Text = "S/. 0.00";
            }
            if (grid_orderline.RowCount == 0) textbox_amount.Text = textbox_igv.Text = textbox_total.Text = "S/. 0.00";
        }
    }
}
