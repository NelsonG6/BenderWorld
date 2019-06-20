using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BenderAndURL
{
    public partial class Form1 : Form
    {
        public Form1() //First entry point of the program
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized; //Start with the window maximized
        }

        private void Form1Load(object sender, EventArgs e)
        {

            AlgorithmManager.SetDefaultConfiguration();

            //Second entry point of the program.
            //When the form loads, we'll create some pictureboxes, that will function as the robot world grid.            

            FormsHandler.load();
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

            textboxStatus.Text = "Program launched.";
            
            FormsHandler.DisplayState(); //First time we display the board.
        }

        private void change_enabled_setting()
        {
            //Buttons
            buttonStartAlgorithm.Enabled = !buttonStartAlgorithm.Enabled;
            buttonRestart.Enabled = !buttonRestart.Enabled;

            //Groupboxes
            //Left side
            groupboxConfiguration.Enabled = !groupboxConfiguration.Enabled;
            groupboxAlgorithmprogress.Enabled = !groupboxAlgorithmprogress.Enabled;

            //Right side
            groupboxQmatrix.Enabled = !groupboxQmatrix.Enabled;
            groupboxSessionprogress.Enabled = !groupboxSessionprogress.Enabled;
            groupboxHistory.Enabled = !groupboxHistory.Enabled;
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
                textboxProgresssteps.Text = stepsToTake.ToString();
                groupboxCountdown.Enabled = true;
                groupboxAlgorithmprogress.Enabled = false;
                groupboxHistory.Enabled = false;
                while (stepsToTake-- > 0 && !FormsHandler.halted)
                {
                    AlgorithmManager.StepPrepare();
                    FormsHandler.LoadAndDisplayState(AlgorithmManager.GetCurrentState());
                    textboxProgresssteps.Text = stepsToTake.ToString();
                    do
                    {
                        await Task.Delay(1);
                        textboxCountdown.Text = delay.ToString();
                    } while (--delay > 0 && !FormsHandler.halted);
                    delay = initial_delay;
                }
                groupboxAlgorithmprogress.Enabled = true;
                groupboxCountdown.Enabled = false;
                groupboxHistory.Enabled = true;
            }

            else
            {
                AlgorithmManager.StepPrepare();
                FormsHandler.LoadAndDisplayState(AlgorithmManager.GetCurrentState());
            }
            
        }

        private void set_episodeFrom_dropdown(object sender, EventArgs e)
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
                set_episodeFrom_dropdown(sender, e);
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
            if (!FormsHandler.lock_indexChange_events && ((ComboBox)sender).SelectedIndex > -1)
                if (((ComboBox)sender).SelectedText != "None.") 
                FormsHandler.small_dropdownChanged((ComboBox)sender);
        }

        private void comboboxQmatrixselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FormsHandler.lock_indexChange_events && ((ComboBox)sender).SelectedIndex > -1)
                FormsHandler.large_dropdownChanged();
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
            
            set_episodeFrom_dropdown(sender, e);
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
    }
}
