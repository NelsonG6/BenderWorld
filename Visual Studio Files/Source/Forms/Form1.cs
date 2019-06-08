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
                    FormsHandler.add(i, 9-j, square_to_build); //9-j to handle the board layout, for some reason!
                }
            }

            //Called from the restart button, but works here on initial launch.
            //This triggers the constructor for algorithm manager, as well

            textboxStatus.Text = "Program launched.";
            FormsHandler.display_state(); //First time we display the board.
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
            AlgorithmStateManager.start_algorithm();
            AlgorithmStateManager.take_step(1); //This will start the algorithm
            FormsHandler.display_state();
        }

        private void reset_algorithm(object sender, EventArgs e)
        {            
            AlgorithmStateManager.create_empty_board(); //Special function that creates a new board but keeps bender's position
            FormsHandler.clear_after_board_reset(); //get rid of the cans generated after creating an empty board
            FormsHandler.display_state();
            change_enabled_setting(); //Togle controls
        }

        //Advance algorithm button
        async private void buttonAdvancestepsdropdown_Click(object sender, EventArgs e)
        {
            FormsHandler.halted = false;
            int steps_to_take = Int32.Parse(comboboxAdvancesteps.Text);
            steps_to_take += Int32.Parse(comboboxAdvanceepisodes.Text) * AlgorithmStateManager.current_state.step_limit;

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
                    
                    AlgorithmStateManager.take_step(1);
                    FormsHandler.display_state();
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
                AlgorithmStateManager.take_step(steps_to_take);
                FormsHandler.display_state();
            }
            
        }

        private void set_episode_from_dropdown(object sender, EventArgs e)
        {
            bool success = Int32.TryParse(comboboxEpisode.Text, out int result);
            if (!success)
                comboboxEpisode.Text = "Invalid.";
            else
            {
                AlgorithmStateManager.current_state.episode_limit = result;
                FormsHandler.display_initial_settings();
            }
        }

        private void set_steps_from_dropdown(object sender, EventArgs e)
        {
            bool success = Int32.TryParse(comboboxSteps.Text, out int result);
            if (!success)
                comboboxSteps.Text = "Invalid.";
            else
            {
                AlgorithmStateManager.current_state.step_limit = result;
                FormsHandler.display_initial_settings();
            }
        }

        private void set_n_from_dropdown(object sender, EventArgs e)
        {

            bool success = float.TryParse(comboboxN.Text, out float result);
            if (!success)
                comboboxN.Text = "Invalid.";
            else
            {
                AlgorithmStateManager.current_state.n_current = result;
                FormsHandler.display_initial_settings();
            }
        }

        private void set_y_from_dropdown(object sender, EventArgs e)
        {
            bool success = float.TryParse(comboboxY.Text, out float result);
            if (!success)
                comboboxY.Text = "Invalid.";
            else
            {
                AlgorithmStateManager.current_state.y_current = result;
                FormsHandler.display_initial_settings();
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
                AlgorithmStateManager.current_state.e_current = result;
                FormsHandler.display_initial_settings();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool success = float.TryParse(comboboxWallpunishment.Text, out float result);
            if (!success)
                comboboxWallpunishment.Text = "Invalid.";
            else
            {
                AlgorithmStateManager.current_state.reinforcement_factors[MoveResultList.move_hit_wall()] = result;
                FormsHandler.display_initial_settings();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool success = float.TryParse(comboboxEmptysquare.Text, out float result);
            if (!success)
                comboboxEmptysquare.Text = "Invalid.";
            else
            {
                AlgorithmStateManager.current_state.reinforcement_factors[MoveResultList.can_missing()] = result;
                FormsHandler.display_initial_settings();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bool success = float.TryParse(comboboxBeer.Text, out float result);
            if (!success)
                comboboxBeer.Text = "Invalid.";
            else
            {
                AlgorithmStateManager.current_state.reinforcement_factors[MoveResultList.can_collected()] = result;
                FormsHandler.display_initial_settings();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AlgorithmStateManager.set_default_configuration();
            FormsHandler.display_initial_settings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = float.TryParse(comboboxMovedwithoutwall.Text, out float result);
            if (!success)
                comboboxMovedwithoutwall.Text = "Invalid.";
            else
            {
                AlgorithmStateManager.current_state.reinforcement_factors[MoveResultList.move_successful()] = result;
                FormsHandler.display_initial_settings();
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
                AlgorithmStateManager.current_state.reinforcement_factors[MoveResultList.can_missing()] = result;
                FormsHandler.display_initial_settings();
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

        private void buttonAdvanceepisodesdropdown_Click(object sender, EventArgs e)
        {
            FormsHandler.display_state();
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
            if(!FormsHandler.is_drop_down_open)
                ((ComboBox)sender).Text = "";
        }

        private void dropdown_opened(object sender, EventArgs e)
        {
            FormsHandler.is_drop_down_open = true;
        }

        private void dropdown_closed(object sender, EventArgs e)
        {
            FormsHandler.is_drop_down_open = false;
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
                comboboxDelayms.Text = "0";
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
            if (comboboxHistoryepisode.SelectedIndex != -1)
            {
                comboboxHistorystep.Enabled = true;
                comboboxHistorystep.Items.Clear();
                int index = comboboxHistoryepisode.SelectedIndex;
                comboboxHistorystep.Items.AddRange(AlgorithmStateManager.state_history[index].ToArray());
            }
            else
            {
                comboboxHistorystep.Items.Clear();
                comboboxHistorystep.Text = "";
                comboboxHistorystep.Enabled = false;
            }
        }

        private void dropdownclosed_historysteps(object sender, EventArgs e)
        {
            FormsHandler.is_drop_down_open = false;
        }

        private void comboboxHistorystep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxAdvancesteps.SelectedIndex != -1)
            {
                //view history
                AlgorithmStateManager.current_state = (AlgorithmState)comboboxHistorystep.SelectedItem;
                FormsHandler.display_state();
            }
        }
    }
}
