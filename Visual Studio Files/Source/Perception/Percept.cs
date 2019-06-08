using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    //This class is just a wrapper for one of three possible strings, but it helps enforce the type.
    class Percept
    {
        public string percept_data;

        private static readonly Percept wall_percept;
        private static readonly Percept empty_percept;
        private static readonly Percept can_percept;
        private static readonly Percept initialized_percept;

        private readonly static List<Percept> list; //for counting

        //This might not be necessary

        static Percept()
        {
            wall_percept = new Percept("Wall");
            empty_percept = new Percept("Empty");
            can_percept = new Percept("Can");

            list = new List<Percept>();
            list.Add(wall_percept);
            list.Add(empty_percept);
            list.Add(can_percept);

            initialized_percept = new Percept("initialized");
        }

        public Percept()
        {
            percept_data = "empty";
            //deleted the move the percept was storing
        }

        public Percept(string to_set)
        {
            percept_data = to_set;
        }

        override public string ToString()
        {
            return percept_data;
        }

        public static List<Percept> get_list()
        {
            return list;
        }

        public static Percept wall()
        {
            return wall_percept;
        }

        public static Percept can()
        {
            return can_percept;
        }

        public static Percept empty()
        {
            return empty_percept;
        }

        public static Percept initialized()
        {
            return initialized_percept;
        }

        public static int get_list_count()
        {
            return list.Count;
        }
    }
}
