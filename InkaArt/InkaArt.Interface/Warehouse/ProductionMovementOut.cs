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
    public partial class ProductionMovementOut : Form
    {
        string idWarehouesOrigin = "";
        string nameWarehouseOrigin = "";
        string typeMovement = "";
        private ProductionItemMovementController productionItemMovementController = new ProductionItemMovementController();
        private ProductionItemWarehouseMovementController productionItemWarehouseMovementController = new ProductionItemWarehouseMovementController();
        private MovementController movementController = new MovementController();

        public ProductionMovementOut()
        {
            InitializeComponent();
        }

        public ProductionMovementOut(string idWarehouse, string nameWarehouse, string typeMovement)
        {
            this.idWarehouesOrigin = idWarehouse;
            this.nameWarehouseOrigin = nameWarehouse;
            this.typeMovement = typeMovement;
            InitializeComponent();
            textBox6.Text = nameWarehouse;
            textBox5.Text = idWarehouse;
        }

        private void ProductionMovementOut_Load(object sender, EventArgs e)
        {

            NpgsqlDataReader datos;
            string id = "";
            try
            {
                Convert.ToInt32(textBox5.Text);
                id = textBox5.Text;
            }
            catch
            {
                MessageBox.Show("Favor de ingresar un valor entero para el número de lote de producción");
                return;
            }

            datos = productionItemMovementController.getQuery(idWarehouesOrigin);
            int rowIndex = 0;

            //Limpiamos el datagridview
            this.dataGridView1.Rows.Clear();

            //Muestra los datos en el gridview
            while (datos.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = datos[0];//idRawMaterial
                row.Cells[1].Value = datos[1];//Nombre
                row.Cells[2].Value = datos[2];//CurrentStock
                row.Cells[3].Value = datos[3];//MinimunStock
                row.Cells[4].Value = datos[4];//MaximunStock
                dataGridView1.Rows.Add(row);
                rowIndex++;
            }
            if(rowIndex == 0)
            {
                MessageBox.Show("No hay materia prima que mostrar para el almacén ingresado.");
                return;
            }

            productionItemMovementController.closeConnection();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idProd = 0,cantMov=0,numRows=0,maxMov=0,exito=0, numRows2=0, availableToMove=0;
            string nameProd = "";
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
                        MessageBox.Show("Línea :" + numRows + " Favor de ingresar un valor válido para la cantidad a mover");
                        continue;
                    }
                    maxMov = Convert.ToInt32(row.Cells[2].Value);
                    int intIdWarehouse = 0;
                    intIdWarehouse = Convert.ToInt32(idWarehouesOrigin);

                    availableToMove = movementController.verifyMovement(idProd, intIdWarehouse, cantMov, -1, typeMovement, "Produccion", "Materia Prima", "");

                    if (availableToMove == 1)
                    {
                        //Se valida que exista la materia prima, el almacén, también que exista la relación materiaPrima-almacén
                        
                        //Aumentar stock físico y lógico del almacén - CORREGIR- PRESENTA ERRORES EN EL UPDATE
                        movementController.updateProductWarehouse(idProd, intIdWarehouse, cantMov, typeMovement, "Materia Prima");
                        //exito =productionItemWarehouseMovementController.updateDataRawMaterialOut(idProd, intIdWarehouse, cantMov, "Salida", "OK");

                        //Grabar movimiento
                        int movemenType = 13; //Indica que es una salida
                        int movementReason = 3;//Indica que es un movimiento por producción
                        int documentTypes = -1;//Indica que no tiene un documento relacionado para validarlo
                        int productType = 0;//0:materia prima | 1:producto
                        int isExchange = -1;//-1:No es intercambio | otro:es intercambio
                        movementController.insertMovement(-1, movemenType, intIdWarehouse, movementReason, documentTypes, isExchange, idProd, cantMov, productType);
                        //productionItemWarehouseMovementController.insertMovement(-1, movemenType, Convert.ToInt32(idWarehouesOrigin), movementReason, documentTypes, isExchange, idProd, cantMov, productType);
                        numRows2++;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo completar el movimiento para la línea: " + (numRows + 1) + ".");
                    }
                }
                numRows++;
            }
            //productionItemMovementController.sacarMateria();
            MessageBox.Show("Se actualizaron: " + numRows2 + " Registros.");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
