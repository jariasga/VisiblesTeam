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
                        if (String.Compare(finalProductList.Rows[j]["idProduct"].ToString(),
                            productProcessesList.Rows[i]["idProduct"].ToString()) == 0)
                        {
                            dataGridView_products.Rows.Add(productProcessesList.Rows[i]["idProduct"],
                                finalProductList.Rows[j]["name"]);
                            break;
                        }
                    }
                }
            }
        }

        private void JobDetails_Load(object sender, EventArgs e)
        {

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            ProcessController control = new ProcessController();
            int number_of_jobs;
            if (int.TryParse(textBox_count.Text, out number_of_jobs))
            {
                number_of_jobs = int.Parse(textBox_count.Text);
                if (number_of_jobs >= 0)
                {
                    int id = int.Parse(textBox_id.Text);
                    control.updateDataNoAdapter(id, number_of_jobs);
                    MessageBox.Show("Se guardaron los cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("La cantidad de turnos no puede ser negativo, por favor ingrese un valor válido.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Formato de datos no válido, por favor verifique los valores.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
