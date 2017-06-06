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

        private void button_delete_Click(object sender, EventArgs e)
        {

        }
        
        private void button_doc_Click(object sender, EventArgs e)
        {

        }
    }
}
