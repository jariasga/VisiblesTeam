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

namespace InkaArt.Interface.Warehouse
{
    public partial class ProductionMovement : Form
    {
        string nameWarehouseOrigin = "";
        string id_warehouse= "";
        string typeMovement = "";

        private ProductionMovementMovementController productionMovementMovementController = new ProductionMovementMovementController();
        private ProductionItemMovementController productionItemMovementController = new ProductionItemMovementController();
        private ProductionItemWarehouseMovementController productionItemWarehouseMovementController = new ProductionItemWarehouseMovementController();
        private MovementController movementController = new MovementController();

        public ProductionMovement()
        {
            InitializeComponent();
        }

        public ProductionMovement(string idWarehouse,string nameWarehouse,string typeMovement)
        {
            InitializeComponent();
            
            this.id_warehouse = idWarehouse;
            this.nameWarehouseOrigin = nameWarehouse;
            this.typeMovement = typeMovement;
            
            text_name_warehouse.Text = nameWarehouse;
            text_id_warehouse.Text = idWarehouse;
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
            int idProd = 0, idWare = 0, idLote = 0,exito2=0;
            string nameProd="";

            int cantMov = 0, maxMov=0,exito=0;
            int numRows = 0;
            try {
                idWare = Convert.ToInt32(text_id_warehouse.Text);
            }
            catch
            {
                MessageBox.Show("Favor de ingresar un valor entero para el almacén");
                return;
            }
            if(idWare < 0)
            {
                MessageBox.Show("Favor de ingresar un valor válido para el almacén");
                return;
            }
            try
            {
                idLote = Convert.ToInt32(text_lote.Text);
            }
            catch
            {
                MessageBox.Show("Favor de ingresar un valor entero para el número de lote de producción");
                return;
            }
            if (idLote < 0)
            {
                MessageBox.Show("Favor de ingresar un valor válido para el lote");
                return;
            }
            //Fin de validaciones

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[7].Value);//Verifica que línea se ha marcado con un check

                if (s == true)
                {
                    idProd = Convert.ToInt32(row.Cells[1].Value);//No se valida porque viene de la base de datos
                    nameProd = Convert.ToString(row.Cells[2].Value);//No se valida porque viene de la base de datos
                    try
                    {
                        cantMov = Convert.ToInt32(row.Cells[6].Value);
                    }
                    catch
                    {
                        MessageBox.Show("Favor de ingresar un valor entero para el número de productos a mover. Linea: " + (numRows+1));
                        return;
                    }
                    if (cantMov < 0)
                    {
                        MessageBox.Show("Línea :" + numRows + " Favor de ingresar un valor válido para la cantidad a mover");
                        continue;
                    }
                    maxMov = Convert.ToInt32(row.Cells[5].Value);

                    exito2 = movementController.verifyMovement(idProd, idWare, cantMov, idLote, typeMovement, "Produccion", "Producto", "LOTE");

                    if (exito2 == 1)
                    {
                        //Aumentar stock físico y lógico del almacén - CORREGIR- PRESENTA ERRORES EN EL UPDATE
                        movementController.updateProductWarehouse(idProd, idWare, cantMov, typeMovement, "Producto");
                        //Aumentar stock físico y lógico del producto
                        movementController.updateProductStock(idProd, cantMov, typeMovement, "Produccion");
                        //Actualizar el stock por mover
                        movementController.updateStockDocument(idLote, idProd, maxMov, cantMov, "LOTE");
                        //Grabar movimiento
                        int movemenType = 2; //Indica que es una entrada
                        int movementReason = 3;//Indica que es un movimiento por producción
                        int documentTypes = 3;//Indica que el documento relacionado es un número de lote
                        int productType = 1;//0:materia prima | 1:producto
                        int isExchange = -1;//-1:No es intercambio | otro:es intercambio
                        movementController.insertMovement(idLote, movemenType, idWare, movementReason, documentTypes, isExchange, idProd, cantMov, productType);
                        exito++;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo completar el movimiento para la línea: " + (numRows + 1) + ".");
                    }
                }
                numRows++;
            }

            //cantMov = Convert.ToInt32(numericUpDown2.Value);
            if (exito > 0) {
                MessageBox.Show("" + exito + " Operaciones realizadas con éxito.");
            }
            else
            {
                MessageBox.Show("No se pudo realizar ningún movimiento...");
            }
        }
        
        private void buttonSearchClick(object sender, EventArgs e)
        {            
            NpgsqlDataReader datos;

            int id_lote;

            if (!int.TryParse(text_lote.Text, out id_lote) || id_lote <= 0)
            {
                MessageBox.Show("Favor de ingresar un valor entero y existente para el número de lote");
                return;
            }
            
            datos = movementController.getProductStock(this.id_warehouse, text_lote.Text);
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
                row.Cells[5].Value = datos[5];
                dataGridView1.Rows.Add(row);
                rowIndex++;
            }
            if(rowIndex == 0)
            {
                MessageBox.Show("El lote ingresado no tiene registros.");
            }            

        }
    }
}
