using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGRASP.Controller
{
    class WorkerManager
    {
        private List<Worker> workers;

        public WorkerManager()
        {
            workers = new List<Worker>();
            //Colocar por mientras en duro los datos
            workers.Add(new Worker(1, "Camila Chávez"));
            workers.Add(new Worker(2, "Ricardo Vente"));
            workers.Add(new Worker(3, "Anthony Gutiérrez"));
            workers.Add(new Worker(4, "Natalia Palomares"));
            workers.Add(new Worker(5, "Flor Noriega"));
            workers.Add(new Worker(6, "Javier Arias"));
            workers.Add(new Worker(7, "Daniel Galán"));
            workers.Add(new Worker(8, "Mauricio Castañeda"));
        }

        public Worker GetWorker(int id)
        {
            for (int i = 0; i < workers.Count; i++) {
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
