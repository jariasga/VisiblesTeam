using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Production;

namespace InkaArt.Interface.Sales
{
    public partial class GenerateSalesReport : Form
    {
        public GenerateSalesReport()
        {
            InitializeComponent();
            FinalProductController controlProd = new FinalProductController();
            DataTable prodList = controlProd.getData();
            for (int i = 0; i < prodList.Rows.Count; i++)
                comboBox_products.Items.Add(prodList.Rows[i]["name"]);
        }

        private void button_generateSalesResport_Click(object sender, EventArgs e)
        {
            int response = validateData();
            if (response == 1)
            {
                SalesReport sales_form = new SalesReport(dateTimePicker_fechaIni.Value.ToString("M/d/yyyy"), dateTimePicker_fechaFin.Value.ToString("M/d/yyyy"), comboBox_products.Text);
                sales_form.Show();
            }
        }

        private int validateData()
        {
            if (dateTimePicker_fechaIni.Value > dateTimePicker_fechaFin.Value)
            {
                MessageBox.Show(this, "Por favor, ingresar fecha inicial menor a la fecha final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else if (comboBox_products.Text == "")
            {
                MessageBox.Show(this, "Por favor, seleccionar un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else if (dateTimePicker_fechaFin.Value > DateTime.Now)
            {
                MessageBox.Show(this, "La fecha final no debe ser mayor a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else return 1;
        }
    }
}
