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
    public partial class ClientOrderIndex : Form
    {
        private OrderController orderController = new OrderController();
        public ClientOrderIndex()
        {
            InitializeComponent();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataTable orderFiltered = orderController.GetOrders(-1, combo_type.SelectedItem, textbox_doc.Text, textbox_name.Text, combo_orderStatus.SelectedItem);
            populateDataGrid(orderFiltered);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            List<string> selectedOrders = new List<string>();
            foreach (DataGridViewRow row in grid_orders.Rows)
            {
                if (Convert.ToBoolean(row.Cells[deleteColumn.Index].Value) == true)
                {
                    selectedOrders.Add(row.Cells[0].Value.ToString());
                }
            }
            if (selectedOrders.Count() > 0)
            {
                orderController.deleteOrders(selectedOrders);
                updateDataGrid();
            }
        }

        private void grid_orders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string id = grid_orders.Rows[e.RowIndex].Cells[0].Value.ToString();
                string type = grid_orders.Rows[e.RowIndex].Cells[1].Value.ToString().ToLower();
                if (type.Equals("pedido"))
                {
                    ClientOrderShow show_form = new ClientOrderShow(id);
                    var response = show_form.ShowDialog();
                    if (response == DialogResult.OK)
                        updateDataGrid();
                }else
                {
                    DevolutionShow show_form = new DevolutionShow(id);
                    var response = show_form.ShowDialog();
                    if (response == DialogResult.OK)
                        updateDataGrid();
                }
            }
        }

        private void updateDataGrid()
        {
            DataTable orderList = orderController.GetOrders();
            populateDataGrid(orderList);
        }

        private void button_create_dev_Click(object sender, EventArgs e)
        {
            DevolutionCreate create_form = new DevolutionCreate();
            var response = create_form.ShowDialog();
            if (response == DialogResult.OK)
                updateDataGrid();
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            ClientOrderCreate create_form = new ClientOrderCreate();
            var response = create_form.ShowDialog();
            if (response == DialogResult.OK)
                updateDataGrid();
        }

        private void ClientOrderIndex_Load(object sender, EventArgs e)
        {
            updateDataGrid();
        }

        private void populateDataGrid(DataTable orderList)
        {
            grid_orders.Rows.Clear();
            foreach (DataRow row in orderList.Rows)
            {
                string status = row["bdStatus"].ToString().Equals("1") ? "Activo" : "Inactivo";
                if (status.Equals("Activo"))
                {
                    string idClient = row["idClient"].ToString();
                    string clientName = orderController.getClientName(idClient), clientDoc = orderController.getClientDoc(idClient);
                    grid_orders.Rows.Add(row["idOrder"], row["type"].ToString().ToUpper(), clientName, clientDoc, row["orderStatus"], row["totalAmount"]);
                }
            }
        }
    }
}
