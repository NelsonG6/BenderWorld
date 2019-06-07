using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    static class AlgorithmStateManager
    {
        static public AlgorithmState current_state; //This is a pointer to the most recently generated state

        static public List<List<AlgorithmState>> state_history; //This is the history of the entire run, and all the configurations and q-matrix instances.
                                                                //The head of this list is the current progress point of our algorithm.

        static public float n_initial; //eta
        static public float y_initial; //discount
        static public float e_initial; //epsilon

        static public int episode_limit; //When to stop
        static public int step_limit;

        //Punishments will be an associated string that returns an integer value.
        static public Dictionary<MoveResult, float> reinforcement_factors;

        static public bool algorithm_started;
        static public bool algorithm_ended;
        static public bool program_launch_message_posted;

        static AlgorithmStateManager()
        {
            current_state = new AlgorithmState(); //Get defaults
            state_history = new List<List<AlgorithmState>>(); //initialize history
            reinforcement_factors = new Dictionary<MoveResult, float>(); //initialize reinforcement factor list

            set_default_configuration();
        }

        //This should be called at the program launch, and when the reset config button is pressed
        public static void set_default_configuration()
        {

            //Consider moving this to algorithm state constructor
            n_initial = .2F;
            y_initial = .9F;
            e_initial = .1F;

            episode_limit = 5000;
            step_limit = 200;

            algorithm_ended = false;
            algorithm_started = false;

            //Build our reinforcement factors dictionary
            reinforcement_factors.Clear();
            reinforcement_factors.Add(MoveResultList.move_hit_wall(), -5);
            reinforcement_factors.Add(MoveResultList.can_collected(), 10);
            reinforcement_factors.Add(MoveResultList.can_missing(), -1);
            reinforcement_factors.Add(MoveResultList.move_successful(), 0);

            algorithm_started = false;
        }

        public static void take_step(int steps_to_take) //Go to the most current state, and step forward once. 
        {   //If the algorithm hasn't started, this will just start the algorithm and leave us at step 0.

            while (steps_to_take-- > 0 && !algorithm_ended)
            {
                if (!algorithm_started) //First step, so just display step 0.
                {
                    algorithm_started = true;
                    //This will normally be updated already at the end of the last run

                    current_state.e_current = e_initial;
                    current_state.y_current = y_initial;
                    current_state.n_current = n_initial;

                    current_state.step_limit = step_limit;
                    current_state.episode_limit = episode_limit;

                    start_new_episode(); //go through the new episode functions
                }
                else if (current_state.step_count >= step_limit) //If the last step hit the max steps count, the step we do next 
                {
                    int episodes = state_history.Count - 1;
                    int steps = state_history[episodes].Count - 1;
                    AlgorithmState copy_from = state_history[episodes][steps]; //Don't just blindly take current_state; find the most recent step.

                    current_state = new AlgorithmState(copy_from); //Copy the old state. We're going to change this one into the new state.
                    start_new_episode(); //First step of a new episode
                                         //This is not the start of the algorithm
                }

                else
                {
                    int episodes = state_history.Count - 1;
                    int steps = state_history[episodes].Count - 1;
                    AlgorithmState copy_from = state_history[episodes][steps]; //Don't just blindly take current_state; find the most recent step.
                    current_state = new AlgorithmState(copy_from); //Copy the old state. We're going to change this one into the new state.
                    //This marks the entry point of the regular algorithm loop
                    current_state.generate_step(); //increments step counter, and builds the status message starting message

                    if (current_state.episode_count >= episode_limit)
                        if (current_state.step_count >= step_limit)
                            algorithm_ended = true; //We've exceeded the episode limit and step limit.

                    state_history.Last().Add(current_state); //Add the state to the history list, after everything possible has been done to it.    
                }
            }
        }

        //This is called when we have confirmed that we are starting a new episode from the first program run,
        //or when we are restarting after reaching a step limit max
        static private void start_new_episode()
        {
            current_state.start_new_episode(); //restart our totals
            List<AlgorithmState> to_add = new List<AlgorithmState>(); //add this to the state history as position 0
            to_add.Add(current_state); //Add the state to the new history list
            state_history.Add(to_add); //Add this history list to the list at large
        }


        static public string get_qmatrix_view(Move move_to_get)
        {
            MoveSet to_get = current_state.live_qmatrix.matrix_data[current_state.board_data.bender.get_perception_state()];
            return to_get.move_list[move_to_get].ToString();   
        }

        public static void create_empty_board()
        {   //Used ONLY with the reset button

            algorithm_started = false; //Algorithm no longer running

            Unit temp_bender;

            //Copy bender so we can keep his position
            if (current_state.board_data.bender == null)
            {
                current_state.board_data.bender = new Unit();
                temp_bender = current_state.board_data.bender;
            }
            else
                temp_bender = new Unit(current_state.board_data.bender);

            //Commenting this function and just going to use a freshly constructed algstate
            //state_history.Clear(); //Erase all state history
            //current_state.start_new_episode(); //Reset everything in our state except the initial values, and keep benders position as well

            current_state = new AlgorithmState(); //Freshly constructed. No progress kept.
            current_state.board_data.clear(); //Erase the cans, since we emptied the board. This is mostly for visual effect, to convey the algoirthm has stopped.
            current_state.board_data.remove_unit(current_state.board_data.bender); //Remove the automatic bender that was placed
            current_state.board_data.add_unit(temp_bender); //Add bender at the position he was in before we cleared the board
        }
    }
}
