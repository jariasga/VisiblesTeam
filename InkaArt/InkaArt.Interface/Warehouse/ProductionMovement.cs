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
        
        public ProductionMovement(string idWarehouse,string nameWarehouse,string typeMovement)
        {
            InitializeComponent();
            
            this.id_warehouse = idWarehouse;
            this.nameWarehouseOrigin = nameWarehouse;
            this.typeMovement = typeMovement;
            
            text_name_warehouse.Text = nameWarehouse;
            text_id_warehouse.Text = idWarehouse;
            grid_lote.AutoGenerateColumns = false;
        }        

        //Botón de aceptar para crear el movimiento
        //AGREGAR: Debería registrarse el lote de producción de donde viene el producto.
        private void buttonSaveClick(object sender, EventArgs e)
        {
            int idProd = 0, idWare = 0, idLote, is_verified=0;
            string nameProd="";
            int cantMov = 0, maxMov=0, saved=0;
            int numRows = 0;

            int movemenType = 2; //Indica que es una entrada
            int movementReason = 3;//Indica que es un movimiento por producción
            int documentTypes = 3;//Indica que el documento relacionado es un número de lote
            int productType = 1;//0:materia prima | 1:producto
            int isExchange = -1;//-1:No es intercambio | otro:es intercambio

            idWare = Convert.ToInt32(text_id_warehouse.Text);

            //Fin de validaciones

            foreach (DataGridViewRow row in grid_lote.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[7].Value);//Verifica que línea se ha marcado con un check
                idLote = Convert.ToInt32(row.Cells["nroLote"].Value); 

                if (s && idLote > 0)
                {                    
                    idProd = Convert.ToInt32(row.Cells[1].Value);//No se valida porque viene de la base de datos
                    nameProd = Convert.ToString(row.Cells[2].Value);//No se valida porque viene de la base de datos
                    cantMov = Convert.ToInt32(row.Cells[MovCant.Index].Value);
                    maxMov = Convert.ToInt32(row.Cells[CurrentCant.Index].Value);

                    //is_verified = movementController.verifyMovement(idProd, idWare, cantMov, idLote, typeMovement, "Produccion", "Producto", "LOTE");
                    is_verified = 1;
                    if (is_verified == 1)
                    {
                        //Aumentar stock físico y lógico del almacén - CORREGIR- PRESENTA ERRORES EN EL UPDATE
                        movementController.updateProductWarehouse(idProd, idWare, cantMov, typeMovement, "Producto");
                        //Aumentar stock físico y lógico del producto
                        movementController.updateProductStock(idProd, cantMov, typeMovement, "Producción");
                        //Actualizar el stock por mover
                        movementController.updateStockDocument(idLote, idProd, maxMov, cantMov, "LOTE");
                        //Grabar movimiento                        
                        movementController.insertMovement(idLote, movemenType, idWare, movementReason, documentTypes, isExchange, idProd, cantMov, productType);
                        saved++;
                    }
                    else
                    {
                        MessageBox.Show("Ingresar datos validos en la línea " + (numRows + 1) + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                numRows++;
            }

            //cantMov = Convert.ToInt32(numericUpDown2.Value);
            if (saved > 0) {
                MessageBox.Show("" + saved + " Operaciones realizadas con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo realizar ningún movimiento...");
            }
        }
        
        private void buttonSearchClick(object sender, EventArgs e)
        {
            updateGrid();
        }

        private void updateGrid()
        {
            int id_lote;

            //if (text_lote.Text == "")
            //{
            //    id_lote = 0;
            //}
            //else
            //{
            //    int.TryParse(text_lote.Text, out id_lote);
            //}

            int.TryParse(text_lote.Text, out id_lote);

            NpgsqlDataReader datos = movementController.getProductStock(this.id_warehouse, id_lote);
            DataTable table_lote = new DataTable();
            table_lote.Load(datos);

            grid_lote.DataSource = table_lote;
            if (grid_lote.Rows.Count <= 0)
                MessageBox.Show("No hay productos que este almacén pueda recibir para el lote ingresado");
        }

        private void textLoteTextChanged(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = text_lote.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    MessageBox.Show("Solo puede ingresar números para el lote", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            text_lote.Text = actualdata;
        }

        private void gridLoteCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || grid_lote.Rows[e.RowIndex].Cells[MovCant.Index].Value == null)
                return;

            string quantity = grid_lote.Rows[e.RowIndex].Cells[MovCant.Index].Value.ToString();
            int pending = int.Parse(grid_lote.Rows[e.RowIndex].Cells[CurrentCant.Index].Value.ToString());
            if (!validateQuantity(e.RowIndex + 1, quantity, pending))
                grid_lote.Rows[e.RowIndex].Cells[MovCant.Index].Value = null;
        }

        private bool validateQuantity(int row, string str_value, int pending)
        {
            int int_value;

            if (!int.TryParse(str_value, out int_value))
                MessageBox.Show("Fila " + row + ": Favor de ingresar un valor entero");
            else if (int_value <= 0)
                MessageBox.Show("Fila " + row + ": Favor de ingresar un valor positivo");
            else if (int_value > pending)
                MessageBox.Show("Fila " + row + ": Favor de ingresar una cantidad menor o igual a la pendiente de ingreso");
            else
                return true;

            return false;
        }
    }
}
