using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Instance
    {
        public List<Worker> workers;
        public List<Ratio> ratios;

        // processes
        public int processes_num;        
        public List<int> processes_positions;       // puestos de trabajo por proceso
        
        // products
        public int products_num;
        public List<float>  products_weights;       // pesos de productos para la funcion objetivo

        // processes x products
        public int processes_products_num;
        public List<int> processes_products;        // los ids de procesos productos

        // ratios
        public int breakage_weight;                 // para los indices de perdida
        public int time_weight;

        public Instance()
        {
            // processes
            processes_num = 4;
            processes_positions = new List<int>(4);
            processes_positions.Add(10);            // tallado
            processes_positions.Add(10);            // modelado
            processes_positions.Add(10);            // horneado
            processes_positions.Add(10);            // pintado

            // products
            products_num = 3;
            products_weights = new List<float>(products_num);
            products_weights.Add(1);                // huacos
            products_weights.Add(1);                // piedras
            products_weights.Add(1);                // retablos

            // processes products
            processes_products_num = 7;
            processes_products = new List<int>(processes_products_num);
            processes_products.Add(0);              // no asignado
            processes_products.Add(10);             // modelado de huacos
            processes_products.Add(11);             // pintado de huacos
            processes_products.Add(12);             // horneado de huacos
            processes_products.Add(20);             // tallado de piedras
            processes_products.Add(30);             // tallado de retablos
            processes_products.Add(31);             // pintado de retablos

            // ratios
            breakage_weight = 1;
            time_weight = 1;

            workers = Worker.read("Workers.csv");
            ratios = Ratio.read("Ratios.csv", workers);
        }

        
    }
}
