using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    class AlgorithmEpisode
    {
        public List<AlgorithmState> state_history_data;

        public int episode_number;

        public AlgorithmEpisode(int set_episode)
        {
            state_history_data = new List<AlgorithmState>();
            episode_number = set_episode;
        }

        override public string ToString()
        {
            return "[Episode #" + episode_number.ToString() + "]";
        }

        //Should allow indexing
        public AlgorithmState this[int i]
        {
            get { return state_history_data[i]; }
            set { state_history_data[i] = value; }
        }

        public int Count()
        {
            return state_history_data.Count;
        }

        public void Add(AlgorithmState to_add)
        {
            state_history_data.Add(to_add);
        }

        public AlgorithmState[] ToArray()
        {
            return state_history_data.ToArray();
        }
    }
}
