﻿using System;
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

        public string short_name; //Shorthand name of move
        public string long_name; //Used for the status box display

        //might not need this constructor
        public Move()
        {
            grid_adjustment = new int[2] { 0, 0 };
            short_name = "Initialized and not set";
            long_name = "Initialized and not set";
        }

        public Move(int set_x, int set_y, string short_name_set)
        {
            grid_adjustment[0] = set_x;
            grid_adjustment[1] = set_y;

            short_name = short_name_set;
        }

        public Move(Move set_from)
        {
            grid_adjustment[0] = set_from.grid_adjustment[0];
            grid_adjustment[1] = set_from.grid_adjustment[1];

            short_name = set_from.short_name;
        }
    }
}
