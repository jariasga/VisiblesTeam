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
        int id_warehouse;
        DataTable devolutions;
        DataTable devolution_lines;
        int id_devolution;


        ProductWarehouseController control_pwh = new ProductWarehouseController();
        StockDocumentController control_stock = new StockDocumentController();
        ProductionMovementMovementController control_mov = new ProductionMovementMovementController();
        OrderController control_order = new OrderController();

        public ReturnMovement(string idWarehouse, string nameWarehouse, string typeMovement)
        {
            InitializeComponent();

            int.TryParse(idWarehouse, out id_warehouse);
            grid_devolution.AutoGenerateColumns = false;
            grid_devolution.Rows.Clear();
            grid_dev_detail.AutoGenerateColumns = false;
            grid_dev_detail.Rows.Clear();
            fillCombo();
        }        

        // fill

        private void fillCombo()
        {
            OrderController control = new OrderController();

            devolutions = control.GetDevolutions();            
            combobox_dev.DataSource = devolutions;
            combobox_dev.ValueMember = "idOrder";
        }

        private void fillDetailGrid()
        {
            OrderController order_controller = new OrderController();
            devolution_lines = order_controller.GetDevolutionLines(id_devolution);
            grid_dev_detail.DataSource = devolution_lines;
        }

        private void fillDevolutionGrid()
        {
            grid_devolution.DataSource = devolution_lines;

            foreach (DataGridViewRow row in grid_devolution.Rows)
            {
                if (row.Cells[idWarehouse.Index].Value == null || row.Cells[product_stock.Index].Value == null)
                    continue;

                if (row.Cells[idWarehouse.Index].Value.ToString() != id_warehouse.ToString())
                {
                    grid_devolution.Rows.Remove(row);
                }
                else if((int) row.Cells[product_stock.Index].Value < 0)
                {
                    row.Cells[product_stock.Index].Value = row.Cells[total_quantity.Index].Value;
                }
            }

            if (grid_devolution.Rows.Count <= 0)
                MessageBox.Show("No hay productos que este almacén pueda devolver para la devolución ingresada.");
        }

        // eventos

        private void buttonCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSaveClick(object sender, EventArgs e)
        {
            int id, quantity, max, current, pending, stock_id;
            int num_rows = 0;
            List<int> id_products = new List<int>();
            List<int> quantities = new List<int>();

            foreach (DataGridViewRow row in grid_devolution.Rows)
            {
                num_rows++;
                if (!Convert.ToBoolean(row.Cells[update.Index].Value) || row.Cells[to_return.Index].Value == null)
                    continue;

                id = Convert.ToInt32(row.Cells[id_product.Index].Value);
                max = Convert.ToInt32(row.Cells[max_stock.Index].Value);
                current = Convert.ToInt32(row.Cells[current_stock.Index].Value);
                quantity = Convert.ToInt32(row.Cells[to_return.Index].Value);
                stock_id = (int) row.Cells[id_stock.Index].Value;
                pending = Convert.ToInt32(row.Cells[product_stock.Index].Value);
                pending = pending < 0 ? 0 : pending;                          

                if (quantity <= Math.Min(max, pending))
                {
                    // tabla Product-Warehouse: Aumentar stock logico y fisico
                    control_pwh.updateOnlyPhStock(id_warehouse.ToString(), id.ToString(), current + quantity);
                    // tabla StockDocument: Reducir por devolver
                    control_stock.updateInsertDevolution(stock_id, id_devolution, id, quantity, pending);
                    // tabla Movement: Insertar                    
                    control_mov.insertMovDev(id_devolution, 2, id_warehouse, 8, 8, id.ToString(), 1, quantity);

                    id_products.Add(id);
                    quantities.Add(quantity);
                }
                else
                    MessageBox.Show("Error en la fila " + num_rows + ": Para el producto:" + row.Cells[name.Index].Value.ToString() + ". Solo se puede quitar " + Math.Min(max, pending) + " items.");
            }

            if (id_products.Count > 0)
            {
                MessageBox.Show("Se actualizaron: " + id_products.Count + " Registros.");                
                fillDevolutionGrid();
                id_products.Add(0);
                quantities.Add(0);                
                control_order.AddSaleDocumentW(id_devolution, id_products.ToArray(), quantities.ToArray(), 1);                                
                updateDevolution();

                this.Close();
            }
            else
                MessageBox.Show("Ingrese los datos para registrar el movimiento");            
        }
        
        private void gridDevolutionCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || grid_devolution.Rows[e.RowIndex].Cells[to_return.Index].Value == null)
                return;
            if(!validatePositiveInt(grid_devolution.Rows[e.RowIndex].Cells[to_return.Index].Value.ToString()))
                grid_devolution.Rows[e.RowIndex].Cells[to_return.Index].Value = null;
        }
        
        private void comboboxDevSelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow devolution = ((DataRowView) combobox_dev.SelectedItem).Row;
            date_dev.Value = DateTime.Parse(devolution["deliveryDate"].ToString()); // formato
            textbox_client.Text = devolution["name"].ToString();
            id_devolution = int.Parse(devolution["idOrder"].ToString()); ;

            fillDetailGrid();
            fillDevolutionGrid();
        }

        // otros 
                
        private void updateDevolution()
        {       
            bool completed = true;

            foreach(DataGridViewRow row in grid_devolution.Rows)
            {
                if (row.Cells[product_stock.Index].Value == null)
                    continue;

                completed &= (int)row.Cells[product_stock.Index].Value == 0;
                if ((int) row.Cells[product_stock.Index].Value == 0)
                    control_order.updateDevolutionLine((int)row.Cells[id_line.Index].Value);
            }
            if (completed)
                control_order.updateDevolution(id_devolution);
        }

        private bool validatePositiveInt(string str_value)
        {
            int int_value;

            if (!int.TryParse(str_value, out int_value))
                MessageBox.Show("Favor de ingresar un valor entero");
            else if (int_value <= 0)
                MessageBox.Show("Favor de ingresar un valor positivo mayor a cero");

            return int_value > 0;
        }

    }
}
