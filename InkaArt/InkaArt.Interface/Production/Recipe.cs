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
    public partial class Recipe : Form
    {

        public Recipe()
        {
            InitializeComponent();
        }

        public Recipe(string id, string name)
        {
            InitializeComponent();
            textBox_id.Text = id;
            textBox_product.Text = name;

            RecipeController control = new RecipeController();
            DataTable recipeList = control.getData();

            //agregar datos a combobox version
            for(int i =0; i<recipeList.Rows.Count;i++)
            {
                if (String.Compare(recipeList.Rows[i]["idProduct"].ToString(), id) == 0)
                {
                    comboBox_version.Items.Add(recipeList.Rows[i]["version"].ToString());
                }
            }
                //llenar datagrid de materias prima dependiendo de la seleccion del comboBox version
            //llanar comboBox materia prima


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Recipe_Load(object sender, EventArgs e)
        {

        }

        private void comboBox_version_SelectedIndexChanged(object sender, EventArgs e)
        {
            //llenar el datagrid
        }
    }
}
