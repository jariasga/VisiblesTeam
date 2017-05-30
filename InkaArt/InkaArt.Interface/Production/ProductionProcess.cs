using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NpgsqlTypes;
using System.Diagnostics;
using InkaArt.Business.Production;
namespace InkaArt.Interface.Production
{
    public partial class ProductionProcess : Form
    {
        public ProductionProcess(string id, string name, string count, string localPrice, string exportPrice)
        {
            InitializeComponent();
            textBox_id.Text = id;
            textBox_product.Text = name;
            textBox_stock.Text = count;
            textBox_localPrice.Text = localPrice;
            textBox_exportPrice.Text = exportPrice;

            ProcessProductController control = new ProcessProductController();
            ProcessController controlProcess = new ProcessController();
            DataTable productProcessesList = control.getData();
            DataTable processList = controlProcess.getData();

            dataGridView_productProceses.Rows.Clear();

            for(int i=0; i< productProcessesList.Rows.Count; i++)
            {
                if (String.Compare(productProcessesList.Rows[i]["idProduct"].ToString(),id)==0)
                {
                    //dataGridView_productProceses.Rows.Add(productProcessesList.Rows[i]["idProcess"]);
                    for(int j=0;j<processList.Rows.Count;j++)
                    {
                        if(String.Compare(processList.Rows[j]["idProcess"].ToString(),productProcessesList.Rows[i]["idProcess"].ToString())==0)
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
            control.updateData(textBox_id.Text, textBox_localPrice.Text, textBox_exportPrice.Text);

        }

        private void ProductionProcess_Load(object sender, EventArgs e)
        {

        }
    }
}
