using System.Collections.Generic;
using System.Linq;


namespace ReinforcementLearning
{
    class BaseSquare
    {
        //The class for storing the data relevant for each square
        public bool beer_can_present;
        public bool bender_present; //Actually dont even think this is being used right now, not sure        

        public Dictionary<Unit, bool> units_present; //A list of units we contain in this square
        //Even though only one unit is possible at a time, this is necessary so we can store a presence value for either unit.

        public SquareVisitedState visited_state; //Using a string to store one of three values: last move, unexplored, explored

        public BaseSquare()
        {
            bender_present = false;
            beer_can_present = false;
            visited_state = SquareVisitedState.unexplored(); //Deafult
            units_present = new Dictionary<Unit, bool>();
        }

        public BaseSquare(BaseSquare set_from)
        {
            bender_present = set_from.bender_present;
            beer_can_present = set_from.beer_can_present;
            visited_state = set_from.visited_state;
        }

        public void copy_status(BaseSquare copy_from)
        {
            beer_can_present = copy_from.beer_can_present;
            bender_present = copy_from.bender_present;
        }
    }
}
