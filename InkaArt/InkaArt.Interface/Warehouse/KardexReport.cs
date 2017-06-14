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

namespace InkaArt.Interface.Warehouse
{
    public partial class KardexReport : Form
    {
        private ReportsController reportControl = new ReportsController();

        public KardexReport()
        {
            InitializeComponent();
            showData();
        }

        public void showData()
        {
            label_todaydate.Text = DateTime.Now.ToString("M/d/yyyy");
            
            DataTable movementsReportList = reportControl.getDataMovements();
            populateDataGrid(movementsReportList);
        }

        private void populateDataGrid(DataTable salesReportList)
        {
            dataGridView_movements.Rows.Clear();
            foreach (DataRow row in salesReportList.Rows)
            {
                dataGridView_movements.Rows.Add(row["Fecha"], row["IdMovimiento"], row["TipoMovimiento"], row["Razon"], row["Almacen"], row["Item"], row["Cantidad"]);
            }
        }
    }
}
