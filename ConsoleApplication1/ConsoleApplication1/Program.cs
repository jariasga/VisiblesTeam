using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        //public Worker first_worker { get; protected set; }
        static void Main(string[] args)
        {
            Worker first_worker = new Worker("camila", "vente");
            Console.WriteLine(first_worker.getFullName()); 
    
            using (var fs = File.OpenRead("prueba ratios.csv"))
            using (var reader = new StreamReader(fs))
            {
                List<string> tipos = new List<string>();
                List<string> procesos = new List<string>();
                List<string> productos = new List<string>();
                List<string> valores = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    Console.WriteLine(values[0]);

                    tipos.Add(values[0]);
                    procesos.Add(values[1]);
                }
            }
            Console.Read();
        }
    }
}
