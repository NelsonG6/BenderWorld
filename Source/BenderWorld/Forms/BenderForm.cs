using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BenderWorld
{
    public partial class BenderForm : Form
    {
        static private readonly List<TextBox> listSessionProgress;

        //store a textbox that displays the percepts of the current position for each move
        static private readonly Dictionary<Move, TextBox> listCurrentPositionTextboxes;
        //Store a textbox that displays a q-matrix value for each move
        static private readonly Dictionary<Move, TextBox> listQmatrixValueTextboxes;
        static private Dictionary<Move, ComboBox> listQmatrixComboboxes; //Store a q-matrix combobox for each move

        static private readonly BoardDisplay pictureBoard;
        //Stored seperately from the algorithm state because this board will store PictureSquares

        //Public
        static public bool hasUrlStartedChasing;

        static public bool lockIndexChangeEvents;

        //static public bool is_drop_down_open; //why do i need this?        

        static public bool halted;

        //This will be set from the outside, and we will display whatever is in here.
        //static public AlgorithmState current_state;

        static public AlgorithmState loadedState; //The forms handler essentially always stores one state to be displayed at a time.


        public BenderForm() //First entry point of the program
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized; //Start with the window maximized

            pictureBoard = new BoardDisplay();


            //Initial settings


            listQmatrixComboboxes = new Dictionary<Move, ComboBox>
            {
                [Move.Left] =
                [Move.Right] = groupboxMatrixSelect.Controls["comboboxRight"] as ComboBox,
                [Move.Up] = groupboxMatrixSelect.Controls["comboboxUp"] as ComboBox,
                [Move.Down] = groupboxMatrixSelect.Controls["comboboxDown"] as ComboBox,
                [Move.Grab] = groupboxMatrixSelect.Controls["comboboxCurrentsquare"] as ComboBox
            };

            listQmatrixValueTextboxes = new Dictionary<Move, TextBox>
            {
                [Move.Left] = groupboxQmatrixValues.Controls["textboxQmatrixleft"] as TextBox,
                [Move.Right] = groupboxQmatrixValues.Controls["textboxQmatrixright"] as TextBox,
                [Move.Down] = groupboxQmatrixValues.Controls["textboxQmatrixdown"] as TextBox,
                [Move.Up] = groupboxQmatrixValues.Controls["textboxQmatrixup"] as TextBox,
                [Move.Grab] = groupboxQmatrixValues.Controls["textboxQmatrixcurrent"] as TextBox
            };



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
            listCurrentPositionTextboxes = new Dictionary<Move, TextBox>
            {
                [Move.Left] = groupboxCurrentPosition.Controls["textboxLeft"] as TextBox,
                [Move.Right] = groupboxCurrentPosition.Controls["textboxRight"] as TextBox,
                [Move.Up] = groupboxCurrentPosition.Controls["textboxUp"] as TextBox,
                [Move.Down] = groupboxCurrentPosition.Controls["textboxDown"] as TextBox,
                [Move.Grab] = groupboxCurrentPosition.Controls["textboxCurrentsquare"] as TextBox
            };

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
            controlProgressSteps = groupboxControlProgress.Controls["comboboxAdvancesteps"] as ComboBox;
            controlProgressEpisodes = groupboxControlProgress.Controls["comboboxAdvanceepisodes"] as ComboBox;
            controlProgressDelay = groupboxControlProgress.Controls["comboboxDelayms"] as ComboBox;


            //Status message
            statusBox = form1Control.Controls["groupboxStatusmessage"].Controls["textboxStatus"] as RichTextBox;

            //History
            groupboxHistory = form1Control.Controls["groupboxHistory"] as GroupBox;
            comboboxHistoryEpisodes = groupboxHistory.Controls["comboboxHistoryepisode"] as ComboBox;
            comboboxHistorySteps = groupboxHistory.Controls["comboboxHistorystep"] as ComboBox;


        }

        private void Form1Load(object sender, EventArgs e)
        {

            AlgorithmManager.SetDefaultConfiguration();

            //Second entry point of the program.
            //When the form loads, we'll create some pictureboxes, that will function as the robot world grid.            

            FormsHandler.Load();
            PictureBox picturebox_inProgress; //Temporary picturebox
            SquareBoardDisplay squareTo_build; //This is object inherits from boardSquare, but has a picture element.

            //Create pictureboxes and pass them to our board
            for (int i = 0; i < InitialSettings.SizeOfBoard; i++)
            {
                for (int j = 0; j < InitialSettings.SizeOfBoard; j++)
                {
                    //Fill in the column with rows
                    picturebox_inProgress = new PictureBox();
                    squareTo_build = new SquareBoardDisplay(i, j);
                    picturebox_inProgress.Name = i.ToString() + "-" + j.ToString(); //Each name is the coordinate
                    picturebox_inProgress.Location =
                        new Point(  InitialSettings.X_Offset + (i * InitialSettings.EdgeLength),
                                    InitialSettings.Y_Offset + (j * InitialSettings.EdgeLength));
                    picturebox_inProgress.Size = new Size(InitialSettings.EdgeLength, InitialSettings.EdgeLength);
                    picturebox_inProgress.SizeMode = PictureBoxSizeMode.StretchImage;
                    picturebox_inProgress.BackgroundImageLayout = ImageLayout.Stretch;
                    Controls.Add(picturebox_inProgress);
                    squareTo_build.pictureData = picturebox_inProgress;
                    FormsHandler.Add(i, 9-j, squareTo_build); //9-j to handle the board layout, for some reason!
                }
            }

            //Called from the restart button, but works here on initial launch.
            //This triggers the constructor for algorithm manager, as well

            //textboxStatus.Text = "Program launched.";
            //Should add this message from somewhere else
            
            FormsHandler.DisplayState(); //First time we display the board.
        }

        private void change_enabled_setting()
        {
            //Buttons
            buttonStartAlgorithm.Enabled = !buttonStartAlgorithm.Enabled;
            buttonRestart.Enabled = !buttonRestart.Enabled;

            //Groupboxes
            //Left side
            tabControl1.TabPages[0].Enabled = !tabControl1.TabPages[0].Enabled;
            groupboxAlgorithmprogress.Enabled = !groupboxAlgorithmprogress.Enabled;

            //Right side
            tabControl1.TabPages[1].Enabled = !tabControl1.TabPages[1].Enabled;
            tabControl1.TabPages[2].Enabled = !tabControl1.TabPages[2].Enabled;
            tabControl1.TabPages[3].Enabled = !tabControl1.TabPages[3].Enabled;
        }

        private void startAlgorithm(object sender, EventArgs e)
        {
            change_enabled_setting(); //Toggle controls
            AlgorithmManager.StartAlgorithm();

            FormsHandler.LoadAndDisplayState(AlgorithmManager.GetCurrentState());
        }

        private void restartAlgorithm_buttonClick(object sender, EventArgs e)
        {
            FormsHandler.loadedState = AlgorithmManager.GetCurrentState();
            AlgorithmManager.EraseBoard();
            
            FormsHandler.ResetConfiguration(); //Clear comboboxes and other forms
            change_enabled_setting(); //Togle controls
        }

        //Advance algorithm button
        async private void buttonAdvancestepsdropdownClick(object sender, EventArgs e)
        {
            FormsHandler.halted = false;
            int stepsToTake = Int32.Parse(comboboxAdvancesteps.Text);
            int episodes = Int32.Parse(comboboxAdvanceepisodes.Text);
            if (episodes > 0)
                stepsToTake += (Int32.Parse(comboboxAdvanceepisodes.Text) * FormsHandler.loadedState.GetStepLimit()) + 1; //+1 to get the new episode generated

            int initial_delay = Int32.Parse(comboboxDelayms.Text);
            int delay = initial_delay;

            if(checkBox1.Checked)
            {
                FormsHandler.hasUrlStartedChasing = true;
            }

            if(FormsHandler.hasUrlStartedChasing)
            {
                while(FormsHandler.hasUrlStartedChasing)
                {
                    AlgorithmManager.StepPrepare();
                    
                }
                FormsHandler.LoadAndDisplayState(AlgorithmManager.GetCurrentState());
            }


            else if(stepsToTake > 1)
            {
                textboxProgressSteps.Text = stepsToTake.ToString();
                groupboxCountdown.Enabled = true;
                groupboxAlgorithmprogress.Enabled = false;
                while (stepsToTake-- > 0 && !FormsHandler.halted)
                {
                    AlgorithmManager.StepPrepare();
                    FormsHandler.LoadAndDisplayState(AlgorithmManager.GetCurrentState());
                    textboxProgressSteps.Text = stepsToTake.ToString();
                    do
                    {
                        await Task.Delay(1);
                        textboxCountdown.Text = delay.ToString();
                    } while (--delay > 0 && !FormsHandler.halted);
                    delay = initial_delay;
                }
                groupboxAlgorithmprogress.Enabled = true;
                groupboxCountdown.Enabled = false;

            }

            else
            {
                AlgorithmManager.StepPrepare();
                FormsHandler.LoadAndDisplayState(AlgorithmManager.GetCurrentState());
            }
            
        }



        private void set_stepsFrom_dropdown(object sender, EventArgs e)
        {
            bool success = Int32.TryParse(comboboxSteps.Text, out int result);
            if (!success)
                comboboxSteps.Text = "Invalid.";
            else
            {
                Qmatrix.stepLimit = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void setNFrom_dropdown(object sender, EventArgs e)
        {

            bool success = double.TryParse(comboboxN.Text, out double result);
            if (!success)
                comboboxN.Text = "Invalid.";
            else
            {
                FormsHandler.loadedState.liveQmatrix.n = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void setYFrom_dropdown(object sender, EventArgs e)
        {
            bool success = double.TryParse(comboboxY.Text, out double result);
            if (!success)
                comboboxY.Text = "Invalid.";
            else
            {
                FormsHandler.loadedState.liveQmatrix.y = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void advance_one_step(object sender, EventArgs e)
        {

        }

        private void button2Click(object sender, EventArgs e)
        {
            bool success = double.TryParse(comboboxE.Text, out double result);
            if (!success)
                comboboxE.Text = "Invalid.";
            else
            {
                FormsHandler.loadedState.liveQmatrix.e = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void button4Click(object sender, EventArgs e)
        {
            bool success = double.TryParse(comboboxWallpunishment.Text, out double result);
            if (!success)
                comboboxWallpunishment.Text = "Invalid.";
            else
            {
                MoveResult.list[MoveResult.TravelFailed] = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void button5Click(object sender, EventArgs e)
        {
            bool success = double.TryParse(comboboxEmptysquare.Text, out double result);
            if (!success)
                comboboxEmptysquare.Text = "Invalid.";
            else
            {
                MoveResult.list[MoveResult.CanMissing] = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void button8Click(object sender, EventArgs e)
        {
            bool success = double.TryParse(comboboxBeer.Text, out double result);
            if (!success)
                comboboxBeer.Text = "Invalid.";
            else
            {
                MoveResult.list[MoveResult.CanCollected] = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void resetConfig_buttonClick(object sender, EventArgs e)
        {
            FormsHandler.ResetConfiguration();
        }

        private void button1Click(object sender, EventArgs e)
        {
            bool success = double.TryParse(comboboxMovedwithoutwall.Text, out double result);
            if (!success)
                comboboxMovedwithoutwall.Text = "Invalid.";
            else
            {
                MoveResult.list[MoveResult.TravelSucceeded] = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void comboboxEpisode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                setEpisodeFromDropdown(sender, e);
            }  
        }

        private void comboboxSteps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                set_stepsFrom_dropdown(sender, e);
            }
        }

        private void comboboxN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                setNFrom_dropdown(sender, e);
            }
        }

        private void comboboxY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                setYFrom_dropdown(sender, e);
            }
        }

        private void comboboxE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button2Click(sender, e);
            }
        }

        private void comboboxBeer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button8Click(sender, e);
            }
        }

        private void comboboxEmptysquare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button6Click(sender, e);
            }
        }

        private void button6Click(object sender, EventArgs e)
        {
            bool success = double.TryParse(comboboxEmptysquare.Text, out double result);
            if (!success)
                comboboxEmptysquare.Text = "Invalid.";
            else
            {
                MoveResult.list[MoveResult.CanMissing] = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void comboboxWallpunishment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button4Click(sender, e);
            }
        }

        private void comboboxMovedwithoutwall_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1Click(sender, e);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboboxEpisode.Text == "Invalid.")
                comboboxEpisode.Text = "";
        }

        private void qmatrix_small_dropdownChanged(object sender, EventArgs e)
        {
            if (!FormsHandler.lockIndexChangeEvents && ((ComboBox)sender).SelectedIndex > -1)
                if (((ComboBox)sender).SelectedText != "None.") 
                FormsHandler.smallDropdownChanged((ComboBox)sender);
        }

        private void comboboxQmatrixselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FormsHandler.lockIndexChangeEvents && ((ComboBox)sender).SelectedIndex > -1)
                FormsHandler.largeDropdownChanged();
        }

        private void comboboxClickedClearText(object sender, EventArgs e)
        {

        }

        private void dropdown_opened(object sender, EventArgs e)
        {
            
        }

        private void dropdownClosed(object sender, EventArgs e)
        {

        }

        private void comboboxAdvancestepsLeave(object sender, EventArgs e)
        {
            bool success = Int32.TryParse(comboboxAdvancesteps.Text, out int result);
            if (!success || result < 1)
            {
                if (Int32.Parse(comboboxAdvanceepisodes.Text) > 0)
                    comboboxAdvancesteps.Text = "0";
                else
                    comboboxAdvancesteps.Text = "1";
            }
            else            
                comboboxAdvancesteps.Text = result.ToString();

                
        }

        private void comboboxAdvanceepisodesLeave(object sender, EventArgs e)
        {
            bool success = Int32.TryParse(comboboxAdvanceepisodes.Text, out int result);
            if (!success || result < 0)
            {
                comboboxAdvanceepisodes.Text = "0";
                if (Int32.Parse(comboboxAdvancesteps.Text) == 0)
                    comboboxAdvancesteps.Text = "1";


            }
        }

        private void comboboxDelaymsLeave(object sender, EventArgs e)
        {
            bool success = Int32.TryParse(comboboxDelayms.Text, out int result);
            if (!success || result < 0)
                comboboxDelayms.Text = InitialSettings.MS_Delay.ToString();
            else
                comboboxDelayms.Text = result.ToString();
        }

        private void buttonStopClick(object sender, EventArgs e)
        {
            FormsHandler.halted = true;
            groupboxAlgorithmprogress.Enabled = true;
            groupboxCountdown.Enabled = false;
        }

        private void history_indexChanged(object sender, EventArgs e)
        {
            ComboBox sender_box = (ComboBox)sender;
            if (sender_box.SelectedIndex > -1)
            {
                comboboxHistorystep.Items.Clear();

                AlgorithmEpisode to_display = (AlgorithmEpisode)sender_box.SelectedItem;
                comboboxHistorystep.Items.AddRange(to_display.stateHistoryData.ToArray());
                comboboxHistorystep.SelectedIndex = 0;

                AlgorithmState stateTo_display = (AlgorithmState)comboboxHistorystep.Items[0];
                FormsHandler.LoadAndDisplayState(stateTo_display);
            }
        }

        private void dropdownclosed_historysteps(object sender, EventArgs e)
        {
            
        }

        private void comboboxHistorystep_SelectedIndexChanged(object sender, EventArgs e)
        {
            AlgorithmState stateTo_dislay = (AlgorithmState)((ComboBox)sender).SelectedItem;
            FormsHandler.LoadAndDisplayState(stateTo_dislay);
        }

        private void dropdownClosedNumberepisodes(object sender, EventArgs e)
        {
            
            setEpisodeFromDropdown(sender, e);
        }

        private void comboboxHistoryepisode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                bool success = Int32.TryParse(comboboxHistoryepisode.Text, out int result);
                if (!success || result < 1 || result > comboboxHistoryepisode.Items.Count)
                    comboboxHistoryepisode.Text = "Invalid.";
                else
                    comboboxHistoryepisode.SelectedIndex = result - 1;
            }
        }

        private void comboboxHistorystep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                bool success = Int32.TryParse(comboboxHistorystep.Text, out int result);
                if (!success || result < 1 || result > comboboxHistorystep.Items.Count)
                    comboboxHistorystep.Text = "Invalid.";
                else
                {
                    comboboxHistorystep.SelectedIndex = result;
                    FormsHandler.LoadAndDisplayState((AlgorithmState)comboboxHistorystep.SelectedItem);
                }
                    
            }
        }

        private void comboboxDelayms_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                bool success = Int32.TryParse(comboboxDelayms.Text, out int result);
                if (!success || result < InitialSettings.MS_Delay)
                    comboboxDelayms.Text = InitialSettings.MS_Delay.ToString();
                else
                    comboboxDelayms.Text = result.ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboboxAdvancesteps.Enabled = !comboboxAdvancesteps.Enabled;
            comboboxAdvanceepisodes.Enabled = !comboboxAdvanceepisodes.Enabled;
        }

        private void comboboxAdvanceepisodes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        static public void Load()
        {
            loadedState = new AlgorithmState();

            InitialSettings.Initialize();

            lockIndexChangeEvents = false;
            halted = false;
            //Pass textboxes to the board, so it can manage them.

            linkHandlerToForm();

            //Initialize dropdown boxes
            controlProgressSteps.SelectedIndex = 0;
            controlProgressEpisodes.Text = "0";
            controlProgressDelay.Text = InitialSettings.MS_Delay.ToString();

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
            if (AlgorithmManager.algorithmEnded == true)
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
            foreach (var i in listQmatrixValueTextboxes)
            {
                i.Value.Clear();
            }

            //Session progess textboxes
            foreach (var i in listSessionProgress)
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





        static public void largeDropdownChanged()
        {
            ViewQmatrixConfiguration((PerceptionState)qmatrixStateComboboxLarge.SelectedItem);
        }

        static public void smallDropdownChanged(ComboBox changed_dropdown)
        {
            if (changed_dropdown.SelectedText != "None.")
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

        static public void linkHandlerToForm()
        {


        }

        public static string GetString(double toConvert)
        {
            return toConvert.ToString();
            //gotta fix this display setting later
        }

        private void setEpisodeFromDropdown(object sender, EventArgs e)
        {
            bool success = Int32.TryParse(comboboxEpisode.Text, out int result);
            if (!success)
                comboboxEpisode.Text = "Invalid.";
            else
            {
                Qmatrix.episodeLimit = result;
                FormsHandler.DisplayInitialSettings();
            }
        }
    }
}
