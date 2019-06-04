using System.Collections.Generic;
using System.Linq;


namespace ReinforcementLearning
{
    public class BoardSquare
    {
        //The class for storing the data relevant for each square
        public bool beer_can_present;
        public bool bender_present; //Actually dont even think this is being used right now, not sure

        public List<int[]> walls;

        public BoardSquare()
        {
            walls = new List<int[]>();
            bender_present = false;
            beer_can_present = false;
        }

        public BoardSquare(BoardSquare set_from)
        {
            //Should clone a list of the walls
            walls = set_from.walls.Select(item => (int[])item.Clone()).ToList();

            bender_present = set_from.bender_present;
            beer_can_present = set_from.beer_can_present;
        }


        public void randomize_beer_presence()
        {
            if (MyRandom.Next(1, 101) < 50)
                beer_can_present = true;
            else
                beer_can_present = false;
        }

        public bool check_wall(int x, int y)
        {
            return walls.Any(p => p.SequenceEqual(new int[] { x, y }));
        }


        public void copy_status(BoardSquare copy_from)
        {
            beer_can_present = copy_from.beer_can_present;
            bender_present = copy_from.bender_present;
        }

    }
}
