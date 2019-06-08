namespace ReinforcementLearning
{
    //This version of SquareBase will have walls
    class BoardSquare : BaseSquare
    {
        //This stores the wall data for the square
        //It will determine if there is one wall, two walls, or no walls. Only a single wall object is needed.
        public BoardSquareWalls walls;

        public BoardSquare() : base()
        {
            walls = null;
        }

        //Boardsquare cannot be constructed from a SquareBase, because it will lose its walls.

        public BoardSquare(BoardSquare set_from) : base(set_from)
        {
            walls = set_from.walls;
        }

        public bool check_if_walls_prevent_move(Move move_to_check)
        {
            //Check walls
            foreach (var i in walls.restricted_moves)
            {
                if (i == move_to_check)
                    return true;
            }

            return false;
        }

        public void copy_status(BoardSquare copy_from)
        {
            beer_can_present = copy_from.beer_can_present;
            bender_present = copy_from.bender_present;
            visited_state = copy_from.visited_state;

            walls = copy_from.walls;
        }

        public void randomize_beer_presence()
        {
            if (MyRandom.Next(1, 101) < 50)
                beer_can_present = true;
            else
                beer_can_present = false;
        }
    }
}
