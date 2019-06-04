using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Dictionary<List<string>, Dictionary<string, float>> matrix_data;

        //Used for building the q matrix.
        Dictionary<String, float> dictionary_to_insert;

        //This stores what moves are possible.
        List<string> moves;

        //Punishments will be an associated string that returns an integer value.
        public Dictionary<string, int> reinforcement_factors;

        public Qmatrix()
        {
            moves = new List<string>();
            moves.Add("Left");
            moves.Add("Right");
            moves.Add("Up");
            moves.Add("Down");
            moves.Add("Grab");

            //This is our q-matrix
            matrix_data = new Dictionary<List<string>, Dictionary<string, float>>();

            //Build our dictionary that has our 5 moves in it
            dictionary_to_insert = new Dictionary<string, float>();
            foreach(var i in moves)
            {
                dictionary_to_insert.Add(i, 0F);
            }

        }

        public Qmatrix(Qmatrix copy_from)
        {
            moves = new List<string>();
            moves.Add("Left");
            moves.Add("Right");
            moves.Add("Up");
            moves.Add("Down");
            moves.Add("Grab");

            Dictionary<string, float> dictionary_to_insert;

            //Copy the q-matrix.
            matrix_data = new Dictionary<List<string>, Dictionary<string, float>>();
            foreach(var i in copy_from.matrix_data.Keys)
            {   //For each list of strings in copy_from.matrix data
                //Get a copy of the dictionary at this list of strings
                //Should be a deep copy
                dictionary_to_insert = copy_from.matrix_data[i].ToDictionary(entry => entry.Key, entry => entry.Value);

                matrix_data.Add(i, dictionary_to_insert);
            }

            //Build our dictionary that has our 5 moves in it
            dictionary_to_insert = new Dictionary<string, float>();
            foreach (var i in moves)
            {
                dictionary_to_insert.Add(i, 0F);
            }

        }

        public void update_state(List<string> percieved_state, string action, float add_to_state)
        {
            //check if this state already exists, and add it to our list of states we've encountered, if not.
            if(!matrix_data.ContainsKey(percieved_state))
                matrix_data.Add(percieved_state, dictionary_to_insert.ToDictionary(  entry => entry.Key,
                                                                                     entry => (float)entry.Value));
            //The above line makes a copy of the dictionary that stores 5 action-float pairs.    
            
            matrix_data[percieved_state][action] += add_to_state;

        }

        public string generate_step(AlgorithmState current_state)
        {
            //Temporary while working out the UI. This will not be a simple random equation.
            return moves[MyRandom.Next(0, 5)];
        }

    }
}
