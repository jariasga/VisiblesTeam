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
using InkaArt.Business.Production;

namespace InkaArt.Interface.Production
{
    public partial class GeneratePerformanceReport : Form
    {
        private WorkerController workers;

        /// <summary>
        /// Constructor del formulario para generar el reporte de productividad de los trabajadores.
        /// </summary>
        public GeneratePerformanceReport()
        {
            InitializeComponent();

            this.workers = new WorkerController();
            this.workers.Load();
            this.list_workers.DataSource = workers.List();
            this.list_workers.DisplayMember = "FullName";

            this.date_picker_start.Format = DateTimePickerFormat.Custom;
            date_picker_start.CustomFormat = "dd/MM/yyyy";
            this.date_picker_end.Format = DateTimePickerFormat.Custom;
            date_picker_end.CustomFormat = "dd/MM/yyyy";
        }

        /// <summary>
        /// Genera un reporte de productividad para los trabajadores seleccionados en un intervalo de fechas determinado.
        /// </summary>
        private void button_generate_Click(object sender, EventArgs e)
        {
            if (!button_generate_ValidateFilters()) return;

            WorkerController selected_workers = new WorkerController();
            for (int i = 0; i < list_workers.Items.Count; i++)
                if (list_workers.GetItemChecked(i)) selected_workers.Add((Worker)list_workers.Items[i]);

            PerformanceReport performance_report = new PerformanceReport(selected_workers, date_picker_start.Value, date_picker_end.Value);
            performance_report.Show();
        }

        private bool button_generate_ValidateFilters()
        {            
            if (date_picker_start.Value > date_picker_end.Value)
            {
                MessageBox.Show(this, "Por favor, ingrese una fecha inicial menor a la fecha final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (date_picker_end.Value > DateTime.Now)
            {
                MessageBox.Show(this, "La fecha final no debe ser mayor a la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (list_workers.CheckedItems.Count <= 0)
            {
                MessageBox.Show(this, "Por favor, seleccione por lo menos un trabajador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void checkbox_workers_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_workers.Enabled)
            {
                for (int i = 0; i < list_workers.Items.Count; i++)
                    list_workers.SetItemChecked(i, true);
                list_workers.Enabled = false;
            }
            else list_workers.Enabled = true;
        }
    }
}
