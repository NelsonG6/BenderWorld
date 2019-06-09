using System.Collections.Generic;

namespace ReinforcementLearning
{
    //This class is useful for simplifying the q-matrix
    //This class will manage the list of 5 q moves that are associated with each state in the q-matrix.
    //A valueset is a row of the q matrix.
    class ValueSet
    {
        //5 moves with q-matrix float values associated for each one
        public Dictionary<Move, float> move_list;

        public ValueSet()
        {
            move_list = new Dictionary<Move, float>();

            //Build a dictionary with 5 moves, by default
            foreach(var i in Move.get_moves())
            {
                move_list.Add(i, 0f);
            }
        }

        public ValueSet(ValueSet set_from)
        {
            move_list = new Dictionary<Move, float>();
            foreach (var i in set_from.move_list)
            {
                move_list.Add(i.Key, i.Value);
            }
        }

    }
}
