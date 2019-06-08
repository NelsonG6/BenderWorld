using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    //This class handles the types of results we get after applying a move to the board.
    class MoveResult
    {
        public string result_data;

        private static readonly MoveResult can_missing_result;
        private static readonly MoveResult can_collected_result;
        private static readonly MoveResult move_successful_result;
        private static readonly MoveResult move_failed_result;
        public static readonly List<MoveResult> list_of_move_results;

        private static MoveResult initialized_result;

        public MoveResult(string to_set)
        {
            result_data = to_set;
        }

        static MoveResult()
        {
            can_missing_result = new MoveResult("Can missing");
            can_collected_result = new MoveResult("Can collected");
            move_successful_result = new MoveResult("Move successful");
            move_failed_result = new MoveResult("Move failed");

            list_of_move_results = new List<MoveResult>();
            list_of_move_results.Add(can_missing_result);
            list_of_move_results.Add(can_collected_result);
            list_of_move_results.Add(move_successful_result);
            list_of_move_results.Add(move_failed_result);

            initialized_result = new MoveResult("Initialized");
        }

        public static MoveResult can_missing()
        {
            return can_missing_result;
        }

        public static MoveResult can_collected()
        {
            return can_collected_result;
        }
        public static MoveResult move_successful()
        {
            return move_successful_result;
        }
        public static MoveResult move_hit_wall()
        {
            return move_failed_result;
        }
        public static MoveResult initialized()
        {
            return initialized_result;
        }
    }
}
