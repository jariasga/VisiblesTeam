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
    public partial class FinalProducts : Form
    {
        public FinalProducts()
        {
            InitializeComponent();
            fillGrid();

        }

        public void fillGrid()
        {
            FinalProductController control = new FinalProductController();
            DataTable finalProductList = control.getData();

            dataGridView_finalProductList.Rows.Clear();

            for (int i = 0; i < finalProductList.Rows.Count; i++)
            {
                dataGridView_finalProductList.Rows.Add(finalProductList.Rows[i]["idProduct"],
                    finalProductList.Rows[i]["name"],
                    finalProductList.Rows[i]["localPrice"],
                    finalProductList.Rows[i]["exportPrice"],
                    finalProductList.Rows[i]["actualStock"]);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void productDetail_Click(object sender, EventArgs e)
        {
            string id, name,stock,localPrice,exportPrice;
            id = name = stock = localPrice = exportPrice = "";
            foreach(DataGridViewRow row in dataGridView_finalProductList.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[5].Value);

                if (s == true)
                {
                    id = row.Cells[0].Value.ToString();
                    name = row.Cells[1].Value.ToString();
                    stock = row.Cells[4].Value.ToString();
                    localPrice = row.Cells[2].Value.ToString();
                    exportPrice = row.Cells[3].Value.ToString();
                    break;

                }
            }

            Form production_process = new ProductionProcess(id,name,stock,localPrice,exportPrice);
            production_process.Show();
        }

        private void productRecipe_Click(object sender, EventArgs e)
        {
            string id, name;
            id = name = "";
            foreach (DataGridViewRow row in dataGridView_finalProductList.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[5].Value);

                if (s == true)
                {
                    id = row.Cells[0].Value.ToString();
                    name = row.Cells[1].Value.ToString();
                    break;

                }
            }

            Form recipe = new Recipe(id,name);
            recipe.Show();
        }

        private void FinalProducts_Load(object sender, EventArgs e)
        {

        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            fillGrid();
        }
    }
}
