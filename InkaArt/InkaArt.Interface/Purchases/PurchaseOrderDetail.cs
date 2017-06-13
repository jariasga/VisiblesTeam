using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Purchases;
namespace InkaArt.Interface.Purchases
{
    public partial class PurchaseOrderDetail : Form
    {
        PurchaseOrderController control;
        PurchaseOrderDetailController control_detail;
        SupplierController control_supplier;
        RawMaterial_SupplierController control_rm_sup;
        RawMaterialController control_rm;
        UnitOfMeasurementController control_unit;
        DataTable supList,rawMat_supList,rmList,unitList,lineaPedidosList;
        int mode;
        string listaMaterialesIds;
        bool isInEditMode = true;
        public PurchaseOrderDetail()
        {
            mode = 1;
            control = new PurchaseOrderController();
            control_supplier = new SupplierController();
            InitializeComponent();
            button_add.Enabled = false;
            buttonDelete.Enabled = true;
            buttonSave.Enabled = true;
            dateTimePicker_creation.Value = DateTime.Now;
            dateTimePicker_delivery.Value = DateTime.Today.AddDays(8);
            textBox_total.Text = "0";
            buttonSave.Text = "🖫 Guardar";
        }
        public PurchaseOrderDetail(PurchaseOrderController controlForm)
        {
            mode = 1;
            control = controlForm;
            InitializeComponent();
            button_add.Enabled = false;
            buttonDelete.Enabled = true;
            buttonSave.Enabled = true;
            dateTimePicker_creation.Value = DateTime.Now;
            dateTimePicker_delivery.Value = DateTime.Today.AddDays(8);
            textBox_total.Text = "0";
            textBox_cantidad.Text = "0";
            buttonSave.Text = "🖫 Guardar";
            control_supplier = new SupplierController();
            llenarComboBoxSuppliers();
        }
        public PurchaseOrderDetail(DataGridViewRow currentPurchaseOrder, PurchaseOrderController controlForm)
        {
            mode = 2;
            control = controlForm;
            InitializeComponent();
            textBox_id.Text = currentPurchaseOrder.Cells[1].Value.ToString();
            textBox_idsupplier.Text = currentPurchaseOrder.Cells[2].Value.ToString();
            comboBox_status.Text = currentPurchaseOrder.Cells[3].Value.ToString();
            dateTimePicker_creation.Value = (DateTime) currentPurchaseOrder.Cells[4].Value;
            dateTimePicker_delivery.Value = (DateTime)currentPurchaseOrder.Cells[5].Value;
            textBox_total.Text = currentPurchaseOrder.Cells[6].Value.ToString();
            textBox_idsupplier.Enabled = false;
            dateTimePicker_creation.Enabled = false;
            dateTimePicker_delivery.Enabled = false;
            comboBox_status.Enabled = false;
            comboBox_supplier.Enabled = false;
            button_add.Enabled = false;
            buttonDelete.Enabled = false;
            textBox_cantidad.Enabled = false;
            control_supplier = new SupplierController();
            buscarNombreSupplier(textBox_idsupplier.Text);
            control_detail = new PurchaseOrderDetailController();
            control_rm = new RawMaterialController();
            control_rm_sup = new RawMaterial_SupplierController();
            control_unit = new UnitOfMeasurementController();
            obtenerMateriasDelSupplier();
            llenarMateriasPedidas();
        }
        private void filterSupplier()
        {
            DataRow[] rows;
            supList = control_supplier.getData();
            rows = supList.Select("status = 'Activo'");
            if (rows.Any()) supList = rows.CopyToDataTable();
            else supList.Rows.Clear();
            string sortQuery = string.Format("id_supplier");
            supList.DefaultView.Sort = sortQuery;
        }
        private void llenarComboBoxSuppliers()
        {
            filterSupplier();
            for (int i = 0; i < supList.Rows.Count; i++)
                comboBox_supplier.Items.Add(supList.Rows[i]["name"].ToString());
        }
        private void buscarNombreSupplier(string idSupp)
        {
            DataRow[] rows;
            supList = control_supplier.getData();
            rows = supList.Select("id_supplier = "+idSupp);
            if (rows.Any()) supList = rows.CopyToDataTable();
            else supList.Rows.Clear();
            string sortQuery = string.Format("id_supplier");
            supList.DefaultView.Sort = sortQuery;
            comboBox_supplier.Items.Add(supList.Rows[0]["name"].ToString());
            comboBox_supplier.SelectedIndex = 0;
        }
        private void filterRawMaterialSupplier()
        {
            //obtengo todos las materias primas que ofrece el supplier
            DataRow[] rows;
            rawMat_supList = control_rm_sup.getData();
            rows = rawMat_supList.Select("status = 'Activo' AND id_supplier="+textBox_idsupplier.Text);
            if (rows.Any()) rawMat_supList = rows.CopyToDataTable();
            else rawMat_supList.Rows.Clear();
            string sortQuery = string.Format("id_raw_material");
            rawMat_supList.DefaultView.Sort = sortQuery;
        }
        private void filterRawMaterials()
        {
            DataRow[] rows;
            rmList = control_rm.getData();
            rows = rmList.Select("status = 'Activo' AND id_raw_material IN ("+listaMaterialesIds+")");
            if (rows.Any()) rmList = rows.CopyToDataTable();
            else rmList.Rows.Clear();
            string sortQuery = string.Format("id_raw_material");
            rmList.DefaultView.Sort = sortQuery;
            for(int i = 0; i < rmList.Rows.Count; i++)
            {
                comboBoxRawMaterialName.Items.Add(rmList.Rows[i]["name"].ToString());
            }
        }
        private void llenarMateriasPedidas()
        {
            //obtengo todas las lineas de pedido de esta orden
            DataRow[] rows;
            lineaPedidosList = control_detail.getData();
            rows = lineaPedidosList.Select("id_order = " + textBox_id.Text + " AND status = 'Activo'");
            if (rows.Any()) lineaPedidosList = rows.CopyToDataTable();
            else lineaPedidosList.Rows.Clear();
            string sortQuery = string.Format("id_detail");
            lineaPedidosList.DefaultView.Sort = sortQuery;

            //id_detail,id_raw_material,name_rm,quantity,amount,id_factura,status
            dataGridView_pedidos.Rows.Clear();
            for (int i = 0; i < lineaPedidosList.Rows.Count; i++)
            {
                string id_detail = lineaPedidosList.Rows[i]["id_detail"].ToString();
                string id_raw_material = lineaPedidosList.Rows[i]["id_raw_material"].ToString();
                string nombre = id_raw_material;
                string quantity = lineaPedidosList.Rows[i]["quantity"].ToString();
                string amount = lineaPedidosList.Rows[i]["amount"].ToString();
                string id_factura = lineaPedidosList.Rows[i]["id_factura"].ToString();
                string status = lineaPedidosList.Rows[i]["status"].ToString();
                dataGridView_pedidos.Rows.Add(false, id_detail,id_raw_material,nombre,quantity,amount,id_factura,status);
            }
        }
        private void obtenerMateriasDelSupplier()
        {
            filterRawMaterialSupplier();
            listaMaterialesIds="";
            for(int i = 0; i < rawMat_supList.Rows.Count; i++)
            {
                if (i != 0) listaMaterialesIds += ",";
                listaMaterialesIds += "'";
                listaMaterialesIds += rawMat_supList.Rows[i]["id_raw_material"].ToString();
                listaMaterialesIds += "'";
            }
            if (listaMaterialesIds.Length > 0) filterRawMaterials();
        }
        /* search */
        private void button1_Click(object sender, EventArgs e)
        {

        }

