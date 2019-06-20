using System;
using System.Collections.Generic;
using System.Linq;

namespace BenderAndURL
{
    class Qmatrix
    {
        //Our robot can make 5 percepts. Each percept has 3 possible results.
        //3 ^ 5 = 243, so there are 243 possible states to correlate our q matrix to.
        //We need to assemble each combination.
        //Our three states are represented by strings:
        //"Wall", "Can", "Empty"

        //Perception state is a string with 5 corresponding action-value pairs. Example: { "beer, beer, beer, beer, empty", "left: 5", "right: 5"
        //Moveset is a dictionary of moves to doubles
        public Dictionary<PerceptionState, ValueSet> matrixData;

        //The q-matrix does not store any details about what state the board is in, so it must have a state passed to it.
        static double Ybase;
        static double EBase;

        public double n; //eta doesn't really need a non-static variable, but it might change in the future
        public double y; //discount
        public double e; //epsilon

        static public int stepLimit;  //limits
        static public int episodeLimit;

        public int episodeNumber; //keeping track of which episode this is, and which step
        public int setNumber;

        public bool didWeUpdate;
        public bool randomlyMoved;


        
        
        public Qmatrix()
        {
            //This is our q-matrix
            matrixData = new Dictionary<PerceptionState, ValueSet>();
            didWeUpdate = false;

            e = InitialSettings.e; //Epsilon; do we explore or exploit. Random factor for taking a best move or random move.
            y = InitialSettings.y; //Gamma; our discounted rate.
            n = InitialSettings.n; //The learning rate
            Ybase = InitialSettings.y;

            stepLimit = InitialSettings.StepLimit;  //limits
            episodeLimit = InitialSettings.EpisodeLimit;

        }

        static Qmatrix()
        {
            //Default limit
            EBase = InitialSettings.e;
            episodeLimit = InitialSettings.EpisodeLimit;
            stepLimit = InitialSettings.StepLimit;
        }
        
        public Qmatrix(Qmatrix copyFrom)
        {
            //Copy the q-matrix.
            matrixData = new Dictionary<PerceptionState, ValueSet>();
            foreach(var i in copyFrom.matrixData.Keys)
            {   //For each list of strings in copy from.matrix data
                //Get a copy of the dictionary at this list of strings
                //Should be a deep copy
                matrixData.Add(i, new ValueSet(copyFrom.matrixData[i]));
            }
            didWeUpdate = copyFrom.didWeUpdate;
            setNumber = copyFrom.setNumber;
            episodeNumber = copyFrom.episodeNumber;
            n = copyFrom.n;
            y = copyFrom.y;
            e = copyFrom.e;
        }

        //Determine what the next move to make will be.
        public Move GenerateStep(PerceptionState perceievedState)
        {
            if (matrixData.Keys.Contains(perceievedState))
            {
                //Always generate the step using the state at algorithmManager.GetCurrentState()
                Dictionary<Move, double> bestPercepts = new Dictionary<Move, double>();

                
                //Determine if we will be making a greedy best selection, or a random selection.
                //e will be a double, possibly very small, but not more than 1.
                if (MyRandom.Next(1, 101) < e * 100)
                {
                    randomlyMoved = true;
                    //Random move. 
                    return Move.HorizontalMovesAndGrab[MyRandom.Next(0, 5)];
                }
                else
                {
                    //Greedy selection, then random among best matches.
                    //Loop through the move-double pair, and do a random selection of any move that is tied for best action.
                    foreach (var i in matrixData[perceievedState].moveList)
                    {
                        if (bestPercepts.Count == 0)
                            bestPercepts.Add(i.Key, i.Value);
                        else if (bestPercepts.Values.First() < i.Value)
                        {
                            bestPercepts = new Dictionary<Move, double>();
                            bestPercepts.Add(i.Key, i.Value);
                        }
                        else if (bestPercepts.Values.First() == i.Value)
                            bestPercepts.Add(i.Key, i.Value);
                    }
                }

                Move[] moves = bestPercepts.Keys.ToArray(); //Convert the moves we retained to a list
                return moves[MyRandom.Next(0, moves.Count())]; //return a random member of this list
            }

            //No q-matrix entry, so just do a random move. 
            return Move.HorizontalMovesAndGrab[MyRandom.Next(0, Move.HorizontalMovesAndGrab.Count)];
        }

        //When this is called, the q matrix will update a previous state with the value of the next state
        //Calculate the change here
        public void UpdateState(PerceptionState stateToUpdate, PerceptionState resultState, Move resultMove, double baseReward)
        {
            double oldQmatrixValue = 0;
            //Initial the start of our update value
            if (matrixData.Keys.Contains(stateToUpdate))
                oldQmatrixValue = matrixData[stateToUpdate].GetBestValue(); //Whats our old best qmatrix value at our old state?

            //Whats the best value at the new one?
            double newQmatrixValue = 0;
            if (matrixData.Keys.Contains(resultState))
                newQmatrixValue = matrixData[resultState].GetBestValue();
            double difference = newQmatrixValue - oldQmatrixValue;

            y = (double)Math.Pow(Ybase, setNumber - 1); //y ^ step-1 is the discount factor
            double discountedDifference = difference * y;
            double rewardAdded = discountedDifference + baseReward;
            double finalValue = n * rewardAdded;

            didWeUpdate = false; //Status message grabs this later
                                   //check if this state already exists, and add it to our list of states we've encountered, if not.

            if (finalValue != 0)
            {
                didWeUpdate = true;
                if (!matrixData.Keys.Contains(stateToUpdate))
                    matrixData[stateToUpdate] = new ValueSet();
                matrixData[stateToUpdate][resultMove] = finalValue;
            }
        }



        public List <string> getListOfQmatrixStates()
        {
            List<string> building = new List<string>();
            foreach (var i in matrixData.Keys.OrderBy(o => o.ID))
            {
                building.Add(i.ToString());
            }
            return building;
        }

        //Called when we have a new episode at the state, and we need to update some values here
        public void ProcessNewEpisode()
        {
            setNumber = 0;
            episodeNumber++;

            e -= (EBase / episodeLimit);

        }
    }
}
