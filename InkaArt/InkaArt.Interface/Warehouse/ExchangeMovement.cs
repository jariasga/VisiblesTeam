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
    public partial class ExchangeMovement : Form
    {
        string typeMovement = "";
        private ProductionItemWarehouseMovementController productionItemWarehouseMovementController = new ProductionItemWarehouseMovementController();
        private MovementController movementController = new MovementController();

        public ExchangeMovement()
        {
            InitializeComponent();
        }

        public ExchangeMovement(string idWarehouse, string nameWarehouse, string typeMovement)
        {
            this.typeMovement = typeMovement;
            InitializeComponent();
            textBox6.Text = nameWarehouse;
            textBox5.Text = idWarehouse;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form new_warehouse_window = new WarehouseSearchMovement(textBox1, textBox2);
            new_warehouse_window.Show();
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            //Form new_warehouse_window = new Form1(ref textBox1,ref textBox2,ref textBox4);
            Form new_warehouse_window = new ExchangeItem(textBox7, textBox3, textBox4, textBox1.Text, textBox5.Text,textBox8);
            new_warehouse_window.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cantMov = Convert.ToInt32(textBox8.Text);
            int idWarehouseOrigin = Convert.ToInt32(textBox5.Text);
            int idWarehouseDestiny = Convert.ToInt32(textBox1.Text);
            int idItem = Convert.ToInt32(textBox7.Text);
            string itemType = textBox7.Text;

            int exito2 = 0,exito3=0,exito=0;

            //Verificar si se puede realizar el movimiento
            exito2 = movementController.verifyMovement(idItem, idWarehouseOrigin, cantMov, -1, typeMovement, "Rotura", "Producto", "");
            if(exito2 == -1)
            {
                MessageBox.Show("No se pudo completar el movimiento.");
            }
            exito3 = movementController.verifyMovement(idItem, idWarehouseDestiny, cantMov, -1, typeMovement, "Hallazgo", "Producto", "");
            if (exito3 == -1)
            {
                MessageBox.Show("No se pudo completar el movimiento.");
            }
            //Aumentar stock físico y lógico del almacén - CORREGIR- PRESENTA ERRORES EN EL UPDATE
            //Se simula como una entrada y salida de un almacén a otro
            movementController.updateProductWarehouse(idItem, idWarehouseOrigin, cantMov, "Entrada", "Producto");
            movementController.updateProductWarehouse(idItem, idWarehouseDestiny, cantMov, "Salida", "Producto");

            if (exito2 == 1 && exito3 == 1)
            {
                int movemenType = 1; //Indica que es una entrada/salida
                int movementReason = 5;//Indica que es un movimiento por traslado entre almacenes
                int documentTypes = 5;//Indica que no hay documento relacionado porque es una transferencia
                int idDocument = -1;//No se genera documento porque es una transferencia
                int productType = 1;//0:materia prima | 1:producto
                int isExchange = -1;//-1:No es intercambio | otro:es intercambio
                //Grabar movimiento
                movementController.insertMovement(idDocument, movemenType, idWarehouseOrigin, movementReason, documentTypes, idWarehouseDestiny, idItem, cantMov, productType);
                movementController.insertMovement(idDocument, movemenType, idWarehouseOrigin, movementReason, documentTypes, idWarehouseDestiny, idItem, cantMov, productType);
                //productionItemWarehouseMovementController.insertMovement(idDocument, movemenType, idWarehouseOrigin, movementReason, documentTypes, idWarehouseDestiny, idItem,cantMov,productType);
                exito++;
            }
            if (exito > 0)
            {
                MessageBox.Show("" + exito + " Operaciones realizadas con éxito.");
                this.Close();
            }

        }
    }
}
