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
        JobManager jobs;
        List<DailyJob> daily_jobs;

        public DailyJobManager(WorkerManager workers)
        {
            this.workers = workers;
            this.daily_jobs = new List<DailyJob>();
        }

        public void Load(string filename)
        {
            FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(';');
                //Añadir ratio
                Worker worker = workers.GetByID(int.Parse(values[0]));
                Job job = jobs.GetByID(int.Parse(values[1]));
                DateTime date = DateTime.Parse(values[2]);
                int amount_produced = int.Parse(values[3]);
                int amount_broken = int.Parse(values[4]);
                int total_time = int.Parse(values[5]);
                //Añadir trabajo diario a la lista de históricos
                DailyJob daily_job = new DailyJob(worker, job, date, amount_produced,
                    amount_broken, total_time);
                daily_jobs.Add(daily_job);
            }
            reader.Close();
            file.Close();
            //Confirmar que se guardaron los datos
            Console.WriteLine("Se cargaron los datos de las jornadas diarias.");
        }

        public double[] GetAverageValuesPerJob(Job job)
        {
            int count = 0;
            double breakage_sum = 0;
            double time_sum = 0;

            //Obtener sumas de rotura y tiempo por puesto de trabajo
            for (int i = 0; i < daily_jobs.Count; i++)
            {
                if (daily_jobs[i].Job == job)
                {
                    count++;
                    breakage_sum += daily_jobs[i].Breakage;
                    time_sum += daily_jobs[i].TimePerProduct;
                }
            }

            //Generar los promedios de rotura y tiempo en un arreglo
            if (count <= 0) return null;
            double[] average_values = { breakage_sum / count, time_sum / count };
            return average_values;
        }
    }
}
