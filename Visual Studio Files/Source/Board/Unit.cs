using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementLearning
{
    //This class represents units on the board that can take actions.
    class Unit
    {
        string unit_name;
        public PerceptionState perception_data; //Store the percepts for this unit

        public int bender_x;
        public int bender_y;

        public Unit()
        {
            perception_data = new PerceptionState();
            unit_name = "Bender";

            bender_x = 0;
            bender_y = 0;
        }

        public Unit(Unit set_from)
        {
            bender_x = set_from.bender_x;
            bender_y = set_from.bender_y;
            unit_name = set_from.unit_name;
            perception_data = set_from.perception_data;
        }

        public PerceptionState get_perception_state()
        {
            return perception_data;
        }

        public Percept get_percept(Move direction_to_check)
        {
            return perception_data.get_percept(direction_to_check);
        }
    }
}
