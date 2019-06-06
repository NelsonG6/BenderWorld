using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    class SquareVisitedState
    {
        private readonly string state_data;

        public SquareVisitedState(string to_set)
        {
            state_data = to_set;
        }
    }
}
