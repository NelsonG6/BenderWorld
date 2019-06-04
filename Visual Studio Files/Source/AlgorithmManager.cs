using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    static class AlgorithmManager
    {
        static public AlgorithmState current_state; //This will store the current configuration of cans and bender, and q matrix.


        static public List<List<AlgorithmState>> state_history;

        static AlgorithmManager()
        {
            current_state = new AlgorithmState(); //This marks the progress point of the entire algorithm.
            //If a history entry is being viewed, then this is not what is being displayed currently.
            //In that case, the currently displayed state will be held by the FormsHandler.

            //Commenting this because pictureboxes get created after this constructor has run
            //textboxes.clear_after_board_reset(main_board); //Will give us the default empty board
            state_history = new List<List<AlgorithmState>>();
        }

        public static void create_empty_board()
        {
            state_history.Clear(); //Erase all state history
            current_state.reset(); //Reset everything in our state except the initial values.
            FormsHandler.update_state(current_state); //use formshandler to display this state
        }

        public static void take_step()
        {
            //figure out which action to take
            if (current_state.episode_count == 0 && current_state.step_count == 0) //First step, so just display step 0.
            {
                current_state.board_data.shuffle_cans_and_bender(); //Shuffle the the current board
                FormsHandler.update_state(current_state);
            }
                
            else
            {
                //Get step from qmatrix. Being randomly generated for now.
                string step_to_take = current_state.live_qmatrix.generate_step(current_state);

                
                if (current_state.step_count >= current_state.step_limit)
                {   //We've taken the max amount of steps.
                    if (current_state.episode_count >= current_state.episode_limit)
                    {
                        //algorithm is done running trials

                    }
                }
            }


            FormsHandler.update_state(current_state);
        }

        static public void place_bender_randomly()
        {
            current_state.board_data.shuffle_bender();
        }
    }
}
