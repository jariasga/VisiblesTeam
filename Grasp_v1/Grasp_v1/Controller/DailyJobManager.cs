using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Model;

namespace InkaArt.Controller
{
    class DailyJobManager
    {
        WorkerManager workers;
        List<DailyJob> daily_jobs;

        public DailyJobManager(WorkerManager workers)
        {
            this.workers = workers;
            this.daily_jobs = new List<DailyJob>();
        }

        /* public void LoadDailyJobs(string filename)
        {
            FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(';');
                //Añadir ratio
                Worker worker = workers.GetWorkerByID(int.Parse(values[0]));
                int process_product_id = 
                DailyJob daily_job = new DailyJob(worker, int.Parse(values[2]), breakage, time);
                daily_jobs.Add(daily_job);
            }
            reader.Close();
            file.Close();
            //Confirmar que se guardaron los datos
            Console.WriteLine("Se cargaron los datos de las jornadas diarias.");
        } */

        /*public double GetAverageBreakage(int process_product_id)
        {
            int count = 0;
            double sum = 0;
            for (int i = 0; i < daily_jobs.Count; i++)
            {
                if (daily_jobs[i].ProcessProduct == process_product_id)
                {
                    count++;
                    sum += daily_jobs[i].Breakage;
                }
            }
            return (count > 0) ? sum / count : -1;
        }*/
    }
}
