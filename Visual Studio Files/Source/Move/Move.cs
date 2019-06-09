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

    class Move : IComparable<Move>
    {   //This class defines the moves bender can make.
        public int[] grid_adjustment; //The motion bender makes from this movement

        readonly static Move left_move;
        readonly static Move right_move;
        readonly static Move up_move;
        readonly static Move down_move;
        readonly static Move grab_move;

        public readonly static List<Move> list;

        public bool to_grab; //determines if we grab the can. This is done after the move step.
        //public string name_of_move; //The description of the move, which is used to translate this move into actions when the result isn't movement-based.'
        //Grab is a non-movement based move, in this case.

        public string short_name; //Shorthand name of move
        public string long_name; //Used for the status box display

        public int order; //This is the order we display the boxes in, and the order we encode the state as

        static Move()
        {
            //These should be the only instances of moves created in the program
            //Q moves will be generated frequently, however
            left_move = new Move();
            left_move.grid_adjustment[0] = -1;
            left_move.grid_adjustment[1] = 0;
            left_move.to_grab = false;
            left_move.short_name = "L";
            left_move.long_name = "Left";
            left_move.order = 1;

            right_move = new Move();
            right_move.grid_adjustment[0] = 1;
            right_move.grid_adjustment[1] = 0;
            right_move.to_grab = false;
            right_move.short_name = "R";
            right_move.long_name = "Right";
            right_move.order = 2;

            down_move = new Move();
            down_move.grid_adjustment[0] = 0;
            down_move.grid_adjustment[1] = -1;
            down_move.to_grab = false;
            down_move.short_name = "D";
            down_move.long_name = "Down";
            down_move.order = 3;

            up_move = new Move();
            up_move.grid_adjustment[0] = 0;
            up_move.grid_adjustment[1] = 1;
            up_move.to_grab = false;
            up_move.short_name = "Up";
            up_move.long_name = "Up";
            up_move.order = 4;

            grab_move = new Move();
            grab_move.grid_adjustment[0] = 0;
            grab_move.grid_adjustment[1] = 0;
            grab_move.to_grab = true;
            grab_move.short_name = "Gr";
            grab_move.long_name = "Grab";
            grab_move.order = 5;

            list = new List<Move>();

            list.Add(left_move);
            list.Add(right_move);
            list.Add(up_move);
            list.Add(down_move);
            list.Add(grab_move);
        }

        public static Move left()
        {
            return left_move;
        }

        public static Move right()
        {
            return right_move;
        }

        public static Move up()
        {
            return up_move;
        }

        public static Move down()
        {
            return down_move;
        }

        public static Move grab()
        {
            return grab_move;
        }

        public static List<Move> get_moves()
        {
            return list;
        }


        //might not need this constructor
        public Move()
        {
            grid_adjustment = new int[2] { 0, 0 };
            short_name = "Initialized and not set";
            long_name = "Initialized and not set";
        }

        public Move(Move set_from)
        {
            grid_adjustment[0] = set_from.grid_adjustment[0];
            grid_adjustment[1] = set_from.grid_adjustment[1];

            short_name = set_from.short_name;
        }

        public int CompareTo(Move compare_from)
        {
            return this.long_name.CompareTo(compare_from.long_name);
        }

        override public string ToString()
        {
            return long_name;
        }
    }
}
