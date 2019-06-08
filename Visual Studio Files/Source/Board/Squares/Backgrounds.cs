using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    //Handles the background images that the squares can have
    static class Backgrounds
    {
        private static System.Drawing.Bitmap last_move_bitmap;
        private static System.Drawing.Bitmap explored_bitmap;
        private static System.Drawing.Bitmap unexplored_bitmap;

        static public Dictionary<SquareVisitedState, System.Drawing.Bitmap> dictionary;

        static Backgrounds()
        {
            last_move_bitmap = Properties.Resources.background_last_move;
            explored_bitmap = Properties.Resources.background_explored;
            unexplored_bitmap = Properties.Resources.background_unexplored;

            dictionary = new Dictionary<SquareVisitedState, System.Drawing.Bitmap>();
            dictionary.Add(SquareVisitedState.last(), last_move_bitmap);
            dictionary.Add(SquareVisitedState.explored(), explored_bitmap);
            dictionary.Add(SquareVisitedState.unexplored(), unexplored_bitmap);
        }
            
        public static System.Drawing.Bitmap last_move()
        {
            return last_move_bitmap;
        }

        public static System.Drawing.Bitmap explored()
        {
            return explored_bitmap;
        }

        public static System.Drawing.Bitmap unexlored()
        {
            return unexplored_bitmap;
        }
    }
}
