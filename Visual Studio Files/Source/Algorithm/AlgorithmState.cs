namespace ReinforcementLearning
{
    class AlgorithmState
    {
        public int episode_count; //current progess
        public int step_count;

        public GameBoard board_data; //Stores the state of the cans and walls (bender is stored with other coordinates)

        public float n_current; //eta
        public float y_current; //discount
        public float e_current; //epsilon

        public int cans_remaining; //Session - Can data
        public int cans_collected;

        public float episode_rewards; //Session - Reward data
        public float total_rewards;

        public string status_message; //The message that was displayed when this state was produced.

        public Percept get_bender_percept(Move direction_to_check)
        {
            return board_data.bender.get_percept(direction_to_check);

        }

        public Qmatrix live_qmatrix; //Moves will be generated from here.

        public Unit current_unit; //Store the unit that is on our board. This would be a list if we had more than one bender.
        //If there were more units, this would not be where the instance lived

        //We dont need this for this program
        //public List<Unit> unit_list; 

        //Empty algorithm state
        //Dont think i need this

        //Default config algorithm state
        //This is called when the program is launched.
        public AlgorithmState()
        {
            board_data = new GameBoard();

            //Any flag means set default
            live_qmatrix = new Qmatrix();

            current_unit = new Unit(); //Only one unit this program, so this will be a bender.
            start_new_episode(); //handle initializing the "current session" fields
        }

        //Copied from another algorithm state
        public AlgorithmState(AlgorithmState set_from)
        {           
            n_current = set_from.n_current;
            y_current = set_from.y_current;
            e_current = set_from.e_current;

            cans_remaining = set_from.cans_remaining; //Can data
            cans_collected = set_from.cans_collected;

            episode_rewards = set_from.episode_rewards; //Reward data
            total_rewards = set_from.total_rewards;

            status_message = set_from.status_message; //Status message

            live_qmatrix = new Qmatrix(set_from.live_qmatrix); //Copy the q matrix

            board_data = new GameBoard(set_from.board_data); //Copy the board
        }

        //Used to erase session-based progress.
        //This is called from AlgorithmManager.create_empty_board(), and only when the reset button is clicked.
        //This is not called during algorithm running.
        //We essentially want a brand new state, aside from the 
        public void start_new_episode()
        {   //We'll keep the placement of bender

            episode_count = 0;
            step_count = 0;

            cans_collected = 0;

            episode_rewards = 0; //Session - Reward data

            //sense benders position

            status_message = "empty"; //For storing what the message was when this state was produced

            update_fields();
        }

        public void update_fields()
        {
            if (board_data.get_cans_remaining() < cans_remaining)
            {
                cans_remaining--;
                cans_collected++;
            }

            status_message = "New episode."; //For storing what the message was when this state was produced
        }

        /*
        public void get_qvalues()
        {
            live_qmatrix.get_qvalues(board_data.bender.get_perception_state());


        }
        */
    }
}
