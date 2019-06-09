using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    static class ReinforcementFactors
    {
        public static Dictionary<MoveResult, double> list;

        static ReinforcementFactors()
        {
            list = new Dictionary<MoveResult, double>(); //initialize reinforcement factor list
            list.Clear();
            list.Add(MoveResult.move_hit_wall(), -5);
            list.Add(MoveResult.can_collected(), 10);
            list.Add(MoveResult.can_missing(), -1);
            list.Add(MoveResult.move_successful(), 0);
        }
    }
}
