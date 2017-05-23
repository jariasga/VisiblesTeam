using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Warehouse
{
    public partial class WarehouseIndex : Form
    {
        public WarehouseIndex()
        {
            InitializeComponent();
        }

        private void button_delete_click(object sender, EventArgs e)
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

        private void button_add_click(object sender, EventArgs e)
        {
            Form new_warehouse_window = new WarehouseDetail();
            new_warehouse_window.Show();
        }
    }
}
