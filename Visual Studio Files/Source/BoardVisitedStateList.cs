using System.Collections.Generic;

namespace ReinforcementLearning
{
    static class BoardVisitedStateList
    {
        static private readonly BoardVisitedState last_state;
        static private readonly BoardVisitedState explored_state;
        static private readonly BoardVisitedState unexplored_state;

        public static List<BoardVisitedState> list;

        static BoardVisitedStateList()
        {
            last_state = new BoardVisitedState("Previous state");
            explored_state = new BoardVisitedState("Explored state");
            unexplored_state = new BoardVisitedState("Unexplored state");

            list = new List<BoardVisitedState>();
            list.Add(last_state);
            list.Add(explored_state);
            list.Add(unexplored_state);
        }

        static public BoardVisitedState last()
        {
            return last_state;
        }

        static public BoardVisitedState explored()
        {
            return explored_state;
        }

        static public BoardVisitedState unexplored()
        {
            return unexplored_state;
        }
    }
}
