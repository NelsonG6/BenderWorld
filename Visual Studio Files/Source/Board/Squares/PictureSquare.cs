using System.Windows.Forms;
using System.Linq;
using System;
using System.Collections.Generic;

namespace ReinforcementLearning
{
    class PictureSquare : BaseSquare
    {
        public PictureBox pictureData;

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
            pictureData.BackgroundImage = Backgrounds.dictionary[visited_state]; //Visisted state belongs to the base class, and is unexplored by default
        }


        new public void copy_status(BaseSquare copy_from)
        {
            beer_can_present = copy_from.beer_can_present;
            bender_present = copy_from.bender_present;
            visited_state = copy_from.visited_state;
        }

        public static void set_backgrounds()
        {

        }
    }
}