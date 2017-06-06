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

        }

        private void button_delete_Click(object sender, EventArgs e)
        {

        }

        private void grid_orders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientOrderShow show_form = new ClientOrderShow();
            var response = show_form.ShowDialog();
            if (response == DialogResult.OK)
                updateDataGrid();
        }

        private void updateDataGrid()
        {
            DataTable orderList = orderController.GetOrders();
            populateDataGrid(orderList);
        }

        private void button_create_dev_Click(object sender, EventArgs e)
        {
            DevolutionCreate create_form = new DevolutionCreate();
            create_form.Show();
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
                if (status.Equals("Activo")) grid_orders.Rows.Add("Pedido", row["idClient"], "999999", row["orderStatus"], row["totalAmount"]);
            }
        }
    }
}
