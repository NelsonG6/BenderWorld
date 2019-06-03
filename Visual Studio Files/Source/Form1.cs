using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReinforcementLearning
{
    public partial class Form1 : Form
    {
        AlgorithmManager current_algorithm;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; //Start with the window maximized

            //Initialize dropdown boxes
            comboboxAdvancesteps.SelectedIndex = 0;
            comboboxAdvanceepisodes.SelectedIndex = 0;
        }

        private void start_algorithm(object sender, EventArgs e)
        {
            change_enabled_setting();
            current_algorithm.take_step();
        }

        private void reset_algorithm(object sender, EventArgs e)
        {
            change_enabled_setting();
            current_algorithm.restartAlgorithm();
        }

        private void next_episode(object sender, EventArgs e)
        {

        }

        private void set_episode_from_dropdown(object sender, EventArgs e)
        {

        }

        private void set_episode_from_textbox(object sender, EventArgs e)
        {

        }

        private void set_steps_from_dropdown(object sender, EventArgs e)
        {

        }

        private void set_steps_from_textbox(object sender, EventArgs e)
        {

        }

        private void set_n_from_dropdown(object sender, EventArgs e)
        {

        }

        private void set_n_from_textbox(object sender, EventArgs e)
        {

        }

        private void set_y_from_dropdown(object sender, EventArgs e)
        {

        }

        private void set_y_from_textbox(object sender, EventArgs e)
        {

        }

        private void advance_one_step(object sender, EventArgs e)
        {

        }

        private void change_enabled_setting()
        {
            buttonStartAlgorithm.Enabled = !buttonStartAlgorithm.Enabled;
            groupboxAlgorithmprogress.Enabled = !groupboxAlgorithmprogress.Enabled;
            groupboxCurrentposition.Enabled = !groupboxCurrentposition.Enabled;
            buttonRestart.Enabled = !buttonRestart.Enabled;
            groupboxConfiguration.Enabled = !groupboxConfiguration.Enabled;
            groupboxQmatrix.Enabled = !groupboxQmatrix.Enabled;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //When the form loads, we'll create some pictureboxes, that will function as the robot world grid.

            //We waited to initialize this until now, instead of in Form1(), because we need the textboxes to be loaded into Application Controls.
            current_algorithm = new AlgorithmManager();

            //Used for creating pictureboxes and their point values
            int edge_length = 75;
            int x_offset = 50;
            int y_offset = 55;

            PictureBox building; //Temporary

            //Create pictureboxes and pass them to our board
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //Fill in the column with rows
                    building = new PictureBox();
                    building.Name = i.ToString() + "-" + j.ToString(); //Each name is the coordinate
                    building.Location = new Point(x_offset + (i * edge_length), y_offset + (j * edge_length));
                    building.Size = new Size(edge_length, edge_length);
                    building.SizeMode = PictureBoxSizeMode.StretchImage;
                    building.BackgroundImage = Properties.Resources.grid_background; //Same background for every image
                    building.BackgroundImageLayout = ImageLayout.Stretch;
                    this.Controls.Add(building);
                    current_algorithm.main_board.board_data[i][9 - j].pictureData = building;
                }
            }


            //Shuffle bender now, after pictureboxes have been included.
            //This helps due to every other time we shuffle, we want to re-display the pictures immediately.
            current_algorithm.main_board.shuffle_bender();
            textboxStatus.Text = "Program launched.";
        }
    }
}
