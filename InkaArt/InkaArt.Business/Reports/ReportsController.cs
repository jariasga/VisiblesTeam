using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Reports;
using System.Data;

namespace InkaArt.Business.Reports
{
    public class ReportsController
    {
        private ReportsData reportData;

        public ReportsController()
        {
            reportData = new ReportsData();
        }

        public DataTable getDataSales(string fechaIni, string fechaFin, string producto)
        {
            return reportData.getDataSales(fechaIni, fechaFin, producto);
        }

        public DataTable getDataStocks(int flag)
        {
            return reportData.getDataStocks(flag);
        }

        public DataTable getDataPerformance(string worker, int chosenIndex, string fechaIni, string fechaFin)
        {
            return reportData.getDataPerformance(worker, chosenIndex, fechaIni, fechaFin);
        }
    }
}
