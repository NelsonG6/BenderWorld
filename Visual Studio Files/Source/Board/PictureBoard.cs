using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    //This class is used by the FormsHandler, and there should only ever be one instance.
    //It stores PictureSquares, instead of BoardSquares
    class PictureBoard : BaseBoard
    {
        public PictureBoard() : base()
        {
            PictureSquare.set_backgrounds(); //This initializes a dictionary of "boardVisistedState" - background image pairs.

            //Initialize 10x10 grid
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board_data[i].Add(new PictureSquare());
                }
            }
        }

        public void clone_position(BaseBoard set_from)
        {
            for (int i = 0; i < board_size; i++)
            {
                for (int j = 0; j < board_size; j++)
                {
                    get_board_data(i, j).copy_status(set_from.get_board_data(i, j));
                }
            }
        }

        public new PictureSquare get_board_data(int x, int y)
        {
            return (PictureSquare)board_data[x][y];
        }
    }
}
