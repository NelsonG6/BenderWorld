using System.Collections.Generic;
using System.Linq;

namespace ReinforcementLearning
{
    class AlgorithmState
    {
        //Static members
        
        //Commenting this so i can just use a function that points to the most recent state
        //static public AlgorithmState current_state; //This is a pointer to the most recently generated state

        static public List<AlgorithmEpisode> state_history; //This is the history of the entire run, and all the configurations and q-matrix instances.
                                                            //The head of this list is the current progress point of our algorithm.

        static public bool algorithm_started; //Used for the status message
        static public bool algorithm_ended;

        public static int step_limit;
        public static int episode_limit;

        //Non-static members
        public GameBoard board_data; //Stores the state of the cans and walls (bender is stored with other coordinates)

        public Qmatrix live_qmatrix; //Moves will be generated from here.

        public PerceptionState bender_perception_starting;
        public PerceptionState bender_perception_ending;

        public int episode_count; //current progess
        public int step_count;

        public float episode_rewards; //Session - Reward data
        public float total_rewards;

        public int[] location_initial; //Just used for the status message
        public int[] location_result;

        public Move move_this_step; //The move we took this step, stored for the status message
        public MoveResult result_this_step; //Moveresult stored for status

        public float obtained_reward; //The raw reward for the action we took

        public int cans_collected;

        //Static functions
        static AlgorithmState()
        {
            SetDefaultConfiguration();
            step_limit = 200;
            episode_limit = 5000;
        }

        //This should be called at the program launch, and when the reset config button is pressed
        public static void SetDefaultConfiguration()
        {
            state_history = new List<AlgorithmEpisode>(); //initialize history
            state_history.Add(new AlgorithmEpisode(1)); //Create the first episode. The current state is retieved from the most recent point. 

            algorithm_ended = false;
            algorithm_started = false;
        }

        public static AlgorithmState GetCurrentState()
        {
            int episode_index = state_history.Count - 1;
            if (episode_index == -1)
            {
                return null; //No episodes created
            }
            else
            {
                int step_index = state_history[episode_index].Count() - 1;
                if (step_index == -1)
                    return null; //Step index shouldn't be 0, because we shouldn't call this at a time when we created a new episode but didn't put a state there.
                else
                    return state_history[episode_index][step_index];
            }
        }

        //Called at algorithm start, and on reset
        public static void StartAlgorithm()
        {
            algorithm_started = true;
            AddToHistory(FormsHandler.loaded_state); //Copy our state from forms handler
            GetCurrentState().StartNewEpisode();
        }

        //Manages the state history, and making sure the correct state is being created/stored
        public static void PrepareStep(int steps_to_take) //Go to the most current state, and step forward once. 
        {   //If the algorithm hasn't started, this will just start the algorithm and leave us at step 0.
            while (steps_to_take-- > 0 && !algorithm_ended)
            {
                //use start new episode if this is the first step
                //step and add, or dont step and dont add
                AlgorithmState step_with = new AlgorithmState(GetCurrentState());

                if (step_with.step_count > step_limit)
                    state_history.Add(new AlgorithmEpisode(state_history.Count + 1)); //Add the first empty episode
                else
                    step_with.TakeStep();
                state_history.Last().Add(step_with); //Add the state to the history list, after everything possible has been done to it.    
            }
        }

        //Gets the qmatrix view for the give move at bender's current position
        static public string GetQmatrixView(Move move_to_get)
        {
            ValueSet to_get = GetCurrentQmatrix().matrix_data[GetCurrentState().board_data.bender.get_perception_state()];
            return to_get.move_list[move_to_get].ToString();
        }

        public void EraseBoardForReset()
        {   //Used ONLY with the restart algorithm button. Keeps a few old things, like bender's position and settings
            algorithm_started = false; //Algorithm no longer running
            InitializeValues();
            state_history = new List<AlgorithmEpisode>();
            state_history.Add(new AlgorithmEpisode(1));

            step_limit = 200;
            episode_limit = 5000;
        }

