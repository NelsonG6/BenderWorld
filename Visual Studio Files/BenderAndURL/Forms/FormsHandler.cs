using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BenderAndURL
{
    static class FormsHandler
    {
        static public bool hasUrlStartedChasing;
        
        //Initial settings
        static public TextBox number_of_episodes;
        static public TextBox number_of_steps;
        static public TextBox n_initial;
        static public TextBox y_initial;
        static public TextBox e_initial;
        //Rewards
        static public TextBox wallPunishmentTextbox;
        static public TextBox empty_squarePunishmentTextbox;
        static public TextBox beer_rewardTextbox;
        static public TextBox successfulMoveTextbox;

        //Q-matrix view
        static public ComboBox qmatrix_stateComboboxLarge; //The larger dropdown
        static public TextBox qmatrix_stored_entires;
        
        //Session progress
        static public TextBox stepNumber;
        static public TextBox episodeNumber;
        static public TextBox e_session;
        static public TextBox y_session;
        //Rewards
        static public TextBox beerCollected;
        static public TextBox beer_remaining;
        static public TextBox reward_episode;
        static public TextBox rewardTotal;

        static public RichTextBox status_box;

        //List of groupbox controls
        static Control form1Control;
        static GroupBox groupbox_initial_settings;
        static GroupBox groupbox_rewards;
        static GroupBox groupbox_qmatrix;
        static GroupBox groupboxMatrix_select;
        static GroupBox groupbox_qmatrix_values;
        static GroupBox groupbox_sessionProgress;
        static GroupBox groupboxCan_data;
        static GroupBox groupbox_reward_data;
        static GroupBox groupboxCurrentPosition;
        static GroupBox groupboxControlProgress;
        static GroupBox groupbox_history;


        //Control progress
        static ComboBox controlProgress_steps;
        static ComboBox controlProgress_episodes;
        static ComboBox controlProgress_delay;

        //History
        static ComboBox combobox_history_episodes;
        static ComboBox combobox_history_steps;

        static public bool lock_indexChange_events;

        //static public bool is_drop_down_open; //why do i need this?        

        static public bool halted;

        static public List<TextBox> list_sessionProgress;

        //store a textbox that displays the percepts of the current position for each move
        static public Dictionary<Move, TextBox> listCurrentPositionTextboxes;
        //Store a textbox that displays a q-matrix value for each move
        static public Dictionary<Move, TextBox> List_qmatrix_valueTextboxes;
        static public Dictionary<Move, ComboBox> list_qmatrixComboboxes; //Store a q-matrix combobox for each move

        //Current position

        //static public List<List<PictureSquare>> current_board;
        //replacing this with a board object
        //not sure if polypmorphism will like that

        //This will be set from the outside, and we will display whatever is in here.
        //static public AlgorithmState current_state;

        static public AlgorithmState loadedState; //The forms handler essentially always stores one state to be displayed at a time.

        static public BoardDisplay picture_board; //Stored seperately from the algorithm state because this board will store PictureSquares

        //Main entry point for my source code
        static FormsHandler()
        {

        }

        static public void load()
        {
            picture_board = new BoardDisplay();
            loadedState = new AlgorithmState();

            InitialSettings.Initialize();

            lock_indexChange_events = false;
            halted = false;
            //Pass textboxes to the board, so it can manage them.

            link_handlerToForm();

            //Initialize dropdown boxes
            controlProgress_steps.SelectedIndex = 0;
            controlProgress_episodes.Text = "0"; ;
            controlProgress_delay.Text = InitialSettings.MS_Delay.ToString();

            foreach (var i in list_qmatrixComboboxes)
            {
                i.Value.SelectedIndex = -1;
            }

            DisplayInitialSettings();
        }

        static public void Initialize()
        {

        }

        //This is ran every time we step through the algorithm.
        //Handles updating all the fields that change every time we look at new data
        //This method handles any time we are updating what is displayed for any reason once the algorithm is active
        //We expect the algorithm state to be set from the outside before we enter this.
        //This will also handle updating the history dropdowns
        static public void DisplayState()
        {
            picture_board.ClonePosition(loadedState.boardData); //This copies the state's board over to our PictureSquare board.

            //Textboxes update
            if (AlgorithmManager.algorithmStarted) //Only display this if we've started
            {
                //This will configure the q-matrix dropdowns properly, and handle if there is no qmatrix as well.
                //This doesn't affect the stored entries textbox
                HandleQmatrixForms(loadedState, loadedState.GetPerception(UnitType.Bender));

                //Session progress
                stepNumber.Text = loadedState.GetStepNumber().ToString();
                episodeNumber.Text = loadedState.GetEpisodeNumber().ToString();
                e_session.Text = GetString(loadedState.liveQmatrix.e);
                y_session.Text = loadedState.liveQmatrix.y.ToString();

                //If this moveset doesn't exist, we should get an error.
                //This function should only be called at the algorithm start, or from a dropdown that has a valid q-matrix combination.
                //These textboxes handle percepts

                PerceptionState to_view = loadedState.boardData.units[UnitType.Bender].perceptionData;

                foreach (var i in Move.HorizontalMovesAndGrab)
                {
                    listCurrentPositionTextboxes[i].Text = to_view.perceptionData[i].ToString();
                }

                beer_remaining.Text = loadedState.boardData.GetCansRemaining().ToString();
                beerCollected.Text = loadedState.cansCollected.ToString();
                reward_episode.Text = loadedState.episodeRewards.ToString();
                rewardTotal.Text = loadedState.totalRewards.ToString();

                //Update the history episode dropdown
                if (combobox_history_episodes.Items.Count < AlgorithmManager.stateHistory.Count)
                    combobox_history_episodes.Items.Add(AlgorithmManager.stateHistory.Last());

                combobox_history_episodes.SelectedIndex = combobox_history_episodes.Items.Count - 1;

                if (!combobox_history_steps.Items.Contains(loadedState) || loadedState.GetStepNumber() == 0)
                {
                    combobox_history_steps.Items.Clear();
                    combobox_history_steps.Items.AddRange(AlgorithmManager.stateHistory.Last().ToArray());
                    combobox_history_steps.Text = loadedState.ToString();
                }
            }

            
            status_box.Text = loadedState.GetStatus();

            //Handle drawing the board
            foreach (var i in picture_board.boardData)
            {
                foreach (var j in i)
                {
                    ((SquareBoardDisplay)j).SetPicture();
                }
            }

            DisplayInitialSettings();

            //If the algorithm is ended, disable the stepping groupbox.
            if(AlgorithmManager.algorithmEnded == true)
            {
                groupboxControlProgress.Enabled = false;
            }
        }

        static public void DisplayInitialSettings()
        {
            //initial settings
            number_of_episodes.Text = loadedState.GetEpisodeLimit().ToString(); //Constructor launcher for algorithmstate 6-5
            number_of_steps.Text = loadedState.GetStepLimit().ToString();

            n_initial.Text = GetString(loadedState.liveQmatrix.n);
            y_initial.Text = GetString(loadedState.liveQmatrix.y);
            e_initial.Text = GetString(loadedState.liveQmatrix.e);
            empty_squarePunishmentTextbox.Text = MoveResult.list[MoveResult.CanMissing].ToString();
            wallPunishmentTextbox.Text = MoveResult.list[MoveResult.TravelFailed].ToString();
            beer_rewardTextbox.Text = MoveResult.list[MoveResult.CanCollected].ToString();
            successfulMoveTextbox.Text = MoveResult.list[MoveResult.TravelSucceeded].ToString();
        }

        //This is used to display rows of the qmatrix and the q-values for each move
        //This is called from FormsHandler.DisplayState, as well as directly from the dropdowns when their contents are changed.
        //When this is called from displaystate, the perception to view may not be valid.
        //When this is called from the dropdown, the perception should exist in the qmatrix.
        static private void HandleQmatrixForms(AlgorithmState current_state, PerceptionState perceptionTo_view)
        {
            qmatrix_stored_entires.Text = current_state.liveQmatrix.matrixData.Count.ToString();

            //May not have qmatrix data at the step being displayed.
            if (current_state.liveQmatrix.matrixData.Count == 0)
            {   //There are no q-matrix entries.
                //reset qmatrix combo boxes
                foreach (var i in list_qmatrixComboboxes.Values)
                {
                    i.Items.Clear();
                    i.Items.Add("None");
                }

                qmatrix_stateComboboxLarge.Items.Clear();
                qmatrix_stateComboboxLarge.Items.Add("A q-matrix entry has not yet been made.");


                //reset qmatrix textboxes
                foreach (var i in List_qmatrix_valueTextboxes.Values) { i.Clear(); }
            }
            else
            {
                //Build q-matrix dropdowns.
                //use a hashset to avoid adding duplicates
                //For each move, we want a hashet of percepts, in other words all the percepts that this move sees in the q matrix entries that exist.
                Dictionary<Move, HashSet<Percept>> dropdownText_items = new Dictionary<Move, HashSet<Percept>>();

                //Initialize hashsets before looping over perceptionstates
                foreach (var i in Move.HorizontalMovesAndGrab)
                {
                    dropdownText_items.Add(i, new HashSet<Percept>());
                }

                //Copy the items over to the small comboboxes.
                foreach (var i in current_state.liveQmatrix.matrixData.Keys)
                {
                    foreach (var j in Move.HorizontalMovesAndGrab)
                    {
                        //For each qmatrix entry, copy each percept over to dropdowns dictionary for the appropriate move.
                        dropdownText_items[j].Add(i.perceptionData[j]);
                    }
                }


                //Cycle through the moves to add to select each small combobox
                foreach (var i in Move.HorizontalMovesAndGrab)
                {
                    list_qmatrixComboboxes[i].Items.Clear();
                    //Cycle through the percepts we gathered for this move's dropdown
                    foreach (var j in dropdownText_items[i].OrderBy(o => o.perceptData))
                    {
                        list_qmatrixComboboxes[i].Items.Add(j); //I think i can just give my objects a tostring method
                    }
                }

                //Refresh the overall-state dropdown
                qmatrix_stateComboboxLarge.Items.Clear();
                foreach (var i in current_state.liveQmatrix.matrixData.Keys.OrderBy(o => o.ID))
                {
                    qmatrix_stateComboboxLarge.Items.Add(i);
                }

                if (current_state.liveQmatrix.matrixData.Keys.Contains(current_state.GetPerception(UnitType.Bender)))
                    ViewQmatrixConfiguration(current_state.GetPerception(UnitType.Bender));
                else
                    ViewQmatrixConfiguration(loadedState.liveQmatrix.matrixData.Keys.First()); //Just grab the first q-matrix item

            }
        }

        //This is called when the dropdown menu boxes change, as well as from display_state().
        //This will update the comboboxes, state dropdown, and the q-matrix value textboxes.
        static public void ViewQmatrixConfiguration(PerceptionState stateTo_view)
        {
            //We're only handed states that exist in the q-matrix already

            //Handle the small dropdowns
            //Set the dropdown to be selected to the correct percept
            //These will trigger the selected_indexChanged events
            //So I'll managed this with a lock
            lock_indexChange_events = true;
            foreach (var i in Move.HorizontalMovesAndGrab)
            {
                list_qmatrixComboboxes[i].SelectedIndex = list_qmatrixComboboxes[i].Items.IndexOf(stateTo_view.perceptionData[i]);
            }

            //Handle the large dropdown
            qmatrix_stateComboboxLarge.SelectedIndex = qmatrix_stateComboboxLarge.Items.IndexOf(stateTo_view);

            //Handle the values stored in the textboxes

            foreach (var i in Move.HorizontalMovesAndGrab)
            {
                List_qmatrix_valueTextboxes[i].Text = loadedState.liveQmatrix.matrixData[stateTo_view].moveList[i].ToString();
            }

            lock_indexChange_events = false;
        }


        

        //Used after "algorithm reset" button is pressed. Not used during algorithm run.
        static public void ResetConfiguration()
        {
            loadedState.InitializeValues(); //Special function that creates a new board but keeps bender's position   
                                            //clear the board and keep bender 
                                            //This needs to handle the data that is not viewed when the algorithm isn't running

            loadedState.SetErasedStatus();

            lock_indexChange_events = true;

            //Clear qmatrix value textboxes
            foreach(var i in List_qmatrix_valueTextboxes)
            {
                i.Value.Clear();
            }

            //Session progess textboxes
            foreach(var i in list_sessionProgress)
            {
                i.Clear();
            }

            

            foreach (var i in list_qmatrixComboboxes.Values) { i.Items.Clear(); i.Text = ""; }
            foreach (var i in List_qmatrix_valueTextboxes.Values) { i.Clear(); }

            lock_indexChange_events = false;

            qmatrix_stateComboboxLarge.Text = "Select a board state...";

            combobox_history_steps.Items.Clear();
            combobox_history_steps.Text = "View prior steps...";

            combobox_history_episodes.Items.Clear();
            combobox_history_episodes.Text = "View prior episodes...";

            loadedState.liveQmatrix = new Qmatrix();

            DisplayState();
            
        }


        //Triggers the constructor. Adds a PictureBox to a PictureSquare.
        static public void Add(int i, int j, SquareBoardDisplay squareTo_set)
        {
            picture_board.boardData[i][j] = squareTo_set;
        }

        



        static public void large_dropdownChanged()
        {
            ViewQmatrixConfiguration((PerceptionState)qmatrix_stateComboboxLarge.SelectedItem);
        }

        static public void small_dropdownChanged(ComboBox changed_dropdown)
        {
            if(changed_dropdown.SelectedText != "None.")
            {

                PerceptionState to_set = new PerceptionState(UnitType.Bender);
                Move perceptMove = null;

                foreach (var i in Move.HorizontalMovesAndGrab)
                {
                    if (changed_dropdown == list_qmatrixComboboxes[i])
                        perceptMove = i;
                }

                //get the percept of the dropdown
                Percept keepFor_bestFit = (Percept)changed_dropdown.SelectedItem;

                //Build a perception state that matches the dropdowns
                foreach (var i in Move.HorizontalMovesAndGrab)
                {
                    to_set.perceptionData[i] = (Percept)list_qmatrixComboboxes[i].SelectedItem;
                }

                to_set.SetName();

                //This state may not exist in our q-matrix states, because we only changed one of the dropdowns.
                //The best solution i think is to make the other dropdowns find the most accurate state.
                //Compare all the states in the q-matrix, and display any that is tied for best matched.
                //Also, the matching state must have the same item as the dropdown we just changed.

                int compare_value = 0;
                int temp = 0;
                PerceptionState bestPerceptionstate = null;
                foreach (PerceptionState i in qmatrix_stateComboboxLarge.Items)
                {
                    temp = to_set.Compare(i);
                    if (temp > compare_value && i.Contains(perceptMove, keepFor_bestFit))
                    {
                        bestPerceptionstate = i;
                        compare_value = temp;
                    }
                }

                ViewQmatrixConfiguration(bestPerceptionstate);
            }


        }

        //Displays the most recent state in the algorithm history list
        static public void LoadAndDisplayState(AlgorithmState to_display)
        {
            loadedState = to_display;
            DisplayState();
        }

        static public void link_handlerToForm()
        {
            form1Control = Application.OpenForms["Form1"];
            groupbox_initial_settings = form1Control.Controls["groupboxInitialsettings"] as GroupBox;
            groupbox_rewards = groupbox_initial_settings.Controls["groupboxRewards"] as GroupBox; ;
            groupbox_qmatrix = form1Control.Controls["groupboxQmatrix"] as GroupBox; ;
            groupboxMatrix_select = groupbox_qmatrix.Controls["groupboxQmatrixselect"] as GroupBox; ;
            groupbox_qmatrix_values = form1Control.Controls["groupboxQmatrix"].Controls["groupboxQmatrixview"] as GroupBox; ;
            groupbox_sessionProgress = form1Control.Controls["groupboxSessionprogress"] as GroupBox; ;
            groupboxCan_data = groupbox_sessionProgress.Controls["groupboxCans"] as GroupBox; ;
            groupbox_reward_data = groupbox_sessionProgress.Controls["groupboxRewarddata"] as GroupBox; ;
            groupboxCurrentPosition = groupbox_sessionProgress.Controls["groupboxCurrentposition"] as GroupBox; ;

            //Initial settings
            number_of_episodes = groupbox_initial_settings.Controls["textboxInitialNumberofepisodes"] as TextBox;
            number_of_steps = groupbox_initial_settings.Controls["textboxInitialNumberofsteps"] as TextBox;
            n_initial = groupbox_initial_settings.Controls["textboxInitialNinitial"] as TextBox;
            y_initial = groupbox_initial_settings.Controls["textboxInitialY"] as TextBox;
            e_initial = groupbox_initial_settings.Controls["textboxInitialEpsilon"] as TextBox;
            //Rewards
            wallPunishmentTextbox = groupbox_rewards.Controls["textboxInitialWallpunishment"] as TextBox;
            empty_squarePunishmentTextbox = groupbox_rewards.Controls["textboxInitialEmptysquare"] as TextBox;
            beer_rewardTextbox = groupbox_rewards.Controls["textboxInitialBeerreward"] as TextBox;
            successfulMoveTextbox = groupbox_rewards.Controls["textboxRewardssuccessmove"] as TextBox;

            //Q-Matrix view
            qmatrix_stateComboboxLarge = groupboxMatrix_select.Controls["comboboxQmatrixselect"] as ComboBox;
            qmatrix_stored_entires = groupbox_qmatrix.Controls["textboxQmatrixentries"] as TextBox;

            list_qmatrixComboboxes = new Dictionary<Move, ComboBox>();
            list_qmatrixComboboxes[Move.Left] = groupboxMatrix_select.Controls["comboboxLeft"] as ComboBox;
            list_qmatrixComboboxes[Move.Right] = groupboxMatrix_select.Controls["comboboxRight"] as ComboBox;
            list_qmatrixComboboxes[Move.Up] = groupboxMatrix_select.Controls["comboboxUp"] as ComboBox;
            list_qmatrixComboboxes[Move.Down] = groupboxMatrix_select.Controls["comboboxDown"] as ComboBox;
            list_qmatrixComboboxes[Move.Grab] = groupboxMatrix_select.Controls["comboboxCurrentsquare"] as ComboBox;

            List_qmatrix_valueTextboxes = new Dictionary<Move, TextBox>();
            List_qmatrix_valueTextboxes[Move.Left] = groupbox_qmatrix_values.Controls["textboxQmatrixleft"] as TextBox;
            List_qmatrix_valueTextboxes[Move.Right] = groupbox_qmatrix_values.Controls["textboxQmatrixright"] as TextBox;
            List_qmatrix_valueTextboxes[Move.Down] = groupbox_qmatrix_values.Controls["textboxQmatrixdown"] as TextBox;
            List_qmatrix_valueTextboxes[Move.Up] = groupbox_qmatrix_values.Controls["textboxQmatrixup"] as TextBox;
            List_qmatrix_valueTextboxes[Move.Grab] = groupbox_qmatrix_values.Controls["textboxQmatrixcurrent"] as TextBox;



            //Session progress
            stepNumber = groupbox_sessionProgress.Controls["textboxStepsprogress"] as TextBox;
            episodeNumber = groupbox_sessionProgress.Controls["textboxEpisodesprogress"] as TextBox;
            e_session = groupbox_sessionProgress.Controls["textboxEprogress"] as TextBox;
            y_session = groupbox_sessionProgress.Controls["textboxYprogress"] as TextBox;

            //Can data and reward data
            beer_remaining = groupboxCan_data.Controls["textboxCansremaining"] as TextBox;
            beerCollected = groupboxCan_data.Controls["textboxCanscollected"] as TextBox;
            reward_episode = groupbox_reward_data.Controls["textboxRewardepisode"] as TextBox;
            rewardTotal = groupbox_reward_data.Controls["textboxRewardtotal"] as TextBox;

            //Current position
            listCurrentPositionTextboxes = new Dictionary<Move, TextBox>();
            listCurrentPositionTextboxes[Move.Left] = groupboxCurrentPosition.Controls["textboxLeft"] as TextBox;
            listCurrentPositionTextboxes[Move.Right] = groupboxCurrentPosition.Controls["textboxRight"] as TextBox;
            listCurrentPositionTextboxes[Move.Up] = groupboxCurrentPosition.Controls["textboxUp"] as TextBox;
            listCurrentPositionTextboxes[Move.Down] = groupboxCurrentPosition.Controls["textboxDown"] as TextBox;
            listCurrentPositionTextboxes[Move.Grab] = groupboxCurrentPosition.Controls["textboxCurrentsquare"] as TextBox;

            //Add all these textboxes to a list
            list_sessionProgress = new List<TextBox>();
            foreach (var i in listCurrentPositionTextboxes)
            {
                list_sessionProgress.Add(i.Value);
            }
            foreach (var i in List_qmatrix_valueTextboxes)
            {
                list_sessionProgress.Add(i.Value);
            }

            list_sessionProgress.Add(stepNumber);
            list_sessionProgress.Add(episodeNumber);
            list_sessionProgress.Add(e_session);
            list_sessionProgress.Add(y_session);
            list_sessionProgress.Add(beer_remaining);
            list_sessionProgress.Add(beerCollected);
            list_sessionProgress.Add(reward_episode);
            list_sessionProgress.Add(rewardTotal);
            list_sessionProgress.Add(qmatrix_stored_entires);

            //Control progess
            groupboxControlProgress = form1Control.Controls["groupboxAlgorithmprogress"] as GroupBox;
            controlProgress_steps = groupboxControlProgress.Controls["comboboxAdvancesteps"] as ComboBox;
            controlProgress_episodes = groupboxControlProgress.Controls["comboboxAdvanceepisodes"] as ComboBox;
            controlProgress_delay = groupboxControlProgress.Controls["comboboxDelayms"] as ComboBox;


            //Status message
            status_box = form1Control.Controls["groupboxStatusmessage"].Controls["textboxStatus"] as RichTextBox;

            //History
            groupbox_history = form1Control.Controls["groupboxHistory"] as GroupBox;
            combobox_history_episodes = groupbox_history.Controls["comboboxHistoryepisode"] as ComboBox;
            combobox_history_steps = groupbox_history.Controls["comboboxHistorystep"] as ComboBox;

        }

        public static string GetString(double toConvert)
        {
            return toConvert.ToString();
            //gotta fix this display setting later
        }
    }


}

