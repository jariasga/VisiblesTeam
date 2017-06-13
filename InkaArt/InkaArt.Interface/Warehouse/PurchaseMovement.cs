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
            PurchaseOrderDetailController controlOrderRm = new PurchaseOrderDetailController();
            DataTable orderList = controlOrderRm.getData();

            string idOrder = textBox_idFactura.Text;
            string idRM,idSup, quantity, name,quantityLeft;
            idRM = quantity = name =idSup =quantityLeft= "";

            dataGridView_orders.Rows.Clear();

            for(int i = 0; i < orderList.Rows.Count; i++)
            {
                if (string.Compare(idOrder, orderList.Rows[i]["id_factura"].ToString()) == 0)
                {
                    idRM = orderList.Rows[i]["id_raw_material"].ToString();
                    if (canIStoreThisMaterial(idRM))
                    {
                        name = giveme_rawName(idRM);
                        quantity = orderList.Rows[i]["quantity"].ToString();
                        quantityLeft = howMuchCanIMove(idOrder, idRM);
                        idSup = orderList.Rows[i]["id_suppliers"].ToString();
                        if (string.Compare(quantityLeft, "falso") == 0)//si no esta en la tabla su valor es igual a quantity
                            quantityLeft = quantity;

                        dataGridView_orders.Rows.Add(idRM,name,quantity,quantityLeft,"",false);
                    }     
                }
            }
            string nameSup = giveme_supplierName(idSup);
            textBox_supplier.Text = nameSup;

            
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
            for(int i = 0; i < dataGridView_orders.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView_orders.Rows[i].Cells[5].Value))
                {
                    if (int.TryParse(dataGridView_orders.Rows[i].Cells[4].Value.ToString(), out cantidad_ingresar))//es un valor numerico
                    {
                        cantidad_ingresar = int.Parse(dataGridView_orders.Rows[i].Cells[4].Value.ToString());
                        cant_necesaria = int.Parse(dataGridView_orders.Rows[i].Cells[3].Value.ToString());
                        if (cant_necesaria >= cantidad_ingresar)
                        {
                            int stockFisico=0;
                            int stockLogico = 0;
                            int cantMax = maxInWarehouse(idWh, dataGridView_orders.Rows[i].Cells[0].Value.ToString(),ref stockFisico,ref stockLogico);
                            if (cantMax >= cantidad_ingresar)
                            {
                                //AUMENTAR
                                RawMaterialWarehouseController controlRmW = new RawMaterialWarehouseController();
                                ProductionMovementMovementController controlMovement = new ProductionMovementMovementController();

                                //agregar en RM-WH
                                controlRmW.updateStock(idWh, dataGridView_orders.Rows[i].Cells[0].Value.ToString(), stockLogico + cantidad_ingresar, stockFisico+ cantidad_ingresar);
                                //agregar en StockDocument
                                updateInStockDocument(textBox_idFactura.Text, dataGridView_orders.Rows[i].Cells[0].Value.ToString(),cant_necesaria- cantidad_ingresar);
                                //agregar en Movement
                                controlMovement.insertPurchaseRmMovement(textBox_idFactura.Text, idWh, dateTimePicker1.Value.ToShortDateString());


                            }
                            else
                                MessageBox.Show("el almacen no tiene espacio necesario para ese elemento.");

                        }
                        else
                            MessageBox.Show("la cantidad excede lo necesario.");
                    }
                    else
                        MessageBox.Show("cantidad no valida.");
                }
            }
        }
    }
}
