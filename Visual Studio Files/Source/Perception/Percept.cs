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
        public string percept_data;
        
        //This might not be necessary

        public Percept()
        {
            percept_data = "empty";
            //deleted the move the percept was storing
        }

        public Percept(string to_set)
        {
            percept_data = to_set;
        }

        override public string ToString()
        {
            return percept_data;
        }
    }
}
