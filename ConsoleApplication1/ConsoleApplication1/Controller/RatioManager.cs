using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using InkaArt.Model;

namespace InkaArt.Controller
{
    class RatioManager
    {
        //Atributos
        private WorkerManager workers;
        private JobManager jobs;
        private List<Ratio> ratios;

        public RatioManager(WorkerManager workers, JobManager jobs)
        {
            this.workers = workers;
            this.jobs = jobs;
            this.ratios = new List<Ratio>();
        }

        public void Load(string filename)
        {
            FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(';');
                //Obtener datos del ratio
                Worker worker = workers.GetByID(int.Parse(values[0]));
                Job job = jobs.GetByID(int.Parse(values[2]));
                double breakage_index = double.Parse(values[3]);
                double time_index = double.Parse(values[3]);
                //Añadir ratio histórico a la lista
                ratios.Add(new Ratio(worker, job, breakage_index, time_index));
            }
            reader.Close();
            file.Close();

            //Confirmar que se guardaron los datos
            Console.WriteLine("Se cargaron los datos de los ratios correctamente.");
        }

        public void Print()
        {
            for (int i = 0; i < ratios.Count; i++)
            {
                Console.Write("Ratio {0}: ", i + 1);
                ratios[i].Print();
            }
        }

        public List<Assignment> GetCandidates()
        {
            List<Assignment> candidates = ratios.ConvertAll(ratio =>
                    new Assignment(ratio.worker, ratio.process_product, ratio.loss_index));
            return candidates;
        }
    }
}
