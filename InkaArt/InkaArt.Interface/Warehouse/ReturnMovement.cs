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
        int warehouse;
        DataTable table_devolutions;
        DataTable table_devolution;
        DataTable table_devolution_detail;
        int devolution;

        ProductWarehouseController control_pwh = new ProductWarehouseController();
        StockDocumentController control_stock = new StockDocumentController();
        ProductionMovementMovementController control_mov = new ProductionMovementMovementController();
        OrderController control_order = new OrderController();

        public ReturnMovement(string idWarehouse, string nameWarehouse, string typeMovement)
        {
            InitializeComponent();

            if (!int.TryParse(idWarehouse, out warehouse))
                this.Close();

            grid_devolution.AutoGenerateColumns = false;            
            grid_devolution_detail.AutoGenerateColumns = false;
            fillCombo();
        }        

        // fill

        private void fillCombo()
        {
            table_devolutions = control_order.GetDevolutions();            
            combobox_dev.DataSource = table_devolutions;
            combobox_dev.ValueMember = "idOrder";
        }

        private void fillGrids()
        {
            table_devolution = control_order.GetDevolutionLines(this.devolution, this.warehouse);
            table_devolution_detail = control_order.GetDevolutionDetail(this.devolution);

            grid_devolution_detail.DataSource = table_devolution_detail;
            grid_devolution.DataSource = table_devolution;
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
            int product, line, quantity, max, current, pending, stock_id;
            List<int> id_products = new List<int>();
            List<int> quantities = new List<int>();

            foreach (DataGridViewRow row in grid_devolution.Rows)
            {
                if (row.Cells[to_return.Index].Value == null || int.Parse(row.Cells[to_return.Index].Value.ToString()) <= 0)
                    continue;

                product     = (int) row.Cells[id_product.Index].Value;
                line        = (int) row.Cells[id_line.Index].Value;
                max         = (int) row.Cells[max_stock.Index].Value;
                current     = (int) row.Cells[current_stock.Index].Value;
                quantity    = int.Parse(row.Cells[to_return.Index].Value.ToString());
                stock_id    = (int) row.Cells[id_stock.Index].Value;
                pending     = (int) row.Cells[product_stock.Index].Value;

                // tabla LineItem
                control_order.updateDevolutionLine(line, pending, quantity);
                // tabla Product-Warehouse: Aumentar stock logico y fisico
                control_pwh.updateWarehouseStock(warehouse.ToString(), product.ToString(), quantity);
                // tabla StockDocument: Reducir por devolver
                control_stock.updateInsertDevolution(stock_id, devolution, product, quantity, pending);
                // tabla Movement: Insertar                    
                control_mov.insertMovDev(devolution, 2, warehouse, 8, 8, product.ToString(), 1, quantity);

                id_products.Add(product);
                quantities.Add(quantity);
            }

            if (id_products.Count > 0)
            {
                MessageBox.Show("Se actualizaron: " + id_products.Count + " Registros.");                
                fillGrids();
                //id_products.Add(0);
                //quantities.Add(0);                
                //control_order.AddSaleDocumentW(devolution, id_products.ToArray(), quantities.ToArray(), 1);                                
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

            string quantity = grid_devolution.Rows[e.RowIndex].Cells[to_return.Index].Value.ToString();
            int pending = int.Parse(grid_devolution.Rows[e.RowIndex].Cells[product_stock.Index].Value.ToString());
            if (!validateQuantity(e.RowIndex + 1, quantity, pending))
                grid_devolution.Rows[e.RowIndex].Cells[to_return.Index].Value = null;
        }
        
        private void comboboxDevSelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow devolution = ((DataRowView) combobox_dev.SelectedItem).Row;
            date_dev.Value = DateTime.Parse(devolution["deliveryDate"].ToString()); // formato
            textbox_client.Text = devolution["name"].ToString();
            this.devolution = int.Parse(devolution["idOrder"].ToString());
            fillGrids();
        }

        // otros 
                
        private void updateDevolution()
        {   
            DataRow[] rows = table_devolution.Select("lineStatus != 'devuelto'");
            int pending = rows.Sum(r => r.Field<int>("product_stock"));
            control_order.updateDevolution(devolution, pending);

            //bool completed = true;
            //grid_devolution.Columns[product_stock.Index].

            //foreach(DataGridViewRow row in grid_devolution.Rows)
            //{
            //    if (row.Cells[product_stock.Index].Value == null)
            //        continue;
            //    completed &= (int)row.Cells[product_stock.Index].Value == 0;
            //}
            //if (completed)
            //    control_order.updateDevolution(devolution);
        }

        private bool validateQuantity(int row, string str_value, int pending)
        {
            int int_value;

            if (!int.TryParse(str_value, out int_value))
                MessageBox.Show("Fila " + row + ": Favor de ingresar un valor entero");
            else if (int_value <= 0)
                MessageBox.Show("Fila " + row + ": Favor de ingresar un valor positivo");
            else if (int_value > pending)
                MessageBox.Show("Fila " + row + ": Favor de ingresar una cantidad menor o igual a la pendiente de devolución");
            else
                return true;

            return false;
        }

    }
}
