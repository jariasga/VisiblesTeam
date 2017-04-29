using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Model;

namespace InkaArt.Controller
{
    class WorkerManager
    {
        private List<Worker> workers;

        public WorkerManager()
        {
            workers = new List<Worker>();
        }

        public void LoadWorkers(string filename)
        {
            FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(';');
                //Añadir trabajador a la lista
                Worker worker = new Worker(int.Parse(values[0]), values[1], values[2]);
                workers.Add(worker);
            }
            reader.Close();
            file.Close();

            //Confirmar que se guardaron los datos
            Console.WriteLine("Se cargaron los datos de los trabajadores correctamente.");
        }

        public void Print()
        {
            for (int i = 0; i < workers.Count; i++)
            {
                Console.Write("Trabajador {0}: ", i + 1);
                workers[i].Print();
            }
        }

        public Worker GetWorkerByID(int id)
        {
            for (int i = 0; i < workers.Count; i++)
            {
                if (workers[i].ID == id) return workers[i];
            }
            return null;
        }

        public int NumberOfWorkers()
        {
            return workers.Count;
        }

        public Worker this[int index]
        {
            get { return workers[index]; }
        }
    }
}
