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
            DataTable rmWarehouseList = rmWarehouseController.GetRMWarehouses();
            populateDataGrid(rmWarehouseList);
        }

        private void populateDataGrid(DataTable warehouseList)
        {
            dataGridView_rawMaterialsList.Rows.Clear();
            foreach (DataRow row in warehouseList.Rows)
            {
                string status = row["state"].ToString();
                if (status.Equals("Activo")) dataGridView_rawMaterialsList.Rows.Add(row["idWarehouse"], row["name"], row["description"], row["address"]);
            }
        }

    }
}
