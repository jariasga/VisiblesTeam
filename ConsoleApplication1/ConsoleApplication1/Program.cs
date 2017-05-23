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
<<<<<<< HEAD
        //public Worker first_worker { get; protected set; }
        static void Main(string[] args)
        {
            int painting = 10;
            int baking = 10;
            int carving = 10;

            Instance instance = new Instance(painting, baking, carving);
            instance.print();
=======
        static void Main(string[] args)
        {
            Instance instance = new Instance();

            //GRASP
            Grasp grasp = new Grasp(instance);
            grasp.GraspAlgorithm();

            // tabu
            TabuSearch tabu = new TabuSearch(instance);
            tabu.run();

>>>>>>> 92598514377fd1d5448cca76b1d5482221e68e1e
            Console.Read();
        }
    }
}
