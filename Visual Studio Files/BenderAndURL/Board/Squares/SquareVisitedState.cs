using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenderAndURL
{
    class SquareVisitedState
    {
        private readonly string stateData;

        static public readonly SquareVisitedState Last;
        static public readonly SquareVisitedState Explored;
        static public readonly SquareVisitedState Unexplored;

        public static List<SquareVisitedState> list;

        static SquareVisitedState()
        {
            Last = new SquareVisitedState("Previous state");
            Explored = new SquareVisitedState("Explored state");
            Unexplored = new SquareVisitedState("Unexplored state");

            list = new List<SquareVisitedState>();
            list.Add(Last);
            list.Add(Explored);
            list.Add(Unexplored);
        }

        public SquareVisitedState(string toSet)
        {
            stateData = toSet;
        }
    }
}
