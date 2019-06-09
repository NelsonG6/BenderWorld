using System;
using System.Collections.Generic;
using System.Linq;

namespace ReinforcementLearning
{
    //a state is a pairing of all possible moves (5) and their percepts
    //This is a state in the sense of, what state is bender in when he perceives his environment
    class PerceptionState : IEquatable<PerceptionState>
    {
        public SortedDictionary<Move, Percept> perception_data;

        public string name_without_id;
        public string name_with_id;

        public int ID;

        //Dumb, but it lets you access the static and persistent perception state
        //By passing in one that you built with equal properties.
        static public Dictionary<PerceptionState, PerceptionState> list_of_states;

        static PerceptionState()
        {
            //Create all 243 possible configurations

            list_of_states = new Dictionary<PerceptionState, PerceptionState>();

            PerceptionState to_build;

            foreach (var i in Percept.get_list())
            {
                foreach (var j in Percept.get_list())
                {
                    foreach (var k in Percept.get_list())
                    {
                        foreach (var l in Percept.get_list())
                        {
                            foreach (var m in Percept.get_list())
                            {
                                to_build = new PerceptionState();
                                to_build.perception_data[Move.left()] = i;
                                to_build.perception_data[Move.right()] = j;
                                to_build.perception_data[Move.down()] = k;
                                to_build.perception_data[Move.up()] = l;
                                to_build.perception_data[Move.grab()] = m;
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

        public PerceptionState()
        {
            perception_data = new SortedDictionary<Move, Percept>();
            foreach(var i in Move.get_moves())
            {
                perception_data.Add(i, Percept.initialized());
            }

            set_name();
        }

        public bool Equals(PerceptionState to_check)
        {
            foreach(var i in perception_data.Keys)
            {
                if (perception_data[i] != to_check.perception_data[i])
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return name_without_id.GetHashCode();
        }

        public bool does_dictionary_match(Dictionary<Move, Percept> to_check)
        {
            foreach(var i in to_check)
            {
                if (i.Value != perception_data[i.Key])
                    return false;
            }
            return true;
        }

        public Percept get_percept(Move perception_cause)
        {
            return perception_data[perception_cause];
        }

        public PerceptionState(PerceptionState copy_from)
        {
            perception_data = new SortedDictionary<Move, Percept>();
            foreach (var i in copy_from.perception_data)
            {
                perception_data.Add(i.Key, i.Value);
            }
        }

        public void set_name()
        {
            string part_one = "[ID: " + ID.ToString() + "]";

            string part_two = "";

            foreach (var i in perception_data.Keys.OrderBy(o => o.order))
            {
                part_two += "[" + i.short_name + ": " + perception_data[i].ToString() + "]";
            }

            name_with_id = part_one + part_two;
            name_without_id = part_two;

        }

        public void set_id(int to_set)
        {
            ID = to_set;
        }

        public override string ToString()
        {
            return name_with_id;
        }

        public int compare(PerceptionState compare_to)
        {
            int compare_total = 0;
            foreach (var i in Move.list)
            {
                if (perception_data[i] == compare_to.perception_data[i])
                    compare_total++;
            }
            return compare_total;
        }

        public bool contains(Move move, Percept percept)
        {
            if (perception_data[move] == percept)
                return true;
            return false;
        }
    }
}
