using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NpgsqlTypes;
using System.Diagnostics;
using InkaArt.Business.Production;
namespace InkaArt.Interface.Production
{
    public partial class RegisterAssignedJob : Form
    {
        public RegisterAssignedJob()
        {
            InitializeComponent();
            FinalProductController controlProduct = new FinalProductController();
            ProcessController controlProcess = new ProcessController();
            WorkerController controlWorker = new WorkerController();
            DataTable productList = controlProduct.getData();
            DataTable processList = controlProcess.getData();
            DataTable workerList = controlWorker.getData();

            textBox_fecha.Text = DateTime.Now.ToShortDateString();

            for (int i = 0; i < productList.Rows.Count; i++)
                comboBox_producto.Items.Add(productList.Rows[i]["name"].ToString());

            for (int i = 0; i < processList.Rows.Count; i++)
                comboBox_proceso.Items.Add(processList.Rows[i]["description"].ToString());

            for (int i = 0; i < workerList.Rows.Count; i++)
                comboBox_nombre.Items.Add(workerList.Rows[i]["firstName"].ToString()+" "+ workerList.Rows[i]["lastName"].ToString());


        }

        private void RegisterAssignedJob_Load(object sender, EventArgs e)
        {

        }

        private void button_agregar_Click(object sender, EventArgs e)
        {
                dataGridView_turn.Rows.Add(comboBox_nombre.SelectedItem.ToString(),
                    comboBox_producto.SelectedItem.ToString(),
                    comboBox_proceso.SelectedItem.ToString(),
                    textbox_horaIni.Text,
                    textBox_horaFin.Text,
                    textBox_rotos.Text,
                    textBox_terminados.Text);

        }

        private void comboBox_nombre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_turn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_turn.Rows.Count; i++)
            {
                bool s = Convert.ToBoolean(dataGridView_turn.Rows[i].Cells[7].Value);

                if (s == true)
                {
                    dataGridView_turn.Rows.RemoveAt(i);
                    dataGridView_turn.Refresh();
                    break;
                }
            }
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            DialogResult logout = MessageBox.Show("¿Esta seguro de guardar los datos?", "Inka Art",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (logout == DialogResult.Yes)
            {
            }
        }
    }
}
