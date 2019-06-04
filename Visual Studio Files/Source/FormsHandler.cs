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

            PictureSquare.set_backgrounds(); //This initializes a dictionary of square states - background image pairs.

            //Pass textboxes to the board, so it can manage them.
            number_of_episodes = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxInitialNumberofepisodes"] as TextBox;
            number_of_steps = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxInitialNumberofsteps"] as TextBox;
            n_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxInitialNinitial"] as TextBox; 
            y_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxInitialY"] as TextBox; 
            e_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxInitialEpsilon"] as TextBox;
            wall_punishment_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxInitialWallpunishment"] as TextBox;
            empty_square_punishment_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxInitialEmptysquare"] as TextBox;
            beer_reward_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxInitialBeerreward"] as TextBox;

            current_position_left = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxLeft"] as TextBox;
            current_position_right = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxRight"] as TextBox; 
            current_position_up = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxUp"] as TextBox;
            current_position_down = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxDown"] as TextBox;
            current_position_square = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxCurrentsquare"] as TextBox;
            current_position_encoding = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxEncodedas"] as TextBox;

            //null
            qmatrix_left = Application.OpenForms["Form1"].Controls["groupboxQmatrix"].Controls["groupboxQmatrixview"].Controls["textboxQmatrixleft"] as TextBox;
            qmatrix_right = Application.OpenForms["Form1"].Controls["groupboxQmatrix"].Controls["groupboxQmatrixview"].Controls["textboxQmatrixright"] as TextBox;
            qmatrix_down = Application.OpenForms["Form1"].Controls["groupboxQmatrix"].Controls["groupboxQmatrixview"].Controls["textboxQmatrixdown"] as TextBox;
            qmatrix_up = Application.OpenForms["Form1"].Controls["groupboxQmatrix"].Controls["groupboxQmatrixview"].Controls["textboxQmatrixup"] as TextBox;
            qmatrix_current_square = Application.OpenForms["Form1"].Controls["groupboxQmatrix"].Controls["groupboxQmatrixview"].Controls["textboxQmatrixcurrent"] as TextBox;

            status_box = Application.OpenForms["Form1"].Controls["groupboxStatusmessage"].Controls["textboxStatus"] as RichTextBox;

            beer_collected = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCans"].Controls["textboxCansremaining"] as TextBox;
            beer_remaining = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCans"].Controls["textboxCanscollected"] as TextBox;
            reward_episode = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxRewarddata"].Controls["textboxRewardepisode"] as TextBox;
            reward_total = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxRewarddata"].Controls["textboxRewardtotal"] as TextBox;

            display_initial_settings();

        }

        static public void display_initial_settings()
        {
            //initial settings
            number_of_episodes.Text = AlgorithmManager.episode_limit.ToString();
            number_of_steps.Text = AlgorithmManager.step_limit.ToString();
            n_textbox.Text = AlgorithmManager.n_initial.ToString();
            y_textbox.Text = AlgorithmManager.y_initial.ToString();
            e_textbox.Text = AlgorithmManager.e_initial.ToString();
            empty_square_punishment_textbox.Text = AlgorithmManager.reinforcement_factors["Empty pickup"].ToString();
            wall_punishment_textbox.Text = AlgorithmManager.reinforcement_factors["Wall collision"].ToString();
            beer_reward_textbox.Text = AlgorithmManager.reinforcement_factors["Beer pickup"].ToString();
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
        static public void display_manager_state()
        {
            current_board.clone_position(AlgorithmManager.state_to_view.board_data); //This copies the state's board over to our PictureSquare board.

            string bender_position = AlgorithmManager.state_to_view.board_data.bender_x.ToString() + ", " + AlgorithmManager.state_to_view.board_data.bender_y.ToString();
            status_box.Text = "Algorithm has started." + Environment.NewLine + "Bender's position is (" + bender_position + ").";



            if (AlgorithmManager.algorithm_started) //Only display this if we've started
            {   //Current position state textboxes             
                current_position_left.Text = AlgorithmManager.state_to_view.left_value;
                current_position_down.Text = AlgorithmManager.state_to_view.down_value;
                current_position_right.Text = AlgorithmManager.state_to_view.right_value;
                current_position_up.Text = AlgorithmManager.state_to_view.up_value;
                current_position_square.Text = AlgorithmManager.state_to_view.current_square_value;
                current_position_encoding.Text = AlgorithmManager.state_to_view.position_encoding;

                current_position_left.Text = AlgorithmManager.state_to_view.board_data.detect_percept(-1, 0);
                current_position_down.Text = AlgorithmManager.state_to_view.board_data.detect_percept(0, -1);
                current_position_right.Text = AlgorithmManager.state_to_view.board_data.detect_percept(1, 0);
                current_position_up.Text = AlgorithmManager.state_to_view.board_data.detect_percept(0, 1);
                current_position_square.Text = AlgorithmManager.state_to_view.board_data.detect_percept(0, 0);
                current_position_encoding.Text = AlgorithmManager.state_to_view.board_data.get_encoding_of_percepts();
            }
            
            foreach(var i in current_board.board_data)
            {   //Handle drawing the board
                foreach (var j in i)
                {
                    ((PictureSquare)j).setPicture();
                }
            }
        }

        //Triggers the constructor. Adds a PictureBox to a PictureSquare.
        static public void add(int i, int j, PictureSquare board_to_set)
        {
            current_board.board_data[i][j] = board_to_set;
        }

        //used for viewing q matrix configurations
        static public void update_qmatrix_view(bool set_flag)
        {
            //set_flag true means this was called from the view button, and we do not have to change the comboboxes
            //set_flag false means this was called from the combobox change event, and we will change the comboboxes.
            if(set_flag)
            {   //dont change comboboxes

            }
            else
            {   //change comboboxes

            }
        }
    }
}