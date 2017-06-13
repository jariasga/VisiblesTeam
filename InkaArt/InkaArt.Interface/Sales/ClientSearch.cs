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
    public partial class ClientSearch : Form
    {
        private ClientController clientController = new ClientController();
        public int SelectedClientId { get; private set; }
        public long SelectedClientDoc { get; private set; }
        public string SelectedClientName { get; private set; }
        public int SelectedClientType { get; private set; }
        public int SelectedClientTypeNat { get; private set; }
        public ClientSearch()
        {
            InitializeComponent();
        }

        private void ClientSearch_Load(object sender, EventArgs e)
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
                if (status.Equals("Activo")) grid_clients.Rows.Add(row["idClient"], row["ruc"], row["name"], status, row["priority"], row["clientType"], row["type"]);
            }
        }

        private void grid_clients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedClientId = int.Parse(grid_clients.Rows[e.RowIndex].Cells[0].Value.ToString());
            SelectedClientDoc = long.Parse(grid_clients.Rows[e.RowIndex].Cells[1].Value.ToString());
            SelectedClientName = (grid_clients.Rows[e.RowIndex].Cells[2].Value.ToString());
            SelectedClientType = int.Parse(grid_clients.Rows[e.RowIndex].Cells[5].Value.ToString());
            SelectedClientTypeNat = int.Parse(grid_clients.Rows[e.RowIndex].Cells[6].Value.ToString());
            DialogResult = DialogResult.OK;
            Close();
        }

        private void grid_clients_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_select_Click(object sender, EventArgs e)
        {
            int index = grid_clients.CurrentCell.RowIndex;
            SelectedClientId = int.Parse(grid_clients.Rows[index].Cells[0].Value.ToString());
            SelectedClientDoc = int.Parse(grid_clients.Rows[index].Cells[1].Value.ToString());
            SelectedClientName = (grid_clients.Rows[index].Cells[2].Value.ToString());
            SelectedClientType = int.Parse(grid_clients.Rows[index].Cells[5].Value.ToString());
            SelectedClientTypeNat = int.Parse(grid_clients.Rows[index].Cells[6].Value.ToString());
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
