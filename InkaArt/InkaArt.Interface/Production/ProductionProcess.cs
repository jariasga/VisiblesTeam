using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using InkaArt.Business.Production;
namespace InkaArt.Interface.Production
{
    public partial class ProductionProcess : Form
    {
        public ProductionProcess(string id, string name, string count, string localPrice, string exportPrice,string basePrice)
        {
            InitializeComponent();
            textBox_id.Text = id;
            textBox_product.Text = name;
            textBox_stock.Text = count;
            textBox_localPrice.Text = localPrice;
            textBox_exportPrice.Text = exportPrice;
            textBox_basePrice.Text = basePrice;

            ProcessProductController control = new ProcessProductController();
            ProcessController controlProcess = new ProcessController();
            DataTable productProcessesList = control.getData();
            DataTable processList = controlProcess.getData();

            dataGridView_productProceses.Rows.Clear();

            for(int i=0; i< productProcessesList.Rows.Count; i++)
            {
                if (String.Compare(productProcessesList.Rows[i]["idProduct"].ToString(),id)==0)
                {
                    //dataGridView_productProceses.Rows.Add(productProcessesList.Rows[i]["id_process"]);
                    for(int j=0;j<processList.Rows.Count;j++)
                    {
                        if(String.Compare(processList.Rows[j]["id_process"].ToString(),productProcessesList.Rows[i]["idProcess"].ToString())==0)
                        {
                            dataGridView_productProceses.Rows.Add(productProcessesList.Rows[i]["idProcess"], processList.Rows[j]["description"]);
                            break;
                        }
                    }
                }
            }

        }


        public ProductionProcess()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            FinalProductController control = new FinalProductController();
            double local,exp;
            local = exp = 0;
            if (double.TryParse(textBox_localPrice.Text, out local) && double.TryParse(textBox_exportPrice.Text, out exp))
            {
                int retorno;
                retorno =control.updateData(textBox_id.Text, textBox_localPrice.Text, textBox_exportPrice.Text);
                if(retorno == 0)//los precios son menores
                {
                    MessageBox.Show("Los precios no pueden ser menores al precio base, por favor ingrese un valor válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Se guardaron los cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Tipo de dato no permitido, por favor ingrese un valor válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ProductionProcess_Load(object sender, EventArgs e)
        {

        }
    }
}
