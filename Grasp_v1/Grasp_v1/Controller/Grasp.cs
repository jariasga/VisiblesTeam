using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; //Esto debe irse en la versión final
using InkaArt.Model;

namespace InkaArt.Controller
{
    class Grasp
    {
        //Parámetros del algoritmo
        private static double Alpha = 0.2;
        private static int Iterations = 1000;

        //Atributos
        private WorkerManager workers;
        private DailyJobManager daily_jobs;
        private List<Ratio> ratios;

        public Grasp(WorkerManager workers, DailyJobManager daily_jobs)
        {
            this.workers = workers;
            this.daily_jobs = daily_jobs;
            //this.ratios = daily_jobs.GenerateRatios();
            this.ratios = new List<Ratio>();
            this.LoadRatios("Ratios.csv");
        }

        //Esta función no debe ir en la versión final
        private void LoadRatios(string filename)
        {
            FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(';');
                //Añadir ratio
                Worker worker = workers.GetWorkerByID(int.Parse(values[0]));
                double breakage = double.Parse(values[3]);
                double time = double.Parse(values[4]);
                Ratio ratio = new Ratio(worker, int.Parse(values[2]), breakage, time);
                ratios.Add(ratio);
            }
            //Confirmar que se guardaron los datos
            Console.WriteLine("Se cargaron los datos de los ratios.");
        }

        public void GraspAlgorithm()
        {

        }
    }
}
