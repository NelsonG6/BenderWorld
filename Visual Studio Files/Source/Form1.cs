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
        Board MainBoard;
        Random random;

        public Form1()
        {
            InitializeComponent();

            random = new Random(); //This random is used throughout the entire program

            MainBoard = new Board(random); //Create our grid

            MainBoard.SetEdgeSize(10); //Simplifies adding pictureboxes to the 10x10 grid

            this.WindowState = FormWindowState.Maximized; //Start with the window maximized

            //Pass textboxes to the board, so it can manage them.
            MainBoard.number_of_episodes = textboxNumberofepisodes;
            MainBoard.number_of_steps = textboxNumberofsteps;
            MainBoard.n_textbox = textboxN;
            MainBoard.y_textbox = textboxY;
            MainBoard.current_position_left = textboxLeft;
            MainBoard.current_position_right = textboxRight;
            MainBoard.current_position_up = textboxUp;
            MainBoard.current_position_down = textboxDown;
            MainBoard.current_position_square = textboxCurrentsquare;
            MainBoard.current_position_encoding = textboxEncodedas;

            //Used for creating pictureboxes and their point values
            int edge_length = 75;
            int x_offset = 50;
            int y_offset = 75;
           
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
                    MainBoard.AddPicturebox(building, i, 9-j); //9-j for pictureboxes being displayed in the correct order
                }
            }

            MainBoard.shuffle_bender();
            MainBoard.clear(); //Will give us the default empty board
            MainBoard.load_initial_settings();
        }

        private void start_algorithm(object sender, EventArgs e)
        {            
            buttonStartAlgorithm.Enabled = false;
            groupboxAlgorithmprogress.Enabled = true;
            listboxBenderhistory.Enabled = true;
            groupboxCurrentposition.Enabled = true;
            groupboxConfiguration.Enabled = false;
            buttonRestart.Enabled = true;
            MainBoard.startAlgorithm();    
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }                

        private void reset_settings(object sender, EventArgs e)
        {
            buttonStartAlgorithm.Enabled = true;
            groupboxAlgorithmprogress.Enabled = false;
            listboxBenderhistory.Enabled = false;
            groupboxCurrentposition.Enabled = false;
            buttonRestart.Enabled = false;
            groupboxConfiguration.Enabled = true;
            MainBoard.clear();
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
