using System.Windows.Forms;
using System.Collections.Generic;

namespace BenderAndURL
{
    class SquareBoardDisplay : SquareBoardBase
    {
        public PictureBox pictureData;

        public SquareBoardDisplay(int x, int y) : base(x, y)
        {
            pictureData = null;
        }

        public void SetPicture()
        {
            //Set can and/or bender
            if (beerCanPresent && UnitsPresent[UnitType.Bender])
                pictureData.Image = Properties.Resources.BenderAndBeer;

            else if (beerCanPresent && UnitsPresent[UnitType.Url])
                pictureData.Image = Properties.Resources.UrlAndBeer;
            else if (UnitsPresent[UnitType.Url])
                pictureData.Image = Properties.Resources.URL;
            else if (beerCanPresent)
                pictureData.Image = Properties.Resources.Beer;
            else if (UnitsPresent[UnitType.Bender])
                pictureData.Image = Properties.Resources.Bender;
            
            else
                pictureData.Image = null;

            //Set background
            pictureData.BackgroundImage = Backgrounds.dictionary[visitedState]; //Visisted state belongs to the base class, and is Unexplored by default
        }


        public void CopyStatus(SquareBoardBase copyFrom)
        {
            UnitsPresent = new Dictionary<UnitBase, bool>();
            foreach(var i in copyFrom.UnitsPresent)
            {
                UnitsPresent.Add(i.Key, i.Value);
            }

            beerCanPresent = copyFrom.beerCanPresent;
            visitedState = copyFrom.visitedState;
            x = copyFrom.x;
            y = copyFrom.y;
        }

        public static void setBackgrounds() //For constructor?
        {
        }
    }
}