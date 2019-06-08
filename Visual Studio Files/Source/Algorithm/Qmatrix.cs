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

        //Q-Matrix is a string with 5 corresponding action-value pairs. Example: { "beer, beer, beer, beer, empty", "left: 5", "right: 5"
        public Dictionary<PerceptionState, MoveSet> matrix_data;

        //The q-matrix does not store any details about what state the board is in, so it must have a state passed to it.

        public bool did_we_update;

        public Qmatrix()
        {
            //This is our q-matrix
            matrix_data = new Dictionary<PerceptionState, MoveSet>();
            did_we_update = false;          
        }

        public Qmatrix(Qmatrix copy_from)
        {
            //Copy the q-matrix.
            matrix_data = new Dictionary<PerceptionState, MoveSet>();
            foreach(var i in copy_from.matrix_data.Keys)
            {   //For each list of strings in copy_from.matrix data
                //Get a copy of the dictionary at this list of strings
                //Should be a deep copy
                matrix_data.Add(i, new MoveSet(copy_from.matrix_data[i]));
            }
            did_we_update = copy_from.did_we_update;
        }

        //When this is called, the q matrix will update
        public void update_state(PerceptionState percieved_state, Move base_move, float amount_to_update)
        {
            did_we_update = false;
            //check if this state already exists, and add it to our list of states we've encountered, if not.
            if (!matrix_data.ContainsKey(percieved_state))
            {
                did_we_update = true;
                matrix_data.Add(percieved_state, new MoveSet());
            }
                
            matrix_data[percieved_state].move_list[base_move] += amount_to_update;
        }

        public Move generate_step(PerceptionState perceieved_state)
        {
            if(matrix_data.Keys.Contains(perceieved_state))
            {
                //Always generate the step using the state at algorithmManager.current_state            
                Dictionary<Move, float> best_percepts = new Dictionary<Move, float>();

                //Loop through the move-float pair, and do a random selection of any move that is tied for best action.
                foreach (var i in matrix_data[perceieved_state].move_list)
                {
                    if (best_percepts.Count == 0)
                        best_percepts.Add(i.Key, i.Value);
                    else
                    {
                        if (best_percepts.Values.First() < i.Value)
                        {
                            best_percepts = new Dictionary<Move, float>();
                            best_percepts.Add(i.Key, i.Value);
                        }
                    }
                }

                //Temporary while working out the UI. This will not be a simple random equation.
                Move[] moves = best_percepts.Keys.ToArray();
                return moves[MyRandom.Next(0, moves.Count())];
            }

            //No q-matrix entry, so just do a random move. 
            return Move.list[MyRandom.Next(0, Move.list.Count)];
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
    }
}
