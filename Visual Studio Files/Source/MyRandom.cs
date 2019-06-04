using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    static class MyRandom
    {
        static Random random;

        static MyRandom()
        {
            random = new Random(); //Seed random for the duration of the program
        }

        public static void set_random (Random to_set)
        {
            random = to_set;
        }

        public static int Next(int a, int b)
        {
            return random.Next(a, b);
        }
    }
}
