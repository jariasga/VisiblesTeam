using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ConsoleApplication1
{
    class Worker
    {
        public string id;
        public string name;
        public string lastname;
        public List<Ratio> ratios;

        public Worker(string id, string name, string lastname)
        {
            this.id = id;
            this.name = name;
            this.lastname = lastname;
            ratios = new List<Ratio>();
        }

        public string getFullName()
        {
            return name + " " + lastname;
        }

        static public List<Worker> read(string filename)
        {
            List<Worker> workers = new List<Worker>();

            using (var fs = File.OpenRead(filename))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    Worker worker = new Worker(values[0], values[1], values[2]);
                    workers.Add(worker);
                }
            }
            Console.WriteLine("workers listos!");
            return workers;
        }

        static public void readRatios(string filename, List<Worker> workers)
        {
            Worker worker;
            using (var fs = File.OpenRead(filename))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    worker = workers.Find(byId(values[0]));
                    Ratio ratio = new Ratio(int.Parse(values[1]), int.Parse(values[2]), double.Parse(values[3]), double.Parse(values[4]));
                    worker.addRatio(ratio);
                }
            }
            Console.WriteLine("ratios listos!");
        }

        public void addRatio(Ratio ratio)
        {
            this.ratios.Add(ratio);
        }

        static Predicate<Worker> byId(string id)
        {
            return delegate (Worker worker)
            {
                return worker.id == id;
            };
        }

        public void print()
        {
            Console.WriteLine(getFullName());
            foreach (Ratio ratio in ratios)
            {
                ratio.print();
            }
            Console.WriteLine();
        }

    }
}
