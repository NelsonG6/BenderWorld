using System.Collections.Generic;

namespace ReinforcementLearning
{
    class Wall
    {
        //A wall is a list of one to two moves that reflect which moves the user cannot do at the square that contains this wall.
        //It is one to two moves because the board is an open square, so there are only at most two corners.
        public HashSet<Move> restricted_moves;

        public string name;



        public Wall()
        {
            restricted_moves = new HashSet<Move>(); //Leave the hashset empty
            name = "Empty walls";
        }

        public Wall(Move move_to_set)
        {
            restricted_moves = new HashSet<Move>();
            restricted_moves.Add(move_to_set);
            name = "One sided wall: " + move_to_set.short_name;
        }

        public Wall(Move move_a, Move move_b)
        {
            restricted_moves = new HashSet<Move>();
            restricted_moves.Add(move_a);
            restricted_moves.Add(move_b);
            name = "Two sided wall: " + move_a.short_name + "+" + move_b.short_name;
        }
    }
}
