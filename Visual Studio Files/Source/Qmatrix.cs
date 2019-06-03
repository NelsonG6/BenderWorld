using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    class Qmatrix
    {   
        //Q-Matrix is a string with 5 corresponding action-value pairs. Example: { "beer, beer, beer, beer, empty", "left: 5", "right: 5"
        Dictionary<List<String>, Dictionary<String, float>> matrix_data;

        //Our robot can make 5 percepts. Each percept has 3 possible results.
        //3 ^ 5 = 243, so there are 243 possible states to correlate our q matrix to.
        //We need to assemble each combination.
        //Our three states are represented by strings:
        //"Wall", "Can", "Empty"

        //This stores what moves are possible.
        List<string> moves;

        //Used for building the q matrix.
        Dictionary<String, float> dictionary_to_insert;

        Random random;

        public AlgorithmState current_state;

        //Punishments will be an associated string that returns an integer value.
        public Dictionary<string, int> reinforcement_factors;

        public Qmatrix(Random set_random)
        {
            moves = new List<string>();
            moves.Add("Left");
            moves.Add("Right");
            moves.Add("Up");
            moves.Add("Down");
            moves.Add("Grab");

            current_state = new AlgorithmState("default");
            random = set_random;
            matrix_data = new Dictionary<List<String>, Dictionary<String, float>>();

            dictionary_to_insert = new Dictionary<string, float>();
            foreach(var i in moves)
            {
                dictionary_to_insert.Add(i, 0F);
            }

            reinforcement_factors = new Dictionary<string, int>();
            reinforcement_factors.Add("Wall", -5);
            reinforcement_factors.Add("Beer", 10);
            reinforcement_factors.Add("Empty", -1);

        }

        public void update_state(List<string> percieved_state, string action, float add_to_state)
        {
            //check if this state already exists, and add it to our list of states we've encountered, if not.
            if(!matrix_data.ContainsKey(percieved_state))
                matrix_data.Add(percieved_state, dictionary_to_insert.ToDictionary(  entry => entry.Key,
                                                                                     entry => (float)entry.Value));

            matrix_data[percieved_state][action] += add_to_state;

        }

        public string generate_step()
        {
            //Temporary while working out the UI. This will not be a simple random equation.
            return moves[random.Next(0, 5)];
        }

    }
}
