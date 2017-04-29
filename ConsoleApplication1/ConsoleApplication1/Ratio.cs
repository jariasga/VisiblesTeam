using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ConsoleApplication1
{
    class Ratio
    {
        public Worker worker;
        public int process_product_id;
        public string process_product_name;
        public double breakage;
        public double time;

        public Ratio(Worker worker, string process_product_name, int process_product, double breakage, double time)
        {
            this.worker = worker;
            this.process_product_name = process_product_name;
            this.process_product_id = process_product;            
            this.breakage = breakage;
            this.time = time;
        }

        static public List<Ratio> read(string filename, List<Worker> workers)
        {
            List<Ratio> ratios = new List<Ratio>();
            Worker worker;

            using (var fs = File.OpenRead(filename))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    worker = workers.Find(Worker.byId(int.Parse(values[0])));
                    if (worker != null)
                    {
                        Ratio ratio = new Ratio(worker, values[1], int.Parse(values[2]), double.Parse(values[3]), double.Parse(values[4]));
                        ratios.Add(ratio);
                    }                    
                }
            }
            Console.WriteLine("ratios listos!");

            return ratios;
        }

        public void print()
        {
        }

        public static double getAverageBreakage(List<Ratio> ratios)
        {
            double sum = 0;
            foreach (Ratio ratio in ratios)
                sum += ratio.breakage;

            return sum / ratios.Count;
        }

        public static double getAverageTime(List<Ratio> ratios)
        {
            double sum = 0;
            foreach (Ratio ratio in ratios)
                sum += ratio.time;

            return (sum / ratios.Count);
        }

        public static Predicate<Ratio> byProcessProductId(int process_product)
        {
            return delegate (Ratio ratio)
            {
                return ratio.process_product_id == process_product;
            };
        }

        public static Predicate<Ratio> byWorkerAndProcessProduct(int worker_id, int process_product_id)
        {
            return delegate (Ratio ratio)
            {
                return ratio.worker.id == worker_id && ratio.process_product_id == process_product_id;
            };
        }
        
    }
}
