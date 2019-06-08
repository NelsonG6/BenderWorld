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

        static private readonly SquareVisitedState last_state;
        static private readonly SquareVisitedState explored_state;
        static private readonly SquareVisitedState unexplored_state;

        public static List<SquareVisitedState> list;

        static SquareVisitedState()
        {
            last_state = new SquareVisitedState("Previous state");
            explored_state = new SquareVisitedState("Explored state");
            unexplored_state = new SquareVisitedState("Unexplored state");

            list = new List<SquareVisitedState>();
            list.Add(last_state);
            list.Add(explored_state);
            list.Add(unexplored_state);
        }

        static public SquareVisitedState last()
        {
            return last_state;
        }

        static public SquareVisitedState explored()
        {
            return explored_state;
        }

        static public SquareVisitedState unexplored()
        {
            return unexplored_state;
        }

        public SquareVisitedState(string to_set)
        {
            state_data = to_set;
        }
    }
}
