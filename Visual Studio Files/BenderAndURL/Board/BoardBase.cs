using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenderAndURL
{
    class BoardBase
    {
        public List<List<SquareBoardBase>> boardData; //These contain pictureboxes
                                                  //This will inherit Either a BoardSquare or a PictureSquare

        public BoardBase()
        {
            boardData = new List<List<SquareBoardBase>>(); //Initialize the board here, but the squares will be added by the child classes

            for (int i = 0; i < InitialSettings.SizeOfBoard; i++)
            {
                boardData.Add(new List<SquareBoardBase>());
                //Cant add squares here because they wont be the correct type later
            }

        }

        public SquareBoardBase GetBoardData(int x, int y)
        {
            return boardData[x][y];
        }


    }
}
