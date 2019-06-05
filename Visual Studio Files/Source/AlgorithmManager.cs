using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    static class AlgorithmManager
    {
        static public AlgorithmState state_to_view; //This will store the currently displayed configuration of cans and bender, and q matrix.
        static public AlgorithmState current_state; //This is a pointer to the most recently generated state

        static public List<List<AlgorithmState>> state_history; //This is the history of the entire run, and all the configurations and q-matrix instances.
                                                                //The head of this list is the current progress point of our algorithm.

        static public Qmatrix qmatrix; //This is the running q matrix.
                                        //We'll be making copies of this for our stored algorithm state history.

        static public float n_initial; //eta
        static public float y_initial; //discount
        static public float e_initial; //epsilon

        static public int episode_limit; //When to stop
        static public int step_limit;

        //Punishments will be an associated string that returns an integer value.
        static public Dictionary<MoveResult, float> reinforcement_factors;

        static public bool algorithm_started;        

        static AlgorithmManager()
        {
            current_state = new AlgorithmState(); //Get defaults
            state_to_view = current_state;
            state_history = new List<List<AlgorithmState>>(); //initialize history
            qmatrix = new Qmatrix();
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

        }

        public static void create_empty_board()
        {   //Used with the reset button, and on program launch
            state_history.Clear(); //Erase all state history
            current_state.reset(); //Reset everything in our state except the initial values, and keep benders position as well
            current_state.board_data.clear(); //get rid of cans
            qmatrix = new Qmatrix(); //Erase q matrix
            algorithm_started = false; //Algorithm no longer running
            state_to_view = current_state; //Set the state to display to match our current state.
            FormsHandler.display_manager_state(); //use formshandler to display this state
        }

        public static void take_step(int steps_to_take) //Go to the most current state, and step forward once. 
        {   //This function also will not step if
            //figure out which action to take

            float update_value = 0;
            PerceptionState state_for_qmatrix;

            while (steps_to_take-- > 0)
            {
                if (!algorithm_started) //First step, so just display step 0.
                {
                    current_state.board_data.shuffle_cans_and_bender(); //Shuffle the the current board
                    current_state.update_fields(); //update everything after the change


                    state_history.Add(new List<AlgorithmState>()); //episode index 0
                    state_history[0].Add(current_state);
                    
                    algorithm_started = true;

                    //Bender percieves
                    current_state.board_data.bender_percieves();
                }
                else
                {
                    current_state = new AlgorithmState(current_state); //Copy the old state. We're going to change this one into the new state.
                    
                    //Get step from qmatrix. Being randomly generated for now.
                    state_for_qmatrix = current_state.board_data.bender.get_perception_state(); //This is used to update the matrix after our move
                    Move step_to_take = qmatrix.generate_step(); //Tentative; we'll attempt this later. just a random move for now.
                    MoveResult move_result = current_state.board_data.apply_move(step_to_take); //The move should be performed now, if possible.
                    update_value = reinforcement_factors[move_result];
                    current_state.episode_rewards += (int)update_value;

                    current_state.live_qmatrix.update_state(state_for_qmatrix, step_to_take, update_value);

                    if (state_to_view.step_count >= step_limit)
                    {   //We've taken the max amount of steps. 
                        
                    }

                    if (state_to_view.episode_count >= episode_limit)
                    {
                        //algorithm is done running trials

                    }


                }
                FormsHandler.display_manager_state();
            }
        }
    }
}
