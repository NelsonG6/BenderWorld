﻿using System.Collections.Generic;

namespace ReinforcementLearning
{
    //Manages a few different classes
    class Board
    {
        public List<List<BoardSquare>> board_data; //These contain pictureboxes, passed from form1
        public int board_size;

        //keeps track of where bender is
        public int bender_x;
        public int bender_y;

        public int beer_can_count;

        public Board()
        {
            board_size = 10;
            board_data = new List<List<BoardSquare>>();
            beer_can_count = 0;

            //Initialize 10x10 grid
            for (int i = 0; i < 10; i++)
            {
                board_data.Add(new List<BoardSquare>());
                for (int j = 0; j < 10; j++)
                {
                    board_data[i].Add(new BoardSquare());
                }
            }

            //Add walls
            //left wall
            for (int i = 0; i < 10; i++) { board_data[0][i].walls.Add(new int[2] { -1, 0 }); }
            //right wall
            for (int i = 0; i < 10; i++) { board_data[9][i].walls.Add(new int[2] { 1, 0 }); }
            //bottom wall
            for (int i = 0; i < 10; i++) { board_data[i][0].walls.Add(new int[2] { 0, -1 }); }
            //above wall
            for (int i = 0; i < 10; i++) { board_data[i][9].walls.Add(new int[2] { 0, 1 }); }

            //Bender location will be set in shuffle
            bender_x = 0;
            bender_y = 0;

        }

        //Copy constructor
        public Board(Board set_from)
        {
            board_size = set_from.board_size;

            beer_can_count = set_from.beer_can_count;

            board_data = new List<List<BoardSquare>>();
            
            //Initialize 10x10 grid
            for (int i = 0; i < 10; i++)
            {
                board_data.Add(new List<BoardSquare>());
                for (int j = 0; j < 10; j++)
                {
                    board_data[i].Add(new BoardSquare(set_from.board_data[i][j]));
                }
            }
        }

        public void shuffle_cans_and_bender()
        {
            beer_can_count = 0;
            //Activate the 50/50 chance for each tile to have beer in it.
            foreach (var i in board_data)
            {
                foreach (var j in i)
                {
                    j.randomize_beer_presence();
                    ++beer_can_count;
                }
            }

            shuffle_bender(); //Place bender randomly somewhere
        }


        //This is called each time we generate a new episode for our algorithm.
        //This is also called at the start of the program launch, disconnected from shuffling the whole board, just once.
        public void shuffle_bender()
        {
            //If Bender is already somewhere on the board, make sure we remove him from that location.
            if (board_data[bender_x][bender_y].bender_present) board_data[bender_x][bender_y].bender_present = false;

            //Get bender's new location.
            bender_x = MyRandom.Next(0, 10); //0-9 inclusive
            bender_y = MyRandom.Next(0, 10);
            board_data[bender_x][bender_y].bender_present = true; //Set bender

            //Commenting this because I want to display pictureboxes from the textboxhandler, from a call from algorithmmanager
            //update_pictureboxes();
        }

        //Used when the robot takes an action
        //We get a string from this, which will be translated into a reward at the q-matrix.
        public string detect_percept(int x_move, int y_move)
        {
            if(board_data[bender_x][bender_y].check_wall(x_move, y_move))
            {
                return "Wall";
            }
            else
            {
                if (board_data[bender_x + x_move][bender_y + y_move].beer_can_present)
                    return "Beer Can";
                else
                    return "Empty";
            }
            //Shouldn't reach this
        }

        //This is how we store each state that bender can percieve.
        public string get_encoding_of_percepts()
        {
            string precept_string = detect_percept(-1, 0);
            precept_string += ", " + detect_percept(0, -1);
            precept_string += ", " + detect_percept(1, 0);
            precept_string += ", " + detect_percept(0, 1);
            precept_string += ", " + detect_percept(0, 0);
            return precept_string;
        }


        //This is called when the algorithm has been reset
        public void clear()
        {
            //Clear all the pictures
            foreach (var i in board_data)
            {
                foreach (var j in i)
                {
                    j.beer_can_present = false;
                }
            }
            
        }

        public void clone_position(Board clone_from)
        {
            for(int i = 0; i < board_size; i++)
            {
                for(int j = 0; j < board_size; j++)
                {
                    board_data[i][j].copy_status(clone_from.board_data[i][j]);
                }
            }
        }
    }    
}
