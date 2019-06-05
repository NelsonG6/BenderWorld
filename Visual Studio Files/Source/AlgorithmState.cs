using System.Collections.Generic;

namespace ReinforcementLearning
{
    class AlgorithmState
    {
        public int episode_count; //current progess
        public int step_count;

        public Board board_data; //Stores the state of the cans and walls (bender is stored with other coordinates)

        public float n_current; //eta
        public float y_current; //discount
        public float e_current; //epsilon

        public int cans_remaining; //Session - Can data
        public int cans_collected;

        public float episode_rewards; //Session - Reward data
        public float total_rewards;

        public float left_q_value; //Q-matrix values for current position
        public float right_q_value;
        public float down_q_value;
        public float up_q_value;
        public float current_q_value;

        public string position_encoding; //Session - Current position
        public string left_value;
        public string right_value;
        public string down_value;
        public string up_value;
        public string current_square_value;

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
            board_data = new Board();

            //Any flag means set default
            live_qmatrix = new Qmatrix();

            current_unit = new Unit(); //Only one unit this program, so this will be a bender.
            reset(); //handle initializing the "current session" fields
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

            position_encoding = set_from.position_encoding; //Session - Current position
            left_value = set_from.left_value;
            right_value = set_from.right_value;
            down_value = set_from.down_value;
            up_value = set_from.up_value;
            current_square_value = set_from.current_square_value;            

            status_message = set_from.status_message; //Status message

            live_qmatrix = new Qmatrix(set_from.live_qmatrix); //Copy the q matrix

            board_data = new Board(set_from.board_data); //Copy the board
        }

        //Used to erase session-based progress.
        public void reset()
        {   //We'll keep the placement of bender
            episode_count = 0; //Current progress
            step_count = 0;

            board_data.clear();

            cans_remaining = 0; //Session - Can data
            cans_collected = 0;

            episode_rewards = 0; //Session - Reward data
            total_rewards = 0;

            left_q_value = 0; //q-matrix state for the current position.
            right_q_value = 0;
            down_q_value = 0;
            up_q_value = 0;
            current_q_value = 0;

            position_encoding = "empty"; //Session - Current position
            left_value = "empty";
            right_value = "empty";
            down_value = "empty";
            up_value = "empty";
            current_square_value = "empty";

            status_message = "empty"; //For storing what the message was when this state was produced
        }

        public void update_fields()
        {
            if (board_data.get_cans_remaining() < cans_remaining)
            {
                cans_remaining--;
                cans_collected++;
            }

            episode_rewards = 0; //Session - Reward data
            total_rewards = 0;

            left_q_value = 0; //q-matrix state for the current position.
            right_q_value = 0;
            down_q_value = 0;
            up_q_value = 0;
            current_q_value = 0;

            position_encoding = "empty"; //Session - Current position
            left_value = "empty";
            right_value = "empty";
            down_value = "empty";
            up_value = "empty";
            current_square_value = "empty";

            status_message = "empty"; //For storing what the message was when this state was produced
        }
    }
}
