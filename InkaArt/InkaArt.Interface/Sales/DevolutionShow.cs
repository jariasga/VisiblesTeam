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
    public partial class DevolutionShow : Form
    {
        private static int ID_NCREDIT = 6;
        private int orderId;
        private int clientId;
        OrderController orderController;
        private List<int> idProd = new List<int>(), quantity = new List<int>();
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
                    string cantMoved = orderController.getStockDocumentParam(orderId, productId, "cantMoved");
                    if (cantMoved.Equals("") || int.Parse(cantMoved) < 0) cantMoved = "0";
                    grid_orderline.Rows.Add(productId,name, orderline["quality"], pu, orderline["quantity"], 0, cantMoved, orderline["quantityInvoiced"]);
                }
            }

            foreach (DataGridViewRow gridRow in grid_orderline.Rows)
            {
                if (int.Parse(gridRow.Cells[7].Value.ToString()) < int.Parse(gridRow.Cells[6].Value.ToString()))
                {
                    return;
                }
            }
            button_fac.Visible = false;
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

        }

        private void button_seedoc_Click(object sender, EventArgs e)
        {
            SaleDocumentShow form = new SaleDocumentShow(orderId, clientId);
            form.Show();
        }

        private void button_fac_Click_1(object sender, EventArgs e)
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
                orderController.AddSaleDocumentW(orderId, idProd.ToArray(), quantity.ToArray(),1);
                MessageBox.Show("Se ha generado la nota de crédito exitosamente.", "Éxito", MessageBoxButtons.OK);
                Close();
            }
            else
            {
                MessageBox.Show(response, "Error", MessageBoxButtons.OK);
            }
        }

        private string validateDataGrid()
        {
            int numZeros = 0, curToFac = 0;
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
                if (int.Parse(gridRow.Cells[5].Value.ToString()) > int.Parse(gridRow.Cells[6].Value.ToString()))
                    return "La cantidad a devolver supera a la cantidad disponible, por favor corriga los datos.";
                if (int.Parse(gridRow.Cells[5].Value.ToString()) > int.Parse(gridRow.Cells[4].Value.ToString()))
                    return "La cantidad a devolver supera a la cantidad que se ha solicitado devolver, por favor corriga los datos.";
                if (int.Parse(gridRow.Cells[5].Value.ToString()) <= 0)
                    numZeros++;
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
                if (fail) return "La cantidad total a devolver de un producto supera a la cantidad disponible, por favor corriga los datos.";
            }
            if (numZeros > 1) return "Por favor ingrese una cantidad a devolver válida en la columna 'A Devolver'.";
            return "OK";
        }
    }
}
