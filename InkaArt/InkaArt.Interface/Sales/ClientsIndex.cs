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
            var response = create_form.ShowDialog();
            if (response == DialogResult.OK)
                updateDataGrid(false);
        }

        private void grid_clients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string id = grid_clients.Rows[e.RowIndex].Cells[0].Value.ToString();
                var show_form = new ClientShow(id);
                var result = show_form.ShowDialog();
                if (result == DialogResult.OK)
                    updateDataGrid(false);
            }
        }

        private void updateDataGrid(bool flag)
        {
            DataTable clientList = clientController.GetClients();
            populateDataGrid(clientList,flag);
        }

        private void ClientsIndex_Load(object sender, EventArgs e)
        {
            updateDataGrid(false);
        }

        private void populateDataGrid(DataTable clientList, bool flag)
        {
            grid_clients.Rows.Clear();
            foreach (DataRow row in clientList.Rows)
            {
                string status = row["status"].ToString().Equals("1") ? "Activo" : "Inactivo";
                if (status.Equals("Activo") || flag) grid_clients.Rows.Add(row["idClient"], row["ruc"], row["name"], status, row["priority"]);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }        

        private void grid_clients_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataTable clientList;
            clientList = clientController.GetClients(textbox_id.Text, textbox_doc.Text, textbox_doc.Text, textbox_name.Text, combobox_state.SelectedIndex, combobox_priority.SelectedIndex);
            populateDataGrid(clientList, combobox_state.SelectedIndex == 0);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            List<string> selectedClients = new List<string>();
            foreach (DataGridViewRow row in grid_clients.Rows)
            {
                if (Convert.ToBoolean(row.Cells[deleteColumn.Index].Value) == true)
                {
                    selectedClients.Add(row.Cells[0].Value.ToString());
                }
            }
            if (selectedClients.Count() > 0)
            {
                clientController.deleteClients(selectedClients);
                updateDataGrid(false);
            }
        }

        private void button_cargamasiva_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Clients File";
            dialog.Filter = "CSV files|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string response = clientController.massiveUpload(dialog.FileName, true);
                if (response.Equals("OK"))
                {
                    clientController.massiveUpload(dialog.FileName);
                    MessageBox.Show(this, "Se ha cargado la data correctamente.", "Carga Masiva", MessageBoxButtons.OK);
                }else MessageBox.Show(this, response + " revise los datos en el archivo.", "Carga Masiva", MessageBoxButtons.OK);
            }
            else MessageBox.Show(this, "No se ha podido cargar el archivo, intente nuevamente.", "Carga Masiva", MessageBoxButtons.OK);
            updateDataGrid(false);
        }
    }
}
