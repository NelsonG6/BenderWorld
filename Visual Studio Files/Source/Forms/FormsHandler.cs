﻿using System;
using System.Windows.Forms;

namespace ReinforcementLearning
{
    static class FormsHandler
    {
        //Initial settings
        static public TextBox number_of_episodes;
        static public TextBox number_of_steps;
        static public TextBox n_initial;
        static public TextBox y_initial;
        static public TextBox e_initial;
        //Rewards
        static public TextBox wall_punishment_textbox;
        static public TextBox empty_square_punishment_textbox;
        static public TextBox beer_reward_textbox;
        static public TextBox successful_move_textbox;

        //Q-matrix view
        static public ComboBox qmatrix_state;
        static public ComboBox qmatrix_left_combobox;
        static public ComboBox qmatrix_right_combobox;
        static public ComboBox qmatrix_up_combobox;
        static public ComboBox qmatrix_down_combobox;
        static public ComboBox qmatrix_current_combobox;

        static public TextBox qmatrix_left;
        static public TextBox qmatrix_right;
        static public TextBox qmatrix_down;
        static public TextBox qmatrix_up;
        static public TextBox qmatrix_current_square;

        //Session progress
        static public TextBox step_number;
        static public TextBox episode_number;
        static public TextBox e_session;
        static public TextBox n_session;
        static public TextBox y_session;
        //Rewards
        static public TextBox beer_collected;
        static public TextBox beer_remaining;
        static public TextBox reward_episode;
        static public TextBox reward_total;

        //Current position
        static public TextBox current_position_left;
        static public TextBox current_position_down;
        static public TextBox current_position_right;
        static public TextBox current_position_up;
        static public TextBox current_position_square;

        static public RichTextBox status_box;

        //Current position

        //static public List<List<PictureSquare>> current_board;
        //replacing this with a board object
        //not sure if polypmorphism will like that

        //This will be set from the outside, and we will display whatever is in here.
        //static public AlgorithmState current_state;

        static public DisplayBoard current_board; //Stored seperately from the algorithm state because this board will store PictureSquares

