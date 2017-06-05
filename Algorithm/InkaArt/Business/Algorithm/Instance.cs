﻿using InkaArt.Data.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Algorithm
{
    class Instance
    {
        public List<Worker> workers;
        //public List<Index> ratios; 
        public double shift_duration;               // minutos en un turno

        // time
        public int start_time;                      // milisegundos
        public int limit_time;                      // 1 000 * 60 * 5 (maximo 5 miutos)

        // processes
        public int processes_num;
        public List<int> processes_positions;       // puestos de trabajo por proceso

        // products
        public int products_num;
        public List<float> products_weights;        // pesos de productos para la funcion objetivo

        // processes x products
        public int processes_products_num;
        public List<int> processes_products;        // los ids de procesos productos

        // ratios
        public double breakage_weight;              // para los indices de perdida
        public double time_weight;

        public Instance(string workers_filename, string ratios_filename)
        {
            // DESDE LA BASE DE DATOS

            // time
            start_time = Environment.TickCount;
            limit_time = 300000;                    // 1 000 * 60 * 5 (maximo 5 miutos)            

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
            breakage_weight = 0.5;
            time_weight = 0.5;
            shift_duration = 8*60;            
        }

        /* Devuelve la lista de procesos productos que existen para un proceso */
        public List<int> getProcessProducts(int i)
        {
            List<int> list = new List<int>();

            if (i == 0)
            {
                list.Add(20);       // tallado de piedras
                list.Add(30);       // tallado de retablos
            }
            else if (i == 1)
            {
                list.Add(10);       // modelado de huacos
            }
            else if (i == 2)
            {
                list.Add(12);       // horneado de huacos
            }
            else if (i == 3)
            {
                list.Add(11);       // pintado de huacos
                list.Add(31);       // pintado de retablos
            }

            return list;
        }

        public List<int> getBestSolution(List<int[]> solutions)
        {
            int best_fitness = int.MaxValue;
            List<int> temp;
            List<int> best = new List<int>();

            foreach(int[] solution in solutions)
            {
                //temp = new List<int>(solution);
                //if (best_fitness > getFitness(temp))
                //    best = temp;
            }

            return best;
        }

        /* Predicado de solucion */
        public static Predicate<int> byProcessProduct(int process_product_id)
        {
            return delegate (int assignment)
            {
                return assignment == process_product_id;
            };
        }

        /* Predicado de solucion */
        public static Predicate<int> byProduct(int product_id)
        {
            // ids: 0 Huacos, 1 piedras, 2 retablos
            return delegate (int assignment)
            {
                return (assignment / 10) == (product_id + 1);
            };
        }

    }
}