using System.Collections.Generic;

namespace ReinforcementLearning
{
    //This class is useful for simplifying the q-matrix
    //This class will manage the list of 5 q moves that are associated with each state in the q-matrix.
    //A valueset is a row of the q matrix.
    class ValueSet
    {
        //5 moves with q-matrix double values associated for each one
        public Dictionary<Move, double> move_list;

        public ValueSet()
        {
            move_list = new Dictionary<Move, double>();

            //Build a dictionary with 5 moves, by default
            foreach(var i in Move.get_moves())
            {
                move_list.Add(i, 0f);
            }
        }

        public ValueSet(ValueSet set_from)
        {
            move_list = new Dictionary<Move, double>();
            foreach (var i in set_from.move_list)
            {
                move_list.Add(i.Key, i.Value);
            }
        }

        public double GetBestValue()
        {
            double to_return = 0;
            foreach (var i in move_list.Values)
            {
                if (i > to_return)
                    to_return = i;
            }
            return to_return;
        }

        public double this[Move key]
        {
            get
            {
                return GetValue(key);
            }
            set
            {
                SetValue(key, value);
            }

        }

        public double GetValue(Move index)
        {
            return move_list[index];
        }

        public void SetValue(Move index, double value)
        {
            move_list[index] = value;
        }
    }
}
