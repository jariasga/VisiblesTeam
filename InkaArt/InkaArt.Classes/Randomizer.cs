using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Classes
{
    public class Randomizer
    {
        private static Random random = new Random();

        public static int NextNumber(int lower_bound, int higher_bound)
        {
             return random.Next(lower_bound, higher_bound + 1);
        }
    }
}
