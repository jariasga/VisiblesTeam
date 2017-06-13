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
    public partial class SimulationReport : Form
    {
        private ReportsController reportControl = new ReportsController();

        public SimulationReport(string name)
        {
            InitializeComponent();
            showData(name);
        }

        public void showData(string name)
        {
            label_todaydate.Text = DateTime.Now.ToString("M/d/yyyy");
            label_simulationName.Text = name;
            //label_simulationTime.Text = time;

            DataTable simulationReportList = reportControl.getDataSimulation(name);
            populateDataGrid(simulationReportList);
        }

        private void populateDataGrid(DataTable simulationReportList)
        {
            simulation_grid.Rows.Clear();
            foreach (DataRow row in simulationReportList.Rows)
            {
                simulation_grid.Rows.Add(row["Fecha"], row["Iteraciones"], row["Huacos"], row["Piedras"], row["Retablos"], row["Trabajadores"]);
            }
        }
    }
}
