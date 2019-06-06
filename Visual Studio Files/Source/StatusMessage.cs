namespace ReinforcementLearning
{
    //A container class for the status message data posted every move
    class StatusMessage
    {
        public string starting_data; //"Episode #, Step # beginning."
        public string move_being_applied_data; //"Bender is attempting the move "" "
        public string moveresult_data; //"The result was "" "
        public string reward_data;  //The reward from this action was: 
        public string new_position_data; //"Bender's position is:
        public string qmatrix_adjustment_data; //"The calculation used on the q matrix was:"
        public string ending_data; //Step completed.
    }
}
