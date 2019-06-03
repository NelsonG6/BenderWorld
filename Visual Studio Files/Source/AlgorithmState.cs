using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ReinforcementLearning
{
    class AlgorithmState
    {
        //Session variables
        public int episode_limit;
        public int step_limit;
        //eta
        public float n;
        //discount
        public float y;
        //epsilon
        public float e;

        //Session - Can data
        public int cans_remaining;
        public int cans_collected;

        //Session - Reward data
        public int episode_rewards;
        public int total_rewards;

        //Session - Current position
        public string position_encoding;
        public string left_value;
        public string right_value;
        public string down_value;
        public string up_value;
        public string current_square_value;

        //Status message
        public string status_message;

        public AlgorithmState()
        {
            //Any flag means set default
            episode_limit = 0;
            step_limit = 0;
            n = 0;
            y = 0;
            e = 0;

            //Session variables
            episode_limit = 0;
            step_limit = 0;
            //eta
            n = 0;
            //discount
            y = 0;
            //epsilon
            e = 0;

            //Session - Can data
            cans_remaining = 0;
            cans_collected = 0;

            //Session - Reward data
            episode_rewards = 0;
            total_rewards = 0;
        }

        //Default config algorithm state
        public AlgorithmState(string set_flag)
        {
            //Any flag means set default
            episode_limit = 5000;
            step_limit = 200;
            n = .2F;
            y = .9F;
            e = .1F;

            //Session variables
            episode_limit = 0;
            step_limit = 0;
            //eta
            n = 0;
            //discount
            y = 0;
            //epsilon
            e = 0;

            //Session - Can data
            cans_remaining = 0;
            cans_collected = 0;

            //Session - Reward data
            episode_rewards = 0;
            total_rewards = 0;
        }

        //Copied from another algorithm state

        /*
        public AlgorithmState(AlgorithmState set_from)
        {
            //Any flag means set default
            episode_limit = set_from.episode_limit;
            step_limit = set_from.step_limit;
            n = set_from.n;
            y = set_from.y;
            e = set_from.e;

            //Session variables
            episode_limit = set_from.episode_limit;
            step_limit = set_from.step_limit;
            //eta
            n = set_from.n;
            //discount
            y = set_from.y;
            //epsilon
            e = set_from.e;

            //Session - Can data
            cans_remaining = set_from.cans_remaining;
            cans_collected = set_from.cans_collected;

            //Session - Reward data
            episode_rewards = set_from.episode_rewards;
            total_rewards = set_from.total_rewards;

            //Session - Current position
            string position_encoding;
            string left_value;
            string right_value;
            string down_value;
            string up_value;
            string current_square_value;

            //Status message
            string status_message;
        }
        */

        public AlgorithmState(AlgorithmState set_from)
        {
            AlgorithmState test = new AlgorithmState();
            test = (AlgorithmState)set_from.MemberwiseClone();
            test.n = .213F;
        }
    }
}
