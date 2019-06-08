using System.Collections.Generic;

namespace ReinforcementLearning
{
    class AlgorithmState
    {
        public int episode_count; //current progess
        public int step_count;

        public int step_limit;  //limits
        public int episode_limit;

        public GameBoard board_data; //Stores the state of the cans and walls (bender is stored with other coordinates)

        public float n_current; //eta
        public float y_current; //discount
        public float e_current; //epsilon

        public int cans_collected;

        public float episode_rewards; //Session - Reward data
        public float total_rewards;

        public StatusMessage status_message; //the status message to be displayed.

        public Qmatrix live_qmatrix; //Moves will be generated from here.

        public int[] location_initial;
        public int[] location_result;

        public Move move_this_step; //The move we took this step, stored for the status message
        public MoveResult result_this_step; //Moveresult stored for status

        public float obtained_reward; //The raw reward for the action we took

        public PerceptionState bender_perception_starting;
        public PerceptionState bender_perception_ending;

        //We dont need this for this program
        //public List<Unit> unit_list; 

        //Empty algorithm state
        //Dont think i need this


        //Punishments will be an associated string that returns an integer value.
        public Dictionary<MoveResult, float> reinforcement_factors;

        //Default config algorithm state
        //This is called when the program is launched.
        public AlgorithmState()
        {
            board_data = new GameBoard(); //Produces a shuffled bender and can-filled board  
            board_data.clear(); //Clear the board for our initial launch

            live_qmatrix = new Qmatrix();

            location_initial = new int[2] { board_data.bender.bender_x, board_data.bender.bender_y };
            location_result = new int[2] { 0, 0 };

            //A new episode will produce shuffled cans, but we'll clear it for the loading screen.
            
            move_this_step = null;
            result_this_step = null;
            obtained_reward = 0;

            status_message = new StatusMessage(this);

            bender_perception_starting = null;
            

            //Set initial data
            e_current = .1F;
            y_current = .9F;
            n_current = .2F;

            reinforcement_factors = new Dictionary<MoveResult, float>(); //initialize reinforcement factor list
            reinforcement_factors.Clear();
            reinforcement_factors.Add(MoveResultList.move_hit_wall(), -5);
            reinforcement_factors.Add(MoveResultList.can_collected(), 10);
            reinforcement_factors.Add(MoveResultList.can_missing(), -1);
            reinforcement_factors.Add(MoveResultList.move_successful(), 0);

            //Default limit
            episode_limit = 5000;
            step_limit = 200;

            episode_count = 1;

            board_data.bender_percieves();
            bender_perception_ending = board_data.bender.get_perception_state();

        }

        //Copied from another algorithm state
        //We reset some data, so we dont reflect values that aren't true for the new state
        //This constructor is called when a new step is being generated, so we transfer some values appropriately.
        public AlgorithmState(AlgorithmState set_from)
        {
            n_current = set_from.n_current;
            y_current = set_from.y_current;
            e_current = set_from.e_current;

            episode_limit = set_from.episode_limit;
            step_limit = set_from.step_limit;

            cans_collected = set_from.cans_collected;

            episode_rewards = set_from.episode_rewards; //Reward data
            total_rewards = set_from.total_rewards;

            status_message = null; //No status message while we're building/stepping the next state
            move_this_step = null;
            result_this_step = null;
            obtained_reward = 0;

            //Detect if we reached the limit for this episode
            if (step_count == step_limit)
                start_new_episode();
            else
            {
                step_count = set_from.step_count + 1;
                episode_count = set_from.episode_count;
            }
            
            live_qmatrix = new Qmatrix(set_from.live_qmatrix); //Copy the q matrix

            board_data = new GameBoard(set_from.board_data); //Copy the board

            reinforcement_factors = set_from.reinforcement_factors;

            //The initial location will be the resulting location of the last step
            location_initial = new int[2] { set_from.location_result[0], set_from.location_result[1] };
            location_result = null;

            bender_perception_starting = set_from.bender_perception_ending;
            bender_perception_ending = null;

        }

        public Percept get_bender_percept(Move direction_to_check)
        {
            return board_data.bender.get_percept(direction_to_check);
        }

        //Used to erase session-based progress.
        //This is also called each new episode once we reach the max steps
        //Not called when the program launches?
        public void start_new_episode()
        {
            ++episode_count;
            step_count = 0;
            cans_collected = 0;
            episode_rewards = 0; //Session - Reward data

            board_data.shuffle_cans_and_bender(); //Shuffle the the current board.

            board_data.bender_percieves();

            location_result = new int[2] { board_data.bender.bender_x, board_data.bender.bender_y };

            bender_perception_starting = board_data.bender.get_perception_state();
            bender_perception_ending = board_data.bender.get_perception_state();



            status_message = new StatusMessage(this);
        }

        //At the algorithm manager, generate step is ambiguous with actually stepping through the algorithm,
        //Or starting the algorithm, and making the first history entry at step 0.
        //Here, a step only happens when we have been asked by the manager to *actually* take a step.
        public void generate_step()
        {   
            //Get step from qmatrix. Being randomly generated for now.
            move_this_step = live_qmatrix.generate_step(); //Tentative; we'll attempt this later. just a random move for now.
            result_this_step = board_data.apply_move(move_this_step); //The move should be performed now, if possible.
            obtained_reward = AlgorithmStateManager.current_state.reinforcement_factors[result_this_step]; //Get the reward for this action

            episode_rewards += obtained_reward; //Update the rewards total

            if (result_this_step == MoveResultList.can_collected())
                ++cans_collected;

            live_qmatrix.update_state(bender_perception_starting, move_this_step, obtained_reward); //give the value to the q matrix to digest

            location_result = new int[2] { board_data.bender.bender_x, board_data.bender.bender_y };
            bender_perception_ending = board_data.bender.get_perception_state();

            if (step_count == step_limit && episode_count > episode_limit)
                AlgorithmStateManager.algorithm_ended = true;

            status_message = new StatusMessage(this);
        }

        override public string ToString()
        {
            return "[Step " + step_count + "]";
        }
    } 
}
