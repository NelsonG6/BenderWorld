using System;
using System.Collections.Generic;
using System.Linq;
namespace ReinforcementLearning
{
    //This handles the reference point for all fields in the program that are defaults
    static class InitialSettings
    {
        //Q-matrix
        private readonly static double n_data; //learning rate
        private readonly static double y_data; //discount
        private readonly static double e_data; //random factor

        private readonly static int episode_limit_data;
        private readonly static int step_limit_data;

        private readonly static int ms_delay_data;

        private static readonly int x_offset_data;
        private static readonly int y_offset_data;
        private static readonly int edge_length_data;
        private static readonly int rounding_digit_data;

        static InitialSettings()
        {
            n_data = .1F; //Epsilon; do we explore or exploit. Random factor for taking a best move or random move.
            y_data = .9F; //Gamma; our discounted rate.
            e_data = .2F; //The learning rate

            //Default limit
            episode_limit_data = 5000;
            step_limit_data = 200;

            //reinforcement factors
            ms_delay_data = 5;

            x_offset_data = 50;
            y_offset_data = 55;
            edge_length_data = 75;
            rounding_digit_data = 5;
        }

        static public int x_offset()
        {
            return x_offset_data;
        }

        static public int y_offset()
        {
            return y_offset_data;
        }

        static public int edge_length()
        {
            return edge_length_data;
        }

        static public double ms_delay()
        {
            return ms_delay_data;
        }

        static public double n()
        {
            return n_data;
        }

        static public double y()
        {
            return y_data;
        }

        static public double e()
        {
            return e_data;
        }

        static public int episode_limit()
        {
            return episode_limit_data;
        }

        static public int step_limit()
        {
            return step_limit_data;
        }

        static public int rounding_digits()
        {
            return rounding_digit_data;
        }
    }

}
