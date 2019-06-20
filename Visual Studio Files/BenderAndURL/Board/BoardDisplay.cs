using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenderAndURL
{
    //This class is used by the FormsHandler, and there should only ever be one instance.
    //It stores PictureSquares, instead of BoardSquares
    class BoardDisplay : BoardBase
    {
        public BoardDisplay() : base()
        {
            SquareBoardDisplay.setBackgrounds(); //This initializes a dictionary of "boardVisistedState" - background image pairs.

            //Initialize 10x10 grid
            for (int i = 0; i < InitialSettings.SizeOfBoard; i++)
            {
                for (int j = 0; j < InitialSettings.SizeOfBoard; j++)
                {
                    boardData[i].Add(new SquareBoardDisplay(i, j));
                }
            }
        }

        public void ClonePosition(BoardBase setFrom)
        {
            for (int i = 0; i < setFrom.boardData.Count; i++)
            {
                for (int j = 0; j < setFrom.boardData[i].Count; j++)
                {
                    GetBoardData(i, j).CopyStatus(setFrom.GetBoardData(i, j));
                }
            }
        }

        public new SquareBoardDisplay GetBoardData(int x, int y)
        {
            return (SquareBoardDisplay)boardData[x][y];
        }
    }
}
