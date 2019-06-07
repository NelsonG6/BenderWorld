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
        //A perception state is essentially a dictionary of moves mapped to percept
        //So we can map dictionaries to perception states, which makes it easier to retrieve from the comboboxes later

        //This takes in new perception states, and returns one from the static list, to help with equality and tracking.
        static public Dictionary<PerceptionState, PerceptionState> list_of_states;

        static PerceptionStateList()
        {
            //Create all 243 possible configurations

            list_of_states = new Dictionary<PerceptionState, PerceptionState>();

            PerceptionState to_build;

            foreach (var i in PerceptList.get_list())
            {
                foreach (var j in PerceptList.get_list())
                {
                    foreach(var k in PerceptList.get_list())
                    {
                        foreach(var l in PerceptList.get_list())
                        {                            
                            foreach(var m in PerceptList.get_list())
                            {
                                to_build = new PerceptionState();
                                to_build.perception_data[MoveList.left()] = i;
                                to_build.perception_data[MoveList.right()] = j;
                                to_build.perception_data[MoveList.down()] = k;
                                to_build.perception_data[MoveList.up()] = l;
                                to_build.perception_data[MoveList.grab()] = m;
                                to_build.set_id(list_of_states.Count);
                                to_build.set_name();

                                list_of_states.Add(to_build, to_build);
                                //list_of_states[to_build] = to_build;
                                //Add the perception state to our dictionary at a location reachable if we can build a similar dictionary.
                            }
                        }
                    }
                }
            }
        }

        static public PerceptionState GetPerceptionFromList(PerceptionState to_find)
        {
            return list_of_states[to_find];
        }

        public static Dictionary<PerceptionState, PerceptionState> get_list()
        {
            return list_of_states;
        }

    }
}
