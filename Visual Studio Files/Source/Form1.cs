using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReinforcementLearning
{
    public partial class Form1 : Form
    {
        public Form1() //First entry point of the program
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; //Start with the window maximized

            //Initialize dropdown boxes
            comboboxAdvancesteps.SelectedIndex = 0;
            comboboxAdvanceepisodes.SelectedIndex = 0;

            comboboxLeft.SelectedIndex = 0;
            comboboxRight.SelectedIndex = 0;
            comboboxDown.SelectedIndex = 0;
            comboboxUp.SelectedIndex = 0;
            comboboxCurrentsquare.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Second entry point of the program.
            //When the form loads, we'll create some pictureboxes, that will function as the robot world grid.

            //Used for creating pictureboxes and their point values
            int edge_length = 75;
            int x_offset = 50;
            int y_offset = 55;

            PictureBox building; //Temporary picturebox
            PictureSquare board_to_build; //This is object inherits from boardSquare, but has a picture element.

            //Create pictureboxes and pass them to our board
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //Fill in the column with rows
                    building = new PictureBox();
                    board_to_build = new PictureSquare();
                    building.Name = i.ToString() + "-" + j.ToString(); //Each name is the coordinate
                    building.Location = new Point(x_offset + (i * edge_length), y_offset + (j * edge_length));
                    building.Size = new Size(edge_length, edge_length);
                    building.SizeMode = PictureBoxSizeMode.StretchImage;
                    building.BackgroundImageLayout = ImageLayout.Stretch;
                    this.Controls.Add(building);
                    board_to_build.pictureData = building;
                    FormsHandler.add(i, 9-j, board_to_build); //9-j to handle the board layout, for some reason!
                    
                }
            }

            AlgorithmManager.create_empty_board(); //This will gives us a board set to empty square.
            //Called from the restart button, but works here on initial launch.
            //This triggers the constructor for algorithm manager, as well

            textboxStatus.Text = "Program launched.";
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
            AlgorithmManager.take_step(1); //This will start the algorithm
        }

        private void reset_algorithm(object sender, EventArgs e)
        {
            change_enabled_setting();
            AlgorithmManager.create_empty_board();
        }



        private void buttonAdvancestepsdropdown_Click(object sender, EventArgs e)
        {
            AlgorithmManager.take_step(Int32.Parse(comboboxAdvancesteps.SelectedItem.ToString()));
        }

        private void buttonAdvancestepstextbox_Click(object sender, EventArgs e)
        {
            bool success = Int32.TryParse(comboboxAdvancesteps.Text, out int result);
            if (!success)
                comboboxAdvancesteps.Text = "Invalid.";
            else
                AlgorithmManager.take_step(result);
        }

        private void next_episode(object sender, EventArgs e)
        {

        }

        private void set_episode_from_dropdown(object sender, EventArgs e)
        {
            bool success = Int32.TryParse(comboboxEpisode.Text, out int result);
            if (!success)
                comboboxEpisode.Text = "Invalid.";
            else
            {
                AlgorithmManager.episode_limit = result;
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
                AlgorithmManager.step_limit = result;
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
                AlgorithmManager.n_initial = result;
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
                AlgorithmManager.y_initial = result;
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
                AlgorithmManager.e_initial = result;
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
                AlgorithmManager.reinforcement_factors[MoveResultList.move_hit_wall()] = result;
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
                AlgorithmManager.reinforcement_factors[MoveResultList.can_missing()] = result;
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
                AlgorithmManager.reinforcement_factors[MoveResultList.can_collected()] = result;
                FormsHandler.display_initial_settings();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AlgorithmManager.set_default_configuration();
            FormsHandler.display_initial_settings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = float.TryParse(comboboxMovedwithoutwall.Text, out float result);
            if (!success)
                comboboxMovedwithoutwall.Text = "Invalid.";
            else
            {
                AlgorithmManager.reinforcement_factors[MoveResultList.move_successful()] = result;
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
                AlgorithmManager.reinforcement_factors[MoveResultList.can_missing()] = result;
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


    }
}
