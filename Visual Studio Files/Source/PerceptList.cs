using System.Collections.Generic;

namespace ReinforcementLearning
{
    static class PerceptList
    {
        private static readonly Percept wall_percept;
        private static readonly Percept empty_percept;
        private static readonly Percept can_percept;
        private static readonly Percept initialized_percept;

        private readonly static List<Percept> list; //for counting

        static PerceptList()
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
