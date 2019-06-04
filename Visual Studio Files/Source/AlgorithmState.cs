using System.Collections.Generic;

namespace ReinforcementLearning
{
    class AlgorithmState
    {
        public int episode_count; //current progess
        public int step_count;

        public Board board_data; //Stores the state of the cans and walls (bender is stored with other coordinates)

        public int episode_limit; //When to stop
        public int step_limit;

        public float n_current; //eta
        public float y_current; //discount
        public float e_current; //epsilon

        public float n_initial; //eta
        public float y_initial; //discount
        public float e_initial; //epsilon

        public int cans_remaining; //Session - Can data
        public int cans_collected;

        public int episode_rewards; //Session - Reward data
        public int total_rewards;

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

        //Punishments will be an associated string that returns an integer value.
        public Dictionary<string, int> reinforcement_factors;

        public Qmatrix live_qmatrix; //Moves will be generated from here.

        //Empty algorithm state
        //Dont think i need this

        //Default config algorithm state
        //This is called when the program is launched.
        public AlgorithmState()
        {
            board_data = new Board();

            //Any flag means set default
            episode_limit = 5000;
            step_limit = 200;
            n_initial = .2F;
            y_initial = .9F;
            e_initial = .1F;

            reinforcement_factors = new Dictionary<string, int>();
            reinforcement_factors.Add("Wall", -5);
            reinforcement_factors.Add("Beer", 10);
            reinforcement_factors.Add("Empty", -1);

            reset(); //handle initializing the "current session" fields
        }

        //Copied from another algorithm state
        public AlgorithmState(AlgorithmState set_from)
        {
            //Any flag means set default
            episode_limit = set_from.episode_limit;
            step_limit = set_from.step_limit;
            n_initial = set_from.n_initial;
            //discount
            y_initial = set_from.y_initial;
            //epsilon
            e_initial = set_from.e_initial;

            //Session variables
            episode_limit = set_from.episode_limit;
            step_limit = set_from.step_limit;
            //eta
            

            n_current = set_from.n_current;
            y_current = set_from.y_current;
            e_current = set_from.e_current;

            //Session - Can data
            cans_remaining = set_from.cans_remaining;
            cans_collected = set_from.cans_collected;

            //Session - Reward data
            episode_rewards = set_from.episode_rewards;
            total_rewards = set_from.total_rewards;

            //Session - Current position
            position_encoding = set_from.position_encoding;
            left_value = set_from.left_value;
            right_value = set_from.right_value;
            down_value = set_from.down_value;
            up_value = set_from.up_value;
            current_square_value = set_from.current_square_value;

            //Status message
            status_message = set_from.status_message;

            board_data = new Board(set_from.board_data);
        }

        //Used to erase session-based progress.
        public void reset()
        {
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
    }
}
