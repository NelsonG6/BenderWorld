using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenderAndURL
{
    //Handles the background images that the squares can have
    static class Backgrounds
    {
        private static readonly System.Drawing.Bitmap LastMove;
        private static readonly System.Drawing.Bitmap ExploredMove;
        private static readonly System.Drawing.Bitmap UnexploredMove;

        static public Dictionary<SquareVisitedState, System.Drawing.Bitmap> dictionary;

        static Backgrounds()
        {
            LastMove = Properties.Resources.BackgroundLast;
            ExploredMove = Properties.Resources.BackgroundExplored;
            UnexploredMove = Properties.Resources.BackgroundUnexplored;

            dictionary = new Dictionary<SquareVisitedState, System.Drawing.Bitmap>();
            dictionary.Add(SquareVisitedState.Last, LastMove);
            dictionary.Add(SquareVisitedState.Explored, ExploredMove);
            dictionary.Add(SquareVisitedState.Unexplored, UnexploredMove);
        }
    }
}
