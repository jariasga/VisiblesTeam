using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGRASP
{
    class Program
    {
        static void Main(string[] args)
        {
            Grasp grasp = new Grasp(0.2, 1000);
            grasp.GraspAlgorithm();
        }
    }
}
