using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BenderWorld
{
    static class FormsHandler
    {
        static public bool hasUrlStartedChasing;
        
        //Initial settings
        static public TextBox NumberOfEpisodes;
        static public TextBox NumberOfSteps;
        static public TextBox nInitial;
        static public TextBox yInitial;
        static public TextBox eInitial;
        //Rewards
        static public TextBox wallPunishmentTextbox;
        static public TextBox emptySquarePunishmentTextbox;
        static public TextBox beerRewardTextbox;
        static public TextBox successfulMoveTextbox;

        //Q-matrix view
        static public ComboBox qmatrixStateComboboxLarge; //The larger dropdown
        static public TextBox qmatrixStoredEntires;
        
        //Session progress
        static public TextBox stepNumber;
        static public TextBox episodeNumber;
        static public TextBox eSession;
        static public TextBox ySession;
        //Rewards
        static public TextBox beerCollected;
        static public TextBox beerRemaining;
        static public TextBox rewardEpisode;
        static public TextBox rewardTotal;

        static public RichTextBox statusBox;

        //List of groupbox controls
        static Control form1Control;
        static GroupBox groupboxInitialSettings;
        static GroupBox groupboxRewards;
        static GroupBox groupboxQmatrix;
        static GroupBox groupboxMatrixSelect;
        static GroupBox groupboxQmatrixValues;
        static GroupBox groupboxSessionProgress;
        static GroupBox groupboxCanData;
        static GroupBox groupboxRewardData;
        static GroupBox groupboxCurrentPosition;
        static GroupBox groupboxControlProgress;
        static GroupBox groupboxHistory;


        //Control progress
        static ComboBox controlProgress_steps;
        static ComboBox controlProgress_episodes;
        static ComboBox controlProgress_delay;

        //History
        static ComboBox comboboxHistoryEpisodes;
        static ComboBox comboboxHistorySteps;

        static public bool lockIndexChangeEvents;

        //static public bool is_drop_down_open; //why do i need this?        

        static public bool halted;

        static public List<TextBox> listSessionProgress;

        //store a textbox that displays the percepts of the current position for each move
        static public Dictionary<Move, TextBox> listCurrentPositionTextboxes;
        //Store a textbox that displays a q-matrix value for each move
        static public Dictionary<Move, TextBox> listQmatrixValueTextboxes;
        static public Dictionary<Move, ComboBox> listQmatrixComboboxes; //Store a q-matrix combobox for each move

        //Current position

        //static public List<List<PictureSquare>> current_board;
        //replacing this with a board object
        //not sure if polypmorphism will like that

        //This will be set from the outside, and we will display whatever is in here.
        //static public AlgorithmState current_state;

        static public AlgorithmState loadedState; //The forms handler essentially always stores one state to be displayed at a time.

        static public BoardDisplay pictureBoard; //Stored seperately from the algorithm state because this board will store PictureSquares

        //Main entry point for my source code
        static FormsHandler()
        {

        }

        static public void Load()
        {
            pictureBoard = new BoardDisplay();
            loadedState = new AlgorithmState();

            InitialSettings.Initialize();

            lockIndexChangeEvents = false;
            halted = false;
            //Pass textboxes to the board, so it can manage them.

            link_handlerToForm();

            //Initialize dropdown boxes
            controlProgress_steps.SelectedIndex = 0;
            controlProgress_episodes.Text = "0"; ;
            controlProgress_delay.Text = InitialSettings.MS_Delay.ToString();

            foreach (var i in listQmatrixComboboxes)
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
            pictureBoard.ClonePosition(loadedState.boardData); //This copies the state's board over to our PictureSquare board.

            //Textboxes update
            if (AlgorithmManager.algorithmStarted) //Only display this if we've started
            {
                //This will configure the q-matrix dropdowns properly, and handle if there is no qmatrix as well.
                //This doesn't affect the stored entries textbox
                HandleQmatrixForms(loadedState, loadedState.GetPerception(UnitType.Bender));

                //Session progress
                stepNumber.Text = loadedState.GetStepNumber().ToString();
                episodeNumber.Text = loadedState.GetEpisodeNumber().ToString();
                eSession.Text = GetString(loadedState.liveQmatrix.e);
                ySession.Text = loadedState.liveQmatrix.y.ToString();

                //If this moveset doesn't exist, we should get an error.
                //This function should only be called at the algorithm start, or from a dropdown that has a valid q-matrix combination.
                //These textboxes handle percepts

                PerceptionState to_view = loadedState.boardData.units[UnitType.Bender].perceptionData;

                foreach (var i in Move.HorizontalMovesAndGrab)
                {
                    listCurrentPositionTextboxes[i].Text = to_view.perceptionData[i].ToString();
                }

                beerRemaining.Text = loadedState.boardData.GetCansRemaining().ToString();
                beerCollected.Text = loadedState.cansCollected.ToString();
                rewardEpisode.Text = loadedState.episodeRewards.ToString();
                rewardTotal.Text = loadedState.totalRewards.ToString();

                //Update the history episode dropdown
                if (comboboxHistoryEpisodes.Items.Count < AlgorithmManager.stateHistory.Count)
                    comboboxHistoryEpisodes.Items.Add(AlgorithmManager.stateHistory.Last());

                comboboxHistoryEpisodes.SelectedIndex = comboboxHistoryEpisodes.Items.Count - 1;

                if (!comboboxHistorySteps.Items.Contains(loadedState) || loadedState.GetStepNumber() == 0)
                {
                    comboboxHistorySteps.Items.Clear();
                    comboboxHistorySteps.Items.AddRange(AlgorithmManager.stateHistory.Last().ToArray());
                    comboboxHistorySteps.Text = loadedState.ToString();
                }
            }

            
            statusBox.Text = loadedState.GetStatus();

            //Handle drawing the board
            foreach (var i in pictureBoard.boardData)
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
            NumberOfEpisodes.Text = loadedState.GetEpisodeLimit().ToString(); //Constructor launcher for algorithmstate 6-5
            NumberOfSteps.Text = loadedState.GetStepLimit().ToString();

            nInitial.Text = GetString(loadedState.liveQmatrix.n);
            yInitial.Text = GetString(loadedState.liveQmatrix.y);
            eInitial.Text = GetString(loadedState.liveQmatrix.e);
            emptySquarePunishmentTextbox.Text = MoveResult.list[MoveResult.CanMissing].ToString();
            wallPunishmentTextbox.Text = MoveResult.list[MoveResult.TravelFailed].ToString();
            beerRewardTextbox.Text = MoveResult.list[MoveResult.CanCollected].ToString();
            successfulMoveTextbox.Text = MoveResult.list[MoveResult.TravelSucceeded].ToString();
        }

        //This is used to display rows of the qmatrix and the q-values for each move
        //This is called from FormsHandler.DisplayState, as well as directly from the dropdowns when their contents are changed.
        //When this is called from displaystate, the perception to view may not be valid.
        //When this is called from the dropdown, the perception should exist in the qmatrix.
        static private void HandleQmatrixForms(AlgorithmState current_state, PerceptionState perceptionTo_view)
        {
            qmatrixStoredEntires.Text = current_state.liveQmatrix.matrixData.Count.ToString();

            //May not have qmatrix data at the step being displayed.
            if (current_state.liveQmatrix.matrixData.Count == 0)
            {   //There are no q-matrix entries.
                //reset qmatrix combo boxes
                foreach (var i in listQmatrixComboboxes.Values)
                {
                    i.Items.Clear();
                    i.Items.Add("None");
                }

                qmatrixStateComboboxLarge.Items.Clear();
                qmatrixStateComboboxLarge.Items.Add("A q-matrix entry has not yet been made.");


                //reset qmatrix textboxes
                foreach (var i in listQmatrixValueTextboxes.Values) { i.Clear(); }
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
                    listQmatrixComboboxes[i].Items.Clear();
                    //Cycle through the percepts we gathered for this move's dropdown
                    foreach (var j in dropdownText_items[i].OrderBy(o => o.perceptData))
                    {
                        listQmatrixComboboxes[i].Items.Add(j); //I think i can just give my objects a tostring method
                    }
                }

                //Refresh the overall-state dropdown
                qmatrixStateComboboxLarge.Items.Clear();
                foreach (var i in current_state.liveQmatrix.matrixData.Keys.OrderBy(o => o.ID))
                {
                    qmatrixStateComboboxLarge.Items.Add(i);
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
            lockIndexChangeEvents = true;
            foreach (var i in Move.HorizontalMovesAndGrab)
            {
                listQmatrixComboboxes[i].SelectedIndex = listQmatrixComboboxes[i].Items.IndexOf(stateTo_view.perceptionData[i]);
            }

            //Handle the large dropdown
            qmatrixStateComboboxLarge.SelectedIndex = qmatrixStateComboboxLarge.Items.IndexOf(stateTo_view);

            //Handle the values stored in the textboxes

            foreach (var i in Move.HorizontalMovesAndGrab)
            {
                listQmatrixValueTextboxes[i].Text = loadedState.liveQmatrix.matrixData[stateTo_view].moveList[i].ToString();
            }

            lockIndexChangeEvents = false;
        }


        

        //Used after "algorithm reset" button is pressed. Not used during algorithm run.
        static public void ResetConfiguration()
        {
            loadedState.InitializeValues(); //Special function that creates a new board but keeps bender's position   
                                            //clear the board and keep bender 
                                            //This needs to handle the data that is not viewed when the algorithm isn't running

            loadedState.SetErasedStatus();

            lockIndexChangeEvents = true;

            //Clear qmatrix value textboxes
            foreach(var i in listQmatrixValueTextboxes)
            {
                i.Value.Clear();
            }

            //Session progess textboxes
            foreach(var i in listSessionProgress)
            {
                i.Clear();
            }

            

            foreach (var i in listQmatrixComboboxes.Values) { i.Items.Clear(); i.Text = ""; }
            foreach (var i in listQmatrixValueTextboxes.Values) { i.Clear(); }

            lockIndexChangeEvents = false;

            qmatrixStateComboboxLarge.Text = "Select a board state...";

            comboboxHistorySteps.Items.Clear();
            comboboxHistorySteps.Text = "View prior steps...";

            comboboxHistoryEpisodes.Items.Clear();
            comboboxHistoryEpisodes.Text = "View prior episodes...";

            loadedState.liveQmatrix = new Qmatrix();

            DisplayState();
            
        }


        //Triggers the constructor. Adds a PictureBox to a PictureSquare.
        static public void Add(int i, int j, SquareBoardDisplay squareTo_set)
        {
            pictureBoard.boardData[i][j] = squareTo_set;
        }

        



        static public void large_dropdownChanged()
        {
            ViewQmatrixConfiguration((PerceptionState)qmatrixStateComboboxLarge.SelectedItem);
        }

        static public void small_dropdownChanged(ComboBox changed_dropdown)
        {
            if(changed_dropdown.SelectedText != "None.")
            {

                PerceptionState to_set = new PerceptionState(UnitType.Bender);
                Move perceptMove = null;

                foreach (var i in Move.HorizontalMovesAndGrab)
                {
                    if (changed_dropdown == listQmatrixComboboxes[i])
                        perceptMove = i;
                }

                //get the percept of the dropdown
                Percept keepFor_bestFit = (Percept)changed_dropdown.SelectedItem;

                //Build a perception state that matches the dropdowns
                foreach (var i in Move.HorizontalMovesAndGrab)
                {
                    to_set.perceptionData[i] = (Percept)listQmatrixComboboxes[i].SelectedItem;
                }

                to_set.SetName();

                //This state may not exist in our q-matrix states, because we only changed one of the dropdowns.
                //The best solution i think is to make the other dropdowns find the most accurate state.
                //Compare all the states in the q-matrix, and display any that is tied for best matched.
                //Also, the matching state must have the same item as the dropdown we just changed.

                int compare_value = 0;
                int temp = 0;
                PerceptionState bestPerceptionstate = null;
                foreach (PerceptionState i in qmatrixStateComboboxLarge.Items)
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
            groupboxInitialSettings = form1Control.Controls["groupboxInitialsettings"] as GroupBox;
            groupboxRewards = groupboxInitialSettings.Controls["groupboxRewards"] as GroupBox; ;
            groupboxQmatrix = form1Control.Controls["groupboxQmatrix"] as GroupBox; ;
            groupboxMatrixSelect = groupboxQmatrix.Controls["groupboxQmatrixselect"] as GroupBox; ;
            groupboxQmatrixValues = form1Control.Controls["groupboxQmatrix"].Controls["groupboxQmatrixview"] as GroupBox; ;
            groupboxSessionProgress = form1Control.Controls["groupboxSessionprogress"] as GroupBox; ;
            groupboxCanData = groupboxSessionProgress.Controls["groupboxCans"] as GroupBox; ;
            groupboxRewardData = groupboxSessionProgress.Controls["groupboxRewarddata"] as GroupBox; ;
            groupboxCurrentPosition = groupboxSessionProgress.Controls["groupboxCurrentposition"] as GroupBox; ;

            //Initial settings
            NumberOfEpisodes = groupboxInitialSettings.Controls["textboxInitialNumberofepisodes"] as TextBox;
            NumberOfSteps = groupboxInitialSettings.Controls["textboxInitialNumberofsteps"] as TextBox;
            nInitial = groupboxInitialSettings.Controls["textboxInitialNinitial"] as TextBox;
            yInitial = groupboxInitialSettings.Controls["textboxInitialY"] as TextBox;
            eInitial = groupboxInitialSettings.Controls["textboxInitialEpsilon"] as TextBox;
            //Rewards
            wallPunishmentTextbox = groupboxRewards.Controls["textboxInitialWallpunishment"] as TextBox;
            emptySquarePunishmentTextbox = groupboxRewards.Controls["textboxInitialEmptysquare"] as TextBox;
            beerRewardTextbox = groupboxRewards.Controls["textboxInitialBeerreward"] as TextBox;
            successfulMoveTextbox = groupboxRewards.Controls["textboxRewardssuccessmove"] as TextBox;

            //Q-Matrix view
            qmatrixStateComboboxLarge = groupboxMatrixSelect.Controls["comboboxQmatrixselect"] as ComboBox;
            qmatrixStoredEntires = groupboxQmatrix.Controls["textboxQmatrixentries"] as TextBox;

            listQmatrixComboboxes = new Dictionary<Move, ComboBox>();
            listQmatrixComboboxes[Move.Left] = groupboxMatrixSelect.Controls["comboboxLeft"] as ComboBox;
            listQmatrixComboboxes[Move.Right] = groupboxMatrixSelect.Controls["comboboxRight"] as ComboBox;
            listQmatrixComboboxes[Move.Up] = groupboxMatrixSelect.Controls["comboboxUp"] as ComboBox;
            listQmatrixComboboxes[Move.Down] = groupboxMatrixSelect.Controls["comboboxDown"] as ComboBox;
            listQmatrixComboboxes[Move.Grab] = groupboxMatrixSelect.Controls["comboboxCurrentsquare"] as ComboBox;

            listQmatrixValueTextboxes = new Dictionary<Move, TextBox>();
            listQmatrixValueTextboxes[Move.Left] = groupboxQmatrixValues.Controls["textboxQmatrixleft"] as TextBox;
            listQmatrixValueTextboxes[Move.Right] = groupboxQmatrixValues.Controls["textboxQmatrixright"] as TextBox;
            listQmatrixValueTextboxes[Move.Down] = groupboxQmatrixValues.Controls["textboxQmatrixdown"] as TextBox;
            listQmatrixValueTextboxes[Move.Up] = groupboxQmatrixValues.Controls["textboxQmatrixup"] as TextBox;
            listQmatrixValueTextboxes[Move.Grab] = groupboxQmatrixValues.Controls["textboxQmatrixcurrent"] as TextBox;



            //Session progress
            stepNumber = groupboxSessionProgress.Controls["textboxStepsprogress"] as TextBox;
            episodeNumber = groupboxSessionProgress.Controls["textboxEpisodesprogress"] as TextBox;
            eSession = groupboxSessionProgress.Controls["textboxEprogress"] as TextBox;
            ySession = groupboxSessionProgress.Controls["textboxYprogress"] as TextBox;

            //Can data and reward data
            beerRemaining = groupboxCanData.Controls["textboxCansremaining"] as TextBox;
            beerCollected = groupboxCanData.Controls["textboxCanscollected"] as TextBox;
            rewardEpisode = groupboxRewardData.Controls["textboxRewardepisode"] as TextBox;
            rewardTotal = groupboxRewardData.Controls["textboxRewardtotal"] as TextBox;

            //Current position
            listCurrentPositionTextboxes = new Dictionary<Move, TextBox>();
            listCurrentPositionTextboxes[Move.Left] = groupboxCurrentPosition.Controls["textboxLeft"] as TextBox;
            listCurrentPositionTextboxes[Move.Right] = groupboxCurrentPosition.Controls["textboxRight"] as TextBox;
            listCurrentPositionTextboxes[Move.Up] = groupboxCurrentPosition.Controls["textboxUp"] as TextBox;
            listCurrentPositionTextboxes[Move.Down] = groupboxCurrentPosition.Controls["textboxDown"] as TextBox;
            listCurrentPositionTextboxes[Move.Grab] = groupboxCurrentPosition.Controls["textboxCurrentsquare"] as TextBox;

            //Add all these textboxes to a list
            listSessionProgress = new List<TextBox>();
            foreach (var i in listCurrentPositionTextboxes)
            {
                listSessionProgress.Add(i.Value);
            }
            foreach (var i in listQmatrixValueTextboxes)
            {
                listSessionProgress.Add(i.Value);
            }

            listSessionProgress.Add(stepNumber);
            listSessionProgress.Add(episodeNumber);
            listSessionProgress.Add(eSession);
            listSessionProgress.Add(ySession);
            listSessionProgress.Add(beerRemaining);
            listSessionProgress.Add(beerCollected);
            listSessionProgress.Add(rewardEpisode);
            listSessionProgress.Add(rewardTotal);
            listSessionProgress.Add(qmatrixStoredEntires);

            //Control progess
            groupboxControlProgress = form1Control.Controls["groupboxAlgorithmprogress"] as GroupBox;
            controlProgress_steps = groupboxControlProgress.Controls["comboboxAdvancesteps"] as ComboBox;
            controlProgress_episodes = groupboxControlProgress.Controls["comboboxAdvanceepisodes"] as ComboBox;
            controlProgress_delay = groupboxControlProgress.Controls["comboboxDelayms"] as ComboBox;


            //Status message
            statusBox = form1Control.Controls["groupboxStatusmessage"].Controls["textboxStatus"] as RichTextBox;

            //History
            groupboxHistory = form1Control.Controls["groupboxHistory"] as GroupBox;
            comboboxHistoryEpisodes = groupboxHistory.Controls["comboboxHistoryepisode"] as ComboBox;
            comboboxHistorySteps = groupboxHistory.Controls["comboboxHistorystep"] as ComboBox;

        }

        public static string GetString(double toConvert)
        {
            return toConvert.ToString();
            //gotta fix this display setting later
        }
    }


}

