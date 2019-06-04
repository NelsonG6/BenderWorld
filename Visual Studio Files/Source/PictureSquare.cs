using System.Windows.Forms;
using System.Linq;
using System;
using System.Collections.Generic;

namespace ReinforcementLearning
{
    class PictureSquare : BoardSquare
    {
        public PictureBox pictureData;

        public static Dictionary<string, System.Drawing.Bitmap> backgrounds;

        public PictureSquare() : base()
        {
            pictureData = null;
        }

        public void setPicture()
        {
            //Set can and/or bender
            if (beer_can_present && bender_present)
                pictureData.Image = Properties.Resources.bender_and_beer;
            else if (beer_can_present)
                pictureData.Image = Properties.Resources.beer;
            else if (bender_present)
                pictureData.Image = Properties.Resources.bender;
            else
                pictureData.Image = null;

            //Set background
            pictureData.BackgroundImage = backgrounds[square_state];
        }

        public static void set_backgrounds()
        {
            backgrounds = new Dictionary<string, System.Drawing.Bitmap>();
            backgrounds.Add("Last", Properties.Resources.background_last_move);
            backgrounds.Add("Explored", Properties.Resources.background_explored);
            backgrounds.Add("Unexplored", Properties.Resources.background_unexplored);
        }

        public void copy_attributes(BoardSquare copy_from)
        {
            beer_can_present = copy_from.beer_can_present;
            bender_present = copy_from.beer_can_present;
            walls = copy_from.walls.Select(item => (int[])item.Clone()).ToList();
        }
    }
}