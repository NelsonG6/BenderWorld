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

        static public List<AlgorithmEpisode> state_history; //This is the history of the entire run, and all the configurations and q-matrix instances.
                                                                //The head of this list is the current progress point of our algorithm.

        static public bool algorithm_started;
        static public bool algorithm_ended;

        static AlgorithmStateManager()
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
            if(episode_index == -1)
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
                if (state_history.Count > 0)
                    current_state = new AlgorithmState(get_latest()); //Only copy the last state if we have a history
                                                                      //If the count wasn't 0, then we are starting the algorithm, and the state was built from the interface. No need to copy.
                if (state_history.Count < current_state.episode_count) //When we copied the state above, it determined if this still will belong to a new episode.
                
                    //Since the episode count is higher than the index of the episodes in our state_history, we know we need to add a new index for a new episode.
                    state_history.Add(new AlgorithmEpisode(AlgorithmStateManager.current_state.episode_count));
                    //Don't advance a step when we do this.
                
                else    //Should have a newly generated algorithm state now
                        //This marks the entry point of the regular algorithm loop
                    current_state.generate_step(); //The state determines a move to make, and attempts it, and records the results.

                state_history.Last().Add(current_state); //Add the state to the history list, after everything possible has been done to it.    
            }
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
            if (get_latest().board_data.bender == null)
            {
                get_latest().board_data.bender = new Unit();
                temp_bender = get_latest().board_data.bender;
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

            state_history = new List<AlgorithmEpisode>();
        }
    }
}
