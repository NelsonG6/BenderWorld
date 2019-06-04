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
                    building.BackgroundImage = Properties.Resources.background_unexplored_ver3; //Same background for every image
                    building.BackgroundImageLayout = ImageLayout.Stretch;
                    this.Controls.Add(building);
                    board_to_build.pictureData = building;
                    FormsHandler.add(i, j, board_to_build);
                    //current_board.board_data[i][9 - j] = board_to_build;
                }
            }

            AlgorithmManager.place_bender_randomly(); //This is the first reference to algorithm manager, which triggers its constructor.
            //This call also places bender on the board initially.

            AlgorithmManager.create_empty_board(); //This will gives us a board set to empty square.
            //Called from the restart button, but works here on initial launch.
            
            textboxStatus.Text = "Program launched.";
        }

        private void start_algorithm(object sender, EventArgs e)
        {
            change_enabled_setting();
            AlgorithmManager.take_step();
        }

        private void reset_algorithm(object sender, EventArgs e)
        {
            change_enabled_setting();
            AlgorithmManager.create_empty_board();
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


        
    }
}
