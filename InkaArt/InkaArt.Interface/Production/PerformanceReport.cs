using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Reports;

namespace InkaArt.Interface.Production
{
    public partial class PerformanceReport : Form
    {
        private ReportsController reportControl = new ReportsController();

        public PerformanceReport(string worker, int chosenIndex, string fechaIni, string fechaFin)
        {
            InitializeComponent();
            showData(worker, chosenIndex, fechaIni, fechaFin);
        }

        public void showData(string worker, int chosenIndex, string fechaIni, string fechaFin)
        {
            label_nameWorker.Text = worker;
            label_today.Text = DateTime.Now.ToString("M/d/yyyy");
            DataTable performanceReportList = reportControl.getDataPerformance(worker, chosenIndex, fechaIni, fechaFin);
            populateDataGrid(performanceReportList);           
        }

        private void populateDataGrid(DataTable performanceReportList)
        {
            dataGridView_performance.Rows.Clear();
            foreach (DataRow row in performanceReportList.Rows)
            {
                dataGridView_performance.Rows.Add(row["Fecha"], row["Puesto"], row["Receta"], row["CantidadRota"], row["CantidadProducida"], row["Tiempo"]);
            }               
        }

    }
}
