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

        static AlgorithmStateManager()
        {
            current_state = new AlgorithmState(); //Get defaults
            state_history = new List<List<AlgorithmState>>(); //initialize history
            reinforcement_factors = new Dictionary<MoveResult, float>(); //initialize reinforcement factor list

            set_default_configuration();
        }

        public static void set_default_configuration()
        {
            n_initial = .2F;
            y_initial = .9F;
            e_initial = .1F;

            episode_limit = 5000;
            step_limit = 200;

            reinforcement_factors.Clear();

            //Build our reinforcement factors dictionary
            
            reinforcement_factors.Add(MoveResultList.move_hit_wall(), -5);
            reinforcement_factors.Add(MoveResultList.can_collected(), 10);
            reinforcement_factors.Add(MoveResultList.can_missing(), -1);
            reinforcement_factors.Add(MoveResultList.move_successful(), 0);

            current_state.board_data.shuffle_bender();
            current_state.board_data.clear();
        }

        public static void take_step(int steps_to_take) //Go to the most current state, and step forward once. 
        {   //If the algorithm hasn't started, this will just start the algorithm and leave us at step 0.

            float update_value = 0; //Our reinforcement value based on the action we take.
            PerceptionState state_for_qmatrix; //This will store the perception that our unit has, so we can index the correct row of the q-matrix.

            while (steps_to_take-- > 0)
            {
                if(!algorithm_started) //First step, so just display step 0.
                {
                    algorithm_started = true;
                    current_state.update_fields(); //Read the data for the first time, since the algorithm just started
                    //This will normally be updated already at the end of the last run

                    ++(current_state.episode_count);
                    current_state.board_data.shuffle_cans_and_bender(); //Shuffle the the current board

                    //Bender percieves
                    current_state.board_data.bender_percieves();

                    //Add benders percept to the matrix
                    current_state.live_qmatrix.matrix_data.Add(current_state.board_data.bender.get_perception_state(), new MoveSet());

                    state_history.Add(new List<AlgorithmState>()); //episode index 0
                    state_history[0].Add(current_state);

                    current_state.e_current = e_initial;
                    current_state.y_current = y_initial;
                    current_state.n_current = n_initial;
                }                
                else
                {
                    if(current_state.step_count >= step_limit)
                    {   //First step
                        current_state = new AlgorithmState(current_state); //Clone the old state, so we dont modify what we stored in the list.
                        current_state.board_data.shuffle_cans_and_bender(); //Shuffle the the current board. //History was already added.
                        current_state.start_new_episode(); //restart our totals
                        ++(current_state.episode_count);
                        current_state.step_count = 0;

                        List<AlgorithmState> to_add = new List<AlgorithmState>(); //add this to the state history as position 0
                        to_add.Add(current_state);
                        state_history.Add(to_add);
                    }

                    current_state = new AlgorithmState(current_state); //Copy the old state. We're going to change this one into the new state.
                    
                    //Get step from qmatrix. Being randomly generated for now.
                    state_for_qmatrix = current_state.board_data.bender.get_perception_state(); //This is used to update the matrix after our move
                    Move step_to_take = current_state.live_qmatrix.generate_step(); //Tentative; we'll attempt this later. just a random move for now.
                    MoveResult move_result = current_state.board_data.apply_move(step_to_take); //The move should be performed now, if possible.
                    update_value = reinforcement_factors[move_result]; //Get the reward for this action

                    current_state.episode_rewards += (int)update_value; //Update the rewards total
                    ++(current_state.step_count);

                    current_state.live_qmatrix.update_state(state_for_qmatrix, step_to_take, update_value); //give the value to the q matrix to digest
                    state_history[current_state.episode_count].Add(current_state);

                    if (current_state.step_count >= step_limit)
                    {   //We've taken the max amount of steps. 
                        
                    }

                    if (current_state.episode_count >= episode_limit)
                    {
                        //algorithm is done running trials

                    }
                }
                
                FormsHandler.display_state(current_state);
            }
        }

        public static void create_empty_board()
        {   //Used with the reset button, and on program launch
            //Not used when the algorithm is running

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

            algorithm_started = false; //Algorithm no longer running

            FormsHandler.display_state(current_state); //use formshandler to display this state
        }

        static public string get_qmatrix_view(Move move_to_get)
        {
            MoveSet to_get = current_state.live_qmatrix.matrix_data[current_state.board_data.bender.get_perception_state()];
            return to_get.move_list[move_to_get].ToString();   
        }
    }
}
