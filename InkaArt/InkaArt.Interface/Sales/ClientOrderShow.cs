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
        private List<int> idProd = new List<int>(), quantity = new List<int>(), idVer = new List<int>();
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
            }
            foreach (DataGridViewRow gridRow in grid_orderline.Rows)
            {
                if (int.Parse(gridRow.Cells[7].Value.ToString()) < int.Parse(gridRow.Cells[4].Value.ToString()))
                {
                    return;
                }
            }
            button_fac.Visible = false;
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
            int numValid = 0, curToFac = 0;
            int[] cant = new int[3];
            bool fail = false;
            foreach (DataGridViewRow gridRow in grid_orderline.Rows)
            {
                switch (int.Parse(gridRow.Cells[0].Value.ToString()))
                {
                    case 1:
                        cant[0] = int.Parse(gridRow.Cells[6].Value.ToString());
                        break;
                    case 2:
                        cant[1] = int.Parse(gridRow.Cells[6].Value.ToString());
                        break;
                    case 3:
                        cant[2] = int.Parse(gridRow.Cells[6].Value.ToString());
                        break;
                }
            }
            foreach (DataGridViewRow gridRow in grid_orderline.Rows)
            {
                if (int.Parse(gridRow.Cells[4].Value.ToString()) <= int.Parse(gridRow.Cells[7].Value.ToString()))
                {
                    if (int.Parse(gridRow.Cells[5].Value.ToString()) != 0) return "No se puede volver a facturar una línea ya facturada, por favor corriga los datos.";
                }
                if (int.Parse(gridRow.Cells[5].Value.ToString()) > 0)
                {
                    if (int.Parse(gridRow.Cells[7].Value.ToString()) + int.Parse(gridRow.Cells[5].Value.ToString()) > int.Parse(gridRow.Cells[4].Value.ToString()))
                        return "No se puede facturar más de lo que se ha pedido";
                }
                if (int.Parse(gridRow.Cells[5].Value.ToString()) > int.Parse(gridRow.Cells[6].Value.ToString()))
                    return "La cantidad a facturar supera a la cantidad disponible, por favor corriga los datos.";
                if (int.Parse(gridRow.Cells[5].Value.ToString()) > int.Parse(gridRow.Cells[4].Value.ToString()))
                    return "La cantidad a facturar supera a la cantidad que se ha pedido, por favor corriga los datos.";
                if (int.Parse(gridRow.Cells[5].Value.ToString()) > 0)
                    numValid++;
                curToFac = int.Parse(gridRow.Cells[5].Value.ToString());
                switch (int.Parse(gridRow.Cells[0].Value.ToString()))
                {
                    case 1:
                        cant[0] -= curToFac;
                        if (cant[0] < 0) fail = true;
                        break;
                    case 2:
                        cant[1] -= curToFac;
                        if (cant[1] < 0) fail = true;
                        break;
                    case 3:
                        cant[2] -= curToFac;
                        if (cant[2] < 0) fail = true;
                        break;
                }
                if (fail) return "La cantidad total a facturar de un producto supera a la cantidad disponible, por favor corriga los datos.";
            }
            if (numValid == 0) return "Por favor ingrese una cantidad a facturar válida en la columna 'A Facturar'.";
            return "OK";
        }

        private void button_calculate_Click(object sender, EventArgs e)
        {
            double amount = 0;
            foreach (DataGridViewRow gridRow in grid_orderline.Rows)
            {
                int toFacCant = int.Parse(gridRow.Cells[5].Value.ToString());
                if (toFacCant > 0)
                {
                    float price = int.Parse(gridRow.Cells[3].Value.ToString());
                    amount = orderController.updateAmount(amount, price,decimal.Parse(toFacCant.ToString()));
                }
            }
            textbox_amount_todoc.Text = orderController.getPolishedAmount(amount);
            textbox_igv_todoc.Text = orderController.getPolishedIGV(amount);
            textbox_total_todoc.Text = orderController.getPolishedTotal(amount);
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
                    int curVersionId = orderController.getVersionId(grid_orderline.Rows[i].Cells[2].Value.ToString());
                    if (curQuantity != 0)
                    {
                        idProd.Add(curProductId);
                        quantity.Add(curQuantity);
                        idVer.Add(curVersionId);
                    }
                }
                orderController.AddSaleDocumentW(orderId, idProd.ToArray(), quantity.ToArray(), idVer.ToArray());
                MessageBox.Show("Se ha generado el documento de venta exitosamente.", "Éxito", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
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
