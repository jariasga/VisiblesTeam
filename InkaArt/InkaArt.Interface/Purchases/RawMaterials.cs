using System;
using System.Collections.Generic;
using System.Data;
using InkaArt.Business.Purchases;
using System.Windows.Forms;

namespace InkaArt.Interface.Purchases
{
    public partial class RawMaterials : Form
    {
        RawMaterialController control;
        public RawMaterials()
        {
            InitializeComponent();
            control = new RawMaterialController();
            DataTable rawMaterialList = control.getData();
            dataGridView_rawMaterialsList.DataSource = rawMaterialList;

            dataGridView_rawMaterialsList.Columns["idRawMaterial"].HeaderText = "ID";
            dataGridView_rawMaterialsList.Columns["name"].HeaderText = "Nombre";
            dataGridView_rawMaterialsList.Columns["unit"].HeaderText = "Unidad";
            dataGridView_rawMaterialsList.Columns["status"].HeaderText = "Estado";
            dataGridView_rawMaterialsList.Columns["description"].HeaderText = "Descripción";
            dataGridView_rawMaterialsList.Columns["averagePrice"].HeaderText = "Precio Promedio";
            dataGridView_rawMaterialsList.Columns["averagePrice"].Visible = false;
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
            Form new_raw_material = new RawMaterialDetail(control);
            new_raw_material.Show();
        }

        private void editRawMaterialDetail(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRawMaterial = dataGridView_rawMaterialsList.CurrentRow;
            Form new_raw_material = new RawMaterialDetail(currentRawMaterial,control);
            new_raw_material.Show();
        }
    }
}
