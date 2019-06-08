using System.Collections.Generic;
using System.Linq;

namespace ReinforcementLearning
{
    class AlgorithmState
    {
        //Static members
        static public AlgorithmState current_state; //This is a pointer to the most recently generated state

        static public List<AlgorithmEpisode> state_history; //This is the history of the entire run, and all the configurations and q-matrix instances.
                                                            //The head of this list is the current progress point of our algorithm.

        static public bool algorithm_started;
        static public bool algorithm_ended;

        //Non-static members
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

        public Qmatrix live_qmatrix; //Moves will be generated from here.

        public int[] location_initial;
        public int[] location_result;

        public Move move_this_step; //The move we took this step, stored for the status message
        public MoveResult result_this_step; //Moveresult stored for status

        public float obtained_reward; //The raw reward for the action we took

        public PerceptionState bender_perception_starting;
        public PerceptionState bender_perception_ending;

        //Static functions
        static AlgorithmState()
        {
            set_default_configuration();
        }

        //This should be called at the program launch, and when the reset config button is pressed
        public static void set_default_configuration()
        {
            current_state = new AlgorithmState(); //Get defaults
            state_history = new List<AlgorithmEpisode>(); //initialize history

            algorithm_ended = false;
            algorithm_started = false;
            //Consider moving this to algorithm state constructor
        }

        public static AlgorithmState get_latest()
        {
            int episode_index = state_history.Count - 1;
            if (episode_index == -1)
            {
                return null; //No episodes created
            }
            else
            {
                int step_index = state_history[episode_index].Count() - 1;
                if (step_index == -1)
                    return null; //Step index shouldn't be 0, because we shouldn't call this at a time when we created a new episode but didn't put a state there.
                else
                    return state_history[episode_index][step_index];
            }
        }

        public static void start_algorithm()
        {
            algorithm_started = true;
            current_state.board_data.shuffle_cans_and_bender();
        }

        public static void take_step(int steps_to_take) //Go to the most current state, and step forward once. 
        {   //If the algorithm hasn't started, this will just start the algorithm and leave us at step 0.
            while (steps_to_take-- > 0 && !algorithm_ended)
            {
                if (state_history.Count == 0)
                {
                    current_state.start_new_episode();
                    state_history.Add(new AlgorithmEpisode(current_state.episode_count));
                }
                else
                {
                    current_state = new AlgorithmState(get_latest()); //Only copy the last state if we have a history
                                                                      //If the count wasn't 0, then we are starting the algorithm, and the state was built from the interface. No need to copy.
                    if (state_history.Count() < current_state.episode_count) //When we copied the state above, it determined if this still will belong to a new episode.
                    //Since the episode count is higher than the index of the episod
                        state_history.Add(new AlgorithmEpisode(current_state.episode_count));
                    
                    else
                        current_state.generate_step();

                }
                state_history.Last().Add(current_state); //Add the state to the history list, after everything possible has been done to it.    
            }
        }

        static public string get_qmatrix_view(Move move_to_get)
        {
            MoveSet to_get = current_state.live_qmatrix.matrix_data[current_state.board_data.bender.get_perception_state()];
            return to_get.move_list[move_to_get].ToString();
        }

        public static void erase_board_for_reset()
        {   //Used ONLY with the reset button, keeps a few old things, like bender's position and settings
            algorithm_started = false; //Algorithm no longer running
            current_state.initialize_values();
            state_history = new List<AlgorithmEpisode>();
        }

        //Non-static functions
        //Default config algorithm state
        //This is called when the program is launched.
        public AlgorithmState()
        {
            board_data = new GameBoard(); //Produces a shuffled bender and can-filled board 

            initialize_values(); //Gives us some empty defaults

            //Set initial data
            e_current = .1F;
            y_current = .9F;
            n_current = .2F;

            //Default limit
            episode_limit = 5000;
            step_limit = 200;

        }

        //Called from create_empty_board (after reset), and the constructor
        //Just a useful container for resetting some values when we want to start over, but making a new state would have us lose bender's position.
        private void initialize_values()
        {
            board_data.clear(); //Clear the board for our initial launch(this doesn't remove bender, just cans)
            episode_count = 0;
            live_qmatrix = new Qmatrix();

            location_initial = new int[2] { board_data.bender.x_coordinate, board_data.bender.y_coordinate };
            location_result = new int[2] { 0, 0 };
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

            board_data = new GameBoard(set_from.board_data); //Copy the board

            episode_count = set_from.episode_count;
            step_count = set_from.step_count;
            
            live_qmatrix = new Qmatrix(set_from.live_qmatrix); //Copy the q matrix

            //The initial location will be the resulting location of the last step
            location_initial = new int[2] { set_from.location_result[0], set_from.location_result[1] };

            bender_perception_starting = set_from.bender_perception_ending;

            //Detect if we reached the limit for this episode
            if (step_count == step_limit)
                start_new_episode();
            else
                ++step_count;
        }

        public Percept get_bender_percept(Move direction_to_check)
        {
            return board_data.bender.get_percept(direction_to_check);
        }

        //Used to erase session-based progress.
        //This is also called each new episode once we reach the max steps
        //Not called when the program launches
        public void start_new_episode()
        {
            ++episode_count;
            step_count = 0;
            cans_collected = 0;
            episode_rewards = 0; //Session - Reward data

            board_data.shuffle_cans_and_bender(); //Shuffle the the current board.

            board_data.bender_percieves();

            location_result = new int[2] { board_data.bender.x_coordinate, board_data.bender.y_coordinate };

            bender_perception_starting = board_data.bender.get_perception_state();
            bender_perception_ending = board_data.bender.get_perception_state();
        }

        //At the algorithm manager, generate step is ambiguous with actually stepping through the algorithm,
        //Or starting the algorithm, and making the first history entry at step 0.
        //Here, a step only happens when we have been asked by the manager to *actually* take a step.
        public void generate_step()
        {   
            //Get step from qmatrix. Being randomly generated for now.
            move_this_step = live_qmatrix.generate_step(board_data.bender.get_perception_state()); //Tentative; we'll attempt this later. just a random move for now.
            result_this_step = board_data.apply_move(move_this_step); //The move should be performed now, if possible.
            obtained_reward = ReinforcementFactors.list[result_this_step]; //Get the reward for this action

            episode_rewards += obtained_reward; //Update the rewards total

            if (result_this_step == MoveResult.can_collected())
                ++cans_collected;

            if (obtained_reward > 0)
                live_qmatrix.update_state(bender_perception_starting, move_this_step, obtained_reward); //give the value to the q matrix to digest

            location_result = new int[2] { board_data.bender.x_coordinate, board_data.bender.y_coordinate };
            bender_perception_ending = board_data.bender.get_perception_state();

            if (step_count == step_limit && episode_count > episode_limit)
                algorithm_ended = true;
        }

        override public string ToString()
        {
            return "[Episode: " + episode_count.ToString() + "][Step: " + step_count + "]";
        }
    } 
}
