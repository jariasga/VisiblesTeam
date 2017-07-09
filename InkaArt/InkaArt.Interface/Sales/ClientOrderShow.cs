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
using InkaArt.Interface.Production;

namespace InkaArt.Interface.Sales
{
    public partial class ClientOrderShow : Form
    {
        int orderId;
        OrderController orderController;
        FinalProducts fp;
        DataTable orderLine;
        DataTable orderLineToFac;
        private double toFacAmount;
        private int clientId;
        private List<int> idProd = new List<int>(), quantity = new List<int>();
        public ClientOrderShow(string id)
        {
            InitializeComponent();
            orderId = int.Parse(id);
            orderController = new OrderController();
            fp = new FinalProducts();
            orderLine = new DataTable();
            orderLineToFac = new DataTable();
            toFacAmount = 0;
        }

        private void ClientOrderShow_Load(object sender, EventArgs e)
        {
            fp.hallaStock();
            DataTable orderObject = orderController.GetOrders(orderId);
            populateFields(orderObject);
        }

        private void populateFields(DataTable orderObject)
        {
            foreach (DataRow row in orderObject.Rows)
            {
                if (row["orderStatus"].ToString().Equals("facturado")) button_fac.Visible = false;
                else button_fac.Visible = true;
                int totalFinished = 0, totalInvoiced = 0, auxResult;
                string clientDoc = "", docType="";
                toFacAmount = 0;
                date_deliverydate.Value = Convert.ToDateTime(row["deliveryDate"]);
                combo_orderstatus.Text = row["orderStatus"].ToString();
                textbox_amount.Text = row["saleAmount"].ToString();
                textbox_igv.Text = row["igv"].ToString();
                textbox_total.Text = row["totalAmount"].ToString();
                if (int.TryParse(row["idClient"].ToString(), out auxResult))
                {
                    clientId = auxResult;
                    clientDoc = orderController.getClientDoc(row["idClient"].ToString());
                    textbox_ruc.Text = clientDoc;
                    textbox_name.Text = orderController.getClientName(row["idClient"].ToString());
                } 
                if (!clientDoc.Equals(""))
                {
                    if (clientDoc.Length == 11)
                    {
                        docType = "Factura";
                        label_doc.Text = "RUC";
                    }
                    else
                    {
                        docType = "Boleta";
                        label_doc.Text = "DNI";
                    }
                }
                combo_doc.Text = docType;
                orderLine = orderController.getOrderLines(row["idOrder"].ToString());
                orderLineToFac = orderLine.Clone();
                grid_orderline.Rows.Clear();
                foreach (DataRow orderline in orderLine.Rows)
                {
                    string productId = orderline["idProduct"].ToString();
                    string name = orderController.getProductName(productId);
                    string pu;
                    if (clientId == 0 && clientDoc.Equals("")) pu = orderController.getProductPU(productId);
                    else pu = orderController.getProductPU(productId, row["idClient"].ToString());
                    string curStock = orderController.getCurrentStock(productId);
                    if (int.Parse(curStock) < 0) curStock = "0";
                    totalFinished += int.Parse(curStock);
                    totalInvoiced += int.Parse(orderline["quantityInvoiced"].ToString());
                    if (int.Parse(orderline["quantityProduced"].ToString()) > 0) orderLineToFac.Rows.Add(orderline.ItemArray);
                    float price = float.Parse(pu.ToString());
                    toFacAmount = orderController.updateAmount(toFacAmount, price, decimal.Parse(orderline["quantityProduced"].ToString()));

                    string cantMoved = orderController.getStockDocumentParam(orderId,productId,"cantMoved");
                    if (cantMoved.Equals("") || int.Parse(cantMoved) < 0) cantMoved = "0";

                    grid_orderline.Rows.Add(productId,name, orderline["quality"], pu, orderline["quantity"],0, cantMoved, orderline["quantityInvoiced"]);
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


        private void button_seedoc_Click(object sender, EventArgs e)
        {
            SaleDocumentShow form = new SaleDocumentShow(orderId, clientId);
            form.Show();
        }
        private string validateDataGrid()
        {
            int numZeros = 0;
            foreach (DataGridViewRow gridRow in grid_orderline.Rows)
            {
                if (int.Parse(gridRow.Cells[5].Value.ToString()) > int.Parse(gridRow.Cells[6].Value.ToString()))
                    return "La cantidad a facturar supera a la cantidad disponible, por favor corriga los datos.";
                if (int.Parse(gridRow.Cells[5].Value.ToString()) <= 0)
                    numZeros++;
            }
            if (numZeros > 1) return "Por favor ingrese una cantidad a facturar en la columna 'A Facturar'.";
            return "OK";
        }

        private void button_fac_Click(object sender, EventArgs e)
        {
            string response = validateDataGrid();
            if (response.Equals("OK"))
            {
                for (int i = 0; i < grid_orderline.Rows.Count; i++)
                {
                    int curProductId = int.Parse(grid_orderline.Rows[i].Cells[0].Value.ToString());
                    int curQuantity = int.Parse(grid_orderline.Rows[i].Cells[5].Value.ToString());
                    if (curQuantity != 0)
                    {
                        idProd.Add(curProductId);
                        quantity.Add(curQuantity);
                    }
                }
                orderController.AddSaleDocumentW(orderId, idProd.ToArray(), quantity.ToArray());
                MessageBox.Show("Se ha generado una nota de crédito exitosamente.", "Éxito", MessageBoxButtons.OK);
                Close();
            }
            else
            {
                MessageBox.Show(response, "Error", MessageBoxButtons.OK);
            }
        }

        private void grid_orderline_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
