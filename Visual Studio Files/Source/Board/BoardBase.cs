using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    class BoardBase
    {
        public List<List<SquareBase>> board_data; //These contain pictureboxes
                                                  //This will inherit Either a BoardSquare or a PictureSquare
        public int board_size;

        public BoardBase()
        {
            board_data = new List<List<SquareBase>>(); //Initialize the board here, but the squares will be added by the child classes

            for (int i = 0; i < 10; i++)
            {
                board_data.Add(new List<SquareBase>());
            }
        }

        public SquareBase get_board_data(int x, int y)
        {
            return board_data[x][y];
        }
    }
}
