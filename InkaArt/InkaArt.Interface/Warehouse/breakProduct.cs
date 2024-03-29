﻿using System;
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
    public partial class breakProduct : Form
    {
        string typeMovement;
        private ProductionItemMovementController productionItemMovementController = new ProductionItemMovementController();

        public breakProduct()
        {
            InitializeComponent();
        }

        private ProductionItemWarehouseMovementController productionItemWarehouseMovementController = new ProductionItemWarehouseMovementController();

        public breakProduct(string idWarehouse, string nameWarehouse, string typeMovement)
        {
            this.typeMovement = typeMovement;
            InitializeComponent();
            textBox6.Text = nameWarehouse;
            textBox5.Text = idWarehouse;
        }

        private void breakProduct_Load(object sender, EventArgs e)
        {

        }

        private void button_create_Click(object sender, EventArgs e)
        {
            //Form new_warehouse_window = new Form1(ref textBox1,ref textBox2,ref textBox4);
            //Form new_warehouse_window = new Form1(textBox7, textBox3, textBox4);
            //new_warehouse_window.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idProd = 0, idWare = 0, idLote = 0, exito2 = 0;
            string nameProd = "";

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
                idLote = Convert.ToInt32(textBox3.Text);
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
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[5].Value);

                if (s == true)
                {
                    idProd = Convert.ToInt32(row.Cells[0].Value);
                    nameProd = Convert.ToString(row.Cells[1].Value);
                    try
                    {
                        cantMov = Convert.ToInt32(row.Cells[4].Value);
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
                    maxMov = Convert.ToInt32(row.Cells[3].Value);

                    if (cantMov <= maxMov)
                    {
                        //Aumentar stock físico y lógico del almacén - CORREGIR- PRESENTA ERRORES EN EL UPDATE
                        exito2 = productionItemWarehouseMovementController.updateData(idProd, idWare, cantMov, "Entrada", "ROTO");
                        if (exito2 == 1)
                        {
                            //Actualizar el stock por mover
                            //productionItemWarehouseMovementController.updateStockDocument(idLote, idProd, maxMov, cantMov, "Salida");
                            //Grabar movimiento
                            int movemenType = 2; //Indica que es una entrada
                            int movementReason = 3;//Indica que es un movimiento por producción
                            int documentTypes = 3;//Indica que el documento relacionado es un número de lote
                            int productType = 1;//0:materia prima | 1:producto
                            int isExchange = -1;//-1:No es intercambio | otro:es intercambio
                            productionItemWarehouseMovementController.insertMovement(idLote, movemenType, idWare, movementReason, documentTypes, isExchange, idProd, cantMov, productType);
                            exito++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error en la fila " + numRows + ": Para el producto:" + nameProd + "Solo quedan " + maxMov + " por asignar según el lote:" + idLote + ".");
                    }
                }
                numRows++;
            }

            //cantMov = Convert.ToInt32(numericUpDown2.Value);
            if (exito > 0)
            {
                MessageBox.Show("" + exito + " Operaciones realizadas con éxito.");
            }
            else
            {
                MessageBox.Show("No se pudo realizar ningún movimiento...");
            }
            this.Close();
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
    }
}
