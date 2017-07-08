using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Business.Algorithm;
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

        /// <summary>
        /// Obtiene los índices necesarios para obtener los ratios
        /// </summary>
        /// <param name="selected_workers"></param>
        /// <param name="start_date"></param>
        /// <param name="end_date"></param>
        /// <returns></returns>
        public DataTable GetDataPerformance(WorkerController selected_workers, DateTime start_date, DateTime end_date)
        {
            RecipeController recipes = new RecipeController();
            recipes.Load();
            JobController jobs = new JobController();
            jobs.Load();

            RatioController ratios = new RatioController(selected_workers, jobs, recipes);
            ratios.GetDataTable();

            throw new NotImplementedException();
        }

        public DataTable GetDataPerformance(WorkerController selected_workers)
        {
            RecipeController recipes = new RecipeController();
            recipes.Load();
            JobController jobs = new JobController();
            jobs.Load();

            IndexController indexes = new IndexController(selected_workers, jobs, recipes);
            return indexes.GetDataTable();            
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
