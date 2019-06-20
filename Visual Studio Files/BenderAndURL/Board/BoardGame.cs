using System.Collections.Generic;

namespace BenderAndURL
{
    //Manages a few different classes
    class BoardGame : BoardBase 
    {
        public Dictionary<UnitType, SquareBoardGame> GetUnitSquare;

        //This units on the board
        public Dictionary<UnitType, UnitBase> units;

        public BoardGame() : base()
        {
            //Initialize 10x10 grid
            int x = 0;
            int y = 0;

            //Bender location will be set in shuffle
            units = new Dictionary<UnitType, UnitBase>();
            units.Add(UnitType.Bender, new UnitBase(UnitType.Bender));
            units.Add(UnitType.Url, new UnitBase(UnitType.Url));

            foreach (var i in boardData)
            {
                y = 0;
                while (i.Count < InitialSettings.SizeOfBoard)
                {
                    i.Add(new SquareBoardGame(x, y++));
                }
                x++;
            }

            AddWalls();

            GetUnitSquare = new Dictionary<UnitType, SquareBoardGame>();
            foreach(var i in units)
            {
                GetUnitSquare.Add(i.Key, null); //Initialize the list so its easier to update later
            }

            ShuffleUnits(); //A fresh board not copied will need randomly generated data, except at program launch. We'll clear it in that case.
        }

        //Copy constructor, used each new step
        public BoardGame(BoardGame setFrom) : base()
        {

            //Initialize 10x10 grid
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    boardData[i].Add(new SquareBoardGame((SquareBoardGame)setFrom.boardData[i][j]));
                    if (boardData[i][j].visitedState == SquareVisitedState.Last && !boardData[i][j].UnitsPresent[UnitType.Bender])
                        boardData[i][j].visitedState = SquareVisitedState.Explored;
                }
            }

            AddWalls();

            units = new Dictionary<UnitType, UnitBase>();

            foreach(var i in setFrom.units)
            {
                units.Add(i.Key, new UnitBase(i.Value));
            }

            GetUnitSquare = new Dictionary<UnitType, SquareBoardGame>();

