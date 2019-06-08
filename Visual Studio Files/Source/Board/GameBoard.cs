using System.Collections.Generic;

namespace ReinforcementLearning
{
    //Manages a few different classes
    class GameBoard : BaseBoard 
    {
        public int beer_can_count;
        public Unit bender;

        public GameBoard() : base()
        {
            //Initialize 10x10 grid
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board_data[i].Add(new BoardSquare());
                }
            }

            add_walls();

            //Bender location will be set in shuffle
            bender = new Unit();
            board_size = 10;
            shuffle_bender(); //A fresh board not copied will need randomly generated data, except at program launch. We'll clear it in that case.
        }

        //Copy constructor
        public GameBoard(GameBoard set_from) : base()
        {
            board_size = set_from.board_size;

            beer_can_count = set_from.beer_can_count;

            //Initialize 10x10 grid
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board_data[i].Add(new BoardSquare((BoardSquare)set_from.board_data[i][j]));
                    if (board_data[i][j].visited_state == SquareVisitedStateList.last() && !board_data[i][j].bender_present)
                        board_data[i][j].visited_state = SquareVisitedStateList.explored();
                }
            }

            add_walls();

            bender = new Unit(set_from.bender);
        }

        //Only called when we start a new episode
        public void shuffle_cans_and_bender()
        {
            beer_can_count = 0;
            //Activate the 50/50 chance for each tile to have beer in it.
            foreach (var i in board_data)
            {
                foreach (var j in i)
                {
                    ((BoardSquare)j).randomize_beer_presence();
                    ++beer_can_count;
                }
            }

            shuffle_bender(); //Place bender randomly somewhere
            board_data[bender.bender_x][bender.bender_y].visited_state = SquareVisitedStateList.last();
        }


        //This is called each time we generate a new episode for our algorithm.
        //This is also called at the start of the program launch, disconnected from shuffling the whole board, just once.
        public void shuffle_bender()
        {
            //If Bender is already somewhere on the board, make sure we remove him from that location.
            if (board_data[bender.bender_x][bender.bender_y].bender_present) board_data[bender.bender_x][bender.bender_y].bender_present = false;

            //Get bender's new location.
            bender.bender_x = MyRandom.Next(0, 10); //0-9 inclusive
            bender.bender_y = MyRandom.Next(0, 10);
            board_data[bender.bender_x][bender.bender_y].bender_present = true; //Set bender
        }

        //This function will give bender perception data from the board
        public void bender_percieves()
        {
            PerceptionState find_perception = new PerceptionState();
            foreach (var i in MoveList.list)
            {
                find_perception.perception_data[i] = percieve(i);
            }
            //Translated: for each move, percieve with this move, and update the perception for this move.

            find_perception.set_name();
            bender.perception_data = PerceptionStateList.GetPerceptionFromList(find_perception);
        }

        //Used when the robot moves *only*, otherwise, the perception will be checked from the state of the unit.
        //Generates percepts, and not MoveResults.
        public Percept percieve(Move move_to_check)
        {
            BaseSquare bender_location = board_data[bender.bender_x][bender.bender_y];

            if (move_to_check != MoveList.grab() && ((BoardSquare)bender_location).check_if_walls_prevent_move(move_to_check))
            {
                return PerceptList.wall(); //Wall percieved 
            }
            else
            {
                int percieve_x = bender.bender_x + move_to_check.grid_adjustment[0];
                int percieve_y = bender.bender_y + move_to_check.grid_adjustment[1];

                BaseSquare percieve_location = board_data[percieve_x][percieve_y];
                if (percieve_location.beer_can_present)
                    return PerceptList.can();
                else
                    return PerceptList.empty();
            }
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

        public void clone_position(GameBoard clone_from)
        {
            for(int i = 0; i < board_size; i++)
            {
                for(int j = 0; j < board_size; j++)
                {
                    get_board_data(i, j).copy_status(clone_from.get_board_data(i, j));
                }
            }
        }

        public bool is_bender_on_can()
        {
            return board_data[bender.bender_x][bender.bender_y].beer_can_present;
        }



        public MoveResult apply_move(Move move_to_apply)
        {
            bender_location().visited_state = SquareVisitedStateList.last();

            //Get the move result based on the current condition
            if (bender_location().check_if_walls_prevent_move(move_to_apply))
                return MoveResultList.move_hit_wall(); //Walls prevent move

            if(move_to_apply == MoveList.grab())
            {
                

                if (bender_location().beer_can_present)
                {
                    collect_can();
                    return MoveResultList.can_collected();
                }
                    
                else
                    return MoveResultList.can_missing();
            }
            //Didn't try to grab a can, and didn't hit a wall. We moved successfully.

            move_bender(move_to_apply);
            return MoveResultList.move_successful();
        }

        public void move_bender(Move to_move)
        {
            bender_location().bender_present = false;

            bender.bender_x += to_move.grid_adjustment[0];
            bender.bender_y += to_move.grid_adjustment[1];
            bender_location().bender_present = true;
            bender_location().visited_state = SquareVisitedStateList.last();
            bender_percieves();
        }

        public void collect_can()
        {
            BaseSquare bender_location = board_data[bender.bender_x][bender.bender_y];
            
            bender_location.beer_can_present = false;

            bender_percieves();
        }

        public int get_cans_remaining()
        {
            int total = 0;
            foreach (var i in board_data)
            {
                foreach(var j in i)
                {
                    if (j.beer_can_present)
                        ++total;
                }
            }
            return total;
        }

        public void remove_unit(Unit to_remove)
        {
            board_data[bender.bender_x][bender.bender_y].bender_present = false;
            bender = null; //I think this removes bender
            
        }

        public void add_unit(Unit to_add)
        {
            bender = to_add;
            board_data[bender.bender_x][bender.bender_y].bender_present = true;
            //bender added
        }

        public void add_walls()
        {
            //Set all walls to empty first

            foreach(var i in board_data)
            {
                foreach(var j in i)
                {
                    ((BoardSquare)j).walls = WallsList.empty_wall();
                }
            }
            
            //Add walls, which will replace some of the empty walls.
            //left wall
            for (int i = 1; i <= 8; i++) { ((BoardSquare)board_data[0][i]).walls = WallsList.left_wall(); }
            //right wall
            for (int i = 1; i <= 8; i++) { ((BoardSquare)board_data[9][i]).walls = WallsList.right_wall(); }
            //bottom wall
            for (int i = 1; i <= 8; i++) { ((BoardSquare)board_data[i][0]).walls = WallsList.bottom_wall(); }
            //above wall
            for (int i = 1; i <= 8; i++) { ((BoardSquare)board_data[i][9]).walls = WallsList.top_wall(); }

            ((BoardSquare)board_data[0][0]).walls = WallsList.bottom_left_wall();
            ((BoardSquare)board_data[9][9]).walls = WallsList.top_right_wall();
            ((BoardSquare)board_data[0][9]).walls = WallsList.top_left_wall();
            ((BoardSquare)board_data[9][0]).walls = WallsList.bottom_right_wall();
        }

        public BoardSquare bender_location()
        {
            return (BoardSquare)board_data[bender.bender_x][bender.bender_y];
        }

        public new BoardSquare get_board_data(int x, int y)
        {
            return (BoardSquare)board_data[x][y];
        }
    }    
}
