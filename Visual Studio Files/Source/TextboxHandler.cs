using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReinforcementLearning
{
    class TextboxHandler
    {
        public TextBox number_of_episodes;
        public TextBox number_of_steps;
        public TextBox n_textbox;
        public TextBox y_textbox;
        public TextBox e_textbox;
        public TextBox current_position_left;
        public TextBox current_position_down;
        public TextBox current_position_right;
        public TextBox current_position_up;
        public TextBox current_position_square;
        public TextBox current_position_encoding;
        public TextBox empty_square_punishment_textbox;
        public TextBox wall_punishment_textbox;
        public TextBox beer_reward_textbox;
        public RichTextBox status_box;
        public TextBox qmatrix_left;
        public TextBox qmatrix_right;
        public TextBox qmatrix_down;
        public TextBox qmatrix_up;
        public TextBox qmatrix_current_square;
        public TextBox beer_collected;
        public TextBox beer_remaining;
        public TextBox reward_episode;
        public TextBox reward_total;

        public TextboxHandler()
        {
            //Pass textboxes to the board, so it can manage them.
            number_of_episodes = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxNumberofepisodes"] as TextBox;
            number_of_steps = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxNumberofsteps"] as TextBox;
            n_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxNinitial"] as TextBox; 
            y_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxY"] as TextBox; 
            e_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxEpsilon"] as TextBox;
            wall_punishment_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxWallpunishment"] as TextBox;
            empty_square_punishment_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxEmptysquare"] as TextBox;
            beer_reward_textbox = Application.OpenForms["Form1"].Controls["groupboxInitialsettings"].Controls["textboxBeerreward"] as TextBox;

            

            current_position_left = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxLeft"] as TextBox;
            current_position_right = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxRight"] as TextBox; 
            current_position_up = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxUp"] as TextBox;
            current_position_down = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxDown"] as TextBox;
            current_position_square = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxCurrentsquare"] as TextBox;
            current_position_encoding = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCurrentposition"].Controls["textboxEncodedas"] as TextBox;

            qmatrix_left = Application.OpenForms["Form1"].Controls["groupboxQmatrix"].Controls["textboxQmatrixleft"] as TextBox;
            qmatrix_right = Application.OpenForms["Form1"].Controls["groupboxQmatrix"].Controls["textboxQmatrixright"] as TextBox;
            qmatrix_down = Application.OpenForms["Form1"].Controls["groupboxQmatrix"].Controls["textboxQmatrixdown"] as TextBox;
            qmatrix_up = Application.OpenForms["Form1"].Controls["groupboxQmatrix"].Controls["textboxQmatrixup"] as TextBox;
            qmatrix_current_square = Application.OpenForms["Form1"].Controls["groupboxQmatrix"].Controls["textboxQmatrixcurrent"] as TextBox;

            status_box = Application.OpenForms["Form1"].Controls["groupboxStatusmessage"].Controls["textboxStatus"] as RichTextBox;

            beer_collected = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCans"].Controls["textboxCansremaining"] as TextBox;
            beer_remaining = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxCans"].Controls["textboxCanscollected"] as TextBox;
            reward_episode = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxRewarddata"].Controls["textboxRewardepisode"] as TextBox;
            reward_total = Application.OpenForms["Form1"].Controls["groupboxSessionprogress"].Controls["groupboxRewarddata"].Controls["textboxRewardtotal"] as TextBox;
        }

        //current position textboxes
        public void update_all_position_info(Board display_from)
        {
            current_position_left.Text = display_from.detect_percept(-1, 0);
            current_position_down.Text = display_from.detect_percept(0, -1);
            current_position_right.Text = display_from.detect_percept(1, 0);
            current_position_up.Text = display_from.detect_percept(0, 1);
            current_position_square.Text = display_from.detect_percept(0, 0);
            current_position_encoding.Text = display_from.get_encoding_of_percepts();
        }

        //Used after reset is pressed. Not used during algorithm run.
        public void clear_after_board_reset(Board to_clear)
        {
            //Clear the current position textboxes
            current_position_down.Clear();
            current_position_left.Clear();
            current_position_right.Clear();
            current_position_up.Clear();
            current_position_square.Clear();
            current_position_encoding.Clear();

            status_box.Text = "Board cleared.";
        }

        //Populate data in the initial settings groupbox
        //This function is only used once, when the program is launched.
        public void load_initial_settings(AlgorithmManager to_load)
        {
            number_of_episodes.Text = to_load.live_qmatrix.current_state.episode_limit.ToString();
            number_of_steps.Text = to_load.live_qmatrix.current_state.step_limit.ToString();
            n_textbox.Text = to_load.live_qmatrix.current_state.n.ToString();
            y_textbox.Text = to_load.live_qmatrix.current_state.y.ToString();
            e_textbox.Text = to_load.live_qmatrix.current_state.e.ToString();
            empty_square_punishment_textbox.Text = to_load.live_qmatrix.reinforcement_factors["Empty"].ToString();
            wall_punishment_textbox.Text = to_load.live_qmatrix.reinforcement_factors["Wall"].ToString();
            beer_reward_textbox.Text = to_load.live_qmatrix.reinforcement_factors["Beer"].ToString();
        }

        //This is ran every time we step through the algorithm.
        public void handle_step(AlgorithmManager current_algorithm)
        {
            string bender_position = current_algorithm.main_board.bender_x.ToString() + ", " + current_algorithm.main_board.bender_y.ToString();
            status_box.Text = "Algorithm has started." + Environment.NewLine + "Bender's position is (" + bender_position + ").";
            update_all_position_info(current_algorithm.main_board);
        }
    }
}