        static FormsHandler()
        {
            current_board = new DisplayBoard();

            PictureSquare.set_backgrounds(); //This initializes a dictionary of "boardVisistedState" - background image pairs.

            //Pass textboxes to the board, so it can manage them.

            Control form1_control = Application.OpenForms["Form1"];
            Control groupbox_initial_settings = form1_control.Controls["groupboxInitialsettings"];
            Control groupbox_rewards = groupbox_initial_settings.Controls["groupboxRewards"];
            Control groupbox_qmatrix = form1_control.Controls["groupboxQmatrix"];
            Control groupbox_matrix_select = groupbox_qmatrix.Controls["groupboxQmatrixselect"];
            Control groupbox_qmatrix_view = form1_control.Controls["groupboxQmatrix"].Controls["groupboxQmatrixview"];
            Control groupbox_session_progress = form1_control.Controls["groupboxSessionprogress"];
            Control groupbox_can_data = groupbox_session_progress.Controls["groupboxCans"];
            Control groupbox_reward_data = groupbox_session_progress.Controls["groupboxRewarddata"];
            Control groupbox_current_position = groupbox_session_progress.Controls["groupboxCurrentposition"];

            //Initial settings
            number_of_episodes = groupbox_initial_settings.Controls["textboxInitialNumberofepisodes"] as TextBox;
            number_of_steps = groupbox_initial_settings.Controls["textboxInitialNumberofsteps"] as TextBox;
            n_initial = groupbox_initial_settings.Controls["textboxInitialNinitial"] as TextBox; 
            y_initial = groupbox_initial_settings.Controls["textboxInitialY"] as TextBox; 
            e_initial = groupbox_initial_settings.Controls["textboxInitialEpsilon"] as TextBox;
            //Rewards
            wall_punishment_textbox = groupbox_rewards.Controls["textboxInitialWallpunishment"] as TextBox;
            empty_square_punishment_textbox = groupbox_rewards.Controls["textboxInitialEmptysquare"] as TextBox;
            beer_reward_textbox = groupbox_rewards.Controls["textboxInitialBeerreward"] as TextBox;
            successful_move_textbox = groupbox_rewards.Controls["textboxRewardssuccessmove"] as TextBox;

            //Q-Matrix view
            qmatrix_state = groupbox_matrix_select.Controls["comboboxQmatrixselect"] as ComboBox;
            qmatrix_left_combobox = groupbox_matrix_select.Controls["comboboxLeft"] as ComboBox;
            qmatrix_right_combobox = groupbox_matrix_select.Controls["comboboxRight"] as ComboBox;
            qmatrix_up_combobox = groupbox_matrix_select.Controls["comboboxUp"] as ComboBox;
            qmatrix_down_combobox = groupbox_matrix_select.Controls["comboboxDown"] as ComboBox;
            qmatrix_current_combobox = groupbox_matrix_select.Controls["comboboxCurrentsquare"] as ComboBox;

            qmatrix_left = groupbox_qmatrix_view.Controls["textboxQmatrixleft"] as TextBox;
            qmatrix_right = groupbox_qmatrix_view.Controls["textboxQmatrixright"] as TextBox;
            qmatrix_down = groupbox_qmatrix_view.Controls["textboxQmatrixdown"] as TextBox;
            qmatrix_up = groupbox_qmatrix_view.Controls["textboxQmatrixup"] as TextBox;
            qmatrix_current_square = groupbox_qmatrix_view.Controls["textboxQmatrixcurrent"] as TextBox;

            //Session progress
            step_number = groupbox_session_progress.Controls["textboxStepsprogress"] as TextBox;
            episode_number = groupbox_session_progress.Controls["textboxEpisodesprogress"] as TextBox;
            e_session = groupbox_session_progress.Controls["textboxEprogress"] as TextBox;
            n_session = groupbox_session_progress.Controls["textboxNprogress"] as TextBox;
            y_session = groupbox_session_progress.Controls["textboxYprogress"] as TextBox;

            //Can data and reward data
            beer_remaining = groupbox_can_data.Controls["textboxCansremaining"] as TextBox;
            beer_collected= groupbox_can_data.Controls["textboxCanscollected"] as TextBox;
            reward_episode = groupbox_reward_data.Controls["textboxRewardepisode"] as TextBox;
            reward_total = groupbox_reward_data.Controls["textboxRewardtotal"] as TextBox;

            //Current position
            current_position_left = groupbox_current_position.Controls["textboxLeft"] as TextBox;
            current_position_right = groupbox_current_position.Controls["textboxRight"] as TextBox; 
            current_position_up = groupbox_current_position.Controls["textboxUp"] as TextBox;
            current_position_down = groupbox_current_position.Controls["textboxDown"] as TextBox;
            current_position_square = groupbox_current_position.Controls["textboxCurrentsquare"] as TextBox;

            //Status message
            status_box = Application.OpenForms["Form1"].Controls["groupboxStatusmessage"].Controls["textboxStatus"] as RichTextBox;

            display_initial_settings();
        }

        static public void display_initial_settings()
        {
            //initial settings
            number_of_episodes.Text = AlgorithmManager.episode_limit.ToString();
            number_of_steps.Text = AlgorithmManager.step_limit.ToString();
            n_initial.Text = AlgorithmManager.n_initial.ToString();
            y_initial.Text = AlgorithmManager.y_initial.ToString();
            e_initial.Text = AlgorithmManager.e_initial.ToString();
            empty_square_punishment_textbox.Text = AlgorithmManager.reinforcement_factors[MoveResultList.can_missing()].ToString();
            wall_punishment_textbox.Text = AlgorithmManager.reinforcement_factors[MoveResultList.move_hit_wall()].ToString();
            beer_reward_textbox.Text = AlgorithmManager.reinforcement_factors[MoveResultList.can_collected()].ToString();
            successful_move_textbox.Text = AlgorithmManager.reinforcement_factors[MoveResultList.move_successful()].ToString();
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
            status_box.Text = "Board cleared.";
        }

