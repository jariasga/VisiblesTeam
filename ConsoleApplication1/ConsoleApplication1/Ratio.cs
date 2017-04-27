using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Ratio
    {
        public int process_product_id;
        public string process_product_name;
        public double breakage;
        public double time;

        public Ratio(string process_product_name, int process_product, double breakage, double time)
        {
            this.process_product_name = process_product_name;
            this.process_product_id = process_product;            
            this.breakage = breakage;
            this.time = time;
        }

        public void print()
        {
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

        public static Predicate<Ratio> byProcessProductId(int process_product)
        {
            return delegate (Ratio ratio)
            {
                return ratio.process_product_id == process_product;
            };
        }
    }
}
