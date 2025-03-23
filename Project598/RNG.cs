using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project598
{
    public static class RNG
    {
        private static Random _random = new Random();

        public static int GetInt(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
