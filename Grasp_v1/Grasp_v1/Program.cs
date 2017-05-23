using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Controller;

namespace InkaArt
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkerManager workers = new WorkerManager();
            workers.Load("Workers.csv");
            ProductManager products = new ProductManager();
            ProcessManager processes = new ProcessManager();
            ProcessProductManager processes_products =
                new ProcessProductManager(processes, products);
            RatioManager ratios = new RatioManager(workers, processes_products);
            ratios.Load("Ratios.csv");

            /*workers.Print();
            products.Print();
            processes.Print();
            processes_products.Print();
            ratios.Print();*/

            Console.WriteLine("Se cargaron los datos iniciales correctamente.");

            Grasp grasp = new Grasp(workers, processes, products, processes_products,
                ratios);
            List<int[]> solutions = grasp.GraspAlgorithm();

            Console.WriteLine("Se ejecutó el algoritmo GRASP correctamente.");

            Console.Error.WriteLine("El programa terminó correctamente. " + 
                "Presione Enter para salir.");
            Console.ReadLine();
        }
    }
}
