using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    //This class handles the types of results we get after applying a move to the board.
    class MoveResult
    {
        public string result_data;

        public MoveResult(string to_set)
        {
            result_data = to_set;
        }
    }
}
