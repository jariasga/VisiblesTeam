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
            DataTable productList = controlProduct.getData();
            DataTable processList = controlProcess.getData();

            textBox_fecha.Text = DateTime.Now.ToShortDateString();

            for (int i = 0; i < productList.Rows.Count; i++)
                comboBox_producto.Items.Add(productList.Rows[i]["name"].ToString());

            for (int i = 0; i < processList.Rows.Count; i++)
                comboBox_proceso.Items.Add(processList.Rows[i]["description"].ToString());


        }

        private void RegisterAssignedJob_Load(object sender, EventArgs e)
        {

        }

        private void button_agregar_Click(object sender, EventArgs e)
        {
            dataGridView_turn.Rows.Add(comboBox_nombre.SelectedItem.ToString(),
                comboBox_producto.SelectedItem.ToString(),
                comboBox_proceso.SelectedItem.ToString(),
                textbox_horaIni.ToString(),
                textBox_horaFin.ToString(),
                textBox_rotos.ToString(),
                textBox_terminados.ToString());
        }
    }
}
