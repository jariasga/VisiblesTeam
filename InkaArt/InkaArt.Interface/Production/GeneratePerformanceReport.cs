using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Algorithm;

namespace InkaArt.Interface.Production
{
    public partial class GeneratePerformanceReport : Form
    {
        private List<int> indexList = new List<int>();

        public GeneratePerformanceReport()
        {
            InitializeComponent();
            WorkerController workerControl = new WorkerController();
            workerControl.Load();
            //comboBox_workers.Items.Clear();
            foreach (var worker in workerControl.List())
            {
                comboBox_workers.Items.Add(worker.Name + " " + worker.LastName);
                indexList.Add(worker.ID);
            }
            
        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            int response = validateData();
            if (response == 1)
            {
                int cIndex = comboBox_workers.SelectedIndex;
                PerformanceReport productivity_form = new PerformanceReport(comboBox_workers.Text, indexList[cIndex], dateTimePicker_ini.Value.ToString("M/d/yyyy HH:MM"), dateTimePicker_fin.Value.ToString("M/d/yyyy HH:MM"));
                productivity_form.Show();
            }            
        }

        private int validateData()
        {            
            if (dateTimePicker_ini.Value >= dateTimePicker_fin.Value)
            {
                MessageBox.Show(this, "Por favor, ingresar fecha inicial menor a la fecha final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else if (comboBox_workers.Text == "")
            {
                MessageBox.Show(this, "Por favor, seleccionar a un trabajador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else return 1;
        }
    }
}
