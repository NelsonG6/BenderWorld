using System.Collections.Generic;

namespace BenderAndURL
{

    //This class represents units on the board that can take actions.
    //This is used for individual instances of the units, for tracking in history and debugging
    class UnitBase
    {
        public PerceptionState perceptionData; //Store the percepts for this unit

        public SquareBoardGame currentLocation;
        public SquareBoardGame previousLocation;

        public bool chasing; //for url

        public string unitName;

        public UnitType enemy;

        public int ID; //Used to keep track in debugging

        public PerceptionState startingPerceptionState; //for the status message
        public Move moveThisStep;

        public UnitBase(UnitBase setFrom)
        {            
            unitName = setFrom.unitName;
            perceptionData = setFrom.perceptionData;
            currentLocation = setFrom.currentLocation;
            previousLocation = setFrom.previousLocation;

            enemy = setFrom.enemy;
            ID = setFrom.ID++;
            chasing = setFrom.chasing;

            //Whenever you copy a unit, you know the starting state is the copied unit's most recent perception
            startingPerceptionState = setFrom.perceptionData;

        }

        public UnitBase()
        {

        }

        public PerceptionState GetPerceptionState()
        {
            return perceptionData;
        }

        public Percept GetPercept(Move directionToCheck)
        {
            return perceptionData.GetPercept(directionToCheck);
        }

        override public string ToString()
        {
            return unitName;
        }

        public Move GetMoveThisStep()
        {
            return moveThisStep;
        }

        public void SetMoveThisStep(Move toSet)
        {
            moveThisStep = toSet;
        }

        public PerceptionState GetStartingPerceptionState()
        {
            return startingPerceptionState;
        }
    }
}
