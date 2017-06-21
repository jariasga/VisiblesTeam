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

        }
    }
}
