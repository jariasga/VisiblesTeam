using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ESTO NO VA EN LA VERSIÓN FINAL
using System.IO;
using InkaArt.Controller;

namespace InkaArt.Model
{
    class Ratio
    {
        //Parámetros de la función objetivo
        public static double BreakageWeight = 0.6;
        public static double TimeWeight = 0.6;

        //Atributos principales

        public Worker worker;
        /*public Worker Worker {
            get { return worker; }
        }*/

        public int process_product_id;
        /*public int ProcessProduct {
            get { return process_product_id; }
        }*/

        //ESTO NO VA EN LA VERSIÓN FINAL
        public string process_product_name;

        public double breakage;
        /*public double Breakage {
            get { return breakage; }
        }*/

        public double time;
        /*public double TimeIndex {
            get { return time_index; }
        }*/

        //Datos derivados

        protected double loss_index;
        /*public double LossIndex {
            get { return loss_index; }
        }*/

        //Constructores

        public Ratio(Worker worker, int process_product, double breakage, double time)
        {
            this.worker = worker;
            this.process_product_id = process_product;
            this.breakage = breakage;
            this.time = time;
            this.loss_index = BreakageWeight * breakage + TimeWeight*time;
        }

        //ESTA FUNCIÓN NO VA EN LA VERSIÓN FINAL
        public Ratio(Worker worker, string process_product_name, int process_product_id, double breakage, double time)
        {
            this.worker = worker;
            this.process_product_name = process_product_name;
            this.process_product_id = process_product_id;
            this.breakage = breakage;
            this.time = time;
            this.loss_index = BreakageWeight * breakage + TimeWeight * time;
        }

        //Métodos

        public void Print()
        {
            Console.WriteLine("Trabajador {0} en {1}: índice de rotura = {2}, índice de tiempo = {3}.",
                worker.GetFullName(), process_product_id, breakage, time);
            Console.WriteLine("Índice de pérdida para el algoritmo = {0}.", loss_index);
        }

        //ESTA FUNCIÓN NO VA EN LA VERSIÓN FINAL
        static public List<Ratio> read(string filename, WorkerManager workers)
        {
            List<Ratio> ratios = new List<Ratio>();

            FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                //Obtener valores para el nuevo ratio
                Worker worker = workers.GetWorkerByID(int.Parse(values[0]));
                int process_product_id = int.Parse(values[2]);
                double breakage = double.Parse(values[3]);
                double time = double.Parse(values[4]);
                //Añadir ratio a la lista
                Ratio ratio = new Ratio(worker, process_product_id, breakage, time);
                ratios.Add(ratio);
            }
            reader.Close();
            file.Close();

            Console.WriteLine("Se han leído los datos de los ratios correctamente.");

            return ratios;
        }
    }
}
