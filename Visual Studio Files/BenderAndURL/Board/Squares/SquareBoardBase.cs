using System.Collections.Generic;
using System.Linq;


namespace BenderAndURL
{
    class SquareBoardBase
    {
        //The class for storing the data relevant for each square

        public bool beerCanPresent;

        //This will only store Unit.Bender and unit.Url, no instances that are on the board
        public Dictionary<UnitBase, bool> UnitsPresent; //A list of units we contain in this square
        //Even though only one unit is possible at a time, this is necessary so we can store a presence value for either unit.

        public SquareVisitedState visitedState; //Using a string to store one of three values: last move, Unexplored, explored

        public int x;
        public int y;

        public SquareBoardBase(int setX, int setY)
        {
            visitedState = SquareVisitedState.Unexplored; //Deafult

            //Initialize units present
            UnitsPresent = new Dictionary<UnitBase, bool>();
            foreach(var i in UnitType.List)
            {
                UnitsPresent.Add(i, false);
            }

            x = setX;
            y = setY;
        }

        public SquareBoardBase(SquareBoardBase setFrom)
        {
            copyStatus(setFrom);
        }

        //Pretty sure this isn't necessary since a constructor can just do this
        public void copyStatus(SquareBoardBase copyFrom)
        {
            UnitsPresent = new Dictionary<UnitBase, bool>();
            foreach (var i in copyFrom.UnitsPresent)
            {
                UnitsPresent.Add(i.Key, i.Value);
            }

            visitedState = copyFrom.visitedState;
            beerCanPresent = copyFrom.beerCanPresent;
            x = copyFrom.x;
            y = copyFrom.y;
        }
    }
}
