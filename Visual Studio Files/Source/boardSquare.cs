using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;


namespace ReinforcementLearning
{
    class BoardSquare
    {
        //true = beer can is here
        public bool beer_can_present;
        public bool bender_present;

        public List<int[]> walls;

        Random random;

        public PictureBox pictureData;

        public BoardSquare(Random random_to_set)
        {
            random = random_to_set;
            walls = new List<int[]>();
            bender_present = false;
        }

        public void randomize_beer_presence()
        {
            if (random.Next(1, 101) < 50)
                beer_can_present = true;
            else
                beer_can_present = false;
        }

        public bool check_wall(int x, int y)
        {
            return walls.Any(p => p.SequenceEqual(new int[] { x, y }));
        }

        public void setPicture()
        {
            if (beer_can_present && bender_present)
                pictureData.Image = Properties.Resources.bender_and_beer;
            else if (beer_can_present)
                pictureData.Image = Properties.Resources.beer;
            else if (bender_present)
                pictureData.Image = Properties.Resources.bender;
            else
                pictureData.Image = null;
        }
    }
}
