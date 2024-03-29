﻿using System;
using System.Collections.Generic;
using System.Data;
using InkaArt.Business.Purchases;
using System.Windows.Forms;
using System.Linq;

namespace InkaArt.Interface.Purchases
{
    public partial class UnitOfMeasurementList : Form
    {
        UnitOfMeasurementController control;
        DataTable unitsList;
        bool canReturn = false;
        public UnitOfMeasurementList()
        {
            InitializeComponent();
            control = new UnitOfMeasurementController();
            unitsList = control.getData();
            desarrolloBusqueda();
            /*string sortQuery = string.Format("id_unit");
            unitsList.DefaultView.Sort = sortQuery;

            dataGridView_unitOfMeasurement.DataSource = unitsList;

            dataGridView_unitOfMeasurement.Columns["id_unit"].HeaderText = "ID";
            dataGridView_unitOfMeasurement.Columns["name"].HeaderText = "Nombre";
            dataGridView_unitOfMeasurement.Columns["abbreviature"].HeaderText = "Abreviatura";
            dataGridView_unitOfMeasurement.Columns["status"].HeaderText = "Estado";*/
        }
        

        private void button_create(object sender, EventArgs e)
        {
            Form new_unit_of_measurement = new UnitOfMeasurement(control,this);
            new_unit_of_measurement.Show();
        }

        public void filter()
        {
            DataRow[] rows;
            unitsList = control.getData();
            string cadena = "";
            if (textBox_id.Text.Length > 0)
            {
                cadena = " AND id_unit = " + textBox_id.Text;
            }
            if (String.Compare(comboBox1.Text, "Activo") == 0)
            {
                rows = unitsList.Select("name LIKE '%" + textBox_name.Text + "%' AND abbreviature LIKE '%" + textBox_abbreviature.Text +"%' AND status LIKE '" +comboBox1.Text + "'" + cadena);
            }
            else
            {
                rows = unitsList.Select("name LIKE '%" + textBox_name.Text + "%' AND abbreviature LIKE '%" + textBox_abbreviature.Text + "%' AND status LIKE '%" + comboBox1.Text + "%'" + cadena);
            }
            if (rows.Any()) unitsList = rows.CopyToDataTable();
            else unitsList.Rows.Clear();
            string sortQuery = string.Format("id_unit");
            unitsList.DefaultView.Sort = sortQuery;
        }
        public void desarrolloBusqueda()
        {
            textBox_abbreviature.Text = textBox_abbreviature.Text.Trim();
            textBox_id.Text = textBox_id.Text.Trim();
            textBox_name.Text = textBox_name.Text.Trim();

            filter();
            dataGridView_unitOfMeasurement.Rows.Clear();
            for (int i = 0; i < unitsList.Rows.Count; i++)
            {
                int id_unit = int.Parse(unitsList.Rows[i]["id_unit"].ToString());
                string nombre = unitsList.Rows[i]["name"].ToString();
                string abreviatura = unitsList.Rows[i]["abbreviature"].ToString();
                string estado = unitsList.Rows[i]["status"].ToString();
                dataGridView_unitOfMeasurement.Rows.Add(id_unit, nombre, abreviatura, estado, false);
            }
            dataGridView_unitOfMeasurement.Sort(dataGridView_unitOfMeasurement.Columns["id_unitM"], System.ComponentModel.ListSortDirection.Ascending);

            canReturn = true;
        }
        private void button_search(object sender, EventArgs e)
        {
            desarrolloBusqueda();
        }

        private void editUnitOfMeasurement(object sender, DataGridViewCellEventArgs e)
        {
            Form new_unit_of_measurement = new UnitOfMeasurement(dataGridView_unitOfMeasurement.CurrentRow,control,this);
            new_unit_of_measurement.Show();
        }

        private void validating_id(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_id.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    MessageBox.Show("Solo puede ingresar números en el id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_id.Text = actualdata;
        }

        private void button_delete(object sender, EventArgs e)
        {
            int registros = dataGridView_unitOfMeasurement.Rows.Count;
            for (int i = 0; i < registros; i++)
            {
                if (Convert.ToBoolean(dataGridView_unitOfMeasurement.Rows[i].Cells[4].Value) == true)
                {
                    string idUnit = dataGridView_unitOfMeasurement.Rows[i].Cells[0].Value.ToString();
                    string name = dataGridView_unitOfMeasurement.Rows[i].Cells[1].Value.ToString();
                    string abbrev = dataGridView_unitOfMeasurement.Rows[i].Cells[2].Value.ToString();
                    string status = dataGridView_unitOfMeasurement.Rows[i].Cells[3].Value.ToString();
                    try { 
                        control.updateData(idUnit,name, abbrev, "Inactivo");
                        
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se pudo eliminar la unidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            desarrolloBusqueda();
        }
        private void button_cargamasivaclick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Units File";
            dialog.Filter = "CSV files|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int resultado = control.massiveUpload(dialog.FileName);
                if (resultado == 1)
                {
                    MessageBox.Show("No se pudo cargar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (resultado == 2)
                {
                    MessageBox.Show("No se realizó la carga porque estas unidades ya existen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else MessageBox.Show("Se realizó la carga masiva de manera exitosa", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBox_abbreviature.Text = "";
            textBox_id.Text = "";
            textBox_abbreviature.Text = "";
            comboBox1.Text = "";
            desarrolloBusqueda();
        
        }
    }
}
