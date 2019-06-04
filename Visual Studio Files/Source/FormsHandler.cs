using System;
using System.Windows.Forms;

namespace ReinforcementLearning
{
    static class FormsHandler
    {
        static public TextBox number_of_episodes;
        static public TextBox number_of_steps;
        static public TextBox n_textbox;
        static public TextBox y_textbox;
        static public TextBox e_textbox;
        static public TextBox current_position_left;
        static public TextBox current_position_down;
        static public TextBox current_position_right;
        static public TextBox current_position_up;
        static public TextBox current_position_square;
        static public TextBox current_position_encoding;
        static public TextBox empty_square_punishment_textbox;
        static public TextBox wall_punishment_textbox;
        static public TextBox beer_reward_textbox;
        static public TextBox qmatrix_left;
        static public TextBox qmatrix_right;
        static public TextBox qmatrix_down;
        static public TextBox qmatrix_up;
        static public TextBox qmatrix_current_square;
        static public TextBox beer_collected;
        static public TextBox beer_remaining;
        static public TextBox reward_episode;
        static public TextBox reward_total;
        static public RichTextBox status_box;

        //static public List<List<PictureSquare>> current_board;
        //replacing this with a board object
        //not sure if polypmorphism will like that

        //This will be set from the outside, and we will display whatever is in here.
        //static public AlgorithmState current_state;

        static public Board current_board; //Stored seperately from the algorithm state because this board will store PictureSquares

        static FormsHandler()
        {
            current_board = new Board();

            //Pass textboxes to the board, so it can manage them.
            number_of_episodes = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxNumberofepisodes"] as TextBox;
            number_of_steps = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxNumberofsteps"] as TextBox;
            n_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxNinitial"] as TextBox; 
            y_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxY"] as TextBox; 
            e_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxEpsilon"] as TextBox;
            wall_punishment_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxWallpunishment"] as TextBox;
            empty_square_punishment_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxEmptysquare"] as TextBox;
            beer_reward_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxBeerreward"] as TextBox;

            current_position_left = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxLeft"] as TextBox;
            current_position_right = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxRight"] as TextBox; 
            current_position_up = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxUp"] as TextBox;
            current_position_down = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxDown"] as TextBox;
            current_position_square = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxCurrentsquare"] as TextBox;
            current_position_encoding = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxEncodedas"] as TextBox;

            qmatrix_left = Application.OpenForms["Form1"].Controls["groupboxQmatrix"].Controls["textboxQmatrixleft"] as TextBox;
            qmatrix_right = Application.OpenForms["Form1"].Controls["groupboxQmatrix"].Controls["textboxQmatrixright"] as TextBox;
            qmatrix_down = Application.OpenForms["Form1"].Controls["groupboxQmatrix"].Controls["textboxQmatrixdown"] as TextBox;
            qmatrix_up = Application.OpenForms["Form1"].Controls["groupboxQmatrix"].Controls["textboxQmatrixup"] as TextBox;
            qmatrix_current_square = Application.OpenForms["Form1"].Controls["groupboxQmatrix"].Controls["textboxQmatrixcurrent"] as TextBox;

            status_box = Application.OpenForms["Form1"].Controls["groupboxStatusmessage"].Controls["textboxStatus"] as RichTextBox;

            beer_collected = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCans"].Controls["textboxCansremaining"] as TextBox;
            beer_remaining = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCans"].Controls["textboxCanscollected"] as TextBox;
            reward_episode = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxRewarddata"].Controls["textboxRewardepisode"] as TextBox;
            reward_total = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxRewarddata"].Controls["textboxRewardtotal"] as TextBox;

            //Maybe display state
        }

        //Used after "algorithm reset" button is pressed. Not used during algorithm run.
        static public void clear_after_board_reset()
        {
            //Clear the current position textboxes
            current_position_down.Clear();
            current_position_left.Clear();
            current_position_right.Clear();
            current_position_up.Clear();
            current_position_square.Clear();
            current_position_encoding.Clear();
            status_box.Text = "Board cleared.";
        }

        //This is ran every time we step through the algorithm.
        //Handles updating all the fields that change every time we look at new data
        //This method handles any time we are updating what is displayed for any reason once the algorithm is active
        //We expect the algorithm state to be set from the outside before we enter this.

           


        static public void update_state(AlgorithmState current_state)
        {
            current_board.clone_position(current_state.board_data);

            string bender_position = current_state.board_data.bender_x.ToString() + ", " + current_state.board_data.bender_y.ToString();
            status_box.Text = "Algorithm has started." + Environment.NewLine + "Bender's position is (" + bender_position + ").";

            //initial settings always get displayed
            number_of_episodes.Text = current_state.episode_limit.ToString();
            number_of_steps.Text = current_state.step_limit.ToString();
            n_textbox.Text = current_state.n_initial.ToString();
            y_textbox.Text = current_state.y_initial.ToString();
            e_textbox.Text = current_state.e_initial.ToString();
            empty_square_punishment_textbox.Text = current_state.reinforcement_factors["Empty"].ToString();
            wall_punishment_textbox.Text = current_state.reinforcement_factors["Wall"].ToString();
            beer_reward_textbox.Text = current_state.reinforcement_factors["Beer"].ToString();

            if (AlgorithmManager.current_state.episode_count != 0) //We'll have 1 episode when we actually start
            {
                //Only display this if we've started
                //Current position state textboxes
                current_position_left.Text = current_state.left_value;
                current_position_down.Text = current_state.down_value;
                current_position_right.Text = current_state.right_value;
                current_position_up.Text = current_state.up_value;
                current_position_square.Text = current_state.current_square_value;
                current_position_encoding.Text = current_state.position_encoding;

                current_position_left.Text = current_state.board_data.detect_percept(-1, 0);
                current_position_down.Text = current_state.board_data.detect_percept(0, -1);
                current_position_right.Text = current_state.board_data.detect_percept(1, 0);
                current_position_up.Text = current_state.board_data.detect_percept(0, 1);
                current_position_square.Text = current_state.board_data.detect_percept(0, 0);
                current_position_encoding.Text = current_state.board_data.get_encoding_of_percepts();
            }

            //Handle drawing the board
            foreach(var i in current_board.board_data)
            {
                foreach(var j in i)
                {
                    ((PictureSquare)j).setPicture();
                }
            }
        }

        //We take a copy of the state to display it.
        //This is necessary so we can take our PictureSquares and display it.
        static public void copy_state(AlgorithmState copy_from)
        {
            for(int i = 0; i < current_board.board_size; i++)
            {
                for (int j = 0; j < current_board.board_size; j++)
                {
                    current_board.board_data[i][j].copy_status(copy_from.board_data.board_data[i][j]);
                }
            }
        }

        //Triggers the constructor. Adds a PictureBox to a PictureSquare.
        static public void add(int i, int j, PictureSquare board_to_set)
        {
            current_board.board_data[i][j] = board_to_set;
        }
    }
}