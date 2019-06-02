using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReinforcementLearning
{
    class Board
    {
        private List<List<BoardSquare>> board_data; //These contain pictureboxes, passed from form1

        public TextBox number_of_episodes;
        public TextBox number_of_steps;
        public TextBox n_textbox;
        public TextBox y_textbox;
        public TextBox current_position_left;
        public TextBox current_position_down;
        public TextBox current_position_right;
        public TextBox current_position_up;
        public TextBox current_position_square;
        public TextBox current_position_encoding;

        private int board_size;

        //keeps track of where bender is
        private int bender_x;
        private int bender_y;
        Random random;

        public int episode_limit;
        public int step_limit;
        public float n;
        public float y;

        public Board(Random set_random)
        {
            random = set_random;
            board_size = 0;
            board_data = new List<List<BoardSquare>>();

            //Initialize 10x10 grid
            for (int i = 0; i < 10; i++)
            {
                board_data.Add(new List<BoardSquare>());
                for (int j = 0; j < 10; j++)
                {
                    board_data[i].Add(new BoardSquare(random));
                }
            }

            episode_limit = 5000;
            step_limit = 200;
            n = .2F;
            y = .9F;

            //Add walls
            //left wall
            for (int i = 0; i < 10; i++) { board_data[0][i].walls.Add(new int[2] { -1, 0 }); }
            //right wall
            for (int i = 0; i < 10; i++) { board_data[9][i].walls.Add(new int[2] { 1, 0 }); }
            //bottom wall
            for (int i = 0; i < 10; i++) { board_data[i][0].walls.Add(new int[2] { 0, -1 }); }
            //above wall
            for (int i = 0; i < 10; i++) { board_data[i][9].walls.Add(new int[2] { 0, 1 }); }

            //Bender location will be set in shuffle
            bender_x = 0;
            bender_y = 0;
        }

        public void shuffle()
        {
            //Activate the 50/50 chance for each tile to have beer in it.
            foreach (var i in board_data) { foreach (var j in i) { j.randomize_beer_presence(); } }

            shuffle_bender(); //Place bender randomly somewhere

            //Update every picturebox, now that the status of beer and bender has possibly changed.
            foreach (var i in board_data) { foreach (var j in i) { j.setPicture(); } }
        }

        public void SetEdgeSize(int to_set)
        {
            board_size = to_set;
        }

        public void AddPicturebox(PictureBox to_add, int x_index, int y_index)
        {
            board_data[x_index][y_index].pictureData = to_add;
        }

        public void update_textboxes()
        {
            current_position_left.Text = detect_percept(-1, 0);
            current_position_down.Text = detect_percept(0, -1);
            current_position_right.Text = detect_percept(1, 0);
            current_position_up.Text = detect_percept(0, 1);
            current_position_square.Text = detect_percept(0, 0);
            current_position_encoding.Text = get_encoding_of_percepts();
            current_position_down.Refresh();
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

        public string get_encoding_of_percepts()
        {
            string precept_string = detect_percept(-1, 0);
            precept_string += ", " + detect_percept(0, -1);
            precept_string += ", " + detect_percept(1, 0);
            precept_string += ", " + detect_percept(0, 1);
            precept_string += ", " + detect_percept(0, 0);
            return precept_string;
        }

        public void startAlgorithm()
        {
            shuffle();
            update_textboxes();
        }

        public void clear()
        {
            //Clear all the pictures
            foreach (var i in board_data) { foreach (var j in i) { j.pictureData.Image = null; } }
            board_data[bender_x][bender_y].pictureData.Image = Properties.Resources.bender; //Keep bender displayed for novelty

            //Clear the current position textboxes
            current_position_down.Clear();
            current_position_left.Clear();
            current_position_right.Clear();
            current_position_up.Clear();
            current_position_square.Clear();
            current_position_encoding.Clear();
        }

        public void shuffle_bender()
        {
            //If Bender is already somewhere on the board, make sure we remove him from that location.
            if (board_data[bender_x][bender_y].bender_present) board_data[bender_x][bender_y].bender_present = false;

            //Get bender's new location.
            bender_x = random.Next(0, 10); //0-9 inclusive
            bender_y = random.Next(0, 10); 
            board_data[bender_x][bender_y].bender_present = true; //Set bender
            board_data[bender_x][bender_y].pictureData.Image = Properties.Resources.bender; //Set picture
        }

        public void load_initial_settings()
        {
            number_of_episodes.Text = episode_limit.ToString();
            number_of_steps.Text = step_limit.ToString();
            n_textbox.Text = n.ToString();
            y_textbox.Text = y.ToString();
        }
    }
}
