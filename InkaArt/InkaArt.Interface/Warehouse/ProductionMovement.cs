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
    public partial class ProductionMovement : Form
    {
        string nameWarehouseOrigin = "";
        string idWarehouesOrigin= "";
        string typeMovement = "";

        private ProductionMovementMovementController productionMovementMovementController = new ProductionMovementMovementController();
        private ProductionItemMovementController productionItemMovementController = new ProductionItemMovementController();
        private ProductionItemWarehouseMovementController productionItemWarehouseMovementController = new ProductionItemWarehouseMovementController();

        public ProductionMovement()
        {
            InitializeComponent();
        }

        public ProductionMovement(string idWarehouse,string nameWarehouse,string typeMovement)
        {
            this.idWarehouesOrigin = idWarehouse;
            this.nameWarehouseOrigin = nameWarehouse;
            this.typeMovement = typeMovement;
            InitializeComponent();
            textBox6.Text = nameWarehouse;
            textBox5.Text = idWarehouse;
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            //Form new_warehouse_window = new Form1(ref textBox1,ref textBox2,ref textBox4);
            Form new_warehouse_window = new Form1(textBox1, textBox2, textBox4);
            new_warehouse_window.Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Botón de aceptar para crear el movimiento
        //AGREGAR: Debería registrarse el lote de producción de donde viene el producto.
        private void button2_Click(object sender, EventArgs e)
        {
            string idProd="", idWare="";
            int cantMov = 0;

            idProd = textBox1.Text;
            idWare = textBox5.Text;
            cantMov = Convert.ToInt32(numericUpDown2.Value);
            //Aumentar stock físico y lógico del almacén - CORREGIR- PRESENTA ERRORES EN EL UPDATE
            //productionItemWarehouseMovementController.updateData(idProd, idWare, cantMov, typeMovement);
            //Aumentar stock físico y lógico del producto
            productionItemMovementController.updateData(idProd, cantMov, typeMovement);
            //Grabar movimiento

            MessageBox.Show("Operación realizada con éxito");
            this.Close();
        }
    }
}
