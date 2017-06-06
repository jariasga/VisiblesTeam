using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Warehouse;


namespace InkaArt.Interface.Warehouse
{
    public partial class AddRawMaterialWarehouse : Form
    {
        private RawMaterialWarehouseController rmWarehouseController = new RawMaterialWarehouseController();
        string idWarehouse;

        public AddRawMaterialWarehouse()
        {
            InitializeComponent();
        }

        private void AddRawMaterialWarehouse_Load(object sender, EventArgs e)
        {
            updateDataGrid();
        }

        private void updateDataGrid()
        {
            DataTable rmList = rmWarehouseController.GetRM();
            populateDataGrid(rmList);
        }

        private void populateDataGrid(DataTable rmList)
        {
            dataGridView_rawMaterialsList.Rows.Clear();
            foreach (DataRow row in rmList.Rows)
            {
                string status = row["state"].ToString();
                if (status.Equals("Activo")) dataGridView_rawMaterialsList.Rows.Add(row["idRawMaterial"], row["name"], row["description"]);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            int registros = dataGridView_rawMaterialsList.Rows.Count;
            for (int i = 0; i < registros; i++)
            {
                if (Convert.ToBoolean(dataGridView_rawMaterialsList.Rows[i].Cells[3].Value) == true)
                {
                    string id = dataGridView_rawMaterialsList.Rows[i].Cells[0].Value.ToString();
                    string name = dataGridView_rawMaterialsList.Rows[i].Cells[1].Value.ToString();
                    string description = dataGridView_rawMaterialsList.Rows[i].Cells[2].Value.ToString();
                    rmWarehouseController.AddRawMaterialToWarehouse(idWarehouse, id, name, description);
                }
            }
            updateDataGrid();
        }
    }
}
