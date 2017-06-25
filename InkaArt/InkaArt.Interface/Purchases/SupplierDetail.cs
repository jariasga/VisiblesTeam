using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Interface.Purchases;
using InkaArt.Business.Purchases;
using System.Net.Mail;
namespace InkaArt.Interface.Purchases
{
    public partial class SupplierDetail : Form
    {
        int mode;
        SupplierController control;
        RawMaterial_SupplierController control_rs;
        RawMaterialController rawMaterialControl;
        DataTable rawMaterialList;
        bool isInEditMode = false;
        bool editPriceMode = false;
        Suppliers suppliersWindow;
        public SupplierDetail()
        {
            mode = 1; //crear Supplier
            control = new SupplierController();
            control_rs = new RawMaterial_SupplierController();
            InitializeComponent();
            textBox_priority.Text = "0";
            textBox_idSupplier.Enabled = false;
            buttonSave.Text = "🖫 Guardar";
            buttonAdd.Enabled = false;
            buttonDelete.Enabled = false;
            comboBox_status.SelectedIndex = 0;
            comboBox_status.Enabled = false;
            comboBox_rawMaterial.Enabled = false;
            textBox_price.Enabled = false;
            isInEditMode = true;
            dataGridView_rm_sup.Enabled = false;
            rawMaterialControl = new RawMaterialController();
            llenarComboBox();
        }

        public SupplierDetail(SupplierController controlForm,Suppliers suppliersView)
        {
            mode = 1;
            control = controlForm;
            control_rs = new RawMaterial_SupplierController();
            InitializeComponent();
            textBox_idSupplier.Enabled = false;
            comboBox_status.SelectedIndex = 0;
            comboBox_status.Enabled = false;
            textBox_priority.Text = "0";
            buttonSave.Text = "🖫 Guardar";
            buttonAdd.Enabled = false;
            buttonDelete.Enabled = false;
            comboBox_rawMaterial.Enabled = false;
            dataGridView_rm_sup.Enabled = false;
            textBox_price.Enabled = false;
            suppliersWindow = suppliersView;
            isInEditMode = true;
            rawMaterialControl = new RawMaterialController();
            llenarComboBox();
        }
        public SupplierDetail(DataGridViewRow currentSupplier,SupplierController controlForm, Suppliers suppliersView)
        {
            mode = 2; //editar Supplier
            control = controlForm;
            suppliersWindow = suppliersView;
            control_rs = new RawMaterial_SupplierController();
            InitializeComponent();
            textBox_idSupplier.Text = currentSupplier.Cells[1].Value.ToString();
            textBox_name.Text = currentSupplier.Cells[2].Value.ToString();
            textBox_ruc.Text = currentSupplier.Cells[3].Value.ToString();
            textBox_address.Text = currentSupplier.Cells[8].Value.ToString();
            trackBar_priority.Value = (int) currentSupplier.Cells[9].Value;
            textBox_priority.Text = trackBar_priority.Value.ToString();
            comboBox_status.Text = currentSupplier.Cells[7].Value.ToString();
            textBox_contactName.Text = currentSupplier.Cells[4].Value.ToString();
            textBox_email.Text = currentSupplier.Cells[6].Value.ToString();
            textBox_telephone.Text = currentSupplier.Cells[5].Value.ToString();
            textBox_idSupplier.Enabled = false;
            textBox_name.Enabled = false;
            textBox_ruc.Enabled = false;
            textBox_address.Enabled = false;
            trackBar_priority.Enabled = false;
            comboBox_status.Enabled = false;
            textBox_telephone.Enabled = false;
            textBox_contactName.Enabled = false;
            comboBox_rawMaterial.Enabled = false;
            textBox_price.Enabled = false;
            textBox_email.Enabled = false;
            buttonAdd.Enabled = false;
            buttonDelete.Enabled = false;
            rawMaterialControl = new RawMaterialController();

            llenarComboBox();
            llenarMateriasProvistas(textBox_idSupplier.Text);
            dataGridView_rm_sup.Enabled = false;

        }
        public void llenarComboBox()
        {
            filterRawMaterial();
            for (int i = 0; i < rawMaterialList.Rows.Count; i++)
                comboBox_rawMaterial.Items.Add(rawMaterialList.Rows[i]["name"].ToString());
        }
        public void filterRawMaterial()
        {
            //obtengo las materias primas para llenar el combobox
            DataRow[] rows;
            rawMaterialList = rawMaterialControl.getData();
            rows = rawMaterialList.Select("status LIKE 'Activo'");
            if (rows.Any()) rawMaterialList = rows.CopyToDataTable();
            else rawMaterialList.Rows.Clear();
            string sortQuery = string.Format("id_raw_material");
            rawMaterialList.DefaultView.Sort = sortQuery;
        }
        
