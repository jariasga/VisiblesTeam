using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Production;
using InkaArt.Business.Warehouse;

namespace InkaArt.Interface.Warehouse
{
    public partial class GenerateKardexReport : Form
    {
        public GenerateKardexReport()
        {
            InitializeComponent();
            loadData();            
        }

        private void loadData()
        {
            FinalProductController controlProd = new FinalProductController();
            DataTable prodList = controlProd.getData();
            for (int i = 0; i < prodList.Rows.Count; i++)
                list_products.Items.Add(prodList.Rows[i]["name"]);
            RawMaterialController_old controlRawMat = new RawMaterialController_old();
            DataTable rawMatList = controlRawMat.getData();
            for (int i = 0; i < rawMatList.Rows.Count; i++)
                list_rawMaterials.Items.Add(rawMatList.Rows[i]["name"]);
            WarehouseCrud controlWarehouse = new WarehouseCrud();
            DataTable warehouseList = controlWarehouse.GetWarehouses();
            for (int i = 0; i < warehouseList.Rows.Count; i++)
                list_warehouses.Items.Add(warehouseList.Rows[i]["name"]);
        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            int response = validateData();
            if (response == 1)
            {
                KardexReport kardex_form = new KardexReport();
                kardex_form.Show();
            }            
        }

        private int validateData()
        {
            if (dateTimePicker_fechaIni.Value >= dateTimePicker_fechaFin.Value)
            {
                MessageBox.Show(this, "Por favor, ingresar fecha inicial menor a la fecha final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }            
            /*else if (comboBox_products.Text == "")
            {
                MessageBox.Show(this, "Por favor, seleccionar un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }*/
            else return 1;
        }

    }
}
