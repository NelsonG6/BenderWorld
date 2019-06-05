using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    //This class stores the possible list of 243 states
    //All states that exist in the q-matrix will be a reference to this list
    static class PerceptionStateList
    {
        static public HashSet<PerceptionState> list_of_states; //hashset for unique elements

        static PerceptionStateList()
        {
            list_of_states = new HashSet<PerceptionState>();

            //Create all 243 possible configurations
            PerceptionState temp_1;
            PerceptionState temp_2;
            PerceptionState temp_3;
            PerceptionState temp_4;
            PerceptionState temp_5;

            int count = PerceptList.get_list().Count();

            //Should give me 243 unique states, check in debug
            for (int i = 0; i < count; i++)
            {
                temp_1 = new PerceptionState();
                temp_1.perceptions[MoveList.left()] = PerceptList.get_list()[i];
                for (int j = 0; j < count; j++)
                {
                    temp_2 = new PerceptionState(temp_1); //Make a new copy, but keep our progress
                    temp_2.perceptions[MoveList.right()] = PerceptList.get_list()[j];
                    for (int k = 0; k < count; k++)
                    {
                        temp_3 = new PerceptionState(temp_2); //Make a new copy, but keep our progress
                        temp_3.perceptions[MoveList.up()] = PerceptList.get_list()[k];
                        for (int l = 0; l < count; l++)
                        {
                            temp_4 = new PerceptionState(temp_3); //Make a new copy, but keep our progress
                            temp_4.perceptions[MoveList.down()] = PerceptList.get_list()[l];
                            for (int m = 0; m < count; m++)
                            {
                                temp_5 = new PerceptionState(temp_4); //Make a new copy, but keep our progress
                                temp_5.perceptions[MoveList.grab()] = PerceptList.get_list()[m];
                                list_of_states.Add(temp_5);
                            }
                        }

                    }
                }
            }
        }

        public static HashSet<PerceptionState> get_list()
        {
            return list_of_states;
        }
    }
}
