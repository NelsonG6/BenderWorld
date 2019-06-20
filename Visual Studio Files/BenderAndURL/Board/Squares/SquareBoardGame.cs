namespace BenderAndURL
{
    //This version of SquareBase will have walls
    class SquareBoardGame : SquareBoardBase
    {
        //This stores the wall data for the square
        //It will determine if there is one wall, two walls, or no walls. Only a single wall object is needed.
        public Walls walls;

        public SquareBoardGame(int x, int y) : base(x, y)
        {
            walls = null;
        }

        //Boardsquare cannot be constructed from a SquareBase, because it will lose its walls.

        public SquareBoardGame(SquareBoardGame setFrom) : base(setFrom)
        {
            walls = setFrom.walls;
        }

        public bool CheckIfWallsPreventMove(Move moveToCheck)
        {
            //Check walls
            foreach (var i in walls.RestrictedMoves)
            {
                if (i == moveToCheck)
                    return true;
            }

            return false;
        }

        public void copy_status(SquareBoardGame copyFrom)
        {
            copyStatus((SquareBoardBase)copyFrom);
            walls = copyFrom.walls;
        }

        public void randomizeBeerPresence()
        {
            if (MyRandom.Next(1, 101) < 50)
                beerCanPresent = true;
            else
                beerCanPresent = false;
        }
    }
}
