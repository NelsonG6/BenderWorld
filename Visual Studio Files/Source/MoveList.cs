using System.Collections.Generic;

namespace ReinforcementLearning
{
    static class MoveList
    {
        readonly static Move left_move;
        readonly static Move right_move;
        readonly static Move up_move;
        readonly static Move down_move;
        readonly static Move grab_move;

        readonly static List<Move> list_of_moves;

        static MoveList()
        {
            //These should be the only instances of moves created in the program
            //Q moves will be generated frequently, however
            left_move = new Move();
            left_move.grid_adjustment[0] = -1;
            left_move.grid_adjustment[1] = 0;
            left_move.grab = false;
            left_move.name_of_move = "Left";

            right_move = new Move();
            right_move.grid_adjustment[0] = 1;
            right_move.grid_adjustment[1] = 0;
            right_move.grab = false;
            right_move.name_of_move = "Right";

            up_move = new Move();
            up_move.grid_adjustment[0] = 0;
            up_move.grid_adjustment[1] = 1;
            up_move.grab = false;
            up_move.name_of_move = "up";

            down_move = new Move();
            down_move.grid_adjustment[0] = 0;
            down_move.grid_adjustment[1] = -1;
            down_move.grab = false;
            down_move.name_of_move = "down";

            grab_move = new Move();
            grab_move.grid_adjustment[0] = 0;
            grab_move.grid_adjustment[1] = 0;
            grab_move.grab = true;
            grab_move.name_of_move = "Grab";

            list_of_moves = new List<Move>();

            list_of_moves.Add(left_move);
            list_of_moves.Add(right_move);
            list_of_moves.Add(up_move);
            list_of_moves.Add(down_move);
            list_of_moves.Add(grab_move);
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
            return list_of_moves;
        }
    }


}
