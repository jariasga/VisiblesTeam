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
    public partial class JobDetails : Form
    {
        public JobDetails()
        {
            InitializeComponent();
        }

        public JobDetails(string id, string name, string count)
        {
            InitializeComponent();
            textBox_id.Text = id;
            textBox_process.Text = name;
            textBox_count.Text = count;

            FinalProductController controlProduct = new FinalProductController();
            DataTable finalProductList = controlProduct.getData();

            ProcessProductController control = new ProcessProductController();
            DataTable productProcessesList = control.getData();

            for (int i = 0; i < productProcessesList.Rows.Count; i++)
            {
                if (String.Compare(productProcessesList.Rows[i]["idProcess"].ToString(), id) == 0)
                {
                    for (int j = 0; j < finalProductList.Rows.Count; j++)
                    {
                        if (String.Compare(finalProductList.Rows[j]["idProduct"].ToString(), productProcessesList.Rows[i]["idProduct"].ToString()) == 0)
                        {
                            dataGridView_products.Rows.Add(productProcessesList.Rows[i]["idProduct"], finalProductList.Rows[j]["name"]);
                            break;
                        }
                    }
                }
            }
        }

        private void JobDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
