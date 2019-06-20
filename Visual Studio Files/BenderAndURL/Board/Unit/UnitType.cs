using System.Collections.Generic;

namespace BenderAndURL
{
    //I think this is necessary to help enforce the baseunit type on some calls and dictionary-dereferences
    //This is a type class for each unit
    class UnitType : UnitBase
    {
        public HashSet<Move> PerceptionCauses; //A list of the moves that the unit uses to get his perception

        //Stores all our pre-defined unit moves
        public HashSet<Move> unitMoveList;

        public string typeName;

        public static readonly HashSet<UnitType> List; //A list of units

        public static readonly UnitType Bender;
        public static readonly UnitType Url;

        static UnitType()
        {
            List = new HashSet<UnitType>();
            Bender = new UnitType();
            Bender.unitName = "Bender";
            Bender.typeName = "Bender";
            Bender.unitMoveList = new HashSet<Move>();
            Bender.unitMoveList.UnionWith(Move.HorizontalMovesAndGrab);
            Bender.PerceptionCauses = new HashSet<Move>();
            Bender.PerceptionCauses.UnionWith(Move.AllMoves); //Perception comes from any of the 9 possible moves
            List.Add(Bender);

            Url = new UnitType();
            Url.unitName = "Url";
            Url.typeName = "Url";
            Url.enemy = Bender;
            Url.unitMoveList = new HashSet<Move>();
            Url.unitMoveList.UnionWith(Move.AllMoves);
            Url.PerceptionCauses = new HashSet<Move>();//perception is caused by any of the 9 possible moves
            Url.PerceptionCauses.UnionWith(Move.AllMoves); //perception is caused by any of the 9 possible moves
            List.Add(Url);

            Bender.enemy = Url;
        }

        public override string ToString()
        {
            return "Static " + base.ToString();

        }

        


    }
}
