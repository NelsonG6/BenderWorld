using System.Collections.Generic;

namespace ReinforcementLearning
{
    class BoardSquareWalls
    {
        //A wall is a list of one to two moves that reflect which moves the user cannot do at the square that contains this wall.
        //It is one to two moves because the board is an open square, so there are only at most two corners.
        public HashSet<Move> restricted_moves;

        public string name;

        private static readonly BoardSquareWalls top_wall_data;
        private static readonly BoardSquareWalls bottom_wall_data;
        private static readonly BoardSquareWalls left_wall_data;
        private static readonly BoardSquareWalls right_wall_data;
        private static readonly BoardSquareWalls top_left_wall_data; //top left corner wall
        private static readonly BoardSquareWalls top_right_wall_data;
        private static readonly BoardSquareWalls bottom_left_wall_data;
        private static readonly BoardSquareWalls bottom_right_wall_data; //bottom right corner
        private static readonly BoardSquareWalls empty_wall_data;

        static BoardSquareWalls()
        {
            top_wall_data = new BoardSquareWalls(Move.up());
            bottom_wall_data = new BoardSquareWalls(Move.down());
            left_wall_data = new BoardSquareWalls(Move.left());
            right_wall_data = new BoardSquareWalls(Move.right());
            top_left_wall_data = new BoardSquareWalls(Move.left(), Move.up());
            top_right_wall_data = new BoardSquareWalls(Move.right(), Move.up());
            bottom_left_wall_data = new BoardSquareWalls(Move.left(), Move.down());
            bottom_right_wall_data = new BoardSquareWalls(Move.right(), Move.down());
            empty_wall_data = new BoardSquareWalls();
        }

        public static BoardSquareWalls top_wall()
        {
            return top_wall_data;
        }
        public static BoardSquareWalls bottom_wall()
        {
            return bottom_wall_data;
        }
        public static BoardSquareWalls left_wall()
        {
            return left_wall_data;
        }
        public static BoardSquareWalls right_wall()
        {
            return right_wall_data;
        }
        public static BoardSquareWalls top_left_wall()
        {
            return top_left_wall_data;
        }
        public static BoardSquareWalls top_right_wall()
        {
            return top_right_wall_data;
        }
        public static BoardSquareWalls bottom_left_wall()
        {
            return bottom_left_wall_data;
        }
        public static BoardSquareWalls bottom_right_wall()
        {
            return bottom_right_wall_data;
        }
        public static BoardSquareWalls empty_wall()
        {
            return empty_wall_data;
        }

        public BoardSquareWalls()
        {
            restricted_moves = new HashSet<Move>(); //Leave the hashset empty
            name = "Empty walls";
        }

        public BoardSquareWalls(Move move_to_set)
        {
            restricted_moves = new HashSet<Move>();
            restricted_moves.Add(move_to_set);
            name = "One sided wall: " + move_to_set.short_name;
        }

        public BoardSquareWalls(Move move_a, Move move_b)
        {
            restricted_moves = new HashSet<Move>();
            restricted_moves.Add(move_a);
            restricted_moves.Add(move_b);
            name = "Two sided wall: " + move_a.short_name + "+" + move_b.short_name;
        }
    }
}
