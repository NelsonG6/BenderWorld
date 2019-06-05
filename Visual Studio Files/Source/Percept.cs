using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    //This class is just a wrapper for one of three possible strings, but it helps enforce the type.
    class Percept
    {
        string percept_data;

        public Percept()
        {
            percept_data = "empty";
        }

        public Percept(string to_set)
        {
            percept_data = to_set;
        }

        public string get_string_data()
        {
            return percept_data;
        }
    }
}
