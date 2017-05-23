using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGRASP
{
    class Grasp
    {
        public double alpha;
        public int iterations;

        public Grasp(double alpha, int iterations)
        {
            this.alpha = alpha;
            this.iterations = iterations;
        }

        public List<GraspOutput> GraspAlgorithm()
        {
            //
            List<GraspInput> data = new List<GraspInput>();
            

            //Inicializar el conjunto de soluciones
            List<GraspOutput> solutions = new List<GraspOutput>();

            for (int i = 0; i < iterations; i++)
            {
                //
            }

            return solutions;
        }
    }
}
