using System;
using System.Collections.Generic;
using System.Linq;

namespace ReinforcementLearning
{
    class Qmatrix
    {
        //Our robot can make 5 percepts. Each percept has 3 possible results.
        //3 ^ 5 = 243, so there are 243 possible states to correlate our q matrix to.
        //We need to assemble each combination.
        //Our three states are represented by strings:
        //"Wall", "Can", "Empty"

        //Perception state is a string with 5 corresponding action-value pairs. Example: { "beer, beer, beer, beer, empty", "left: 5", "right: 5"
        //Moveset is a dictionary of moves to doubles
        public Dictionary<PerceptionState, ValueSet> matrix_data;

        //The q-matrix does not store any details about what state the board is in, so it must have a state passed to it.
        static double y;

        public double n_current; //eta doesn't really need a non-static variable, but it might change in the future
        public double y_current; //discount
        public double e_current; //epsilon

        static public int step_limit;  //limits
        static public int episode_limit;

        public int episode_number; //keeping track of which episode this is, and which step
        public int step_number;

        public bool did_we_update;
        public bool randomly_moved;


        static double e_initial;
        
        public Qmatrix()
        {
            //This is our q-matrix
            matrix_data = new Dictionary<PerceptionState, ValueSet>();
            did_we_update = false;

            e_current = InitialSettings.e(); //Epsilon; do we explore or exploit. Random factor for taking a best move or random move.
            y_current = InitialSettings.y(); //Gamma; our discounted rate.
            n_current = InitialSettings.n(); //The learning rate
            y = InitialSettings.y();

            step_limit = InitialSettings.step_limit();  //limits
            episode_limit = InitialSettings.episode_limit();

        }

        static Qmatrix()
        {
            //Default limit
            e_initial = InitialSettings.e();
            episode_limit = InitialSettings.episode_limit();
            step_limit = InitialSettings.step_limit();
        }
        
        public Qmatrix(Qmatrix copy_from)
        {
            //Copy the q-matrix.
            matrix_data = new Dictionary<PerceptionState, ValueSet>();
            foreach(var i in copy_from.matrix_data.Keys)
            {   //For each list of strings in copy_from.matrix data
                //Get a copy of the dictionary at this list of strings
                //Should be a deep copy
                matrix_data.Add(i, new ValueSet(copy_from.matrix_data[i]));
            }
            did_we_update = copy_from.did_we_update;
            step_number = copy_from.step_number;
            episode_number = copy_from.episode_number;
            n_current = copy_from.n_current;
            y_current = copy_from.y_current;
            e_current = copy_from.e_current;
        }

        //Determine what the next move to make will be.
        public Move GenerateStep(PerceptionState perceieved_state)
        {
            if (matrix_data.Keys.Contains(perceieved_state))
            {
                //Always generate the step using the state at algorithmManager.GetCurrentState()
                Dictionary<Move, double> best_percepts = new Dictionary<Move, double>();

                
                //Determine if we will be making a greedy best selection, or a random selection.
                //e will be a double, possibly very small, but not more than 1.
                if (MyRandom.Next(1, 101) < e_current * 100)
                {
                    randomly_moved = true;
                    //Random move. 
                    return Move.list[MyRandom.Next(0, 5)];
                }
                else
                {
                    //Greedy selection, then random among best matches.
                    //Loop through the move-double pair, and do a random selection of any move that is tied for best action.
                    foreach (var i in matrix_data[perceieved_state].move_list)
                    {
                        if (best_percepts.Count == 0)
                            best_percepts.Add(i.Key, i.Value);
                        else if (best_percepts.Values.First() < i.Value)
                        {
                            best_percepts = new Dictionary<Move, double>();
                            best_percepts.Add(i.Key, i.Value);
                        }
                        else if (best_percepts.Values.First() == i.Value)
                            best_percepts.Add(i.Key, i.Value);
                    }
                }

                Move[] moves = best_percepts.Keys.ToArray(); //Convert the moves we retained to a list
                return moves[MyRandom.Next(0, moves.Count())]; //return a random member of this list
            }

            //No q-matrix entry, so just do a random move. 
            return Move.list[MyRandom.Next(0, Move.list.Count)];
        }

        //When this is called, the q matrix will update a previous state with the value of the next state
        //Calculate the change here
        public void UpdateState(PerceptionState state_to_update, PerceptionState result_state, Move result_move, double base_reward)
        {
            double old_qmatrix_value = 0;
            //Initial the start of our update value
            if (matrix_data.Keys.Contains(state_to_update))
                old_qmatrix_value = matrix_data[state_to_update].GetBestValue(); //Whats our old best qmatrix value at our old state?

            //Whats the best value at the new one?
            double new_qmatrix_value = 0;
            if (matrix_data.Keys.Contains(result_state))
                new_qmatrix_value = matrix_data[result_state].GetBestValue();
            double difference = new_qmatrix_value - old_qmatrix_value;

            y_current = (double)Math.Pow(y, step_number - 1); //y ^ step-1 is the discount factor
            double discounted_difference = difference * y_current;
            double reward_added = discounted_difference + base_reward;
            double final_value = n_current * reward_added;

            did_we_update = false; //Status message grabs this later
                                   //check if this state already exists, and add it to our list of states we've encountered, if not.

            if (final_value != 0)
            {
                did_we_update = true;
                if (!matrix_data.Keys.Contains(state_to_update))
                    matrix_data[state_to_update] = new ValueSet();
                matrix_data[state_to_update][result_move] = final_value;
            }
        }



        public List <string> get_list_of_qmatrix_states()
        {
            List<string> building = new List<string>();
            foreach (var i in matrix_data.Keys.OrderBy(o => o.ID))
            {
                building.Add(i.ToString());
            }
            return building;
        }

        //Called when we have a new episode at the state, and we need to update some values here
        public void ProcessNewEpisode()
        {
            step_number = 0;
            episode_number++;

            e_current -= (e_initial / episode_limit);

        }
    }
}
