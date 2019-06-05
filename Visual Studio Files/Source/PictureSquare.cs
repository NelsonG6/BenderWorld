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
            pictureData.BackgroundImage = Backgrounds.dictionary[visited_state];
        }


        public void copy_attributes(BoardSquare copy_from)
        {
            beer_can_present = copy_from.beer_can_present;
            bender_present = copy_from.beer_can_present;
            walls = new Dictionary<Move, bool>();

            foreach (var i in copy_from.walls.Keys)
            {
                walls.Add(i, copy_from.walls[i]);
            }
        }

        public static void set_backgrounds()
        {

        }
    }
}