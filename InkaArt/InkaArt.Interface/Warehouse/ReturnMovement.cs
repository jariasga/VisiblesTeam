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
    public partial class ReturnMovement : Form
    {
        string typeMovement = "";

        string idWarehouesOrigin = "";
        string nameWarehouseOrigin = "";
        private ProductionItemMovementController productionItemMovementController = new ProductionItemMovementController();


        public ReturnMovement()
        {
            InitializeComponent();
        }

        public ReturnMovement(string idWarehouse, string nameWarehouse, string typeMovement)
        {
            this.idWarehouesOrigin = idWarehouse;
            this.nameWarehouseOrigin = nameWarehouse;
            this.typeMovement = typeMovement;
            InitializeComponent();
            textBox6.Text = nameWarehouse;
            textBox5.Text = idWarehouse;
        }


        private int validarEntero(string entero)
        {
            int enteroNuevo = -1;
            try
            {
                enteroNuevo = Convert.ToInt32(entero);
            }
            catch
            {
                MessageBox.Show("Por favor ingrese un valor entero y positivo para el número de nota de crédito");
                return -1;
            }
            if (enteroNuevo < 0)
            {
                MessageBox.Show("Por favor ingrese un valor positivo para la nota de crédito");
                return -1;
            }
            return enteroNuevo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numNota = 0;
            string notaCredStr;
            NpgsqlDataReader datos;

            //Validación para que el número de nota de crédito sea entero y positivo
            notaCredStr = textBox3.Text;
            if ((numNota = validarEntero(notaCredStr)) == -1)
            {
                return;
            }

            //Buscar la nota de crédito en Order
            datos = productionItemMovementController.getQueryCreditNote(idWarehouesOrigin, numNota);
            int rowIndex = 0;

            //Limpiamos el datagridview
            this.dataGridView1.Rows.Clear();

            //Muestra los datos en el gridview
            while (datos.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = datos[0];//idRawMaterial
                row.Cells[1].Value = datos[1];//Nombre
                row.Cells[2].Value = datos[2];//Cantidad total a devolver
                row.Cells[3].Value = datos[3];//Stock en almacén
                row.Cells[4].Value = 100;//MaximunStock
                dataGridView1.Rows.Add(row);
                rowIndex++;
            }
            productionItemMovementController.closeConnection();
            if (rowIndex == 0)
            {
                MessageBox.Show("No hay productos que este almacén pueda devolver para la nota de crédito ingresada.");
                return;
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
