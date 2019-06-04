using System.Windows.Forms;
using System.Linq;

namespace ReinforcementLearning
{
    class PictureSquare : BoardSquare
    {
        public PictureBox pictureData;

        public PictureSquare() : base()
        {
            pictureData = null;
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

        public void copy_attributes(BoardSquare copy_from)
        {
            beer_can_present = copy_from.beer_can_present;
            bender_present = copy_from.beer_can_present;
            walls = copy_from.walls.Select(item => (int[])item.Clone()).ToList();
        }
    }
}