        /* save */
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (comboBoxRawMaterialName.Text.Length < 0)
            {
                MessageBox.Show("Debe escoger alguna materia prima", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (double.Parse(textBox_subtotal.Text) < 0.01)
            {
                MessageBox.Show("No se puede agregar un pedido con subtotal cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id_order = int.Parse(textBox_id.Text);
            int id_rm = int.Parse(textBox_idrm.Text);
            int id_sup = int.Parse(textBox_idsupplier.Text);
            control_detail.insertData(id_order, id_rm, id_sup, int.Parse(textBox_cantidad.Text), double.Parse(textBox_subtotal.Text), int.Parse(textBox_factura.Text),"Activo");
            llenarMateriasPedidas();
        }
        
        /* delete */
        private void button_delete(object sender, EventArgs e)
        {
            
        }

        private void textBox_supplier_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_idsupplier.Text == "")
            {
                this.button_add.Enabled = false;
            }
            else this.button_add.Enabled = true;
        }
        private bool validating_alldata()
        {
            textBox_idsupplier.Text = textBox_idsupplier.Text.Trim();
            string cadenaCampos = "";
            int camposFaltantes = 0;
            if (comboBox_supplier.Text.Length < 1)
            {
                cadenaCampos += "proveedor";
                camposFaltantes++;
            }
            if (comboBox_status.Text.Length < 1)
            {
                if (camposFaltantes > 0) cadenaCampos += " y estado";
                else cadenaCampos += "estado";
                camposFaltantes++;
            }
            if (camposFaltantes>0)
            {
                cadenaCampos += ".";
                string cadenaInicial = "";
                if (camposFaltantes == 1) cadenaInicial += "Debe llenar el campo: ";
                else cadenaInicial += "Debe llenar los campos: ";
                MessageBox.Show(cadenaInicial+cadenaCampos, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(dateTimePicker_creation.Value > dateTimePicker_delivery.Value)
            {
                MessageBox.Show("La fecha de emisión no puede ser posterior a la entrega", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
                return true;

        }
        private void button_save(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                if (!validating_alldata())
                {
                    return;
                }

                buttonSave.Text = "Editar";
                mode = 2;
                isInEditMode = false;
                comboBox_supplier.Enabled = false;
                dateTimePicker_creation.Enabled = false;
                dateTimePicker_delivery.Enabled = false;
                comboBox_status.Enabled = false;
                button_add.Enabled = false;
                buttonDelete.Enabled = false;
                //hacer insert
                control.inserData(int.Parse(textBox_idsupplier.Text),comboBox_status.Text,DateTime.Parse(dateTimePicker_creation.Text),DateTime.Parse(dateTimePicker_delivery.Text),double.Parse(textBox_total.Text));
                Close();
            }
            else if(mode==2 && isInEditMode)
            {
                if (!validating_alldata())
                {
                    return;
                }
                buttonSave.Text = "Editar";
                isInEditMode = false;
                comboBox_supplier.Enabled = false;
                dateTimePicker_creation.Enabled = false;
                dateTimePicker_delivery.Enabled = false;
                comboBox_status.Enabled = false;
                button_add.Enabled = false;
                buttonDelete.Enabled = false;
                //hacer update
                control.updateData(textBox_id.Text, int.Parse(textBox_idsupplier.Text), comboBox_status.Text, DateTime.Parse(dateTimePicker_creation.Text), DateTime.Parse(dateTimePicker_delivery.Text), double.Parse(textBox_total.Text));
            }
            else
            {
                isInEditMode = true;
                buttonSave.Text = "🖫 Guardar";
                dateTimePicker_creation.Enabled = true;
                dateTimePicker_delivery.Enabled = true;
                textBox_cantidad.Enabled = true;
                button_add.Enabled = true;
                buttonDelete.Enabled = true;
                comboBox_status.Enabled = true;

            }
        }
        
        private void verifying_quantity(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_cantidad.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    MessageBox.Show("Solo puede ingresar números enteros en la cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_cantidad.Text = actualdata;
            int cantidad=int.Parse(textBox_cantidad.Text);
            double precio = double.Parse(textBox_price.Text);
            double subtotal = precio * cantidad;
            textBox_subtotal.Text = subtotal.ToString();
        }

        private void verifying_factura(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_factura.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    MessageBox.Show("Solo puede números en la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_factura.Text = actualdata;
        }
        
        private void mostrarOtrosCampos(object sender, EventArgs e)
        {
            int iCombo = comboBoxRawMaterialName.SelectedIndex;
            textBox_idrm.Text= rmList.Rows[iCombo]["id_raw_material"].ToString();
            idUnit.Text = rmList.Rows[iCombo]["unit"].ToString();
            unitAbrev.Text=hallarNombreUnit(int.Parse(idUnit.Text));
            textBox_price.Text = hallarPrecio(textBox_idrm.Text);            
        }
        private string hallarNombreUnit(int idUnit)
        {
            DataRow[] rows;
            unitList = control_unit.getData();
            rows = unitList.Select("id_unit =" + idUnit);
            if (rows.Any()) unitList = rows.CopyToDataTable();
            else unitList.Rows.Clear();
            string sortQuery = string.Format("id_unit");
            unitList.DefaultView.Sort = sortQuery;
            string nombUnit = "";
            if (unitList.Rows.Count > 0) nombUnit = unitList.Rows[0]["name"].ToString();
            return nombUnit;
        }
        private string hallarPrecio(string idMat)
        {
            DataRow[] rows;
            rawMat_supList = control_rm_sup.getData();
            rows = rawMat_supList.Select("id_raw_material = " + idMat+" AND id_supplier = "+textBox_idsupplier.Text+ " AND status = 'Activo'");
            if (rows.Any()) rawMat_supList = rows.CopyToDataTable();
            else rawMat_supList.Rows.Clear();
            string sortQuery = string.Format("id_rawmaterial_supplier");
            rawMat_supList.DefaultView.Sort = sortQuery;
            string nombUnit = "0";
            if (rawMat_supList.Rows.Count > 0) nombUnit = rawMat_supList.Rows[0]["price"].ToString();
            return nombUnit;
        }
        private int hallarId()
        {
            for (int i = 0; i < supList.Rows.Count; i++)
            {
                if (String.Compare(supList.Rows[i]["name"].ToString(), comboBox_supplier.Text) == 0)
                {
                    return int.Parse(supList.Rows[i]["id_supplier"].ToString());
                }
            }
            return -1;
        }
        private void cambiar_idsupplier(object sender, EventArgs e)
        {
            //cuando se elija un nuevo supplier se cambiará el id a mostrar
            textBox_idsupplier.Text = hallarId().ToString();
        }
    }
}