using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGRASP.Controller
{
    class DailyJobManager
    {
        WorkerManager worker_manager;
        JobManager job_manager;
        ProductManager product_manager;
        List<DailyJob> daily_jobs;

        /*public DailyJobManager()
        {
            worker_manager = new WorkerManager();
            job_manager = new JobManager();
            product_manager = new ProductManager();
            daily_jobs = new List<DailyJob>();
        }*/

        public DailyJobManager(WorkerManager worker_manager, JobManager job_manager,
            ProductManager product_manager)
        {
            this.worker_manager = worker_manager;
            this.job_manager = job_manager;
            this.product_manager = product_manager;
            this.daily_jobs = new List<DailyJob>();
        }

        public void LoadDailyJobs()
        {
            //Se cargará desde un archivo .csv
            FileStream file = new FileStream("", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            //Nos saltamos la línea de cabecera
            reader.ReadLine();
            //Leemos el resto de archivos para obtener los datos
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(';');
                //Obtener los datos para crear un trabajo diario
                Worker worker = worker_manager.GetWorker(int.Parse(data[0]));
                Job job = job_manager.GetJob(int.Parse(data[1]));
                Product product = product_manager.GetProduct(int.Parse(data[2]));
                DateTime date = DateTime.Parse(data[3]);
                int amount_produced = int.Parse(data[4]);
                int amount_broken = int.Parse(data[4]);
                int total_time = int.Parse(data[4]);
                //Crear el trabajo diario y agregarlo a la lista
                daily_jobs.Add(new DailyJob(worker, job, product, date, amount_produced,
                    amount_broken, total_time));
            }
            reader.Close();
            file.Close();
        }

        public void CalculateIndexes()
        {
            for (int i = 0; i < product_manager.NumberOfProducts(); i++)
            {
                for (int j = 0; j < job_manager.NumberOfJobs(); j++)
                {
                    List<Worker> workers = new List<Worker>();
                    for (int k = 0; k < worker_manager.NumberOfWorkers(); k++)
                        if (worker_manager[k].Product = product_manager[i] && worker_manager[k].)

                }
            }
        }
    }
}
