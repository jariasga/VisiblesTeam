using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using InkaArt.Business.Purchases;
using System.Windows.Forms;

namespace InkaArt.Interface.Purchases
{
    public partial class RawMaterials : Form
    {
        public RawMaterials()
        {
            InitializeComponent();
            RawMaterialController control = new RawMaterialController();
            DataTable rawMaterialList = control.getData();
            dataGridView_rawMaterialsList.DataSource=rawMaterialList;
        }

        private void button_search(object sender, EventArgs e)
        {

            
        }

        private void button_delete(object sender, EventArgs e)
        {
            List<DataGridViewRow> toDelete = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataGridView_rawMaterialsList.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[0].Value);

                if (s == true)
                {
                    toDelete.Add(row);
                }
            }

            foreach (DataGridViewRow row in toDelete)
            {
                dataGridView_rawMaterialsList.Rows.Remove(row);
            }
        }

        private void button_create(object sender, EventArgs e)
        {
            Form new_raw_material = new RawMaterialDetail();
            new_raw_material.Show();
        }
    }
}
