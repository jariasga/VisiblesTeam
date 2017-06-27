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
//using InkaArt.Business.Security;
using InkaArt.Data;
using InkaArt.Data.Algorithm;

namespace InkaArt.Interface.Production
{
    public partial class GeneratePerformanceReport : Form
    {
        private List<int> indexList = new List<int>();
        WorkerController workers = new WorkerController();
        private List<string> workersList;

        public GeneratePerformanceReport()
        {
            InitializeComponent();
            workersList = new List<string>();
            
            workers.Load();
            this.list_workers.DataSource = workers.List();
            this.list_workers.DisplayMember = "FullName";
        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            int response = validateData();
            if (response == 1)
            {
                /*int cIndex = comboBox_workers.SelectedIndex;
                PerformanceReport productivity_form = new PerformanceReport(comboBox_workers.Text, indexList[cIndex], dateTimePicker_ini.Value.ToString("M/d/yyyy HH:MM"), dateTimePicker_fin.Value.ToString("M/d/yyyy HH:MM"));
                productivity_form.Show();*/
                for (int i = 0; i < list_workers.Items.Count; i++)
                {
                    if (list_workers.GetItemChecked(i))
                    {
                        string str = ((Worker)list_workers.Items[i]).FullName;
                        workersList.Add(str);
                    }
                }
                PerformanceReport productivity_form = new PerformanceReport(workersList, dateTimePicker_ini.Value.ToString("M/d/yyyy HH:MM"), dateTimePicker_fin.Value.ToString("M/d/yyyy HH:MM"));
                productivity_form.Show();
                workersList.Clear();
            }            
        }

        private int validateData()
        {
            int result = DateTime.Compare(dateTimePicker_ini.Value, dateTimePicker_fin.Value);
            if (result > 0)
            {
                MessageBox.Show(this, "Por favor, ingresar fecha inicial menor a la fecha final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else if (dateTimePicker_fin.Value > DateTime.Now)
            {
                MessageBox.Show(this, "La fecha final no debe ser mayor a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else return 1;
        }

        private void checkBox_allWorkers_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_allWorkers.Checked)
                list_workers.Enabled = true;
            else
                list_workers.Enabled = false;
        }
    }
}
