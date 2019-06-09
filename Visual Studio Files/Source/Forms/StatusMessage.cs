namespace ReinforcementLearning
{
    //A container class for the status message data posted every move
    class StatusMessage
    {
        public static bool program_launch_message;



        static StatusMessage()
        {
            program_launch_message = false;
        }

        public static string GetMessageFromState(AlgorithmState set_from)
        {
            string complete_message;
            complete_message = "";
            if (!program_launch_message)
            {
                program_launch_message = true;
                complete_message = "The program has been launched.\nBender's starting position is (";
                complete_message += (set_from.board_data.bender.x_coordinate + 1).ToString() + ", " + (set_from.board_data.bender.y_coordinate + 1).ToString() + ").";
            }
            else if (!AlgorithmState.algorithm_started)

                complete_message = "The board was reset. Progress has been erased.";

            //Starting data
            else if (set_from.GetStepNumber() == 0)
            {
                complete_message = "A new episode has been created.\n";
                complete_message += "Starting turn [Episode: " + set_from.GetEpisodeNumber().ToString();
                complete_message += ", Step: " + set_from.GetStepNumber().ToString() + "]";
                complete_message += " at position (" + (set_from.board_data.bender.x_coordinate + 1).ToString();
                complete_message += ", " + (set_from.board_data.bender.y_coordinate + 1).ToString() + ").";
                complete_message += System.Environment.NewLine + "Bender's initial perception is:";
                complete_message += System.Environment.NewLine + set_from.bender_perception_ending.ToString() + ".";
            }
            else
            {

                //"Episode #, Step # beginning."
                string starting_data = "Starting turn [Episode: " + set_from.GetEpisodeNumber().ToString() + ", Step: " + set_from.GetStepNumber().ToString() + "]";
                starting_data += " at position (" + (set_from.location_initial[0] + 1).ToString() + ", " + (set_from.location_initial[1] + 1).ToString() + ").";

                string initial_percept_data = "Bender's initial perception is: " + System.Environment.NewLine;
                initial_percept_data += set_from.bender_perception_starting.ToString();

                string move_being_applied_data = "";

                if (set_from.live_qmatrix.randomly_moved)
                    move_being_applied_data += "A the move was randomly generated." + System.Environment.NewLine;
                else
                    move_being_applied_data += "The move was greedily chosen." + System.Environment.NewLine;

                if (set_from.move_this_step == Move.grab())
                    move_being_applied_data += "A [Grab] was attempted.";
                else
                    move_being_applied_data += "A [" + set_from.move_this_step.long_name + "] was attempted.";

                //moveresult
                string moveresult_data = "The result of the move was [" + set_from.result_this_step.result_data + "].";

                //The reward from this action was: 
                string math_sign = "+";
                if (set_from.obtained_reward < 0)
                    math_sign = "";
                string reward_data = "The reward for this action was: [" + math_sign + set_from.obtained_reward.ToString() + "]";
                //reward_data + = ", applied to state ";
                //Add bender perception data in his new location here

                //"Bender's position is:
                string new_position_data = "The resulting position was (" + (set_from.location_result[0] + 1).ToString();
                new_position_data += ", " + ((set_from.location_result[1]) + 1).ToString() + ").";

                //New percept
                string new_percept_data = "The percept at the new location is: " + System.Environment.NewLine + set_from.bender_perception_ending.ToString() + ".";

                //"The calculation used on the q matrix was:"
                string qmatrix_adjustment_data = "No qmatrix entry was made.";
                if (set_from.live_qmatrix.did_we_update)
                    qmatrix_adjustment_data = "A q-matrix entry was made for this perception.";

                //ending data
                string ending_data = "Move [" + set_from.GetStepNumber().ToString() + "] complete.";

                string newline = System.Environment.NewLine;

                complete_message = starting_data;
                complete_message += newline + initial_percept_data;
                complete_message += newline + move_being_applied_data;
                complete_message += newline + moveresult_data;
                complete_message += newline + reward_data;
                complete_message += newline + new_position_data;
                complete_message += newline + new_percept_data;
                complete_message += newline + qmatrix_adjustment_data;
                complete_message += newline + ending_data;

            }
            return complete_message;
        }

    }
}
