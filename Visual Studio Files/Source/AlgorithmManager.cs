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
        static public Dictionary<string, int> reinforcement_factors;

        static public bool algorithm_started;

        static AlgorithmManager()
        {
            current_state = new AlgorithmState(); //Get defaults
            state_to_view = current_state;
            state_history = new List<List<AlgorithmState>>(); //initialize history
            qmatrix = new Qmatrix();

            set_default_configuration();
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
            while(steps_to_take-- > 0)
            {
                if (!algorithm_started) //First step, so just display step 0.
                {
                    current_state.board_data.shuffle_cans_and_bender(); //Shuffle the the current board
                    state_history.Add(new List<AlgorithmState>()); //episode index 0
                    state_history[0].Add(current_state);
                    
                    algorithm_started = true;                    
                }
                else
                {
                    //Get step from qmatrix. Being randomly generated for now.
                    string step_to_take = qmatrix.generate_step(state_to_view);

                    //We got our move. Determine if we have a grab attempt, or a move attempt.
                    if(step_to_take == "Grab")
                    {
                        //see if there is a can to grab or not.
                        if(current_state.board_data.is_bender_on_can())
                        {
                            //There was a can here.
                            //update total rewards
                            //update reward value for this iteration

                        }

                    }
                    

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

        public static void set_default_configuration()
        {
            n_initial = .2F;
            y_initial = .9F;
            e_initial = .1F;

            episode_limit = 5000;
            step_limit = 200;
            
            //Build our reinforcement factors dictionary
            if (reinforcement_factors == null)
            {
                reinforcement_factors = new Dictionary<string, int>();
                reinforcement_factors.Add("Wall collision", -5);
                reinforcement_factors.Add("Beer pickup", 10);
                reinforcement_factors.Add("Empty pickup", -1);
            }
            else
            {
                reinforcement_factors["Wall collision"] = -5;
                reinforcement_factors["Beer pickup"] = 10;
                reinforcement_factors["Empty pickup"] = -1;
            }
        }

    }
}
