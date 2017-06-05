using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                comboBox_nombre.Items.Add(workerList.Rows[i]["first_name"].ToString()+" "+ workerList.Rows[i]["last_name"].ToString());


        }

        private void RegisterAssignedJob_Load(object sender, EventArgs e)
        {

        }

        private void button_agregar_Click(object sender, EventArgs e)
        {
            //validacion
            DateTime auxDate;
            int auxInt;
            if (comboBox_nombre.SelectedItem != null && comboBox_producto.SelectedItem != null &&
                comboBox_proceso.SelectedItem != null)
            {
                if (DateTime.TryParse(textbox_horaIni.Text, out auxDate) &&
                    DateTime.TryParse(textBox_horaFin.Text, out auxDate) &&
                    int.TryParse(textBox_rotos.Text, out auxInt) &&
                    int.TryParse(textBox_terminados.Text, out auxInt))
                {
                    dataGridView_turn.Rows.Add(comboBox_nombre.SelectedItem.ToString(),
                        comboBox_producto.SelectedItem.ToString(),
                        comboBox_proceso.SelectedItem.ToString(),
                        textbox_horaIni.Text,
                        textBox_horaFin.Text,
                        textBox_rotos.Text,
                        textBox_terminados.Text);
                }
                else
                    MessageBox.Show("Formato de datos no válido, por favor verifique todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
                MessageBox.Show("Por favor asegurese de seleccionar un nombre, producto y proceso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                WorkerController controlWorker = new WorkerController();
                DataTable workerList = controlWorker.getData();
                TurnReportController controlReport = new TurnReportController();

                string broken, finished, date, start, end, process, product, idWorker;
                broken = finished = date = start = end = process = product = idWorker  = "";
                
                for (int i=0; i<dataGridView_turn.Rows.Count-1;i++)//guadra toda la grilla
                {
                    DataGridViewRow row = dataGridView_turn.Rows[i];
                    for(int j = 0; j < workerList.Rows.Count; j++)//super ineficiente :C
                    {
                        string nameAux = workerList.Rows[j]["firstName"].ToString() + " " + workerList.Rows[j]["lastName"].ToString();
                        Debug.WriteLine(nameAux);
                        Debug.WriteLine(row.Cells[0].Value.ToString());
                        if (String.Compare(nameAux, row.Cells[0].Value.ToString()) == 0)
                        {
                            idWorker = workerList.Rows[j]["idWorker"].ToString();
                            break;
                        }
                    }

                    broken = row.Cells[5].Value.ToString();
                    finished = row.Cells[6].Value.ToString();
                    date = textBox_fecha.Text;
                    start = row.Cells[3].Value.ToString();
                    end = row.Cells[4].Value.ToString();
                    product = row.Cells[1].Value.ToString();
                    process = row.Cells[2].Value.ToString();

                    //agregar
                    controlReport.insertData(broken, finished, date, start, end, product, process, idWorker);

                }
                dataGridView_turn.Rows.Clear();
            }
        }
    }
}
