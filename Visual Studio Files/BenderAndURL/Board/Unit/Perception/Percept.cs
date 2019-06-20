using System.Collections.Generic;

namespace BenderAndURL
{
    //This class is just a wrapper for one of three possible strings, but it helps enforce the type.
    class Percept
    {
        public string perceptData;

        public static readonly Percept Wall;
        public static readonly Percept Empty;
        public static readonly Percept Can;
        public static readonly Percept Initialized; //Just for debugging mostly
        public static readonly Percept Enemy;

        private readonly static List<Percept> list; //for counting

        //This might not be necessary

        static Percept()
        {
            Wall = new Percept("Wall");
            Empty = new Percept("Empty");
            Can = new Percept("Can");
            Enemy = new Percept("Enemy");

            list = new List<Percept>();
            list.Add(Wall);
            list.Add(Empty);
            list.Add(Can);
            list.Add(Enemy);
            Initialized = new Percept("initialized");
        }

        public Percept()
        {
            perceptData = "empty";
            //deleted the move the percept was storing
        }

        public Percept(string to_set)
        {
            perceptData = to_set;
        }

        override public string ToString()
        {
            return perceptData;
        }

        public static List<Percept> GetList()
        {
            return list;
        }

        public static int GetListCount()
        {
            return list.Count;
        }
    }
}
