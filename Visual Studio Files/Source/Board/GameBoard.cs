using System.Collections.Generic;

namespace ReinforcementLearning
{
    //Manages a few different classes
    class GameBoard : BaseBoard 
    {
        public Unit bender;
        //make a URL for the next project

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
            bender = new Unit(Unit.bender());
            board_size = 10;
            shuffle_bender(); //A fresh board not copied will need randomly generated data, except at program launch. We'll clear it in that case.
        }

        //Copy constructor
        public GameBoard(GameBoard set_from) : base()
        {
            board_size = set_from.board_size;

            //Initialize 10x10 grid
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board_data[i].Add(new BoardSquare((BoardSquare)set_from.board_data[i][j]));
                    if (board_data[i][j].visited_state == SquareVisitedState.last() && !board_data[i][j].bender_present)
                        board_data[i][j].visited_state = SquareVisitedState.explored();
                }
            }

            add_walls();

            bender = new Unit(set_from.bender);
        }

        //Only called when we start a new episode
        //We need to reset the visited state as well
        public void shuffle_cans_and_bender()
        {
            //Activate the 50/50 chance for each tile to have beer in it.
            foreach (var i in board_data)
            {
                foreach (var j in i)
                {
                    ((BoardSquare)j).randomize_beer_presence();
                    ((BoardSquare)j).visited_state = SquareVisitedState.unexplored();
                }
            }

            shuffle_bender(); //Place bender randomly somewhere
            //get_square_unit_is_on().visited_state = SquareVisitedState.last();
        }


        //This is called each time we generate a new episode for our algorithm.
        //This is also called at the start of the program launch, disconnected from shuffling the whole board, just once.
        public void shuffle_bender()
        {
            //If Bender is already somewhere on the board, make sure we remove him from that location.
            if (get_square_unit_is_on(bender).bender_present)
                board_data[bender.x_coordinate][bender.y_coordinate].bender_present = false;

            //Get bender's new location.
            bender.x_coordinate = MyRandom.Next(0, 10); //0-9 inclusive
            bender.y_coordinate = MyRandom.Next(0, 10);
            get_square_unit_is_on(bender).bender_present = true; //Set bender
            get_square_unit_is_on(bender).visited_state = SquareVisitedState.last();
            bender_percieves();
        }

        //This function will give bender perception data from the board
        public void bender_percieves()
        {
            PerceptionState find_perception = new PerceptionState();
            foreach (var i in Move.list)
            {
                find_perception.perception_data[i] = percieve(i);
            }
            //Translated: for each move, percieve with this move, and update the perception for this move.

            find_perception.set_name();
            bender.perception_data = PerceptionState.GetPerceptionFromList(find_perception);
        }

        public PerceptionState get_bender_perception()
        {
            PerceptionState find_perception = new PerceptionState();
            foreach (var i in Move.list)
            {
                find_perception.perception_data[i] = percieve(i);
            }
            //Translated: for each move, percieve with this move, and update the perception for this move.

            find_perception.set_name();
            return PerceptionState.GetPerceptionFromList(find_perception);
        }

        //Used when the robot moves *only*, otherwise, the perception will be checked from the state of the unit.
        //Generates percepts, and not MoveResults.
        public Percept percieve(Move move_to_check)
        {
            BaseSquare bender_location = board_data[bender.x_coordinate][bender.y_coordinate];

            if (move_to_check != Move.grab() && ((BoardSquare)bender_location).check_if_walls_prevent_move(move_to_check))
            {
                return Percept.wall(); //Wall percieved 
            }
            else
            {
                int percieve_x = bender.x_coordinate + move_to_check.grid_adjustment[0];
                int percieve_y = bender.y_coordinate + move_to_check.grid_adjustment[1];

                BaseSquare percieve_location = board_data[percieve_x][percieve_y];
                if (percieve_location.beer_can_present)
                    return Percept.can();
                else
                    return Percept.empty();
            }
        }

        //This is called when the algorithm has been reset
        public void ClearCans()
        {
            //Clear all cans
            foreach (var i in board_data)
            {
                foreach (var j in i)
                {
                    j.beer_can_present = false;
                    if (j.bender_present) j.visited_state = SquareVisitedState.last();
                    else
                        j.visited_state = SquareVisitedState.unexplored();
                }
            }
        }

        public void ClonePosition(GameBoard clone_from)
        {
            for(int i = 0; i < board_size; i++)
            {
                for(int j = 0; j < board_size; j++)
                {
                    get_board_data(i, j).copy_status(clone_from.get_board_data(i, j));
                }
            }
        }

        public bool IsBenderOnCan()
        {
            return board_data[bender.x_coordinate][bender.y_coordinate].beer_can_present;
        }



        public MoveResult ApplyMove(Move move_to_apply)
        {
            get_square_unit_is_on(bender).visited_state = SquareVisitedState.last();

            //Get the move result based on the current condition
            if (get_square_unit_is_on(bender).check_if_walls_prevent_move(move_to_apply))
                return MoveResult.move_hit_wall(); //Walls prevent move

            if(move_to_apply == Move.grab())
            {
                

                if (get_square_unit_is_on(bender).beer_can_present)
                {
                    collect_can();
                    return MoveResult.can_collected();
                }
                    
                else
                    return MoveResult.can_missing();
            }
            //Didn't try to grab a can, and didn't hit a wall. We moved successfully.

            MoveBender(move_to_apply);
            return MoveResult.move_successful();
        }

        public void MoveBender(Move to_move)
        {
            get_square_unit_is_on(bender).bender_present = false;

            bender.x_coordinate += to_move.grid_adjustment[0];
            bender.y_coordinate += to_move.grid_adjustment[1];
            get_square_unit_is_on(bender).bender_present = true;
            get_square_unit_is_on(bender).visited_state = SquareVisitedState.last();
            bender_percieves();
        }

        public void collect_can()
        {
            BaseSquare bender_location = board_data[bender.x_coordinate][bender.y_coordinate];
            
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
            board_data[bender.x_coordinate][bender.y_coordinate].bender_present = false;
            bender = null; //I think this removes bender
            
        }

        public void add_unit(Unit to_add)
        {
            bender = to_add;
            board_data[bender.x_coordinate][bender.y_coordinate].bender_present = true;
            //bender added
        }

        public void add_walls()
        {
            //Set all walls to empty first

            foreach(var i in board_data)
            {
                foreach(var j in i)
                {
                    ((BoardSquare)j).walls = BoardSquareWalls.empty_wall();
                }
            }
            
            //Add walls, which will replace some of the empty walls.
            //left wall
            for (int i = 1; i <= 8; i++) { ((BoardSquare)board_data[0][i]).walls = BoardSquareWalls.left_wall(); }
            //right wall
            for (int i = 1; i <= 8; i++) { ((BoardSquare)board_data[9][i]).walls = BoardSquareWalls.right_wall(); }
            //bottom wall
            for (int i = 1; i <= 8; i++) { ((BoardSquare)board_data[i][0]).walls = BoardSquareWalls.bottom_wall(); }
            //above wall
            for (int i = 1; i <= 8; i++) { ((BoardSquare)board_data[i][9]).walls = BoardSquareWalls.top_wall(); }

            ((BoardSquare)board_data[0][0]).walls = BoardSquareWalls.bottom_left_wall();
            ((BoardSquare)board_data[9][9]).walls = BoardSquareWalls.top_right_wall();
            ((BoardSquare)board_data[0][9]).walls = BoardSquareWalls.top_left_wall();
            ((BoardSquare)board_data[9][0]).walls = BoardSquareWalls.bottom_right_wall();
        }

        public BoardSquare get_square_unit_is_on(Unit unit_to_find)
        {
            return (BoardSquare)board_data[unit_to_find.x_coordinate][unit_to_find.y_coordinate];
        }

        public new BoardSquare get_board_data(int x, int y)
        {
            return (BoardSquare)board_data[x][y];
        }
    }    
}
