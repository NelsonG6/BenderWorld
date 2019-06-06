using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    class BaseBoard
    {
        public List<List<BaseSquare>> board_data; //These contain pictureboxes
                                                  //This will inherit Either a BoardSquare or a PictureSquare
        public int board_size;

        public BaseBoard()
        {
            board_data = new List<List<BaseSquare>>(); //Initialize the board here, but the squares will be added by the child classes

            board_size = 10;

            for (int i = 0; i < board_size; i++)
            {
                board_data.Add(new List<BaseSquare>());
            }
        }

        public BaseSquare get_board_data(int x, int y)
        {
            return board_data[x][y];
        }
    }
}
