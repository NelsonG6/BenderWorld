using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    //Moves in this program created from this object:
    //4 movements with grab false
    //one no-movement with grab true

    class Move
    {   //This class defines the moves bender can make.
        public int[] grid_adjustment; //The motion bender makes from this movement

        public bool grab; //determines if we grab the can. This is done after the move step.
        //public string name_of_move; //The description of the move, which is used to translate this move into actions when the result isn't movement-based.'
        //Grab is a non-movement based move, in this case.

        public string name_of_move;

        //might not need this constructor
        public Move()
        {
            grid_adjustment = new int[2] { 0, 0 };
            name_of_move = "Initialized and not set";
        }

        public Move(int set_x, int set_y, string string_to_set)
        {
            grid_adjustment[0] = set_x;
            grid_adjustment[1] = set_y;

            name_of_move = string_to_set;
        }

        public Move(Move set_from)
        {
            grid_adjustment[0] = set_from.grid_adjustment[0];
            grid_adjustment[1] = set_from.grid_adjustment[1];

            name_of_move = set_from.name_of_move;
        }
    }
}