        //This is ran every time we step through the algorithm.
        //Handles updating all the fields that change every time we look at new data
        //This method handles any time we are updating what is displayed for any reason once the algorithm is active
        //We expect the algorithm state to be set from the outside before we enter this.
        static public void display_manager_state()
        {
            current_board.clone_position(AlgorithmManager.state_to_view.board_data); //This copies the state's board over to our PictureSquare board.

            string bender_position = AlgorithmManager.state_to_view.board_data.bender.bender_x.ToString();
            bender_position += ", " + AlgorithmManager.state_to_view.board_data.bender.bender_y.ToString();
            status_box.Text = "Bender's position is (" + bender_position + ").";


            
            if (AlgorithmManager.algorithm_started) //Only display this if we've started
            {   //Current position state textboxes             
                //I think i want to get these directly from the q matrix
                //to do that, i need the perceptions bender is in, and then i can request the moveset, which has my values.
                PerceptionState benders_perception = AlgorithmManager.current_state.board_data.bender.get_perception_state();
                display_qmatrix_values(benders_perception);

                //matrix stuff
                qmatrix_left.Text = AlgorithmManager.get_qmatrix_view(MoveList.left());
                qmatrix_right.Text = AlgorithmManager.get_qmatrix_view(MoveList.right());
                qmatrix_up.Text = AlgorithmManager.get_qmatrix_view(MoveList.up());
                qmatrix_down.Text = AlgorithmManager.get_qmatrix_view(MoveList.down());
                qmatrix_current_square.Text = AlgorithmManager.get_qmatrix_view(MoveList.grab());

                qmatrix_state.Items.Clear();
                foreach (var i in AlgorithmManager.current_state.live_qmatrix.get_list_of_qmatrix_states())
                {
                    qmatrix_state.Items.Add(i);
                }

                //Session progress
                step_number.Text = AlgorithmManager.current_state.step_count.ToString();
                episode_number.Text = AlgorithmManager.current_state.episode_count.ToString();
                e_session.Text = AlgorithmManager.current_state.e_current.ToString();
                n_session.Text = AlgorithmManager.current_state.n_current.ToString();
                y_session.Text = AlgorithmManager.current_state.y_current.ToString();

                beer_remaining.Text = AlgorithmManager.current_state.board_data.get_cans_remaining().ToString();
                beer_collected.Text = AlgorithmManager.current_state.cans_collected.ToString();
                reward_episode.Text = AlgorithmManager.current_state.episode_rewards.ToString();
                reward_total.Text = AlgorithmManager.current_state.total_rewards.ToString();

                current_position_left.Text = AlgorithmManager.current_state.get_bender_percept(MoveList.left()).get_string_data();
                current_position_right.Text = AlgorithmManager.current_state.get_bender_percept(MoveList.right()).get_string_data();
                current_position_down.Text = AlgorithmManager.current_state.get_bender_percept(MoveList.down()).get_string_data();
                current_position_up.Text = AlgorithmManager.current_state.get_bender_percept(MoveList.up()).get_string_data();
                current_position_square.Text = AlgorithmManager.current_state.get_bender_percept(MoveList.grab()).get_string_data();
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

        //This is used to display rows of the qmatrix and the q-values for each move
        //Pass this a perceptionstate built from the dropdown box(s)
        static private void display_qmatrix_values(PerceptionState benders_perception)
        {
            MoveSet values_to_display = AlgorithmManager.current_state.live_qmatrix.matrix_data[benders_perception];

            current_position_left.Text = values_to_display.move_list[MoveList.left()].ToString();
            current_position_down.Text = values_to_display.move_list[MoveList.left()].ToString();
            current_position_right.Text = values_to_display.move_list[MoveList.left()].ToString();
            current_position_up.Text = values_to_display.move_list[MoveList.left()].ToString();
            current_position_square.Text = values_to_display.move_list[MoveList.left()].ToString();
        }

    }
}