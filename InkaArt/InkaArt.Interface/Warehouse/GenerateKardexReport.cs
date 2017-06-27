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
        DataTable prodList, rawMatList, warehouseList;
        List<string> warehouses, items;
        public GenerateKardexReport()
        {
            InitializeComponent();
            warehouses = new List<string>();
            items = new List<string>();              
            loadData();

            this.dateTimePicker_fechaIni.Format = DateTimePickerFormat.Custom;
            dateTimePicker_fechaIni.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker_fechaFin.Format = DateTimePickerFormat.Custom;
            dateTimePicker_fechaFin.CustomFormat = "dd/MM/yyyy";
        }

        private void checkBox_allProd_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_allProd.Checked)
                list_products.Enabled = true;
            else
                list_products.Enabled = false;
        }

        private void checkBox_allRM_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_allRM.Checked)
                list_rawMaterials.Enabled = true;
            else
                list_rawMaterials.Enabled = false;
        }

        private void checkBox_allW_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_allW.Checked)
                list_warehouses.Enabled = true;
            else
                list_warehouses.Enabled = false;
        }

        private void loadData()
        {
            FinalProductController controlProd = new FinalProductController();
            prodList = controlProd.getData();
            for (int i = 0; i < prodList.Rows.Count; i++)
                if (prodList.Rows[i]["status"].ToString().Equals("1"))
                    list_products.Items.Add(prodList.Rows[i]["name"]);
            RawMaterialController_old controlRawMat = new RawMaterialController_old();
            rawMatList = controlRawMat.getData();
            for (int i = 0; i < rawMatList.Rows.Count; i++)
                if (rawMatList.Rows[i]["status"].ToString().Equals("Activo"))
                    list_rawMaterials.Items.Add(rawMatList.Rows[i]["name"]);
            WarehouseCrud controlWarehouse = new WarehouseCrud();
            warehouseList = controlWarehouse.GetWarehouses();
            for (int i = 0; i < warehouseList.Rows.Count; i++)
                if (warehouseList.Rows[i]["state"].ToString().Equals("Activo"))
                    list_warehouses.Items.Add(warehouseList.Rows[i]["name"]);
        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            int response = validateData();
            if (response == 1)
            {
                for (int i = 0; i < list_products.Items.Count; i++)
                {
                    if (list_products.GetItemChecked(i))
                    {
                        string str = list_products.Items[i].ToString();
                        items.Add(str);
                    }
                }
                for (int i = 0; i < list_rawMaterials.Items.Count; i++)
                {
                    if (list_rawMaterials.GetItemChecked(i))
                    {
                        string str = list_rawMaterials.Items[i].ToString();
                        items.Add(str);
                    }
                }
                for (int i = 0; i < list_warehouses.Items.Count; i++)
                {
                    if (list_warehouses.GetItemChecked(i))
                    {
                        string str = list_warehouses.Items[i].ToString();
                        warehouses.Add(str);
                    }
                }
                KardexReport kardex_form = new KardexReport(dateTimePicker_fechaIni.Value.ToString("MM/dd/yyyy"), dateTimePicker_fechaFin.Value.ToString("MM/dd/yyyy"), items, warehouses);
                kardex_form.Show();
                items.Clear();
                warehouses.Clear();
            }            
        }

        private int validateData()
        {
            if (dateTimePicker_fechaIni.Value > dateTimePicker_fechaFin.Value)
            {
                MessageBox.Show(this, "Por favor, ingresar fecha inicial menor a la fecha final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else if (dateTimePicker_fechaFin.Value > DateTime.Now)
            {
                MessageBox.Show(this, "La fecha final no debe ser mayor a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else return 1;
        }

    }
}
