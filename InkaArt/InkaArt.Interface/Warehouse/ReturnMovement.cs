using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using InkaArt.Business.Warehouse;
using InkaArt.Business.Sales;

namespace InkaArt.Interface.Warehouse
{
    public partial class ReturnMovement : Form
    {
        string typeMovement = "";

        string idWarehouesOrigin = "";
        string nameWarehouseOrigin = "";
        private ProductionItemMovementController productionItemMovementController = new ProductionItemMovementController();
        private ProductionItemWarehouseMovementController productionItemWarehouseMovementController = new ProductionItemWarehouseMovementController();


        public ReturnMovement()
        {
            InitializeComponent();
        }

        public ReturnMovement(string idWarehouse, string nameWarehouse, string typeMovement)
        {
            this.idWarehouesOrigin = idWarehouse;
            this.nameWarehouseOrigin = nameWarehouse;
            this.typeMovement = typeMovement;
            InitializeComponent();
            textBox6.Text = nameWarehouse;
            textBox5.Text = idWarehouse;
        }


        private int validarEntero(string entero)
        {
            int enteroNuevo = -1;
            try
            {
                enteroNuevo = Convert.ToInt32(entero);
            }
            catch
            {
                MessageBox.Show("Por favor ingrese un valor entero y positivo para el número de nota de crédito");
                return -1;
            }
            if (enteroNuevo < 0)
            {
                MessageBox.Show("Por favor ingrese un valor positivo para la nota de crédito");
                return -1;
            }
            return enteroNuevo;
        }

        private int hallaPorDevolver(string idProduct, int cantDev)
        {
            int retornar = cantDev;
            StockDocumentController control = new StockDocumentController();
            DataTable stockList = control.getData();

            for(int i = 0; i < stockList.Rows.Count; i++)
            {
                if(stockList.Rows[i]["idDocument"].ToString() == textBox3.Text 
                    && stockList.Rows[i]["documentType"].ToString() == "DEVOLUCION"
                    && stockList.Rows[i]["product_id"].ToString()==idProduct
                    && stockList.Rows[i]["product_type"].ToString() == "producto")
                {
                    retornar = int.Parse(stockList.Rows[i]["product_stock"].ToString());
                    break;
                }
            }

            return retornar;
        }

        private void updateInsertDevueltos(string idProduct, int cantADev, int cantDev)
        {
            StockDocumentController control = new StockDocumentController();
            DataTable stockList = control.getData();

            int encontrado = 0;
            for (int i = 0; i < stockList.Rows.Count; i++)
            {
                if (stockList.Rows[i]["idDocument"].ToString() == textBox3.Text
                    && stockList.Rows[i]["documentType"].ToString() == "DEVOLUCION"
                    && stockList.Rows[i]["product_id"].ToString() == idProduct
                    && stockList.Rows[i]["product_type"].ToString() == "producto")
                {
                    //update
                    control.updateReturn(textBox3.Text, idProduct, cantDev - cantADev);
                    encontrado = 1;
                    break;
                }
            }
            if(encontrado == 0)//insertar por primera vez
            {
                //insert
                control.insertReturn(textBox3.Text, idProduct, cantDev - cantADev);
                
            }

        }

        private void actualizaDocumentos()
        {
            OrderController controlOrder = new OrderController();
            //revisar
            DataTable orderList = controlOrder.GetOrders();

            //for del datagrid
            int actualizar = 0;
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
                if (int.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString()) != 0)
                {
                    actualizar = 1;
                    break;
                }
            if(actualizar ==0)
                controlOrder.updateReturn(textBox3.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numNota = 0;
            string notaCredStr;
            NpgsqlDataReader datos;

            //Validación para que el número de nota de crédito sea entero y positivo
            notaCredStr = textBox3.Text;
            if ((numNota = validarEntero(notaCredStr)) == -1)
            {
                return;
            }

            //Buscar la nota de crédito en Order
            datos = productionItemMovementController.getQueryCreditNote(idWarehouesOrigin, numNota);
            int rowIndex = 0;

            //Limpiamos el datagridview
            this.dataGridView1.Rows.Clear();

            //Muestra los datos en el gridview
            while (datos.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = datos[0];//idProduct
                row.Cells[1].Value = datos[1];//Nombre
                row.Cells[2].Value = datos[2];//Cantidad total a devolver
                row.Cells[3].Value = datos[3];//Stock en almacén
                row.Cells[4].Value = datos[4];//MinimunStock
                row.Cells[5].Value = datos[5];//MaximunStock
                row.Cells[6].Value = "";
                //REVISAR
                row.Cells[7].Value = hallaPorDevolver(datos[0].ToString(), int.Parse(datos[2].ToString()));
                row.Cells[8].Value = false;   
                //TODO
                //verificacion de cells 7 si es 0 actualizar el estado de la devolucion
                dataGridView1.Rows.Add(row);
                rowIndex++;
            }
            productionItemMovementController.closeConnection();
            if (rowIndex == 0)
            {
                MessageBox.Show("No hay productos que este almacén pueda devolver para la nota de crédito ingresada.");
                return;
            }
            actualizaDocumentos();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idProd = 0, cantMov = 0, numRows = 0, maxMov = 0, exito = 0, numRows2 = 0, availableToMove = 0, idReturn=0;
            string nameProd = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[8].Value);

