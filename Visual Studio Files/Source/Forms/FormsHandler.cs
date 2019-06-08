using System;
using System.Collections.Generic;
using System.Linq;
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
        static public ComboBox qmatrix_state_combobox_large; //The larger dropdown
        static public TextBox qmatrix_stored_entires;
        
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

        static public RichTextBox status_box;

        //List of groupbox controls
        static Control form1_control;
        static GroupBox groupbox_initial_settings;
        static GroupBox groupbox_rewards;
        static GroupBox groupbox_qmatrix;
        static GroupBox groupbox_matrix_select;
        static GroupBox groupbox_qmatrix_values;
        static GroupBox groupbox_session_progress;
        static GroupBox groupbox_can_data;
        static GroupBox groupbox_reward_data;
        static GroupBox groupbox_current_position;
        static GroupBox groupbox_control_progress;
        static GroupBox groupbox_history;


        //Control progress
        static ComboBox control_progress_steps;
        static ComboBox control_progress_episodes;
        static ComboBox control_progress_delay;

        //History
        static ComboBox combobox_history_episodes;
        static ComboBox combobox_history_steps;

        static public bool lock_index_change_events;
        static public bool is_drop_down_open;
        static public bool halted;

        static public List<TextBox> list_session_progress;

        //store a textbox that displays the percepts of the current position for each move
        static public Dictionary<Move, TextBox> list_current_position_textboxes;
        //Store a textbox that displays a q-matrix value for each move
        static public Dictionary<Move, TextBox> List_qmatrix_value_textboxes;
        static public Dictionary<Move, ComboBox> list_qmatrix_comboboxes; //Store a q-matrix combobox for each move

        //Current position

        //static public List<List<PictureSquare>> current_board;
        //replacing this with a board object
        //not sure if polypmorphism will like that

        //This will be set from the outside, and we will display whatever is in here.
        //static public AlgorithmState current_state;

        static public PictureBoard picture_board; //Stored seperately from the algorithm state because this board will store PictureSquares

        static FormsHandler()
        {
            picture_board = new PictureBoard();

            lock_index_change_events = false;
            is_drop_down_open = false;
            halted = false;
            //Pass textboxes to the board, so it can manage them.

            link_handler_to_form();

            //Initialize dropdown boxes
            control_progress_steps.SelectedIndex = 0;
            control_progress_episodes.Text = "0"; ;
            control_progress_delay.Text = "25";

            foreach(var i in list_qmatrix_comboboxes)
            {
                i.Value.SelectedIndex = -1;
            }
            
            display_initial_settings();
        }

        static public void display_initial_settings()
        {
            //initial settings
            number_of_episodes.Text = AlgorithmStateManager.current_state.episode_limit.ToString(); //Constructor launcher for algorithmstate 6-5
            number_of_steps.Text = AlgorithmStateManager.current_state.step_limit.ToString();
            n_initial.Text = AlgorithmStateManager.current_state.n_current.ToString();
            y_initial.Text = AlgorithmStateManager.current_state.y_current.ToString();
            e_initial.Text = AlgorithmStateManager.current_state.e_current.ToString();
            empty_square_punishment_textbox.Text = AlgorithmStateManager.current_state.reinforcement_factors[MoveResultList.can_missing()].ToString();
            wall_punishment_textbox.Text = AlgorithmStateManager.current_state.reinforcement_factors[MoveResultList.move_hit_wall()].ToString();
            beer_reward_textbox.Text = AlgorithmStateManager.current_state.reinforcement_factors[MoveResultList.can_collected()].ToString();
            successful_move_textbox.Text = AlgorithmStateManager.current_state.reinforcement_factors[MoveResultList.move_successful()].ToString();
        }

        //Used after "algorithm reset" button is pressed. Not used during algorithm run.
        
        static public void clear_after_board_reset()
        {
            //This needs to handle the data that is not viewed when the algorithm isn't running
            lock_index_change_events = true;

            //Clear qmatrix value textboxes
            foreach(var i in List_qmatrix_value_textboxes)
            {
                i.Value.Clear();
            }

            foreach(var i in list_session_progress)
            {
                i.Clear();
            }

            qmatrix_state_combobox_large.Text = "";

            foreach (var i in list_qmatrix_comboboxes.Values) { i.Items.Clear(); i.Text = ""; }
            foreach (var i in List_qmatrix_value_textboxes.Values) { i.Clear(); }

            lock_index_change_events = false;
        }

        //This is ran every time we step through the algorithm.
        //Handles updating all the fields that change every time we look at new data
        //This method handles any time we are updating what is displayed for any reason once the algorithm is active
        //We expect the algorithm state to be set from the outside before we enter this.
        //This will also handle updating the history dropdowns
        static public void display_state()
        {
            picture_board.clone_position(AlgorithmStateManager.current_state.board_data); //This copies the state's board over to our PictureSquare board.

            //Textboxes update
            if (AlgorithmStateManager.algorithm_started) //Only display this if we've started
            {
                //This will configure the q-matrix dropdowns properly, and handle if there is no qmatrix as well.
                //This doesn't affect the stored entries textbox
                handle_qmatrix_forms(AlgorithmStateManager.current_state, AlgorithmStateManager.current_state.bender_perception_starting);

                //Session progress
                step_number.Text = AlgorithmStateManager.current_state.step_count.ToString();
                episode_number.Text = AlgorithmStateManager.current_state.episode_count.ToString();
                e_session.Text = AlgorithmStateManager.current_state.e_current.ToString();
                n_session.Text = AlgorithmStateManager.current_state.n_current.ToString();
                y_session.Text = AlgorithmStateManager.current_state.y_current.ToString();

                //If this moveset doesn't exist, we should get an error.
                //This function should only be called at the algorithm start, or from a dropdown that has a valid q-matrix combination.
                //These textboxes handle percepts

                PerceptionState to_view = AlgorithmStateManager.current_state.bender_perception_ending;

                foreach (var i in MoveList.list)
                {
                    list_current_position_textboxes[i].Text = to_view.perception_data[i].ToString();

                }

                beer_remaining.Text = AlgorithmStateManager.current_state.board_data.get_cans_remaining().ToString();
                beer_collected.Text = AlgorithmStateManager.current_state.cans_collected.ToString();
                reward_episode.Text = AlgorithmStateManager.current_state.episode_rewards.ToString();
                reward_total.Text = AlgorithmStateManager.current_state.total_rewards.ToString();

                //Update the history episode dropdown
                if (combobox_history_episodes.Items.Count < AlgorithmStateManager.state_history.Count)
                    combobox_history_episodes.Items.Add(AlgorithmStateManager.state_history.Last());

            }

            picture_board.clone_position(AlgorithmStateManager.current_state.board_data);

            //Handle drawing the board
            foreach (var i in picture_board.board_data)
            {
                foreach (var j in i)
                {
                    ((PictureSquare)j).setPicture();
                }
            }




            status_box.Text = AlgorithmStateManager.current_state.status_message.complete_message;
        }

        //Triggers the constructor. Adds a PictureBox to a PictureSquare.
        static public void add(int i, int j, PictureSquare square_to_set)
        {
            picture_board.board_data[i][j] = square_to_set;
        }

        //This is used to display rows of the qmatrix and the q-values for each move
        //This is called from FormsHandler.DisplayState, as well as directly from the dropdowns when their contents are changed.
        //When this is called from displaystate, the perception to view may not be valid.
        //When this is called from the dropdown, the perception should exist in the qmatrix.
        static private void handle_qmatrix_forms(AlgorithmState state_to_display, PerceptionState perception_to_view)
        {
            qmatrix_stored_entires.Text = AlgorithmStateManager.current_state.live_qmatrix.matrix_data.Count.ToString();
            
            //May not have qmatrix data at the step being displayed.
            if (state_to_display.live_qmatrix.matrix_data.Count == 0)
            {   //There are no q-matrix entries.
                //reset qmatrix combo boxes
                foreach (var i in list_qmatrix_comboboxes.Values)
                {
                    i.Items.Clear();
                    i.Items.Add("None");
                }

                qmatrix_state_combobox_large.Items.Clear();
                qmatrix_state_combobox_large.Items.Add("A q-matrix entry has not yet been made.");

                
                //reset qmatrix textboxes
                foreach (var i in List_qmatrix_value_textboxes.Values) { i.Clear(); }
            }
            else
            {
                //Build q-matrix dropdowns.
                //use a hashset to avoid adding duplicates
                //For each move, we want a hashet of percepts, in other words all the percepts that this move sees in the q matrix entries that exist.
                Dictionary<Move, HashSet<Percept>> dropdown_text_items =  new Dictionary<Move, HashSet<Percept>>();

                //Initialize hashsets before looping over perceptionstates
                foreach (var i in MoveList.list)
                {
                    dropdown_text_items.Add(i, new HashSet<Percept>());
                }

                //Copy the items over to the combobox. Loop over perception states.
                foreach (var i in state_to_display.live_qmatrix.matrix_data.Keys)
                {
                    foreach (var j in MoveList.list)
                    {
                        //For each qmatrix entry, copy each percept over to dropdowns dictionary for the appropriate move.
                        dropdown_text_items[j].Add(i.perception_data[j]);
                    }
                }
                
                //Update the comboboxes with the percepts that are available in the qmatrix.
                List<string> string_list = new List<string>(); //Used for sorting...?

                //Cycle through the moves to select each dropdown
                foreach (var i in MoveList.list)
                {
                    list_qmatrix_comboboxes[i].Items.Clear();
                    //Cycle through the percepts we gathered for this move's dropdown
                    foreach (var j in dropdown_text_items[i].OrderBy(o => o.percept_data))
                    {
                        list_qmatrix_comboboxes[i].Items.Add(j); //I think i can just give my objects a tostring method
                    }
                    
                }

                //Refresh the overall-state dropdown
                qmatrix_state_combobox_large.Items.Clear();
                foreach (var i in state_to_display.live_qmatrix.matrix_data.Keys.OrderBy(o => o.ID))
                {
                    qmatrix_state_combobox_large.Items.Add(i);
                }

                //Here, we assume that we are viewing the location bender was previously in.
                view_qmatrix_configuration(state_to_display.bender_perception_starting);

                
            }
        }


        //This is called when the dropdown menu boxes change, as well as from display_state().
        //This will update the comboboxes, state dropdown, and the q-matrix value textboxes.
        static public void view_qmatrix_configuration(PerceptionState state_to_view)
        {
            //We're only handed states that exist in the q-matrix already

            //Handle the small dropdowns
            //Set the dropdown to be selected to the correct percept
            //These will trigger the selected_index_changed events
            //So I'll managed this with a lock
            lock_index_change_events = true;
            foreach(var i in MoveList.list)
            {
                list_qmatrix_comboboxes[i].SelectedIndex = list_qmatrix_comboboxes[i].Items.IndexOf(state_to_view.perception_data[i]);
            }

            //Handle the large dropdown
            qmatrix_state_combobox_large.SelectedIndex = qmatrix_state_combobox_large.Items.IndexOf(state_to_view);

            //Handle the values stored in the textboxes
            foreach (var i in MoveList.list)
            {
                List_qmatrix_value_textboxes[i].Text = AlgorithmStateManager.current_state.live_qmatrix.matrix_data[state_to_view].move_list[i].ToString();
            }

            lock_index_change_events = false;
        }

        static public void large_dropdown_changed()
        {
            view_qmatrix_configuration((PerceptionState)qmatrix_state_combobox_large.SelectedItem);
        }

        static public void small_dropdown_changed(ComboBox changed_dropdown)
        {
            if(changed_dropdown.SelectedText != "None.")
            {

                PerceptionState to_set = new PerceptionState();
                Move percept_move = null;

                foreach (var i in MoveList.list)
                {
                    if (changed_dropdown == list_qmatrix_comboboxes[i])
                        percept_move = i;
                }

                //get the percept of the dropdown
                Percept keep_for_best_fit = (Percept)changed_dropdown.SelectedItem;

                //Build a perception state that matches the dropdowns
                foreach (var i in MoveList.list)
                {
                    to_set.perception_data[i] = (Percept)list_qmatrix_comboboxes[i].SelectedItem;
                }

                to_set.set_name();
                to_set = PerceptionStateList.list_of_states[to_set]; //Convert to static instance

                //This state may not exist in our q-matrix states, because we only changed one of the dropdowns.
                //The best solution i think is to make the other dropdowns find the most accurate state.
                //Compare all the states in the q-matrix, and display any that is tied for best matched.
                //Also, the matching state must have the same item as the dropdown we just changed.

                int compare_value = 0;
                int temp = 0;
                PerceptionState best_perceptionstate = null;
                foreach (PerceptionState i in qmatrix_state_combobox_large.Items)
                {
                    temp = to_set.compare(i);
                    if (temp > compare_value && i.contains(percept_move, keep_for_best_fit))
                    {
                        best_perceptionstate = i;
                        compare_value = temp;
                    }
                }

                view_qmatrix_configuration(best_perceptionstate);
            }


        }

        static public void link_handler_to_form()
        {
            form1_control = Application.OpenForms["Form1"];
            groupbox_initial_settings = form1_control.Controls["groupboxInitialsettings"] as GroupBox;
            groupbox_rewards = groupbox_initial_settings.Controls["groupboxRewards"] as GroupBox; ;
            groupbox_qmatrix = form1_control.Controls["groupboxQmatrix"] as GroupBox; ;
            groupbox_matrix_select = groupbox_qmatrix.Controls["groupboxQmatrixselect"] as GroupBox; ;
            groupbox_qmatrix_values = form1_control.Controls["groupboxQmatrix"].Controls["groupboxQmatrixview"] as GroupBox; ;
            groupbox_session_progress = form1_control.Controls["groupboxSessionprogress"] as GroupBox; ;
            groupbox_can_data = groupbox_session_progress.Controls["groupboxCans"] as GroupBox; ;
            groupbox_reward_data = groupbox_session_progress.Controls["groupboxRewarddata"] as GroupBox; ;
            groupbox_current_position = groupbox_session_progress.Controls["groupboxCurrentposition"] as GroupBox; ;

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
            qmatrix_state_combobox_large = groupbox_matrix_select.Controls["comboboxQmatrixselect"] as ComboBox;
            qmatrix_stored_entires = groupbox_qmatrix.Controls["textboxQmatrixentries"] as TextBox;

            list_qmatrix_comboboxes = new Dictionary<Move, ComboBox>();
            list_qmatrix_comboboxes[MoveList.left()] = groupbox_matrix_select.Controls["comboboxLeft"] as ComboBox;
            list_qmatrix_comboboxes[MoveList.right()] = groupbox_matrix_select.Controls["comboboxRight"] as ComboBox;
            list_qmatrix_comboboxes[MoveList.up()] = groupbox_matrix_select.Controls["comboboxUp"] as ComboBox;
            list_qmatrix_comboboxes[MoveList.down()] = groupbox_matrix_select.Controls["comboboxDown"] as ComboBox;
            list_qmatrix_comboboxes[MoveList.grab()] = groupbox_matrix_select.Controls["comboboxCurrentsquare"] as ComboBox;

            List_qmatrix_value_textboxes = new Dictionary<Move, TextBox>();
            List_qmatrix_value_textboxes[MoveList.left()] = groupbox_qmatrix_values.Controls["textboxQmatrixleft"] as TextBox;
            List_qmatrix_value_textboxes[MoveList.right()] = groupbox_qmatrix_values.Controls["textboxQmatrixright"] as TextBox;
            List_qmatrix_value_textboxes[MoveList.down()] = groupbox_qmatrix_values.Controls["textboxQmatrixdown"] as TextBox;
            List_qmatrix_value_textboxes[MoveList.up()] = groupbox_qmatrix_values.Controls["textboxQmatrixup"] as TextBox;
            List_qmatrix_value_textboxes[MoveList.grab()] = groupbox_qmatrix_values.Controls["textboxQmatrixcurrent"] as TextBox;



            //Session progress
            step_number = groupbox_session_progress.Controls["textboxStepsprogress"] as TextBox;
            episode_number = groupbox_session_progress.Controls["textboxEpisodesprogress"] as TextBox;
            e_session = groupbox_session_progress.Controls["textboxEprogress"] as TextBox;
            n_session = groupbox_session_progress.Controls["textboxNprogress"] as TextBox;
            y_session = groupbox_session_progress.Controls["textboxYprogress"] as TextBox;

            //Can data and reward data
            beer_remaining = groupbox_can_data.Controls["textboxCansremaining"] as TextBox;
            beer_collected = groupbox_can_data.Controls["textboxCanscollected"] as TextBox;
            reward_episode = groupbox_reward_data.Controls["textboxRewardepisode"] as TextBox;
            reward_total = groupbox_reward_data.Controls["textboxRewardtotal"] as TextBox;

            //Current position
            list_current_position_textboxes = new Dictionary<Move, TextBox>();
            list_current_position_textboxes[MoveList.left()] = groupbox_current_position.Controls["textboxLeft"] as TextBox;
            list_current_position_textboxes[MoveList.right()] = groupbox_current_position.Controls["textboxRight"] as TextBox;
            list_current_position_textboxes[MoveList.up()] = groupbox_current_position.Controls["textboxUp"] as TextBox;
            list_current_position_textboxes[MoveList.down()] = groupbox_current_position.Controls["textboxDown"] as TextBox;
            list_current_position_textboxes[MoveList.grab()] = groupbox_current_position.Controls["textboxCurrentsquare"] as TextBox;

            //Add all these textboxes to a list
            list_session_progress = new List<TextBox>();
            foreach (var i in list_current_position_textboxes)
            {
                list_session_progress.Add(i.Value);
            }
            foreach (var i in List_qmatrix_value_textboxes)
            {
                list_session_progress.Add(i.Value);
            }

            list_session_progress.Add(step_number);
            list_session_progress.Add(episode_number);
            list_session_progress.Add(e_session);
            list_session_progress.Add(n_session);
            list_session_progress.Add(y_session);
            list_session_progress.Add(beer_remaining);
            list_session_progress.Add(beer_collected);
            list_session_progress.Add(reward_episode);
            list_session_progress.Add(reward_total);
            list_session_progress.Add(qmatrix_stored_entires);

            //Control progess
            groupbox_control_progress = form1_control.Controls["groupboxAlgorithmprogress"] as GroupBox;
            control_progress_steps = groupbox_control_progress.Controls["comboboxAdvancesteps"] as ComboBox;
            control_progress_episodes = groupbox_control_progress.Controls["comboboxAdvanceepisodes"] as ComboBox;
            control_progress_delay = groupbox_control_progress.Controls["comboboxDelayms"] as ComboBox;


            //Status message
            status_box = form1_control.Controls["groupboxStatusmessage"].Controls["textboxStatus"] as RichTextBox;

            //History
            groupbox_history = form1_control.Controls["groupboxHistory"] as GroupBox;
            combobox_history_episodes = groupbox_history.Controls["comboboxHistoryepisode"] as ComboBox;

        }
    }
}

