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
                    string.Compare("materia prima", stockDocList.Rows[i]["product_type"].ToString()) == 0)
                {
                    respuesta = stockDocList.Rows[i]["product_stock"].ToString(); 
                    break;
                }

            return respuesta;
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
    }
}
