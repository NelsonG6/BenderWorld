using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReinforcementLearning
{
    class Board
    {
        private List<List<BoardSquare>> board_data;
        private int board_size;

        //keeps track of where bender is
        private int bender_x;
        private int bender_y;
        Random random;

        public Board(Random set_random)
        {
            random = set_random;
            board_size = 0;
            board_data = new List<List<BoardSquare>>();
            for (int i = 0; i < 10; i++)
            {
                board_data.Add(new List<BoardSquare>());
                for (int j = 0; j < 10; j++)
                {
                    board_data[i].Add(new BoardSquare(random));
                }
            }

            //Add walls
            for (int i = 0; i < 10; i++)
            {   //left wall
                board_data[0][i].walls.Add(new int[2] { -1, 0 });
            }

            for (int i = 0; i < 10; i++)
            {   //right wall
                board_data[9][i].walls.Add(new int[2] { 1, 0 });
            }

            for (int i = 0; i < 10; i++)
            {   //bottom wall
                board_data[i][0].walls.Add(new int[2] { 0, -1 });
            }

            for (int i = 0; i < 10; i++)
            {   //above wall
                board_data[i][9].walls.Add(new int[2] { 0, 1 });
            }

            bender_x = 0;
            bender_y = 0;
            shuffle();
        }

        public void shuffle()
        {
            foreach (var i in board_data) { foreach (var j in i) { j.randomize_beer_presence(); } }

            if (board_data[bender_x][bender_y].bender_present) board_data[bender_x][bender_y].bender_present = false;
            bender_x = random.Next(0, 10);
            bender_y = random.Next(0, 10);
            board_data[bender_x][bender_y].bender_present = true;
        }

        public void SetEdgeSize(int to_set)
        {
            board_size = to_set;
        }

        public void AddPicturebox(PictureBox to_add, int x_index, int y_index)
        {
            board_data[x_index][y_index].pictureData = to_add;
        }

        public void update()
        {
            foreach (var i in board_data) { foreach(var j in i) { j.setPicture(); } }
        }

        public string get_encoding_of_percepts()
        {
            string precept_string = detect_percept(-1, 0);
            precept_string += ", " + detect_percept(0, -1);
            precept_string += ", " + detect_percept(1, 0);
            precept_string += ", " + detect_percept(0, 1);
            precept_string += ", " + detect_percept(0, 0);
            return precept_string;
        }

        public string detect_percept(int x_move, int y_move)
        {
            if(board_data[bender_x][bender_y].check_wall(x_move, y_move))
            {
                return "Wall";
            }
            else
            {
                if (board_data[bender_x + x_move][bender_y + y_move].beer_can_present)
                    return "Beer Can";
                else
                    return "Empty";
            }
            //Shouldn't reach this
        }
    }
}
