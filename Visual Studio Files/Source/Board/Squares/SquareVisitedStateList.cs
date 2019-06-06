using System.Collections.Generic;

namespace ReinforcementLearning
{
    static class SquareVisitedStateList
    {
        static private readonly SquareVisitedState last_state;
        static private readonly SquareVisitedState explored_state;
        static private readonly SquareVisitedState unexplored_state;

        public static List<SquareVisitedState> list;

        static SquareVisitedStateList()
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
    }
}
