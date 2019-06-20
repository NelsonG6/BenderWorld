using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenderAndURL
{
    //Moves in this program created from this object:
    //4 movements with grab false
    //one no-movement with grab true

    class Move : IComparable<Move>, IEqualityComparer<Move>
    {   //This class defines the moves bender can make.
        public int[] gridAdjustment; //The motion bender makes from this movement

        public readonly static Move Left;
        public readonly static Move Right;
        public readonly static Move Up;
        public readonly static Move Down;
        public readonly static Move Grab;
        public readonly static Move UpLeft;
        public readonly static Move UpRight;
        public readonly static Move DownLeft;
        public readonly static Move DownRight;
        public readonly static Move Wait;

        public readonly static List<Move> HorizontalMovesAndGrab;

        public readonly static List<Move> AllMoves;

        public readonly static List<Move> CardinalMoves;

        public readonly static List<Move> Diagonals;

        public bool to_grab; //determines if we grab the can. This is done after the move step.
        //public string name_ofMove; //The description of the move, which is used to translate this move into actions when the result isn't movement-based.'
        //Grab is a non-movement based move, in this case.

        public string shortName; //Shorthand name of move
        public string longName; //Used for the status box display

        public int order; //This is the order we display the boxes in, and the order we encode the state as

        static Move()
        {
            //These should be the only instances of moves created in the program
            //Q moves will be generated frequently, however
            int move_order = 0;

            Diagonals = new List<Move>();

            Left = new Move();
            Left.gridAdjustment[0] = -1;
            Left.gridAdjustment[1] = 0;
            Left.to_grab = false;
            Left.shortName = "L";
            Left.longName = "Left";
            Left.order = ++move_order;

            Right = new Move();
            Right.gridAdjustment[0] = 1;
            Right.gridAdjustment[1] = 0;
            Right.to_grab = false;
            Right.shortName = "R";
            Right.longName = "Right";
            Right.order = ++move_order;

            Down = new Move();
            Down.gridAdjustment[0] = 0;
            Down.gridAdjustment[1] = -1;
            Down.to_grab = false;
            Down.shortName = "D";
            Down.longName = "Down";
            Down.order = ++move_order;

            Up = new Move();
            Up.gridAdjustment[0] = 0;
            Up.gridAdjustment[1] = 1;
            Up.to_grab = false;
            Up.shortName = "Up";
            Up.longName = "Up";
            Up.order = ++move_order;

            Grab = new Move();
            Grab.gridAdjustment[0] = 0;
            Grab.gridAdjustment[1] = 0;
            Grab.to_grab = true;
            Grab.shortName = "Gr";
            Grab.longName = "Grab";
            Grab.order = ++move_order;

            UpLeft = new Move();
            UpLeft.gridAdjustment[0] = -1;
            UpLeft.gridAdjustment[1] = 1;
            UpLeft.to_grab = false;
            UpLeft.shortName = "UL";
            UpLeft.longName = "Up-Left";
            UpLeft.order = ++move_order;

            UpRight = new Move();
            UpRight.gridAdjustment[0] = 1;
            UpRight.gridAdjustment[1] = 1;
            UpRight.to_grab = true;
            UpRight.shortName = "UR";
            UpRight.longName = "Up-Right";
            UpRight.order = ++move_order;

            DownLeft = new Move();
            DownLeft.gridAdjustment[0] = -1;
            DownLeft.gridAdjustment[1] = -1;
            DownLeft.to_grab = true;
            DownLeft.shortName = "DL";
            DownLeft.longName = "Down-Left";
            DownLeft.order = ++move_order;

            DownRight = new Move();
            DownRight.gridAdjustment[0] = 1;
            DownRight.gridAdjustment[1] = -1;
            DownRight.to_grab = true;
            DownRight.shortName = "DR";
            DownRight.longName = "Down-Right";
            DownRight.order = ++move_order;

            HorizontalMovesAndGrab = new List<Move>();
            CardinalMoves = new List<Move>();

            CardinalMoves.Add(Left);
            CardinalMoves.Add(Right);
            CardinalMoves.Add(Up);
            CardinalMoves.Add(Down);

            HorizontalMovesAndGrab.AddRange(CardinalMoves);
            HorizontalMovesAndGrab.Add(Grab);

            AllMoves = new List<Move>();
            AllMoves.AddRange(HorizontalMovesAndGrab.ToArray());
            AllMoves.Add(UpLeft);
            AllMoves.Add(UpRight);
            AllMoves.Add(DownLeft);
            AllMoves.Add(DownRight);

            Wait = new Move();
            Wait.gridAdjustment[0] = 0;
            Wait.gridAdjustment[1] = 0;
            Wait.to_grab = false;
            Wait.shortName = "W";
            Wait.longName = "Wait";
            Wait.order = ++move_order;

            Diagonals.Add(UpLeft);
            Diagonals.Add(UpRight);
            Diagonals.Add(DownLeft);
            Diagonals.Add(DownRight);
        }

        public static void Initialize()
        {

        }

        //might not need this constructor
        public Move()
        {
            gridAdjustment = new int[2] { 0, 0 };
            shortName = "Initialized and not set";
            longName = "Initialized and not set";
        }

        public Move(Move setFrom)
        {
            gridAdjustment[0] = setFrom.gridAdjustment[0];
            gridAdjustment[1] = setFrom.gridAdjustment[1];

            shortName = setFrom.shortName;
        }

        public int CompareTo(Move compareFrom)
        {
            return longName.CompareTo(compareFrom.longName);
        }

        override public string ToString()
        {
            return longName;
        }

        public bool Equals(Move first, Move second)
        {
            if (first.GetHashCode() == second.GetHashCode())
                return true;
            return false;
        }

        public int GetHashCode(Move check)
        {
            return check.longName.GetHashCode();
        }
    }
}
