using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Purchases
{
    public partial class SupplierDetail : Form
    {
        int mode;
        public SupplierDetail()
        {
            mode = 1; //crear Supplier
            InitializeComponent();
        }

        public SupplierDetail(DataGridViewRow currentSupplier)
        {
            mode = 2; //editar Supplier
            InitializeComponent();
            textBox_idSupplier.Text = currentSupplier.Cells[1].Value.ToString();
            textBox_name.Text = currentSupplier.Cells[2].Value.ToString();
            textBox_ruc.Text = currentSupplier.Cells[3].Value.ToString();
            textBox_address.Text = currentSupplier.Cells[8].Value.ToString();
            trackBar_priority.Value = (int) currentSupplier.Cells[9].Value;
            textBox_priority.Text = trackBar_priority.Value.ToString();
            comboBox_status.Text = currentSupplier.Cells[7].Value.ToString();
            textBox_contactName.Text = currentSupplier.Cells[4].Value.ToString();
            textBox_email.Text = currentSupplier.Cells[6].Value.ToString();
            textBox_telephone.Text = currentSupplier.Cells[5].Value.ToString();
        }

        private void button_add(object sender, EventArgs e)
        {
            Form pageAddSupply = new AddSupply();
            pageAddSupply.Show();
        }

        private void button_delete(object sender, EventArgs e)
        {
            List<DataGridViewRow> toDelete = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[0].Value);

                if (s == true)
                {
                    toDelete.Add(row);
                }
            }

            foreach (DataGridViewRow row in toDelete)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void button_save_click(object sender, EventArgs e)
        {
            /*Closing*/
            this.textBox_idSupplier.Text = "";
            this.textBox_name.Text = "";
            this.textBox_ruc.Text = "";
            this.textBox_address.Text = "";
            this.textBox_contactName.Text = "";
            this.textBox_telephone.Text = "";
            this.comboBox_status.Text = "";
            this.textBox_email.Text = "";
            this.textBox_priority.Text = "0";
            this.textBox_idRawMaterial.Text = "";
            this.textBox_nameRawMaterial.Text = "";
            this.dataGridView1.Rows.Clear();
            this.Close();
        }

        private void trackBar_priority_Scroll(object sender, EventArgs e)
        {
            this.textBox_priority.Text = trackBar_priority.Value.ToString();
        }
    }
}
