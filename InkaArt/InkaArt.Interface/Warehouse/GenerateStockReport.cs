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
    public partial class GenerateStockReport : Form
    {
        public GenerateStockReport()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            int flag;
            //0 para producto, 1 para materias primas y 2 para ambos
            if (!checkBox_product.Checked && !checkBox_rawMaterial.Checked) {
                MessageBox.Show(this, "Por favor, seleccionar al menos una de las dos opciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (checkBox_product.Checked && !checkBox_rawMaterial.Checked) //reporte SOLO PARA PRODUCTOS
            {
                flag = 0;
                StockReport stock_form = new StockReport(flag);
                stock_form.Show();
            } else if (!checkBox_product.Checked && checkBox_rawMaterial.Checked) //reporte SOLO PARA MATERIAS PRIMAS
            {
                flag = 1;
                StockReport stock_form = new StockReport(flag);
                stock_form.Show();
            } else
            {
                flag = 2;
                StockReport stock_form = new StockReport(flag);
                stock_form.Show();
            }
        }
    }
}