            int x = 0;
            int y = 0;
            foreach (var i in setFrom.GetUnitSquare)
            {
                x = i.Value.x;
                y = i.Value.y;

                GetUnitSquare.Add(i.Key, (SquareBoardGame)boardData[x][y]);
            }

        }

        //Only called when we start a new episode
        //We need to reset the visited state as well
        public void ShuffleCansAndUnits()
        {
            //Activate the 50/50 chance for each tile to have beer in it.
            foreach (var i in boardData)
            {
                foreach (var j in i)
                {
                    ((SquareBoardGame)j).randomizeBeerPresence();
                    ((SquareBoardGame)j).visitedState = SquareVisitedState.Unexplored;
                }
            }

            ShuffleUnits(); //Place bender randomly somewhere
            //get square unit is on().visited state = SquareVisitedState.Last;
        }


        //This is called each time we generate a new episode for our algorithm.
        //This is also called at the start of the program launch, disconnected from shuffling the whole board, just once.
        public void ShuffleUnits()
        {
            //The function can be the starting place of inserting units.

            int benderX;
            int benderY;
            int urlX;
            int urlY; 

            //If Bender is already somewhere on the board, make sure we remove him from that location.
            if (GetUnitSquare[UnitType.Bender] != null)
            {
                benderX = GetUnitSquare[UnitType.Bender].x;
                benderY = GetUnitSquare[UnitType.Bender].x;

                //Remove bender
                if (benderX != -1)
                    GetUnitSquare[UnitType.Bender].UnitsPresent[UnitType.Bender] = false;
            }

            //Get bender's new location.
            benderX = MyRandom.Next(0, 10);
            benderY = MyRandom.Next(0, 10);


            //Get url coordinates
            if(GetUnitSquare[UnitType.Url] != null)
            { //remove url
                urlX = GetUnitSquare[UnitType.Url].x;
                urlY = GetUnitSquare[UnitType.Url].y;

                GetUnitSquare[UnitType.Url].UnitsPresent[UnitType.Url] = false;
            }
            
            //Prevent them from being on the same square
            do
            {
                //Url too
                urlX = MyRandom.Next(0, 10); //0-9 inclusive
                urlY = MyRandom.Next(0, 10); //0-9 inclusive
            } while (urlX == benderX && benderY == urlY);



            //Set the unit-to-board translator data locater
            GetUnitSquare[UnitType.Bender] = (SquareBoardGame)(boardData[benderX][benderY]);
            GetUnitSquare[UnitType.Url] = (SquareBoardGame)boardData[urlX][urlY];

            //Set the square's unit booleans
            (GetUnitSquare[UnitType.Bender]).UnitsPresent[UnitType.Bender] = true; //Set the square's unit booleans
            (GetUnitSquare[UnitType.Url]).UnitsPresent[UnitType.Url] = true; 

            //Assign visited state based on bender
            (GetUnitSquare[UnitType.Bender]).visitedState = SquareVisitedState.Last;

            //Have the units look at their surroundings
            UnitPercieves(UnitType.Bender);
            UnitPercieves(UnitType.Url);

            units[UnitType.Url].chasing = false;
        }

        //This function will give bender perception data from the board
        public void UnitPercieves(UnitType toFind)
        {
            PerceptionState findPerception = new PerceptionState(toFind);
            foreach (var i in toFind.PerceptionCauses)
            {
                findPerception.perceptionData[i] = PercieveMove(i, toFind);
            }
            //Translated: for each move, percieve with this move, and update the perception for this move.

            findPerception.SetName();
            units[toFind].perceptionData = findPerception;
        }

        //Used when the robot moves *only*, otherwise, the perception will be checked from the state of the unit.
        //Generates percepts, and not MoveResults.
        public Percept PercieveMove(Move moveToCheck, UnitType unitToCheck)
        {
            SquareBoardGame unitLocation = GetUnitSquare[unitToCheck];            

            if (moveToCheck != Move.Grab && unitLocation.CheckIfWallsPreventMove(moveToCheck))
                return Percept.Wall; //Wall percieved 
            else
            {
                int percieveX = GetUnitSquare[unitToCheck].x + moveToCheck.gridAdjustment[0];
                int percieveY = GetUnitSquare[unitToCheck].y + moveToCheck.gridAdjustment[1];

                SquareBoardBase percieveLocation = boardData[percieveX][percieveY];
                if (percieveLocation.UnitsPresent[unitToCheck.enemy] == true)
                    return Percept.Enemy;
                if (percieveLocation.beerCanPresent)
                    return Percept.Can;
                else
                    return Percept.Empty;
            }
        }

        //This is called when the algorithm has been reset
        public void ClearCans()
        {
            //Clear all cans
            foreach (var i in boardData)
            {
                foreach (var j in i)
                {
                    j.beerCanPresent = false;
                    if (j.UnitsPresent[UnitType.Bender]) j.visitedState = SquareVisitedState.Last;
                    else
                        j.visitedState = SquareVisitedState.Unexplored;
                }
            }
        }

        public bool IsBenderOnCan()
        {
            

            return (GetUnitSquare[UnitType.Bender]).beerCanPresent;
        }



        public MoveResult ApplyMove(UnitType unitToMove, Move moveToApply)
        {
            SquareBoardGame unitSquare = GetUnitSquare[unitToMove];
            unitSquare.visitedState = SquareVisitedState.Last;

            //Get the move result based on the current condition
            if (unitSquare.CheckIfWallsPreventMove(moveToApply))
                return MoveResult.TravelFailed; //Walls prevent move

            if (moveToApply != Move.Wait && units[unitToMove].perceptionData.perceptionData[moveToApply] == Percept.Enemy)
                return MoveResult.EnemyEncountered;

            if(moveToApply == Move.Grab)
            {
                if (GetUnitSquare[unitToMove].beerCanPresent)
                {
                    BenderCollectsCan();
                    return MoveResult.CanCollected;
                }
                    
                else
                    return MoveResult.CanMissing;
            }
            //Didn't try to grab a can, and didn't hit a wall. We moved successfully.

            MoveUnit(unitToMove, moveToApply);
            units[unitToMove].SetMoveThisStep(moveToApply);
            return MoveResult.TravelSucceeded;
        }

        public void MoveUnit(UnitType unitToMove, Move moveToMake)
        {
            //We're going to move the unit. Remove him from the previous location.
            (GetUnitSquare[unitToMove]).UnitsPresent[unitToMove] = false;

            //Get the new coordinates.
            int x = GetUnitSquare[unitToMove].x + moveToMake.gridAdjustment[0];
            int y = GetUnitSquare[unitToMove].y + moveToMake.gridAdjustment[1];            

            GetUnitSquare[unitToMove] = (SquareBoardGame)boardData[x][y];

            GetUnitSquare[unitToMove].UnitsPresent[unitToMove] = true;
            GetUnitSquare[unitToMove].visitedState = SquareVisitedState.Last;
             
            UnitPercieves(unitToMove); //take in new surroundings
        }

        public void BenderCollectsCan()
        {   
            (GetUnitSquare[UnitType.Bender]).beerCanPresent = false;
            UnitPercieves(UnitType.Bender);
        }

        public int GetCansRemaining()
        {
            int total = 0;
            foreach (var i in boardData)
            {
                foreach(var j in i)
                {
                    if (j.beerCanPresent)
                        ++total;
                }
            }
            return total;
        }

        //Does this need to add a baseunit?
        public void AddUnit(UnitBase toAdd)
        {
            units[UnitType.Bender] = toAdd; //I think this removes bender
            GetUnitSquare[UnitType.Bender].UnitsPresent[UnitType.Bender] = true;
            //bender added
        }

        public void AddWalls()
        {
            //Set all walls to empty first

            foreach(var i in boardData)
            {
                foreach(var j in i)
                {
                    ((SquareBoardGame)j).walls = Walls.EmptyWallData;
                }
            }

            //Add walls, which will replace some of the empty walls.
            //left wall
            for (int i = 1; i <= 8; i++) { ((SquareBoardGame)boardData[0][i]).walls = Walls.Left; }
            //right wall
            for (int i = 1; i <= 8; i++) { ((SquareBoardGame)boardData[9][i]).walls = Walls.Right; }
            //bottom wall
            for (int i = 1; i <= 8; i++) { ((SquareBoardGame)boardData[i][0]).walls = Walls.Bottom; }
            //above wall
            for (int i = 1; i <= 8; i++) { ((SquareBoardGame)boardData[i][9]).walls = Walls.Top; }

            ((SquareBoardGame)boardData[0][0]).walls = Walls.BottomLeft;
            ((SquareBoardGame)boardData[9][9]).walls = Walls.TopRight;
            ((SquareBoardGame)boardData[0][9]).walls = Walls.TopLeft;
            ((SquareBoardGame)boardData[9][0]).walls = Walls.BottomRight;
        }

        public new SquareBoardGame GetBoardData(int x, int y)
        {
            return (SquareBoardGame)boardData[x][y];
        }

        public SquareBoardBase GetSquareFromMove(SquareBoardBase baseSquare, Move toMove)
        {
            int x = baseSquare.x + toMove.gridAdjustment[0];
            int y = baseSquare.y + toMove.gridAdjustment[1];
            return boardData[x][y];
        }

    }
}
