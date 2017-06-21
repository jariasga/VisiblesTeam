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

        public DataTable getDataPerformance(List<string> workersList, string fechaIni, string fechaFin)
        {
            return reportData.getDataPerformance(workersList, fechaIni, fechaFin);
        }

        public DataTable getDataSimulation(string name)
        {
            return reportData.getDataSimulation(name);
        }
        public DataTable getDataMovements(string fechaIni, string fechaFin, List<string> items, List<string> warehouses)
        {
            return reportData.getDataMovements(fechaIni, fechaFin, items, warehouses);
        }
    }
}
