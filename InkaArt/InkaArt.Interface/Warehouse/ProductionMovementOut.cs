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
                row.Cells[0].Value = datos[0];
                row.Cells[1].Value = datos[1];
                row.Cells[2].Value = datos[2];
                row.Cells[3].Value = datos[3];
                row.Cells[4].Value = datos[4];
                dataGridView1.Rows.Add(row);
                rowIndex++;
            }
            productionItemMovementController.closeConnection();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idProd = 0,cantMov=0,numRows=0,maxMov=0;
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
                        cantMov = Convert.ToInt32(row.Cells[3].Value);
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

                    if (cantMov <= maxMov)
                    {
                        //Aumentar stock físico y lógico del almacén - CORREGIR- PRESENTA ERRORES EN EL UPDATE
                        productionItemWarehouseMovementController.updateDataRawMaterialOut(idProd, Convert.ToInt32(idWarehouesOrigin), cantMov, "Salida", "OK");
                    }
                    else
                    {
                        MessageBox.Show("Error en la fila " + numRows + ": Para el producto:" + nameProd + ". Solo se puede quitar " + maxMov + " items.");
                    }
                }
                numRows++;
            }
            //productionItemMovementController.sacarMateria();
            MessageBox.Show("Actualizando...");
        }
    }
}