                if (s == true)
                {
                        idProd = Convert.ToInt32(row.Cells[0].Value);
                        nameProd = Convert.ToString(row.Cells[1].Value);
                        try
                        {
                            cantMov = Convert.ToInt32(row.Cells[6].Value);
                        }
                        catch
                        {
                            MessageBox.Show("Favor de ingresar un valor entero para el número de productos a mover. Linea: " + (numRows + 1));
                            return;
                        }
                        if (cantMov < 0)
                        {
                            MessageBox.Show("Línea :" + numRows + " Favor de ingresar un valor válido para la cantidad a mover");
                            continue;
                        }
                        maxMov = Convert.ToInt32(row.Cells[2].Value);
                        try
                        {
                            idReturn = Convert.ToInt32(textBox3.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Favor de ingresar un valor entero para el número de lote de producción");
                            return;
                        }
                        if (idReturn < 0)
                        {
                            MessageBox.Show("Favor de ingresar un valor válido para el número de pedido");
                            return;
                        }
                        if (cantMov <= maxMov && cantMov <= int.Parse(row.Cells[7].ToString()))
                        {
                            //Se valida que exista la materia prima, el almacén, también que exista la relación materiaPrima-almacén
                            int intIdWarehouse = 0;
                            intIdWarehouse = Convert.ToInt32(idWarehouesOrigin);

                            availableToMove = productionItemMovementController.availableReturn(idProd, intIdWarehouse);
                            if (availableToMove != 1)
                            {
                                return;
                            }

                            //Aumentar stock físico y lógico del almacén - CORREGIR- PRESENTA ERRORES EN EL UPDATE
                            //exito = productionItemWarehouseMovementController.updateDataProduct(idProd, intIdWarehouse, cantMov, "Entrada", "OK");

                            //mi forma de aumentar stock logico y fisico
                            ProductWarehouseController controlpwh = new ProductWarehouseController();
                            DataTable pwhList = controlpwh.getData();
                            controlpwh.updateOnlyPhStock(intIdWarehouse.ToString(), idProd.ToString(), int.Parse(row.Cells[3].Value.ToString()) + cantMov);
                            //update o insert en la tabla stockDocument
                            updateInsertDevueltos(idProd.ToString(), cantMov, int.Parse(row.Cells[7].Value.ToString()));

                            //DONE
                            //añadir en la tabla movimientos
                            ProductionMovementMovementController controlM = new ProductionMovementMovementController();
                            controlM.insertMovDev(int.Parse(textBox3.Text), 2, intIdWarehouse, 8, 8, idProd.ToString(), 1, cantMov);


                            if (exito == 1)
                            {
                                //Aumentar stock físico y lógico del producto
                                productionItemMovementController.updateData(idProd, cantMov, typeMovement);
                                //Grabar movimiento
                                int movemenType = 2; //Indica que es una entrada
                                int movementReason = 8;//Indica que es un movimiento por producción
                                int documentTypes = 8;//Indica que no tiene un documento relacionado para validarlo
                                int productType = 1;//0:materia prima | 1:producto
                                int isExchange = -1;//-1:No es intercambio | otro:es intercambio
                                productionItemWarehouseMovementController.insertMovement(idReturn, movemenType, Convert.ToInt32(idWarehouesOrigin), movementReason, documentTypes, isExchange, idProd, cantMov, productType);
                                numRows2++;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error en la fila " + numRows + ": Para el producto:" + nameProd + ". Solo se puede quitar " + maxMov + " items.");
                        }

                }
                numRows++;
            }
            //productionItemMovementController.sacarMateria();
            MessageBox.Show("Se actualizaron: " + numRows2 + " Registros.");
            this.Close();
        }
    }
}
