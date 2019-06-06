using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    //a state is a pairing of all possible moves (5) and their percepts
    //This is a state in the sense of, what state is bender in when he perceives his environment
    class PerceptionState
    {
        public Dictionary<Move, Percept> perceptions;

        public PerceptionState()
        {
            perceptions = new Dictionary<Move, Percept>();
            foreach(var i in MoveList.get_moves())
            {
                perceptions.Add(i, PerceptList.initialized());
            }
        }

        public Percept get_percept(Move perception_cause)
        {
            return perceptions[perception_cause];
        }

        public PerceptionState(PerceptionState copy_from)
        {
            perceptions = new Dictionary<Move, Percept>();
            foreach (var i in copy_from.perceptions)
            {
                perceptions.Add(i.Key, i.Value);
            }
        }

        public string get_string()
        {
            string building = "";
            foreach (var i in perceptions)
            {
                building += ("[" + i.Key.short_name) + ": " + i.Value.get_string_data() + "]";
            }
            return building;
        }
    }
}
