using System.Collections.Generic;

namespace BenderAndURL
{
    class Walls
    {
        //A wall is a list of one to two moves that reflect which moves the user cannot do at the square that contains this wall.
        //It is one to two moves because the board is an open square, so there are only at most two corners.
        public HashSet<Move> RestrictedMoves;

        public string name;

        public static readonly Walls Top;
        public static readonly Walls Bottom;
        public static readonly Walls Left;
        public static readonly Walls Right;
        public static readonly Walls TopLeft; //top left corner wall
        public static readonly Walls TopRight;
        public static readonly Walls BottomLeft;
        public static readonly Walls BottomRight; //bottom right corner
        public static readonly Walls EmptyWallData;

        static Walls()
        {
            //Three moves here
            Move[] leftMoves = new Move[] { Move.Left, Move.UpLeft, Move.DownLeft };
            Move[] rightMoves = new Move[] { Move.Right, Move.UpRight, Move.DownRight };
            Move[] upMoves = new Move[] { Move.Up, Move.UpRight, Move.UpLeft };
            Move[] downMoves = new Move[] { Move.Down, Move.DownRight, Move.DownLeft };

            Top = new Walls(upMoves);
            Bottom = new Walls(downMoves);
            Left = new Walls(leftMoves);
            Right = new Walls(rightMoves);

            //five moves here
            //Topleft
            HashSet<Move> list = new HashSet<Move>();
            list.UnionWith(Top.RestrictedMoves);
            list.UnionWith(Left.RestrictedMoves);
            TopLeft = new Walls(GetArray(list));

            //Topright
            list = new HashSet<Move>();
            list.UnionWith(upMoves);
            list.UnionWith(rightMoves);
            TopRight = new Walls(GetArray(list));

            list = new HashSet<Move>();
            list.UnionWith(downMoves);
            list.UnionWith(leftMoves);
            BottomLeft = new Walls(GetArray(list));

            list = new HashSet<Move>();
            list.UnionWith(downMoves);
            list.UnionWith(rightMoves);
            BottomRight = new Walls(GetArray(list));

            EmptyWallData = new Walls();
        }

        public static void Initialize()
        {

        }

        public Walls()
        {
            RestrictedMoves = new HashSet<Move>(); //Leave the hashset empty
            name = "Empty walls";
        }

        public Walls(Move[] addFrom)
        {
            List<Move> presentCardinals = new List<Move>();
            foreach (var i in addFrom)
            {
                if(Move.CardinalMoves.Contains(i))
                    presentCardinals.Add(i);
            }

            string wallName = "";

            foreach(var i in presentCardinals)
            {
                wallName += i.longName;
            }

            RestrictedMoves = new HashSet<Move>();
            if (presentCardinals.Count <= 1)
            
                name = "One sided wall: " + wallName + "]";
            
            else
            
                name = "Two sided wall: " + wallName + "]";
            
            
            foreach (var i in addFrom)
            {
                RestrictedMoves.Add(i);

            }

        }

        private static Move[] GetArray(HashSet<Move> to_search)
        {
            List<Move> to_return = new List<Move>();

            foreach (var i in to_search)
            {
                to_return.Add(i);
            }

            return to_return.ToArray();
        }
        

    }
}
