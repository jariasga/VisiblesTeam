using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Ratio
    {
        public int process;
        public int product;
        public double breakage;
        public double time;

        public Ratio(int process, int product, double breakage, double time)
        {
            this.process = process;
            this.product = product;
            this.breakage = breakage;
            this.time = time;
        }

        public void print()
        {
            Console.WriteLine(process + " - " + product);
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

        public static Predicate<Ratio> byProcess(int process)
        {
            return delegate (Ratio ratio)
            {
                return ratio.process == process;
            };
        }

        static Predicate<Ratio> byProduct(int product)
        {
            return delegate (Ratio ratio)
            {
                return ratio.product == product;
            };
        }
    }
}
