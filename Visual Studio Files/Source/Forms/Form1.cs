using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReinforcementLearning
{
    public partial class Form1 : Form
    {
        public Form1() //First entry point of the program
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; //Start with the window maximized
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Second entry point of the program.
            //When the form loads, we'll create some pictureboxes, that will function as the robot world grid.

            //Used for creating pictureboxes and their point values
            int edge_length = 75;
            int x_offset = 50;
            int y_offset = 55;

            PictureBox picturebox_in_progress; //Temporary picturebox
            PictureSquare square_to_build; //This is object inherits from boardSquare, but has a picture element.

            //Create pictureboxes and pass them to our board
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //Fill in the column with rows
                    picturebox_in_progress = new PictureBox();
                    square_to_build = new PictureSquare();
                    picturebox_in_progress.Name = i.ToString() + "-" + j.ToString(); //Each name is the coordinate
                    picturebox_in_progress.Location = new Point(x_offset + (i * edge_length), y_offset + (j * edge_length));
                    picturebox_in_progress.Size = new Size(edge_length, edge_length);
                    picturebox_in_progress.SizeMode = PictureBoxSizeMode.StretchImage;
                    picturebox_in_progress.BackgroundImageLayout = ImageLayout.Stretch;
                    this.Controls.Add(picturebox_in_progress);
                    square_to_build.pictureData = picturebox_in_progress;
                    FormsHandler.Add(i, 9-j, square_to_build); //9-j to handle the board layout, for some reason!
                }
            }

            //Called from the restart button, but works here on initial launch.
            //This triggers the constructor for algorithm manager, as well

            textboxStatus.Text = "Program launched.";
            //AlgorithmState.GetCurrentBoard().ClearCans();
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

        private void start_algorithm(object sender, EventArgs e)
        {
            change_enabled_setting(); //Toggle controls
            AlgorithmState.StartAlgorithm();

            FormsHandler.LoadAndDisplayState(AlgorithmState.GetCurrentState());
        }

        private void restart_algorithm_button_click(object sender, EventArgs e)
        {
            FormsHandler.HandleRestart(AlgorithmState.GetCurrentState());
            
            change_enabled_setting(); //Togle controls
        }

        //Advance algorithm button
        async private void buttonAdvancestepsdropdown_Click(object sender, EventArgs e)
        {
            FormsHandler.halted = false;
            int steps_to_take = Int32.Parse(comboboxAdvancesteps.Text);
            int episodes = Int32.Parse(comboboxAdvanceepisodes.Text);
            if (episodes > 0)
                steps_to_take += (Int32.Parse(comboboxAdvanceepisodes.Text) * AlgorithmState.step_limit) + 1; //+1 to get the new episode generated

            int initial_delay = Int32.Parse(comboboxDelayms.Text);
            int delay = initial_delay;

            if(delay > 25 || steps_to_take > 4)
            {
                textboxProgresssteps.Text = steps_to_take.ToString();
                groupboxCountdown.Enabled = true;
                groupboxAlgorithmprogress.Enabled = false;
                groupboxHistory.Enabled = false;
                while (steps_to_take-- > 0 && !FormsHandler.halted)
                {
                    
                    AlgorithmState.PrepareStep(1);
                    FormsHandler.LoadAndDisplayState(AlgorithmState.GetCurrentState());
                    textboxProgresssteps.Text = steps_to_take.ToString();
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
                AlgorithmState.PrepareStep(steps_to_take);
                FormsHandler.LoadAndDisplayState(AlgorithmState.GetCurrentState());
            }
            
        }

        private void set_episode_from_dropdown(object sender, EventArgs e)
        {
            bool success = Int32.TryParse(comboboxEpisode.Text, out int result);
            if (!success)
                comboboxEpisode.Text = "Invalid.";
            else
            {
                AlgorithmState.episode_limit = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void set_steps_from_dropdown(object sender, EventArgs e)
        {
            bool success = Int32.TryParse(comboboxSteps.Text, out int result);
            if (!success)
                comboboxSteps.Text = "Invalid.";
            else
            {
                AlgorithmState.step_limit = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void set_n_from_dropdown(object sender, EventArgs e)
        {

            bool success = float.TryParse(comboboxN.Text, out float result);
            if (!success)
                comboboxN.Text = "Invalid.";
            else
            {
                FormsHandler.loaded_state.live_qmatrix.n_current = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void set_y_from_dropdown(object sender, EventArgs e)
        {
            bool success = float.TryParse(comboboxY.Text, out float result);
            if (!success)
                comboboxY.Text = "Invalid.";
            else
            {
                FormsHandler.loaded_state.live_qmatrix.y_current = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void advance_one_step(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool success = float.TryParse(comboboxE.Text, out float result);
            if (!success)
                comboboxE.Text = "Invalid.";
            else
            {
                FormsHandler.loaded_state.live_qmatrix.e_current = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool success = float.TryParse(comboboxWallpunishment.Text, out float result);
            if (!success)
                comboboxWallpunishment.Text = "Invalid.";
            else
            {
                ReinforcementFactors.list[MoveResult.move_hit_wall()] = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool success = float.TryParse(comboboxEmptysquare.Text, out float result);
            if (!success)
                comboboxEmptysquare.Text = "Invalid.";
            else
            {
                ReinforcementFactors.list[MoveResult.can_missing()] = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bool success = float.TryParse(comboboxBeer.Text, out float result);
            if (!success)
                comboboxBeer.Text = "Invalid.";
            else
            {
                ReinforcementFactors.list[MoveResult.can_collected()] = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void reset_config_button_click(object sender, EventArgs e)
        {
            AlgorithmState.SetDefaultConfiguration();
            FormsHandler.DisplayInitialSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = float.TryParse(comboboxMovedwithoutwall.Text, out float result);
            if (!success)
                comboboxMovedwithoutwall.Text = "Invalid.";
            else
            {
                ReinforcementFactors.list[MoveResult.move_successful()] = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void comboboxEpisode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                set_episode_from_dropdown(sender, e);
            }  
        }

        private void comboboxSteps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                set_steps_from_dropdown(sender, e);
            }
        }

        private void comboboxN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                set_n_from_dropdown(sender, e);
            }
        }

        private void comboboxY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                set_y_from_dropdown(sender, e);
            }
        }

        private void comboboxE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button2_Click(sender, e);
            }
        }

        private void comboboxBeer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button8_Click(sender, e);
            }
        }

        private void comboboxEmptysquare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button6_Click(sender, e);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool success = float.TryParse(comboboxEmptysquare.Text, out float result);
            if (!success)
                comboboxEmptysquare.Text = "Invalid.";
            else
            {
                ReinforcementFactors.list[MoveResult.can_missing()] = result;
                FormsHandler.DisplayInitialSettings();
            }
        }

        private void comboboxWallpunishment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button4_Click(sender, e);
            }
        }

        private void comboboxMovedwithoutwall_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(sender, e);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboboxEpisode.Text == "Invalid.")
                comboboxEpisode.Text = "";
        }

        private void qmatrix_small_dropdown_changed(object sender, EventArgs e)
        {
            if (!FormsHandler.lock_index_change_events && ((ComboBox)sender).SelectedIndex > -1)
                if (((ComboBox)sender).SelectedText != "None.") 
                FormsHandler.small_dropdown_changed((ComboBox)sender);
        }

        private void comboboxQmatrixselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FormsHandler.lock_index_change_events && ((ComboBox)sender).SelectedIndex > -1)
                FormsHandler.large_dropdown_changed();
        }

        private void combobox_clicked_clear_text(object sender, EventArgs e)
        {
            if(((ComboBox)sender).DroppedDown == false)
                ((ComboBox)sender).Text = "";
        }

        private void dropdown_opened(object sender, EventArgs e)
        {
            
        }

        private void dropdown_closed(object sender, EventArgs e)
        {

        }

        private void comboboxAdvancesteps_Leave(object sender, EventArgs e)
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

        private void comboboxAdvanceepisodes_Leave(object sender, EventArgs e)
        {
            bool success = Int32.TryParse(comboboxAdvanceepisodes.Text, out int result);
            if (!success || result < 0)
            {
                comboboxAdvanceepisodes.Text = "0";
                if (Int32.Parse(comboboxAdvancesteps.Text) == 0)
                    comboboxAdvancesteps.Text = "1";


            }
        }

        private void comboboxDelayms_Leave(object sender, EventArgs e)
        {
            bool success = Int32.TryParse(comboboxDelayms.Text, out int result);
            if (!success || result < 0)
                comboboxDelayms.Text = "5";
            else
                comboboxDelayms.Text = result.ToString();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            FormsHandler.halted = true;
            groupboxAlgorithmprogress.Enabled = true;
            groupboxCountdown.Enabled = false;
        }

        private void history_index_changed(object sender, EventArgs e)
        {
            ComboBox sender_box = (ComboBox)sender;
            if (sender_box.SelectedIndex > -1)
            {
                comboboxHistorystep.Items.Clear();

                AlgorithmEpisode to_display = (AlgorithmEpisode)sender_box.SelectedItem;
                comboboxHistorystep.Items.AddRange(to_display.state_history_data.ToArray());
                comboboxHistorystep.SelectedIndex = 0;

                AlgorithmState state_to_display = (AlgorithmState)comboboxHistorystep.Items[0];
                FormsHandler.LoadAndDisplayState(state_to_display);
            }
        }

        private void dropdownclosed_historysteps(object sender, EventArgs e)
        {
            
        }

        private void comboboxHistorystep_SelectedIndexChanged(object sender, EventArgs e)
        {
            AlgorithmState state_to_dislay = (AlgorithmState)((ComboBox)sender).SelectedItem;
            FormsHandler.LoadAndDisplayState(state_to_dislay);
        }

        private void dropdown_closed_numberepisodes(object sender, EventArgs e)
        {
            
            set_episode_from_dropdown(sender, e);
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
                if (!success || result < 5)
                    comboboxDelayms.Text = "5";
                else
                    comboboxDelayms.Text = result.ToString();

            }
        }
    }
}
