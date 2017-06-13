﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Warehouse;

namespace InkaArt.Interface.Warehouse
{
    public partial class Movements : Form
    {
        private ReasonMovementController reasonMovementController = new ReasonMovementController();
        private TypeMovementController typeMovementController = new TypeMovementController();

        public Movements()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string reason = comboBox2.Text;

            if (reason == "Produccion")
            {
                string nameWarehouseOrigin;
                string idWarehouesOrigin;
                nameWarehouseOrigin = textBox6.Text;
                idWarehouesOrigin = textBox5.Text;
                Form formView = new InkaArt.Interface.Warehouse.ProductionMovement(idWarehouesOrigin, nameWarehouseOrigin, comboBox1.Text);
                formView.Show();
            }
            else
            {
                if(reason == "Compra")
                {
                    Form formView = new InkaArt.Interface.Warehouse.PurchaseMovement(textBox5.Text);
                    formView.Show();
                }
                else
                {
                    if (reason == "Venta")
                    {
                        Form formView = new InkaArt.Interface.Warehouse.SaleMovementcs();
                        formView.Show();
                    }
                    else
                    {
                        if (reason == "Traslado")
                        {
                            Form formView = new InkaArt.Interface.Warehouse.ExchangeMovement();
                            formView.Show();
                        }
                        else
                        {
                            if (reason == "Rotura")
                            {
                                MessageBox.Show("Ventana aún no definida");
                            }
                            else
                            {
                                MessageBox.Show("Por favor seleccione una razón válida de movimiento");
                            }
                        }
                    }
                }
            }
            
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            //int a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form new_warehouse_window = new WarehouseSearchMovement(textBox5, textBox6);
            new_warehouse_window.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Movements_Load(object sender, EventArgs e)
        {
            DataTable movementReasonList;
            DataTable movementTypeList;

            movementReasonList = reasonMovementController.GetReasonMovementList();
            foreach (DataRow row in movementReasonList.Rows)
            {
                comboBox2.Items.Add(row["description"]);
            }

            movementTypeList = typeMovementController.GetTypeMovementList();
            foreach (DataRow row in movementTypeList.Rows)
            {
                comboBox1.Items.Add(row["description"]);
            }
        }
    }
}
