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
using InkaArt.Business.Warehouse;

namespace InkaArt.Interface.Warehouse
{
    public partial class PurchaseMovement : Form
    {
        string idWh = "";
        public PurchaseMovement(string id)
        {
            InitializeComponent();
            idWh = id;
            fillCombo();
        }

        private void fillCombo()
        {
            PurchaseOrderController control = new PurchaseOrderController();
            DataTable OcList = control.getData();

            for (int i = 0; i < OcList.Rows.Count; i++)
                if (OcList.Rows[i]["status"].ToString() == "Pendiente")
                    comboBox_OC.Items.Add(OcList.Rows[i]["id_order"].ToString());
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void PurchaseMovement_Load(object sender, EventArgs e)
        {

        }

        private string giveme_rawName(string id)
        {
            string name = "";
            RawMaterialController control = new RawMaterialController();
            DataTable RmList = control.getData();
            for(int i=0;i<RmList.Rows.Count;i++)
                if (string.Compare(id, RmList.Rows[i]["id_raw_material"].ToString()) == 0)
                {
                    name = RmList.Rows[i]["name"].ToString();
                    break;
                }
            return name;
        }

        private string giveme_supplierName(string id)
        {
            string name = "";
            SupplierController control = new SupplierController();
            DataTable supplyList = control.getData();

            for(int i=0;i<supplyList.Rows.Count;i++)
                if (string.Compare(id, supplyList.Rows[i]["id_supplier"].ToString()) == 0)
                {
                    name = supplyList.Rows[i]["name"].ToString();
                    break;
                }
            return name;
        }

        public bool canIStoreThisMaterial(string idRm)//validacion de que se puede agregar determinada materia prima al almacen
        {
            RawMaterialWarehouseController control = new RawMaterialWarehouseController();
            DataTable RmWList = control.getData();

            bool respuesta = false;

            for (int i=0;i<RmWList.Rows.Count;i++)
                if(string.Compare(idWh,RmWList.Rows[i]["idWarehouse"].ToString())==0)
                    if (string.Compare(idRm, RmWList.Rows[i]["idRawMaterial"].ToString()) == 0)
                    {
                        respuesta = true;
                        break;
                    }

            
           
            return respuesta;
        }

        public string howMuchCanIMove(string idFactura,string  idRm)
        {
            StockDocumentController control = new StockDocumentController();
            DataTable stockDocList = control.getData();

            string respuesta = "falso";

            for(int i=0;i<stockDocList.Rows.Count;i++)
                if(string.Compare(idRm,stockDocList.Rows[i]["product_id"].ToString())==0 &&
                    string.Compare(idFactura, stockDocList.Rows[i]["idDocument"].ToString()) == 0 &&
                    string.Compare("materia_prima", stockDocList.Rows[i]["product_type"].ToString()) == 0)
                {
                    respuesta = stockDocList.Rows[i]["product_stock"].ToString();
                     
                    break;
                }

            return respuesta;
        }

        private void actualizaLinea(string idLinea, int id_factura)
        {
            PurchaseOrderDetailController control = new PurchaseOrderDetailController();
            DataTable ocDetailList = control.getData();
            if (id_factura != 0)
            {
                int id_linea = int.Parse(idLinea);
                for (int i = 0; i < ocDetailList.Rows.Count; i++)
                    if (ocDetailList.Rows[i]["id_detail"].ToString() == idLinea)
                        //updete del controller
                        control.updateLineaEntregada(id_linea,id_factura);
            }
        }

        private void actualizaOrdenes()
        {
            PurchaseOrderController control = new PurchaseOrderController();
            DataTable OcList = control.getData();

            int id_orden = int.Parse(comboBox_OC.SelectedItem.ToString());
            int estado_terminado = 0;
            for (int i = 0; i < dataGridView_details.Rows.Count; i++)
                if (dataGridView_details.Rows[i].Cells[1].Value.ToString() != "Facturado" &&
                    dataGridView_details.Rows[i].Cells[1].Value.ToString() != "Entregado")
                    estado_terminado = 1;
            if (estado_terminado == 0)
                //update del controlador orden de compra
                control.updateOrdenEntregada(id_orden);

        }

        private string fillGrid(int idFactura) //devuelve el idSupplier
        {
            PurchaseOrderDetailController controlOrderRm = new PurchaseOrderDetailController();
            DataTable orderList = controlOrderRm.getData();

            string idOrder = comboBox_OC.SelectedItem.ToString();
            string idRM, idSup, quantity, name, quantityLeft;
            idRM = quantity = name = idSup = quantityLeft = "";
            bool encontre_fac = false;

            dataGridView_orders.Rows.Clear();
            dataGridView_details.Rows.Clear();

            for (int i = 0; i < orderList.Rows.Count; i++)
            {
                if (string.Compare(idOrder, orderList.Rows[i]["id_order"].ToString()) == 0 &&
                    orderList.Rows[i]["status"].ToString()!= "Inactivo")
                {
                    encontre_fac = true;
                    idRM = orderList.Rows[i]["id_raw_material"].ToString();
                    name = giveme_rawName(idRM);
                    idSup = orderList.Rows[i]["id_suppliers"].ToString();
                    if (orderList.Rows[i]["status"].ToString() == "Enviado")//llenar el datagrid de detalle de la orden
                    {
  
                        if (canIStoreThisMaterial(idRM))
                        {                      
                            quantity = orderList.Rows[i]["quantity"].ToString();                   
                            quantityLeft = howMuchCanIMove(idOrder, idRM);                            
                            if (string.Compare(quantityLeft, "falso") == 0)//si no esta en la tabla su valor es igual a quantity
                                quantityLeft = quantity;
                            if (int.Parse(quantityLeft) == 0)//si ya no hay mas por mover verifica si actualiza la orden total a entregada
                            {
                                //la linea pasa a entregada y verifica el total
                                actualizaLinea(orderList.Rows[i]["id_detail"].ToString(),idFactura);
                                actualizaOrdenes();
                                //orderList = controlOrderRm.getData();

                            }
                            dataGridView_details.Rows.Add(name, orderList.Rows[i]["status"].ToString());
                            dataGridView_orders.Rows.Add(idRM, name, quantity, quantityLeft, "", false,orderList.Rows[i]["id_detail"].ToString());
                        }

                    }
                    else
                    {
                        if (orderList.Rows[i]["status"].ToString() == "Facturado" || orderList.Rows[i]["status"].ToString() == "Entregado")
                        {
                            dataGridView_details.Rows.Add(name, orderList.Rows[i]["status"].ToString());
                        }
                    }

                }
            }
            if (encontre_fac == false)
                MessageBox.Show("No se encontró la factura, por favor revise el número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return idSup;
        }

        public void updateInStockDocument(string idFactura, string idRm, int cantidad)
        {
            StockDocumentController control = new StockDocumentController();

            string aux = howMuchCanIMove(idFactura, idRm);
            if (string.Compare(aux, "falso") == 0)//no existe el registro, entonces agregar la fila
            {
                //insert
                control.insertData(idFactura, idRm, cantidad, dateTimePicker1.Value.ToShortDateString());
            }else//si existe el registro
            {
                int nuevo = int.Parse(aux) - cantidad;
                //update
                control.updateStock(idFactura, idRm, cantidad, dateTimePicker1.Value.ToShortDateString());
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int aux_idOc;
            string idSup = "";

            dataGridView_orders.Rows.Clear();
            if (int.TryParse(comboBox_OC.SelectedItem.ToString(),out aux_idOc))
            {
                //fill grid
                idSup = fillGrid(0);
                string nameSup = giveme_supplierName(idSup);
                textBox_supplier.Text = nameSup;
           }
            else
                MessageBox.Show("Por favor ingrese un numero de factura válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int maxInWarehouse(string idWh, string idRm, ref int stockFisico,ref int stockLogico)
        {
            //stox maximo - cantidadFisica
            int rpta = 0;
            RawMaterialWarehouseController control = new RawMaterialWarehouseController();
            DataTable table = control.getData();
            for(int i = 0; i < table.Rows.Count; i++)
            {
                if(string.Compare(idWh,table.Rows[i]["idWarehouse"].ToString())==0 &&
                    string.Compare(idRm, table.Rows[i]["idRawMaterial"].ToString()) == 0 &&
                    string.Compare("Activo", table.Rows[i]["state"].ToString()) == 0)
                {
                    stockFisico = int.Parse(table.Rows[i]["currentStock"].ToString());
                    stockLogico = int.Parse(table.Rows[i]["virtualStock"].ToString());
                    rpta = int.Parse(table.Rows[i]["maximunStock"].ToString())-stockFisico;
                    break;
                }
            }
            return rpta;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cantidad_ingresar=0;
            int cant_necesaria;
            int idFactura;
            for(int i = 0; i < dataGridView_orders.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView_orders.Rows[i].Cells[6].Value))
                {
                    if (int.TryParse(dataGridView_orders.Rows[i].Cells[4].Value.ToString(), out cantidad_ingresar))//es un valor numerico
                    {
                        if (int.Parse(dataGridView_orders.Rows[i].Cells[4].Value.ToString()) > 0)
                        {
                            if (int.TryParse(dataGridView_orders.Rows[i].Cells[5].Value.ToString(), out idFactura))
                            {
                                idFactura = int.Parse(dataGridView_orders.Rows[i].Cells[5].Value.ToString());

                                if (idFactura > 0)
                                {
                                    cantidad_ingresar = int.Parse(dataGridView_orders.Rows[i].Cells[4].Value.ToString());
                                    cant_necesaria = int.Parse(dataGridView_orders.Rows[i].Cells[3].Value.ToString());
                                    if (cant_necesaria >= cantidad_ingresar)
                                    {
                                        int stockFisico = 0;
                                        int stockLogico = 0;
                                        int cantMax = maxInWarehouse(idWh, dataGridView_orders.Rows[i].Cells[0].Value.ToString(), ref stockFisico, ref stockLogico);
                                        if (cantMax >= cantidad_ingresar)
                                        {
                                            //AUMENTAR
                                            RawMaterialWarehouseController controlRmW = new RawMaterialWarehouseController();
                                            ProductionMovementMovementController controlMovement = new ProductionMovementMovementController();

                                            //agregar en RM-WH
                                            controlRmW.updateStock(idWh, dataGridView_orders.Rows[i].Cells[0].Value.ToString(), stockLogico + cantidad_ingresar, stockFisico + cantidad_ingresar);
                                            //agregar en StockDocument
                                            updateInStockDocument(comboBox_OC.SelectedItem.ToString(), dataGridView_orders.Rows[i].Cells[0].Value.ToString(), cant_necesaria - cantidad_ingresar);
                                            //agregar en Movement
                                            controlMovement.insertPurchaseRmMovement(comboBox_OC.SelectedItem.ToString(), idWh, dateTimePicker1.Value.ToShortDateString(), int.Parse(dataGridView_orders.Rows[i].Cells[0].Value.ToString()), cantidad_ingresar);

                                            MessageBox.Show("Se guardaron los cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            fillGrid(idFactura);

                                        }
                                        else
                                            MessageBox.Show("El almacen no tiene espacio necesario para ese elemento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                        MessageBox.Show("La cantidad excede lo necesario, por favor ingrese otro valor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                                else
                                    MessageBox.Show("El numero de Factura no puede ser cero, por favor ingrese otro valor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                                MessageBox.Show("Debe ingresar un numero de factura válida, por favor ingrese otro valor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                        }
                        else
                            MessageBox.Show("El valor a mover debe ser mayor a cero, por favor ingrese otro valor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                        MessageBox.Show("Cantidad no válida, por favor verifique el valor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBox_OC_SelectedIndexChanged(object sender, EventArgs e)
        {
            int aux_idOc;
            string idSup = "";

            dataGridView_orders.Rows.Clear();
            //TODO que solo salgan las listas "Enviadas"
            if (int.TryParse(comboBox_OC.SelectedItem.ToString(), out aux_idOc))
            {
                //fill grid
                idSup = fillGrid(0);
                string nameSup = giveme_supplierName(idSup);
                textBox_supplier.Text = nameSup;
            }
            else
                MessageBox.Show("Por favor ingrese un numero de factura válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
