namespace BenderAndURL
{
    //A container class for the status message data posted every move
    class StatusMessage
    {
        public static bool programLaunchMessage;

        string completeMessage;

        string startingData;

        string initialPerceptData;

        string moveBeingAppliedData;
        string moveResultData;
        string rewardData;

        string newPerceptData;
        string newPositionData;
        string qmatrixAdjustmentData;
        string endingData;

        string urlData;

        static public StatusMessage ErasedMessage;

        static StatusMessage()
        {
            programLaunchMessage = false;
            ErasedMessage = new StatusMessage();
            ErasedMessage.completeMessage = "The board has been reset.";           
        }

        public StatusMessage() { }

        public string GetMessage()
        {
            return completeMessage;
        }

        override public string ToString()
        {
            return "Status Message";
        }

        public StatusMessage(AlgorithmState setFrom)
        {

            string newline = System.Environment.NewLine;

            completeMessage = "";
            if (!programLaunchMessage)
            {
                programLaunchMessage = true;
                completeMessage = "The program has been launched.\nBender's starting position is (";
                completeMessage += (setFrom.boardData.GetUnitSquare[UnitType.Bender].x + 1).ToString();
                completeMessage += ", " + (setFrom.boardData.GetUnitSquare[UnitType.Bender].y + 1).ToString() + ").";
            }
            else if (!AlgorithmManager.algorithmStarted)

                completeMessage = "The board was reset. Progress has been erased.";

            //Starting data
            else if (setFrom.GetStepNumber() == 0)
            {
                completeMessage = "A new episode has been created.\n";
                completeMessage += "Starting turn [Episode: " + setFrom.GetEpisodeNumber().ToString();
                completeMessage += ", Step: " + setFrom.GetStepNumber().ToString() + "]";
                completeMessage += " at position (" + (setFrom.boardData.GetUnitSquare[UnitType.Bender].x + 1).ToString();
                completeMessage += ", " + (setFrom.boardData.GetUnitSquare[UnitType.Bender].y + 1).ToString() + ").";

                foreach(var unit in UnitType.List)
                {
                    completeMessage += System.Environment.NewLine + unit.unitName + "'s initial perception is:";
                    completeMessage += System.Environment.NewLine + setFrom.GetPerception(unit).ToString() + ".";
                }
            }
            else
            {
                //"Episode #, Step # beginning."
                startingData = "Starting turn [Episode: " + setFrom.GetEpisodeNumber().ToString() + ", Step: " + setFrom.GetStepNumber().ToString() + "]";
                startingData += " at position (" + (setFrom.locationInitial.x + 1).ToString() + ", " + (setFrom.locationInitial.y + 1).ToString() + ").";

                initialPerceptData = "Bender's initial perception is: " + System.Environment.NewLine;
                initialPerceptData += setFrom.GetPerception(UnitType.Bender).ToString();

                moveBeingAppliedData = "";

                if (setFrom.liveQmatrix.randomlyMoved)
                    moveBeingAppliedData += "A the move was randomly generated." + System.Environment.NewLine;
                else
                    moveBeingAppliedData += "The move was greedily chosen." + System.Environment.NewLine;

                //if (setFrom.movesThisStep.Count == 0)
                //    moveBeingAppliedData += "No move this turn.";
                if (setFrom.GetUnit(UnitType.Bender).GetMoveThisStep() == Move.Grab)
                    moveBeingAppliedData += "A [Grab] was attempted.";
                else
                    moveBeingAppliedData += "A [" + setFrom.GetUnit(UnitType.Bender).GetMoveThisStep().longName + "] was attempted.";

                //moveresult
                if(setFrom.resultThisStep != null)
                moveResultData = "The result of the move was [" + setFrom.resultThisStep.result_data + "].";

                //The reward from this action was: 
                string math_sign = "+";
                if (setFrom.obtainedReward < 0)
                    math_sign = "";
                rewardData = "The reward for this action was: [" + math_sign + setFrom.obtainedReward.ToString() + "]";
                //reward_data + = ", applied to state ";
                //Add bender perception data in his new location here

                //"Bender's position is:
                newPositionData = "The resulting position was (" + (setFrom.boardData.GetUnitSquare[UnitType.Bender].x + 1).ToString();
                newPositionData += ", " + (setFrom.boardData.GetUnitSquare[UnitType.Bender].y + 1).ToString() + ").";

                //New percept

                newPerceptData = "The percept at the new location is: " + System.Environment.NewLine;
                newPerceptData += setFrom.boardData.units[UnitType.Bender].perceptionData.ToString() + ".";

                //"The calculation used on the q matrix was:"

                qmatrixAdjustmentData = "No qmatrix entry was made.";
                if (setFrom.liveQmatrix.didWeUpdate)
                    qmatrixAdjustmentData = "A q-matrix entry was made for this perception.";

                urlData = "Url made a move of " + setFrom.GetUnit(UnitType.Url).GetMoveThisStep().longName + ".";

                if(setFrom.urlRandomlyStopped)
                {
                    urlData += newline + "Url randomly hit his change to stop chasing this turn.";
                }

                if (setFrom.startedChasing)
                    urlData += newline + "Url started chasing Bender.";
                else if (setFrom.boardData.units[UnitType.Url].chasing)
                        urlData += System.Environment.NewLine + "Url is chasing bender.";
                else
                        urlData += System.Environment.NewLine + "Url is wandering randomly.";


                //ending data
                if (setFrom.benderAttacked)
                    endingData += "Bender was attacked this turn, and the board was reset." + newline;
                endingData += "Move [" + setFrom.GetStepNumber().ToString() + "] complete.";

                completeMessage = startingData;
                completeMessage += newline + initialPerceptData;
                completeMessage += newline + moveBeingAppliedData;
                completeMessage += newline + moveResultData;
                completeMessage += newline + rewardData;
                completeMessage += newline + newPositionData;
                completeMessage += newline + newPerceptData;
                completeMessage += newline + urlData;
                completeMessage += newline + qmatrixAdjustmentData;
                completeMessage += newline + endingData;
            }
        }

    }
}
