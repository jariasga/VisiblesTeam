using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class RandomExtensions
    {
        public static double NextDouble(
        this Random random,
        double minValue,
        double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }

        public static int getRandom(int min, int max)
        {
            Random ran = new Random(Guid.NewGuid().GetHashCode());
            return ran.Next(min, max);
        }
    }

}
