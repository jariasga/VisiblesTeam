using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Sales;
using Npgsql;
using InkaArt.Business.Warehouse;

namespace InkaArt.Interface.Warehouse
{
    public partial class SaleMovementcs : Form
    {
        public SaleMovementcs()
        {
            InitializeComponent();
        }

        string nameWarehouseOrigin = "";
        string idWarehouesOrigin = "";
        string typeMovement = "";

        public SaleMovementcs(string idWarehouse, string nameWarehouse, string typeMovement)
        {
            this.idWarehouesOrigin = idWarehouse;
            this.nameWarehouseOrigin = nameWarehouse;
            this.typeMovement = typeMovement;
            InitializeComponent();
            textBox6.Text = nameWarehouse;
            textBox5.Text = idWarehouse;

        }


        /*************************************************/
        /*************************************************/
        /*************************************************/


        private ProductionMovementMovementController productionMovementMovementController = new ProductionMovementMovementController();
        private ProductionItemMovementController productionItemMovementController = new ProductionItemMovementController();
        private ProductionItemWarehouseMovementController productionItemWarehouseMovementController = new ProductionItemWarehouseMovementController();
        private MovementController movementController = new MovementController();

        //private void button_create_Click(object sender, EventArgs e)
        //{
        //    //Form new_warehouse_window = new Form1(ref textBox1,ref textBox2,ref textBox4);
        //    Form new_warehouse_window = new Form1(textBox1, textBox2, textBox4);
        //    new_warehouse_window.Show();
        //}

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
            int idProd = 0, idWare = 0, idPedido = 0, exito2 = 0;
            OrderController classFacture = new OrderController();
            string nameProd = "";
            int[] arrIdProd = new int[500];
            int[] arrCantProd = new int[500];
            int countArr = 0;

            int cantMov = 0, maxMov = 0, exito = 0;
            int numRows = 0;
            try
            {
                idWare = Convert.ToInt32(textBox5.Text);
            }
            catch
            {
                MessageBox.Show("Favor de ingresar un valor entero para el almacén");
                return;
            }
            if (idWare < 0)
            {
                MessageBox.Show("Favor de ingresar un valor válido para el almacén");
                return;
            }
            try
            {
                idPedido = Convert.ToInt32(textBox3.Text);
            }
            catch
            {
                MessageBox.Show("Favor de ingresar un valor entero para el número de lote de producción");
                return;
            }
            if (idPedido < 0)
            {
                MessageBox.Show("Favor de ingresar un valor válido para el número de pedido");
                return;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[6].Value);

                if (s == true)
                {
                    idProd = Convert.ToInt32(row.Cells[0].Value);
                    nameProd = Convert.ToString(row.Cells[1].Value);
                    try
                    {
                        cantMov = Convert.ToInt32(row.Cells[5].Value);
                    }
                    catch
                    {
                        MessageBox.Show("Favor de ingresar un valor entero para el número de productos a mover. Linea: " + (numRows + 1));
                        return;
                    }
                    if (cantMov < 0)
                    {
                        MessageBox.Show("Favor de ingresar un valor válido para la cantidad a mover");
                        continue;
                    }

                    maxMov = Convert.ToInt32(row.Cells[4].Value);

                    exito2 = movementController.verifyMovement(idProd, idWare, cantMov, idPedido, typeMovement, "Venta", "Producto","Venta");

                    if (exito2 == 1)
                    {
                        //Aumentar stock físico y lógico del almacén 
                        movementController.updateProductWarehouse(idProd, idWare, cantMov, typeMovement, "Producto");
                        //Aumentar stock físico y lógico del producto
                        movementController.updateProductStock(idProd, cantMov, typeMovement,"Venta");
                        //Actualizar el stock que queda para mover
                        movementController.updateStockDocument(idPedido, idProd, maxMov, cantMov, "Venta");

                        int movemenType = 13; //Indica que es una salida
                        int movementReason = 2;//Indica que es un movimiento por venta
                        int documentTypes = 4;//Indica que el documento relacionado es un número de pedido
                        int productType = 1;//0:materia prima | 1:producto
                        int isExchange = -1;//-1:No es intercambio | otro:es intercambio
                                            //Grabar movimiento
                        movementController.insertMovement(idPedido, movemenType, idWare, movementReason, documentTypes, isExchange, idProd,cantMov, productType);
                        arrIdProd[countArr] = idProd;
                        arrCantProd[countArr] = cantMov;
                        countArr++;
                        exito++;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo completar el movimiento para la línea: " + (numRows + 1) + ".");
                    }
                }
                numRows++;
            }
            movementController.updateOrder(idPedido);
            //cantMov = Convert.ToInt32(numericUpDown2.Value);
            if (exito > 0)
            {
                MessageBox.Show("" + exito + " Operaciones realizadas con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo realizar ningún movimiento...");
            }
        }

        private void populateDataGridLote(DataTable listList)
        {
            foreach (DataRow row in listList.Rows)
            {
                dataGridView1.Rows.Add(row["idProduct"], row["name"], "Producto");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            NpgsqlDataReader datos;
            string id = "";
            try
            {
                Convert.ToInt32(textBox3.Text);
                id = textBox3.Text;
            }
            catch
            {
                MessageBox.Show("Favor de ingresar un valor entero para el número de lote de producción");
                return;
            }

            datos = productionItemMovementController.getProductLote(id, textBox5.Text);
            int rowIndex = 0;

            //Limpiamos el datagridview
            this.dataGridView1.Rows.Clear();

            //Muestra los datos en el gridview
            while (datos.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = datos[0];
                row.Cells[1].Value = datos[1];
                row.Cells[2].Value = datos[2];
                row.Cells[3].Value = datos[3];
                dataGridView1.Rows.Add(row);
                rowIndex++;
            }
            productionItemMovementController.closeConnection();

        }















        /*************************************************/
        /*************************************************/
        /*************************************************/


        //private void button2_Click(object sender, EventArgs e)
        //{

        //}


        private void button3_Click(object sender, EventArgs e)
        {
            NpgsqlDataReader datos;
            string id = "";
            try
            {
                Convert.ToInt32(textBox3.Text);
                id = textBox3.Text;
            }
            catch
            {
                MessageBox.Show("Favor de ingresar un valor entero para el número de orden de pedido");
                return;
            }

            datos = productionItemMovementController.getProductOrder(id, textBox5.Text);
            int rowIndex = 0;

            //Limpiamos el datagridview
            this.dataGridView1.Rows.Clear();

            //Muestra los datos en el gridview
            while (datos.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = datos[0];
                row.Cells[1].Value = datos[1];
                row.Cells[2].Value = datos[2];
                row.Cells[3].Value = datos[3];
                row.Cells[4].Value = datos[4];
                dataGridView1.Rows.Add(row);
                rowIndex++;
            }
            productionItemMovementController.closeConnection();
            if (rowIndex == 0)
            {
                MessageBox.Show("No hay productos que este almacén pueda devolver para la orden de pedido ingresada.");
                return;
            }
        }


        //private void buttonDelete_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
    }
}
