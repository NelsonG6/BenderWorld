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

        public readonly static List<Move> list;

        static MoveList()
        {
            //These should be the only instances of moves created in the program
            //Q moves will be generated frequently, however
            left_move = new Move();
            left_move.grid_adjustment[0] = -1;
            left_move.grid_adjustment[1] = 0;
            left_move.grab = false;
            left_move.short_name = "L";
            left_move.long_name = "Left";
            left_move.order = 1;

            right_move = new Move();
            right_move.grid_adjustment[0] = 1;
            right_move.grid_adjustment[1] = 0;
            right_move.grab = false;
            right_move.short_name = "R";
            right_move.long_name = "Right";
            right_move.order = 2;

            down_move = new Move();
            down_move.grid_adjustment[0] = 0;
            down_move.grid_adjustment[1] = -1;
            down_move.grab = false;
            down_move.short_name = "D";
            down_move.long_name = "Down";
            down_move.order = 3;

            up_move = new Move();
            up_move.grid_adjustment[0] = 0;
            up_move.grid_adjustment[1] = 1;
            up_move.grab = false;
            up_move.short_name = "Up";
            up_move.long_name = "Up";
            up_move.order = 4;

            grab_move = new Move();
            grab_move.grid_adjustment[0] = 0;
            grab_move.grid_adjustment[1] = 0;
            grab_move.grab = true;
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
    }


}
