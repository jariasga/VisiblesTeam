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
        int id_warehouse;
        string nameWarehouseOrigin = "";
        private ProductionItemMovementController productionItemMovementController = new ProductionItemMovementController();
        private ProductionItemWarehouseMovementController productionItemWarehouseMovementController = new ProductionItemWarehouseMovementController();
        DataTable devolutions;


        public ReturnMovement(string idWarehouse, string nameWarehouse, string typeMovement)
        {
            int.TryParse(idWarehouse, out id_warehouse);
            this.nameWarehouseOrigin = nameWarehouse;
            this.typeMovement = typeMovement;            
            InitializeComponent();
            fillCombo();
        }        

        private void fillCombo()
        {
            OrderController control = new OrderController();

            devolutions = control.GetDevolutions();            
            combobox_dev.DataSource = devolutions;
            combobox_dev.ValueMember = "idOrder";
        }

        //private int hallaPorDevolver(string idProduct, int cantDev)
        //{
        //    int retornar = cantDev;
        //    StockDocumentController control = new StockDocumentController();
        //    DataTable stockList = control.getData();

        //    for (int i = 0; i < stockList.Rows.Count; i++)
        //    {
        //        if (stockList.Rows[i]["idDocument"].ToString() == textbox_return.Text
        //            && stockList.Rows[i]["documentType"].ToString() == "DEVOLUCION"
        //            && stockList.Rows[i]["product_id"].ToString() == idProduct
        //            && stockList.Rows[i]["product_type"].ToString() == "producto")
        //        {
        //            retornar = int.Parse(stockList.Rows[i]["product_stock"].ToString());
        //            break;
        //        }
        //    }

        //    return retornar;
        //}

        private void updateInsertDevueltos(string idProduct, int cantADev, int cantDev)
        {
            //StockDocumentController control = new StockDocumentController();
            //DataTable stockList = control.getData();

            //int encontrado = 0;
            //for (int i = 0; i < stockList.Rows.Count; i++)
            //{
            //    if (stockList.Rows[i]["idDocument"].ToString() == textbox_return.Text
            //        && stockList.Rows[i]["documentType"].ToString() == "DEVOLUCION"
            //        && stockList.Rows[i]["product_id"].ToString() == idProduct
            //        && stockList.Rows[i]["product_type"].ToString() == "producto")
            //    {
            //        //update
            //        control.updateReturn(textbox_return.Text, idProduct, cantDev - cantADev);
            //        encontrado = 1;
            //        break;
            //    }
            //}
            //if (encontrado == 0)//insertar por primera vez
            //{
            //    //insert
            //    control.insertReturn(textbox_return.Text, idProduct, cantDev - cantADev);

            //}

        }

        private void updateDevolution()
        {
            //OrderController controlOrder = new OrderController();
            ////revisar
            //DataTable orderList = controlOrder.GetOrders();

            ////for del datagrid
            //bool needs_update = false;
            //for (int i = 0; i < grid_devolution.Rows.Count && !needs_update; i++)
            //{
            //    needs_update = (grid_devolution.Rows[i].Cells[7].Value != null && int.Parse(grid_devolution.Rows[i].Cells[7].Value.ToString()) != 0);
            //}
                
            //if (needs_update) controlOrder.updateReturn(textbox_return.Text);
        }

        private void buttonSearchClick(object sender, EventArgs e)
        {
            updateGrid();            
            updateDevolution();
        }

        private void updateGrid()
        {
            //NpgsqlDataReader data = productionItemMovementController.getQueryDevolution(id_warehouse, textbox_return.Text);

            //this.grid_devolution.Rows.Clear();
            //while (data.Read())
            //{
            //    DataGridViewRow row = (DataGridViewRow)grid_devolution.Rows[0].Clone();
            //    row.Cells[0].Value = data[0];//idProduct
            //    row.Cells[1].Value = data[1];//Nombre
            //    row.Cells[2].Value = data[2];//Cantidad total a devolver
            //    row.Cells[3].Value = data[3];//Stock en almacén
            //    row.Cells[4].Value = data[4];//MinimunStock
            //    row.Cells[5].Value = data[5];//MaximunStock
            //    row.Cells[6].Value = "";
            //    //REVISAR
            //    row.Cells[7].Value = hallaPorDevolver(data[0].ToString(), int.Parse(data[2].ToString()));
            //    row.Cells[8].Value = false;
            //    //TODO
            //    //verificacion de cells 7 si es 0 actualizar el estado de la devolucion
            //    grid_devolution.Rows.Add(row);
            //}
            //productionItemMovementController.closeConnection();

            //if (grid_devolution.Rows.Count <= 0)
            //{
            //    MessageBox.Show("No hay productos que este almacén pueda devolver para la devolución ingresada.");
            //    return;
            //}
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSaveClick(object sender, EventArgs e)
        {
            //int id_product = 0, cant_dev = 0, numRows = 0, max_dev = 0, rows_updated = 0, id_devolution = 0;
            //List<int> id_products = new List<int>();
            //List<int> quantities = new List<int>();

            //foreach (DataGridViewRow row in grid_devolution.Rows)
            //{
            //    numRows++;
            //    if (!Convert.ToBoolean(row.Cells[8].Value)) continue;

            //    id_product = Convert.ToInt32(row.Cells[0].Value);
            //    max_dev = Convert.ToInt32(row.Cells[2].Value);
            //    cant_dev = Convert.ToInt32(row.Cells[6].Value);
            //    id_devolution = int.Parse(textbox_return.Text);
                
            //    if (cant_dev <= max_dev && cant_dev <= int.Parse(row.Cells[7].Value.ToString()))
            //    {
            //        // tabla Product-Warehouse: Aumentar stock logico y fisico
            //        ProductWarehouseController control_pwh = new ProductWarehouseController();
            //        DataTable pwhList = control_pwh.getData();
            //        control_pwh.updateOnlyPhStock(id_warehouse.ToString(), id_product.ToString(), int.Parse(row.Cells[3].Value.ToString()) + cant_dev);
            //        // tabla StockDocument: Reducir por devolver
            //        updateInsertDevueltos(id_product.ToString(), cant_dev, int.Parse(row.Cells[7].Value.ToString()));
            //        // tabla Movement: Insertar
            //        ProductionMovementMovementController controlM = new ProductionMovementMovementController();
            //        controlM.insertMovDev(int.Parse(textbox_return.Text), 2, id_warehouse, 8, 8, id_product.ToString(), 1, cant_dev);

            //        id_products.Add(id_product);
            //        quantities.Add(cant_dev);                    
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error en la fila " + numRows + ": Para el producto:" + row.Cells[1].Value.ToString() + ". Solo se puede quitar " + max_dev + " items.");
            //    }

            //}

            //if (id_products.Count > 0)
            //{
            //    OrderController control_order = new OrderController();
            //    id_products.Add(0);
            //    quantities.Add(0);                
            //    int[] arr_ids = id_products.ToArray();
            //    int[] quants = quantities.ToArray();
            //    control_order.AddSaleDocumentW(int.Parse(textbox_return.Text), arr_ids, quants, 1);
            //    //productionItemMovementController.sacarMateria();
            //    MessageBox.Show("Se actualizaron: " + rows_updated + " Registros.");
            //    this.Close();
            //} else
            //{
            //    MessageBox.Show("Ingrese los datos para registrar el movimiento");
            //}           

            //updateGrid();
            //updateDevolution();
        }

        private void textboxReturnTextChanged(object sender, EventArgs e)
        {
            //int id_devolution = validatePositiveInt(textbox_return.Text);
        }

        private void gridDevolutionCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //int new_value = validatePositiveInt(grid_devolution.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }

        private int validatePositiveInt(string str_value)
        {
            int int_value;
            if (!int.TryParse(str_value, out int_value))
                MessageBox.Show("Favor de ingresar un valor entero");
            else if (int_value < 0)
                MessageBox.Show("Favor de ingresar un valor positivo");

            return int_value;
        }

        private void comboboxDevSelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow devolution = ((DataRowView) combobox_dev.SelectedItem).Row;
            date_dev.Value = DateTime.Parse(devolution["deliveryDate"].ToString()); // formato
            textbox_client.Text = devolution["name"].ToString();

            fillDetailGrid(devolution["idOrder"].ToString());
        }

        private void fillDetailGrid(string id_devolution)
        {
            OrderController order_controller = new OrderController();
            DataTable lines = order_controller.getOrderLines(id_devolution);

            foreach(DataRow row in lines.Rows)
            {
                DataGridViewRow grid_row = (DataGridViewRow)grid_dev_detail.Rows[0].Clone();
                grid_row.Cells[product.Index].Value = row[];
                row.Cells[worker.Index].Value = miniturn.Worker.FullName;
                row.Cells[job.Index].Value = miniturn.Job.Name;
                row.Cells[recipe.Index].Value = miniturn.Recipe.Description;
                row.Cells[quantity.Index].Value = miniturn.Produced;
                row.Cells[index.Index].Value = miniturn.LossValue;
                simulation_grid.Rows.Add(row);
            }

            

        }
    }
}
