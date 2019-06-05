using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    //This class is useful for simplifying the q-matrix
    //This class will manage the list of 5 q moves that are associated with each state in the q-matrix.
    //Each Row of the q matrix has one of these items, so there will be 243 total.
    class MoveSet
    {
        //5 moves with q-matrix float values associated for each one
        public Dictionary<Move, float> move_list;

        public MoveSet()
        {
            move_list = new Dictionary<Move, float>();

            //Build a dictionary with 5 moves, by default
            foreach(var i in MoveList.get_moves())
            {
                move_list.Add(i, 0f);
            }
        }

        public MoveSet(MoveSet set_from)
        {
            move_list = new Dictionary<Move, float>();
            foreach (var i in set_from.move_list)
            {
                move_list.Add(i.Key, i.Value);
            }
        }

        /*
        public MoveSet(Move set_from, float value_to_adjust)
        {
            move_list = new Dictionary<Move, float>();

            move_list = new Dictionary<Move, float>();
            foreach (var i in MoveList.get_moves())
            {
                move_list.Add(i, 0f);
                if (set_from == i)
                    move_list[i] = +value_to_adjust;
            }
        }
        */
    }
}
