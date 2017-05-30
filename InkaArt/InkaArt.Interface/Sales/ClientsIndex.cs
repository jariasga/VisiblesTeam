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
    public partial class ClientsIndex : Form
    {
        private ClientController clientController = new ClientController();
        public ClientsIndex()
        {
            InitializeComponent();
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            ClientCreate create_form = new ClientCreate();
            create_form.Show();
        }

        private void grid_clients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = grid_clients.Rows[e.RowIndex].Cells[0].Value.ToString();
            ClientShow show_form = new ClientShow(id);
            show_form.Show();
        }

        private void ClientsIndex_Load(object sender, EventArgs e)
        {
            DataTable clientList = clientController.GetClients();
            populateDataGrid(clientList);            
        }

        private void populateDataGrid(DataTable clientList)
        {
            grid_clients.Rows.Clear();
            foreach (DataRow row in clientList.Rows)
            {
                string status = row["status"].ToString().Equals("1") ? "Activo" : "Inactivo";
                if (status.Equals("Activo")) grid_clients.Rows.Add(row["idClient"], row["ruc"], row["name"], status , row["priority"]);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataTable clientList;
            if (textbox_id.Text.Equals("") && textbox_doc.Text.Equals("") && textbox_name.Text.Equals("") && combobox_state.SelectedIndex == -1 && combobox_priority.SelectedIndex == -1) clientList = clientController.GetClients();
            else
                clientList = clientController.GetClients(int.Parse(textbox_id.Text), int.Parse(textbox_doc.Text), int.Parse(textbox_doc.Text), textbox_name.Text,combobox_state.SelectedIndex,combobox_priority.SelectedIndex);
            populateDataGrid(clientList);
        }

        private void grid_clients_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }
}
