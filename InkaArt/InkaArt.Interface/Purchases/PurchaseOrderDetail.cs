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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using InkaArt.Business.Warehouse;

namespace InkaArt.Interface.Purchases
{
    public partial class PurchaseOrderDetail : Form
    {
        PurchaseOrderController control;
        PurchaseOrderDetailController control_detail;
        SupplierController control_supplier;
        RawMaterial_SupplierController control_rm_sup;
        RawMaterialController control_rm;
        string estadoInicial = "";
        UnitOfMeasurementController control_unit;
        PurchaseOrder ventanaListaOrdenes;
        DataTable supList,rawMat_supList,rmList,unitList,lineaPedidosList;
        int mode;
        string listaMaterialesIds;
        bool isInEditMode = true;
        bool enProcesoDeLlenado = true;

        public PurchaseOrderDetail()
        {
            mode = 1;
            control = new PurchaseOrderController();
            control_supplier = new SupplierController();
            InitializeComponent();
            button_add.Enabled = false;
            comboBox_status.SelectedIndex = 0;
            comboBox_status.Enabled = false;
            buttonDelete.Enabled = true;
            buttonSave.Enabled = true;
            dateTimePicker_creation.Value = DateTime.Now;
            dateTimePicker_delivery.Value = DateTime.Today.AddDays(8);
            dataGridView_pedidos.Enabled = false;
            comboBoxRawMaterialName.Enabled = false;
            textBox_cantidad.Enabled = false;
            textBox_total.Text = "0";
            buttonSave.Text = "🖫 Guardar";
        }
        public PurchaseOrderDetail(PurchaseOrderController controlForm,PurchaseOrder ventana)
        {
            mode = 1;
            ventanaListaOrdenes = ventana;
            control = controlForm;
            InitializeComponent();
            button_add.Enabled = false;
            buttonDelete.Enabled = true;
            buttonSave.Enabled = true;
            dataGridView_pedidos.Enabled = false;
            comboBoxRawMaterialName.Enabled = false;
            comboBox_status.SelectedIndex = 0;
            comboBox_status.Enabled = false;
            textBox_cantidad.Enabled = false;
            buttonDelete.Enabled = false;
            dateTimePicker_creation.Value = DateTime.Now;
            dateTimePicker_delivery.Value = DateTime.Today.AddDays(8);
            textBox_total.Text = "0";
            textBox_cantidad.Text = "0";
            buttonSave.Text = "🖫 Guardar";
            control_supplier = new SupplierController();
            control_detail = new PurchaseOrderDetailController();
            control_rm = new RawMaterialController();
            control_rm_sup = new RawMaterial_SupplierController();
            control_unit = new UnitOfMeasurementController();
            llenarComboBoxSuppliers();
        }
        public PurchaseOrderDetail(DataGridViewRow currentPurchaseOrder, PurchaseOrderController controlForm,PurchaseOrder ventana)
        {
            mode = 2;
            isInEditMode = false;
            ventanaListaOrdenes = ventana;
            control = controlForm;
            InitializeComponent();
            textBox_id.Text = currentPurchaseOrder.Cells[0].Value.ToString();
            textBox_idsupplier.Text = currentPurchaseOrder.Cells[6].Value.ToString();
            if (string.Compare(currentPurchaseOrder.Cells[5].Value.ToString(), "Entregado")==0){
                comboBox_status.Items.Add(currentPurchaseOrder.Cells[5].Value.ToString());
            }
            comboBox_status.Text = currentPurchaseOrder.Cells[5].Value.ToString();
            dateTimePicker_creation.Value = DateTime.Parse(currentPurchaseOrder.Cells[2].Value.ToString());
            dateTimePicker_delivery.Value = DateTime.Parse(currentPurchaseOrder.Cells[3].Value.ToString());
            textBox_total.Text = currentPurchaseOrder.Cells[4].Value.ToString();
            textBox_idsupplier.Enabled = false;
            dateTimePicker_creation.Enabled = false;
            dateTimePicker_delivery.Enabled = false;
            comboBox_status.Enabled = false;
            
            comboBox_supplier.Enabled = false;
            button_add.Enabled = false;
            buttonDelete.Enabled = false;
            textBox_cantidad.Enabled = false;
            dataGridView_pedidos.Enabled = false;
            comboBoxRawMaterialName.Enabled = false;
            control_supplier = new SupplierController();
            buscarNombreSupplier(textBox_idsupplier.Text);
            control_detail = new PurchaseOrderDetailController();
            control_rm = new RawMaterialController();
            control_rm_sup = new RawMaterial_SupplierController();
            control_unit = new UnitOfMeasurementController();
            obtenerMateriasDelSupplier();
            estadoInicial=comboBox_status.Text;
            llenarMateriasPedidas();
            buttonExport.Visible = false;
            if (string.Compare(comboBox_status.Text, "Eliminado") == 0)
            {
                buttonSave.Visible = false;
            }
            else if (string.Compare(comboBox_status.Text, "Borrador") != 0)
            {
                buttonExport.Visible = true;
                buttonSave.Visible = false;
            }
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
            enProcesoDeLlenado = true;
            //obtengo todas las lineas de pedido de esta orden
            DataRow[] rows;
            lineaPedidosList = control_detail.getData();
            rows = lineaPedidosList.Select("id_order = " + textBox_id.Text + " AND status NOT IN ('Eliminado')");
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
                string nombre = buscarNombre(id_raw_material);
                string quantity = lineaPedidosList.Rows[i]["quantity"].ToString();
                string amount = lineaPedidosList.Rows[i]["amount"].ToString();
                string igv = lineaPedidosList.Rows[i]["igv"].ToString();
                string id_factura = lineaPedidosList.Rows[i]["id_factura"].ToString();
                string status = lineaPedidosList.Rows[i]["status"].ToString();
                dataGridView_pedidos.Rows.Add(id_detail,id_raw_material,nombre,quantity,amount,igv,id_factura,status,false,false,false);
            }
            enProcesoDeLlenado = false;
        }
        private string buscarNombre(string id_raw)
        {
            DataRow[] rows;
            DataTable auxiliarLista = control_rm.getData();
            rows = auxiliarLista.Select("id_raw_material = " + id_raw);
            if (rows.Any()) auxiliarLista = rows.CopyToDataTable();
            else auxiliarLista.Rows.Clear();
            string sortQuery = string.Format("id_raw_material");
            auxiliarLista.DefaultView.Sort = sortQuery;
            if (auxiliarLista.Rows.Count != 0) return auxiliarLista.Rows[0]["name"].ToString();
            else return "";
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
            textBox_cantidad.Text = textBox_cantidad.Text.Trim();
            if(textBox_cantidad.Text.Length==0 || int.Parse(textBox_cantidad.Text) == 0)
            {
                MessageBox.Show("No se puede agregar un pedido con cantidad cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            textBox_subtotal.Text = textBox_subtotal.Text.Trim();
            if (textBox_subtotal.Text.Length==0 || double.Parse(textBox_subtotal.Text) < 0.01)
            {
                MessageBox.Show("No se puede agregar un pedido con subtotal cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cant = int.Parse(textBox_cantidad.Text);
            int id_rm = int.Parse(textBox_idrm.Text);
            int maximoEstablecido = cantidadSuperaMaximo(id_rm);
            if (maximoEstablecido < cant)
            {
                MessageBox.Show("No se puede pedir más de " + maximoEstablecido + " de este materia prima.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id_order = int.Parse(textBox_id.Text);
            int id_sup = int.Parse(textBox_idsupplier.Text);
            double subTotalNuevo = Math.Round(double.Parse(textBox_subtotal.Text),2);
            double igv = Math.Round(double.Parse(textBox_igv.Text),2);
            /*try
            {
                control_detail.insertData(id_order, id_rm, id_sup, int.Parse(textBox_cantidad.Text), subTotalNuevo,igv, 0, "Borrador");
                textBox_subtotal.Text = "0";
                textBox_cantidad.Text = "0";
                textBox_igv.Text = "0";
                textBox_price.Text = "0";
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo agregar la línea de pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            double total = Math.Round(double.Parse(textBox_total.Text), 2);
            int indiceExistente;
            if ((indiceExistente = estaEnDataGrid(id_rm)) != -1)
            {
                //si esta en el datagrid, actualizo valor del datagrid
                dataGridView_pedidos.Rows[indiceExistente].Cells[3].Value = int.Parse(textBox_cantidad.Text);
                //Le resto el valor del subtotal e igv anterior
                total -= Math.Round(double.Parse(dataGridView_pedidos.Rows[indiceExistente].Cells[4].Value.ToString()),2);
                dataGridView_pedidos.Rows[indiceExistente].Cells[4].Value = subTotalNuevo;
                total -= Math.Round(double.Parse(dataGridView_pedidos.Rows[indiceExistente].Cells[5].Value.ToString()), 2);
                dataGridView_pedidos.Rows[indiceExistente].Cells[5].Value = igv;
                if (dataGridView_pedidos.Rows[indiceExistente].Cells[0].Value != null)
                {//si existe en la base de datos marco que se ha modificado
                    dataGridView_pedidos.Rows[indiceExistente].Cells[9].Value = true;//marco que se ha modificado
                }

            }
            else
            {
                //si no está en el dataGrid
                dataGridView_pedidos.Rows.Add(null, id_rm, comboBoxRawMaterialName.Text, textBox_cantidad.Text, subTotalNuevo, igv, null, "Borrador", false, false, false);

            }
            
            total += subTotalNuevo;
            total += igv;
            total = Math.Round(total, 2);
            textBox_total.Text = total.ToString();
            //control.updateData(textBox_id.Text, int.Parse(textBox_idsupplier.Text), comboBox_status.Text, DateTime.Parse(dateTimePicker_creation.Text), DateTime.Parse(dateTimePicker_delivery.Text), double.Parse(textBox_total.Text));
            //llenarMateriasPedidas();
        }
        private int cantidadSuperaMaximo(int id_rm)
        {
            DataRow[] rows;
            RawMaterialWarehouseController control_rw = new RawMaterialWarehouseController();
            DataTable tablaAuxiliar = control_rw.getData();
            rows = tablaAuxiliar.Select("idRawMaterial = " + id_rm+ " AND state = 'Activo'");
            if (rows.Any()) tablaAuxiliar = rows.CopyToDataTable();
            else tablaAuxiliar.Rows.Clear();
            string sortQuery = string.Format("idWarehouse");
            tablaAuxiliar.DefaultView.Sort = sortQuery;
            int numero = tablaAuxiliar.Rows.Count;
            int maximo = 0;
            int stockActual= 0;
            for (int i = 0; i < numero; i++)
            {
                maximo += int.Parse(tablaAuxiliar.Rows[i]["maximunStock"].ToString());
                stockActual += int.Parse(tablaAuxiliar.Rows[i]["currentStock"].ToString());
            }
            return (maximo-stockActual);
        }
        private int estaEnDataGrid(int id_rm)
        {
            //solo devuelve los ids de filas que no estan eliminadas
            for (int i = 0; i < dataGridView_pedidos.Rows.Count; i++)
            {
                if (int.Parse(dataGridView_pedidos.Rows[i].Cells[1].Value.ToString()) == id_rm && !Convert.ToBoolean(dataGridView_pedidos.Rows[i].Cells[10].Value))
                    return i;
            }
            return -1;
        }
        /* delete */
        private void button_delete(object sender, EventArgs e)
        {
            for (int i = dataGridView_pedidos.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(dataGridView_pedidos.Rows[i].Cells[8].Value))
                {
                    double totalOr = Math.Round(double.Parse(textBox_total.Text), 2);
                    double subtotalAux = Math.Round(double.Parse(dataGridView_pedidos.Rows[i].Cells[4].Value.ToString()), 2);
                    double igvLinea = Math.Round(double.Parse(dataGridView_pedidos.Rows[i].Cells[5].Value.ToString()), 2);
                    totalOr -= subtotalAux;
                    totalOr -= igvLinea;
                    textBox_total.Text = Math.Round(totalOr,2).ToString();
                    if (dataGridView_pedidos.Rows[i].Cells[0].Value == null)
                    {
                        //si no está en la BD
                        dataGridView_pedidos.Rows.RemoveAt(i);
                    }
                    else
                    {
                        //Si está en la BD
                        dataGridView_pedidos.Rows[i].Cells[10].Value = true;
                        dataGridView_pedidos.Rows[i].Visible = false;
                    }
                       /* int id_detailAux = int.Parse(dataGridView_pedidos.Rows[i].Cells[0].Value.ToString());
                    int cantidadAux = int.Parse(dataGridView_pedidos.Rows[i].Cells[3].Value.ToString());
                    try
                    {
                        control_detail.updateData(id_detailAux, cantidadAux, subtotalAux, igvLinea, "Eliminado");
                        dataGridView_pedidos.Rows[i].Cells[8].Value = false;
                        control.updateData(textBox_id.Text, int.Parse(textBox_idsupplier.Text), comboBox_status.Text, DateTime.Parse(dateTimePicker_creation.Text), DateTime.Parse(dateTimePicker_delivery.Text), totalOr);
                        
                    }
                    catch (Exception)
                    {
                        continue;
                    }*/
                }
            }
            /*llenarMateriasPedidas();
            ventanaListaOrdenes.desarrolloBusqueda();*/
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
            if (string.Compare(comboBox_status.Text, "Enviado") == 0 && double.Parse(textBox_total.Text)<0.01)
            {
                MessageBox.Show("No se puede enviar una orden con monto 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }
        private string buscarValorId(string id_supplier)
        {
            DataRow[] rows;
            DataTable tablaAuxiliar = control.getData();
            rows = tablaAuxiliar.Select("status LIKE 'Borrador'");
            if (rows.Any()) tablaAuxiliar = rows.CopyToDataTable();
            else tablaAuxiliar.Rows.Clear();
            string sortQuery = string.Format("id_order");
            tablaAuxiliar.DefaultView.Sort = sortQuery;
            int numero = tablaAuxiliar.Rows.Count;
            int comprobar = 5;
            if (numero < 5) comprobar = numero;
            for (int i = 1; i <= comprobar; i++)
            {
                if (String.Compare(tablaAuxiliar.Rows[numero - i]["id_supplier"].ToString(), id_supplier) == 0)
                {
                    return tablaAuxiliar.Rows[numero - i]["id_order"].ToString();
                }
            }
            return "";
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
                try
                {
                    //hacer insert
                    control.inserData(int.Parse(textBox_idsupplier.Text), comboBox_status.Text, DateTime.Parse(dateTimePicker_creation.Text), DateTime.Parse(dateTimePicker_delivery.Text), double.Parse(textBox_total.Text));
                    ventanaListaOrdenes.desarrolloBusqueda();
                    textBox_id.Text = buscarValorId(textBox_idsupplier.Text);
                    obtenerMateriasDelSupplier();
                    llenarMateriasPedidas();

                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo crear la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else if (mode == 2 && isInEditMode)
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
                try {
                    guardarLineasDePedido();
                    control.updateData(textBox_id.Text, int.Parse(textBox_idsupplier.Text), comboBox_status.Text, DateTime.Parse(dateTimePicker_creation.Text), DateTime.Parse(dateTimePicker_delivery.Text), double.Parse(textBox_total.Text));
                    if (string.Compare(comboBox_status.Text, estadoInicial) != 0) {//cambioElEstado
                        if(string.Compare(comboBox_status.Text, "Eliminado") == 0) pasarTodasLasLineasAEstado("Eliminado");
                        else if(string.Compare(comboBox_status.Text, "Enviado")==0) pasarTodasLasLineasAEstado("Enviado");
                        estadoInicial = comboBox_status.Text;
                    }
                    llenarMateriasPedidas();
                    ventanaListaOrdenes.desarrolloBusqueda();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo guardar los cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                isInEditMode = true;
                buttonSave.Text = "🖫 Guardar";
                if (string.Compare(comboBox_status.Text, "Borrador") == 0) {
                    dateTimePicker_creation.Enabled = true;
                    dateTimePicker_delivery.Enabled = true;
                    comboBox_status.Enabled = true;
                    textBox_cantidad.Enabled = true;
                    button_add.Enabled = true;
                    buttonDelete.Enabled = true;
                    comboBoxRawMaterialName.Enabled = true;
                    activarBotonAgregar();
                }
                dataGridView_pedidos.Enabled = true;

            }
        }
        private void guardarLineasDePedido()
        {
            for (int i = 0; i < dataGridView_pedidos.Rows.Count; i++)
            {
                if (dataGridView_pedidos.Rows[i].Cells[0].Value == null)
                {
                    //si no está en la bd lo inserto
                    int id_orderR = int.Parse(textBox_id.Text);
                    int idMat = int.Parse(dataGridView_pedidos.Rows[i].Cells[1].Value.ToString());
                    string price = dataGridView_pedidos.Rows[i].Cells[2].Value.ToString();
                    int id_supplierR = int.Parse(textBox_idsupplier.Text);
                    int cantidad = int.Parse(dataGridView_pedidos.Rows[i].Cells[3].Value.ToString());
                    double subtotal = Math.Round(double.Parse(dataGridView_pedidos.Rows[i].Cells[4].Value.ToString()),2);
                    double igv = Math.Round(double.Parse(dataGridView_pedidos.Rows[i].Cells[5].Value.ToString()), 2);
                    control_detail.insertData(id_orderR, idMat, id_supplierR,cantidad,subtotal,igv,0,"Borrador");
                }
                else if (Convert.ToBoolean(dataGridView_pedidos.Rows[i].Cells[10].Value))
                {
                    //si existe en la BD y está marcado como eliminado, lo paso a Inactivo
                    int id_detailAux = int.Parse(dataGridView_pedidos.Rows[i].Cells[0].Value.ToString());
                    int cantidad = int.Parse(dataGridView_pedidos.Rows[i].Cells[3].Value.ToString());
                    double subtotal = Math.Round(double.Parse(dataGridView_pedidos.Rows[i].Cells[4].Value.ToString()), 2);
                    double igv = Math.Round(double.Parse(dataGridView_pedidos.Rows[i].Cells[5].Value.ToString()), 2);
                    control_detail.updateData(id_detailAux, cantidad, subtotal, igv, "Eliminado");

                }
                else if (Convert.ToBoolean(dataGridView_pedidos.Rows[i].Cells[9].Value))
                {
                    //si existe en la BD y está marcado como modificado, lo actualizo
                    int id_detailAux = int.Parse(dataGridView_pedidos.Rows[i].Cells[0].Value.ToString());
                    int cantidad = int.Parse(dataGridView_pedidos.Rows[i].Cells[3].Value.ToString());
                    double subtotal = Math.Round(double.Parse(dataGridView_pedidos.Rows[i].Cells[4].Value.ToString()), 2);
                    double igv = Math.Round(double.Parse(dataGridView_pedidos.Rows[i].Cells[5].Value.ToString()), 2);

                    control_detail.updateData(id_detailAux, cantidad, subtotal, igv, "Borrador");
                }
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
            int modelo,cantidad=0;
            if(int.TryParse(textBox_cantidad.Text,out modelo)) cantidad=int.Parse(textBox_cantidad.Text);
            else
            {
                textBox_subtotal.Text = "0";
                textBox_igv.Text = "0";
                return;
            }
            double precio = Math.Round(double.Parse(textBox_price.Text),2);
            double subtotal = Math.Round(precio * cantidad,2);
            textBox_subtotal.Text = subtotal.ToString();
            double montoIgv = Math.Round(subtotal * 0.18,2);
            textBox_igv.Text = montoIgv.ToString();
        }       
        private void mostrarOtrosCampos(object sender, EventArgs e)
        {
            int iCombo = comboBoxRawMaterialName.SelectedIndex;
            textBox_idrm.Text= rmList.Rows[iCombo]["id_raw_material"].ToString();
            idUnit.Text = rmList.Rows[iCombo]["unit"].ToString();
            unitAbrev.Text=hallarNombreUnit(int.Parse(idUnit.Text));
            textBox_price.Text = hallarPrecio(textBox_idrm.Text);
            textBox_cantidad.Text = "0";
            textBox_igv.Text = "0";
            textBox_subtotal.Text = "0";       
        }
        private void pasarTodasLasLineasAEstado(string nuevoEstado)
        {
            for (int i = 0; i < dataGridView_pedidos.Rows.Count; i++)
            {
                int id_detailAux = int.Parse(dataGridView_pedidos.Rows[i].Cells[0].Value.ToString());
                int cantidadAux = int.Parse(dataGridView_pedidos.Rows[i].Cells[3].Value.ToString());
                double subtotalAux = Math.Round(double.Parse(dataGridView_pedidos.Rows[i].Cells[4].Value.ToString()), 2);
                double igvLinea = Math.Round(double.Parse(dataGridView_pedidos.Rows[i].Cells[5].Value.ToString()), 2);
                try
                {
                        control_detail.updateData(id_detailAux, cantidadAux, subtotalAux, igvLinea, nuevoEstado);
                        dataGridView_pedidos.Rows[i].Cells[8].Value = false;
                }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            
            llenarMateriasPedidas();
            ventanaListaOrdenes.desarrolloBusqueda();
        }

        private void activarBotonAgregar()
        {
            if(isInEditMode && textBox_id.Text.Length>0 && textBox_idsupplier.Text.Length >= 0)
            {
                button_add.Enabled = true;
            }
        }
        
        private void generarOrdenDoc(object sender, EventArgs e)
        {
            if(mode==2 && string.Compare(comboBox_status.Text, "Eliminado") != 0)
            {
                FileStream fs = new FileStream("OrdenPrueba.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                Document document = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                
                Paragraph title = new Paragraph("ORDEN DE COMPRA", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph(" "));
                var phrase = new Phrase();
                phrase.Add(new Chunk("N°:                              ", boldFont));
                phrase.Add(new Chunk(textBox_id.Text));
                document.Add(new Paragraph(phrase));
                var phrase2 = new Phrase();
                phrase2.Add(new Chunk("Proveedor:               ", boldFont));
                phrase2.Add(new Chunk(comboBox_supplier.Text));
                document.Add(new Paragraph(phrase2));
                var phrase3 = new Phrase();
                phrase3.Add(new Chunk("Fecha de emisión:    ", boldFont));
                phrase3.Add(new Chunk(dateTimePicker_creation.Text));
                document.Add(new Paragraph(phrase3));
                document.Add(new Paragraph(" "));
                PdfPTable table = new PdfPTable(5);
                for (int i = 1; i < dataGridView_pedidos.Columns.Count-5; i++)
                {
                    table.AddCell(dataGridView_pedidos.Columns[i].HeaderText);
                }
                for (int i = 0; i < dataGridView_pedidos.Rows.Count; i++)
                {
                    for (int j = 1; j < dataGridView_pedidos.Columns.Count-5; j++)
                    {
                        if (dataGridView_pedidos.Rows[i].Cells[j].Value != null)
                        {
                            table.AddCell(dataGridView_pedidos.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                        {
                            table.AddCell("");
                        }
                    }
                }
                document.Add(table);
                document.Add(new Paragraph(" "));
                var phrase4 = new Phrase();
                phrase4.Add(new Chunk("TOTAL:                         ", boldFont));
                phrase4.Add(new Chunk(textBox_total.Text));
                document.Add(new Paragraph(phrase4));
                document.Close();
                MessageBox.Show("Se generó el archivo de la orden exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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