        private void llenarMateriasProvistas(string idSup)
        {
            //obtengo solo las materias provistas por este supplier
            DataRow[] rows;
            DataTable rm_supList = control_rs.getData();
            rows = rm_supList.Select("id_supplier = " + idSup+" AND status = 'Activo'");
            if (rows.Any()) rm_supList = rows.CopyToDataTable();
            else rm_supList.Rows.Clear();
            string sortQuery = string.Format("id_raw_material");
            rm_supList.DefaultView.Sort = sortQuery;
            
            dataGridView_rm_sup.Rows.Clear();
            for(int i = 0; i < rm_supList.Rows.Count; i++)
            {
                string id = rm_supList.Rows[i]["id_raw_material"].ToString();
                string nombre = hallarNombreMat(id);
                string price = rm_supList.Rows[i]["price"].ToString();
                string idRM_Sup= rm_supList.Rows[i]["id_rawmaterial_supplier"].ToString();
                dataGridView_rm_sup.Rows.Add(id, nombre, price, idRM_Sup, false);
            }
        }
        private string hallarNombreMat(string idMat)
        {
            DataRow[] rows;
            DataTable auxiliarLista = rawMaterialControl.getData();
            rows = auxiliarLista.Select("id_raw_material = "+idMat);
            if (rows.Any()) auxiliarLista = rows.CopyToDataTable();
            else auxiliarLista.Rows.Clear();
            string sortQuery = string.Format("id_raw_material");
            auxiliarLista.DefaultView.Sort = sortQuery;
            if (auxiliarLista.Rows.Count != 0) return auxiliarLista.Rows[0]["name"].ToString();
            else return "";
        }
        private int hallarIdMat()
        {
            for (int i = 0; i < rawMaterialList.Rows.Count; i++)
                {
                    if (String.Compare(rawMaterialList.Rows[i]["name"].ToString(), comboBox_rawMaterial.Text) == 0)
                    {
                        return int.Parse(rawMaterialList.Rows[i]["id_raw_material"].ToString());
                    }
                }
            return -1;
        }
        private void button_add(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                MessageBox.Show("Primero debe crear el proveedor para agregar las materias primas", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (comboBox_rawMaterial.Text.Length < 1)
            {
                MessageBox.Show("Debe seleccionar la materia prima que desee agregar", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if(textBox_price.Text.Last()== '.')
            {
                textBox_price.Text += "0";
            }
            else if (double.Parse(textBox_price.Text) < 0.01)
            {
                MessageBox.Show("El precio no puede ser 0", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int idMaterial=hallarIdMat();
            if (idMaterial == -1) return;
            control_rs.insertRM_Sup(idMaterial.ToString(), textBox_idSupplier.Text, textBox_price.Text, "Activo");
            llenarMateriasProvistas(textBox_idSupplier.Text);
        }

        private void button_delete(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_rm_sup.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView_rm_sup.Rows[i].Cells[4].Value) == true)
                {
                    string idRMSup = dataGridView_rm_sup.Rows[i].Cells[3].Value.ToString();
                    string idMat = dataGridView_rm_sup.Rows[i].Cells[0].Value.ToString();
                    string price= dataGridView_rm_sup.Rows[i].Cells[2].Value.ToString();
                    control_rs.UpdateRM_Sup(idRMSup,idMat,textBox_idSupplier.Text, price, "Inactivo");
                }
            }
            llenarMateriasProvistas(textBox_idSupplier.Text);
        }
        

        private void trackBar_priority_Scroll(object sender, EventArgs e)
        {
            this.textBox_priority.Text = trackBar_priority.Value.ToString();
        }
        private bool verifying_email()
        {
            try
            {
                new MailAddress(textBox_email.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("El email no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private string crear_cadenaCampos()
        {
            string cadenaDeCampos = "";
            int numFaltante = 0;
            if (textBox_name.Text.Length < 1)
            {
                cadenaDeCampos += "nombre";
                numFaltante++;
            }
            if (textBox_ruc.Text.Length < 1)
            {
                if (numFaltante > 0) cadenaDeCampos += ", ";
                cadenaDeCampos += "RUC";
                numFaltante++;
            }
            if (textBox_address.Text.Length < 1)
            {
                if (numFaltante > 0) cadenaDeCampos += ", ";
                cadenaDeCampos += "dirección";
                numFaltante++;
            }
            if(comboBox_status.Text.Length < 1)
            {
                if (numFaltante > 0) cadenaDeCampos += ", ";
                cadenaDeCampos += "estado";
                numFaltante++;
            }
            if (textBox_contactName.Text.Length < 1)
            {
                if (numFaltante > 0) cadenaDeCampos += ", ";
                cadenaDeCampos += "contacto";
                numFaltante++;
            }
            if(textBox_email.Text.Length < 1)
            {
                if (numFaltante > 0) cadenaDeCampos += ", ";
                cadenaDeCampos += "correo";
                numFaltante++;
            }
            if (textBox_telephone.Text.Length < 1)
            {
                if (numFaltante > 0) cadenaDeCampos += ", ";
                cadenaDeCampos += "teléfono";
                numFaltante++;
            }
            if (numFaltante == 1) cadenaDeCampos = "Debe llenar el campo: " + cadenaDeCampos + ".";
            else if (numFaltante > 1) cadenaDeCampos = "Debe llenar los campos: " + cadenaDeCampos + ".";
            return cadenaDeCampos;
        }
        private bool validating_filled()
        {
            textBox_name.Text = textBox_name.Text.Trim();
            textBox_address.Text = textBox_address.Text.Trim();
            textBox_contactName.Text = textBox_contactName.Text.Trim();
            textBox_email.Text = textBox_email.Text.Trim();
            string cadena_Error = crear_cadenaCampos();       
            if (cadena_Error.Length>1)
            {
                MessageBox.Show(cadena_Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool verifying_length_ruc()
        {
            if (textBox_ruc.Text.Length != 11)
            {
                MessageBox.Show("El RUC debe tener 11 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool verifying_length_telephone()
        {
            if (textBox_ruc.Text.Length != 11)
            {
                MessageBox.Show("El teléfono debe tener al menos 7 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void button_event_click(object sender, EventArgs e)
        {
            if (mode==2 && isInEditMode)
            {
                if (!validating_filled() || !verifying_length_ruc()||!verifying_length_telephone() || !verifying_email())
                {
                    return;
                }
                try
                {
                    control.updateData(textBox_idSupplier.Text, textBox_name.Text, textBox_ruc.Text, textBox_contactName.Text, int.Parse(textBox_telephone.Text), textBox_email.Text, textBox_address.Text, int.Parse(textBox_priority.Text), comboBox_status.Text);
                    suppliersWindow.desarrolloBusqueda();
                }
                catch (Exception)
                {

                }
                this.Close();
            }
            else if (mode==2)
            {
                isInEditMode = true;
                textBox_name.Enabled = true;
                textBox_ruc.Enabled = true;
                textBox_address.Enabled = true;
                trackBar_priority.Enabled = true;
                comboBox_status.Enabled = true;
                textBox_telephone.Enabled = true;
                textBox_contactName.Enabled = true;
                textBox_price.Enabled = true;
                comboBox_rawMaterial.Enabled = true;
                dataGridView_rm_sup.Enabled = true;
                textBox_email.Enabled = true;
                buttonAdd.Enabled = true;
                buttonDelete.Enabled = true;
                dataGridView_rm_sup.Columns["Precio"].ReadOnly = false;
                buttonSave.Text = "🖫 Guardar";
            }
            else
            {
                if (!validating_filled() || !verifying_length_ruc() ||!verifying_length_telephone()|| !verifying_email())
                {
                    return;
                }
                try
                {
                    control.insertData(textBox_name.Text, textBox_ruc.Text, textBox_contactName.Text, int.Parse(textBox_telephone.Text), textBox_email.Text, textBox_address.Text, int.Parse(textBox_priority.Text), comboBox_status.Text);
                    textBox_idSupplier.Text = obtenerIdSupplierNuevo(textBox_name.Text, textBox_ruc.Text,int.Parse(textBox_priority.Text));
                    mode = 2;
                    isInEditMode = true;
                    textBox_name.Enabled = true;
                    textBox_ruc.Enabled = true;
                    textBox_address.Enabled = true;
                    trackBar_priority.Enabled = true;
                    comboBox_status.Enabled = true;
                    textBox_telephone.Enabled = true;
                    comboBox_rawMaterial.Enabled = true;
                    textBox_price.Enabled = true;
                    textBox_contactName.Enabled = true;
                    dataGridView_rm_sup.Enabled = true;
                    textBox_email.Enabled = true;
                    buttonAdd.Enabled = true;
                    buttonDelete.Enabled = true;
                    dataGridView_rm_sup.Columns["Precio"].ReadOnly = false;
                    suppliersWindow.desarrolloBusqueda();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo crear el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void actualizar_precio(int fila)
        {
            string id_rm = dataGridView_rm_sup.Rows[fila].Cells[0].Value.ToString();
            string id_sup = dataGridView_rm_sup.Rows[fila].Cells[1].Value.ToString();
            string price = dataGridView_rm_sup.Rows[fila].Cells[2].Value.ToString();
            //control_rs.UpdateRM_Sup(id_rm, id_sup, price);
        }

        private void obtain_idEdit(object sender, EventArgs e)
        {
            if (isInEditMode)
            {
                editPriceMode = true;
            }
        }

        private void verifying_contactname(object sender, EventArgs e)
        {
            if (!isInEditMode) return;
            string actualdata = string.Empty;
            char[] entereddata = textBox_contactName.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (!Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    MessageBox.Show("Solo puede ingresar letras en el nombre de contacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_contactName.Text = actualdata;
        }

        private void verifying_price(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_price.Text.ToCharArray();
            int cantPuntos = 0;
            int numDecimales = 0;
            bool primerCaracter = true;
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if ((Char.IsDigit(aChar) && numDecimales<3)|| (!primerCaracter && aChar=='.' && cantPuntos==0))
                {
                    actualdata = actualdata + aChar;
                    if (primerCaracter) primerCaracter = false;
                    if (cantPuntos == 1) numDecimales++;
                    if (aChar == '.') cantPuntos++;
                }
                else
                {
                    MessageBox.Show("En el precio solo puede ingresar números con hasta dos decimales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_price.Text = actualdata;
        }
        private void verifying_number(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_ruc.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    MessageBox.Show("Solo puede ingresar números en el RUC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_ruc.Text = actualdata;
        }

        private void verifying_telephone(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_telephone.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    MessageBox.Show("Solo puede ingresar números en el teléfono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_telephone.Text = actualdata;
        }
        private string obtenerIdSupplierNuevo(string name,string ruc, int priority)
        {
            
            DataRow[] rows;
            DataTable tablaAuxiliar = control.getData();
            rows = tablaAuxiliar.Select("status LIKE 'Activo'");
            if (rows.Any()) tablaAuxiliar = rows.CopyToDataTable();
            else tablaAuxiliar.Rows.Clear();
            string sortQuery = string.Format("id_supplier");
            tablaAuxiliar.DefaultView.Sort = sortQuery;
            int numero = tablaAuxiliar.Rows.Count;
            int comprobar = 5;
            if (numero < 5) comprobar = numero;
            for(int i = 1; i < comprobar; i++)
            {
                if(String.Compare(tablaAuxiliar.Rows[numero-i]["name"].ToString(),name)==0 && String.Compare(tablaAuxiliar.Rows[numero - i]["ruc"].ToString(), ruc) == 0 && priority==int.Parse(tablaAuxiliar.Rows[numero - i]["priority"].ToString()))
                {
                    return tablaAuxiliar.Rows[numero - i]["id_supplier"].ToString();
                }
            }
            return "";
        }

        private void limpiarPrecio(object sender, EventArgs e)
        {
            textBox_price.Text = "";
        }
    }
}
