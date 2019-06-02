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

            random = new Random();
            MainBoard = new Board(random);

            //This makes it so when I add pictureboxes to the mainboard,
            //It doesn't need specific coordinates. It just adds 10 to a row and then addes a new row.
            MainBoard.SetEdgeSize(10);

            this.WindowState = FormWindowState.Maximized;
            
            int edge_length = 75;
            int x_offset = 50;
            int y_offset = 75;

            PictureBox building;
            
            //Create pictureboxes and pass them to our board
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //Fill in the column with rows
                    building = new PictureBox();
                    building.Name = i.ToString() + "-" + j.ToString();
                    building.Location = new Point(x_offset + (i * edge_length),
                        y_offset + (j * edge_length));
                    building.Size = new Size(edge_length, edge_length);
                    building.SizeMode = PictureBoxSizeMode.StretchImage;
                    building.BackgroundImage = Properties.Resources.grid_background;
                    building.BackgroundImageLayout = ImageLayout.Stretch;
                    this.Controls.Add(building);
                    MainBoard.AddPicturebox(building, i, 9-j);
                }
            }

            updateBoard();
        }

        public void updateBoard()
        {
            MainBoard.update();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainBoard.shuffle();
            updateBoard();

            textboxLeft.Clear();
            textboxDown.Clear();
            textboxRight.Clear();
            textboxUp.Clear();
            textboxCurrentsquare.Clear();
            textboxEncodedas.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateCurrentPositionGroupbox();
        }

        private void updateCurrentPositionGroupbox()
        {
            textboxLeft.Text = MainBoard.detect_percept(-1, 0);
            textboxDown.Text = MainBoard.detect_percept(0, -1);
            textboxRight.Text = MainBoard.detect_percept(1, 0);
            textboxUp.Text = MainBoard.detect_percept(0, 1);
            textboxCurrentsquare.Text = MainBoard.detect_percept(0, 0);
            textboxEncodedas.Text = MainBoard.get_encoding_of_percepts();
        }
    }
}
