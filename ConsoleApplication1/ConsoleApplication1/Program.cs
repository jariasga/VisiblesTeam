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
            int painting = 10;
            int baking = 10;
            int carving = 10;

            Instance instance = new Instance(painting, baking, carving);
            instance.print();
            Console.Read();
        }
    }
}
