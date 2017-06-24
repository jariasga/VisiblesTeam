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
using InkaArt.Business.Warehouse;

namespace InkaArt.Interface.Production
{
    public partial class FinalProducts : Form
    {
        private int maxrow = 0;
        public FinalProducts()
        {
            FinalProductController control = new FinalProductController();
            hallaStock();
            DataTable finalProductList = control.getData();
            maxrow = finalProductList.Rows.Count;
            InitializeComponent();
            fillGrid();
            
        }

        private void hallaStock()
        {
            int huaco, piedra, retablo, huacoL, piedraL, retabloL;
            huaco = piedra = retablo = huacoL = piedraL = retabloL = 0;
            ProductWarehouseController control = new ProductWarehouseController();
            DataTable whList = control.getData();
            for(int i = 0; i<whList.Rows.Count; i++)
            {
                if (whList.Rows[i]["idProduct"].ToString() == "1" &&
                    whList.Rows[i]["state"].ToString()=="Activo")
                {
                    huaco += int.Parse(whList.Rows[i]["currentStock"].ToString());
                    huacoL += int.Parse(whList.Rows[i]["virtualStock"].ToString());
                }
                if (whList.Rows[i]["idProduct"].ToString() == "2" &&
                    whList.Rows[i]["state"].ToString() == "Activo")
                {
                    piedra += int.Parse(whList.Rows[i]["currentStock"].ToString());
                    piedraL += int.Parse(whList.Rows[i]["virtualStock"].ToString());
                }
                if (whList.Rows[i]["idProduct"].ToString() == "3" &&
                    whList.Rows[i]["state"].ToString() == "Activo")
                {
                    retablo += int.Parse(whList.Rows[i]["currentStock"].ToString());
                    retabloL += int.Parse(whList.Rows[i]["virtualStock"].ToString());

                }
            }
            FinalProductController controlFp = new FinalProductController();
            DataTable finalProductList = controlFp.getData();
            controlFp.updateStock(huaco, piedra, retablo, huacoL, piedraL, retabloL);
        }

        public void fillGrid()
        {
            FinalProductController control = new FinalProductController();
            DataTable finalProductList = control.getData();
            dataGridView_finalProductList.Rows.Clear();

            //hallaStock();

            for (int i = 0; i < finalProductList.Rows.Count; i++)
            {
                dataGridView_finalProductList.Rows.Add(finalProductList.Rows[i]["idProduct"],
                    finalProductList.Rows[i]["name"],
                    finalProductList.Rows[i]["localPrice"],
                    finalProductList.Rows[i]["exportPrice"],
                    finalProductList.Rows[i]["BasePrice"],
                    finalProductList.Rows[i]["actualStock"]);


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, name, stock, localPrice, exportPrice,basePrice;
            id = name = stock = localPrice = exportPrice = "";

            if (e.RowIndex >= 0 && e.RowIndex<maxrow)
            {
                DataGridViewRow row = dataGridView_finalProductList.Rows[e.RowIndex];

                if (e.ColumnIndex == 6)//detalles
                {
                    id = row.Cells[0].Value.ToString();
                    name = row.Cells[1].Value.ToString();
                    stock = row.Cells[5].Value.ToString();
                    basePrice = row.Cells[4].Value.ToString();
                    localPrice = row.Cells[2].Value.ToString();
                    exportPrice = row.Cells[3].Value.ToString();

                    Form production_process = new ProductionProcess(id, name, stock, localPrice, exportPrice,basePrice);
                    production_process.MdiParent = this.MdiParent;
                    production_process.Show();
                }
                else
                    if (e.ColumnIndex == 7)//receta
                {
                    id = row.Cells[0].Value.ToString();
                    name = row.Cells[1].Value.ToString();

                    Form recipe = new Recipe(id, name);
                    recipe.MdiParent = this.MdiParent;
                    recipe.Show();
                }
            }
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
