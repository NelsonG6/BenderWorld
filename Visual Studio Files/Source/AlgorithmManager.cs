using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    class AlgorithmManager
    {
        private Random random;
        public Qmatrix live_qmatrix;
        public TextboxHandler textboxes;
        public Board main_board;

        public List<List<AlgorithmState>> state_history;

        public AlgorithmManager()
        {
            random = new Random();
            main_board = new Board(random); //Create our grid
            live_qmatrix = new Qmatrix(random);
            textboxes = new TextboxHandler();
            textboxes.clear_after_board_reset(main_board); //Will give us the default empty board
            textboxes.load_initial_settings(this);
            state_history = new List<List<AlgorithmState>>();
        }

        public void restartAlgorithm()
        {
            state_history.Clear();
            textboxes.clear_after_board_reset(main_board);
            main_board.clear();    
        }

        public void take_step()
        {
            //figure out which action to take

            //Lets randomly generate it for now
            string step_to_take = live_qmatrix.generate_step();
            main_board.shuffle_cans_and_bender();

            textboxes.handle_step(this);

        }

        //This handles when we are resetting our episode data.
        public void start_episode()
        {

        }
    }
}