        //Non-static functions
        //Default config algorithm state
        //This is called when the program is launched.
        public AlgorithmState()
        {
            board_data = new GameBoard(); //Produces a shuffled bender and can-filled board 

            InitializeValues(); //Gives us some empty defaults

            //Set initial data

        }

        //Called from create_empty_board (after reset), and the constructor
        //Just a useful container for resetting some values when we want to start over, but making a new state would have us lose bender's position.
        private void InitializeValues()
        {
            board_data.ClearCans(); //Clear the board for our initial launch(this doesn't remove bender, just cans)
            episode_count = 0;
            live_qmatrix = new Qmatrix();



            location_initial = new int[2] { 0, 0 };
            location_result = new int[2] { 0, 0 };
        }

        //Copied from another algorithm state
        //We reset some data, so we dont reflect values that aren't true for the new state
        //This constructor is called when a new step is being generated, so we transfer some values appropriately.
        public AlgorithmState(AlgorithmState set_from)
        {
            cans_collected = set_from.cans_collected;

            episode_rewards = set_from.episode_rewards; //Reward data
            total_rewards = set_from.total_rewards;

            board_data = new GameBoard(set_from.board_data); //Copy the board

            episode_count = set_from.episode_count;
            
            
            live_qmatrix = new Qmatrix(set_from.live_qmatrix); //Copy the q matrix

            //The initial location will be the resulting location of the last step
            location_initial = new int[2] { set_from.location_result[0], set_from.location_result[1] };

            bender_perception_starting = set_from.bender_perception_ending;

            //Detect if we reached the limit for this episode
            step_count = set_from.step_count;

            if (step_count == step_limit)
                StartNewEpisode();
            else
                ++step_count;
        }

        public Percept GetBenderPercept(Move direction_to_check)
        {
            return board_data.bender.get_percept(direction_to_check);
        }

        //Used to erase session-based progress.
        //This is also called each new episode once we reach the max steps
        //Not called when the program launches
        public void StartNewEpisode()
        {
            ++episode_count;
            step_count = 0;
            cans_collected = 0;
            episode_rewards = 0; //Session - Reward data

            board_data.shuffle_cans_and_bender(); //Shuffle the the current board.

            board_data.bender_percieves();

            location_result = new int[2] { board_data.bender.x_coordinate, board_data.bender.y_coordinate };

            bender_perception_starting = board_data.bender.get_perception_state();
            bender_perception_ending = board_data.bender.get_perception_state();
        }

        //At the algorithm manager, generate step is ambiguous with actually stepping through the algorithm,
        //Or starting the algorithm, and making the first history entry at step 0.
        //Here, a step only happens when we have been asked by the manager to *actually* take a step.
        public void TakeStep()
        {   
            //Get step from qmatrix. Being randomly generated for now.
            move_this_step = live_qmatrix.generate_step(board_data.bender.get_perception_state()); //Tentative; we'll attempt this later. just a random move for now.
            result_this_step = board_data.ApplyMove(move_this_step); //The move should be performed now, if possible.
            obtained_reward = ReinforcementFactors.list[result_this_step]; //Get the reward for this action

            episode_rewards += obtained_reward; //Update the rewards total

            if (result_this_step == MoveResult.can_collected())
                ++cans_collected;

            if (obtained_reward != 0)
                live_qmatrix.update_state(bender_perception_starting, move_this_step, obtained_reward); //give the value to the q matrix to digest

            location_result = new int[2] { board_data.bender.x_coordinate, board_data.bender.y_coordinate };
            bender_perception_ending = board_data.bender.get_perception_state();

            if (step_count == step_limit && episode_count > episode_limit)
                algorithm_ended = true;
        }

        override public string ToString()
        {
            return "[Episode: " + episode_count.ToString() + "][Step: " + step_count + "]";
        }

        public static Qmatrix GetCurrentQmatrix()
        {
            return GetCurrentState().live_qmatrix;
        }

        public static GameBoard GetCurrentBoard()
        {
            return GetCurrentState().board_data;
        }

        //Add a state
        public static void AddToHistory(AlgorithmState to_add)
        {
            state_history.Last().Add(to_add);
        }
        
    } 
}
