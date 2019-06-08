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

        public int x_coordinate;
        public int y_coordinate;

        public BoardSquare current_location;
        public BoardSquare previous_location;

        public System.Drawing.Bitmap unit_image;

        //Stores our pre-defined unit types

            static public Unit bender_data;
            static public Unit url_data;

            static Unit()
            {
                bender_data = new Unit();
                bender_data.unit_name = "Bender";
                bender_data.x_coordinate = 0;


                url_data = new Unit();
            }

            static public Unit bender()
            {
                return bender_data;
            }

            static public Unit url()
            {
                return url_data;
            }
        

        public Unit()
        {
            perception_data = new PerceptionState();
            unit_name = null;

            x_coordinate = 0;
            y_coordinate = 0;

            current_location = null;
            previous_location = null;
        }

        public Unit(Unit set_from)
        {
            x_coordinate = set_from.x_coordinate;
            y_coordinate = set_from.y_coordinate;
            unit_name = set_from.unit_name;
            perception_data = set_from.perception_data;
            current_location = set_from.current_location;
            previous_location = set_from.previous_location;
            unit_image = set_from.unit_image;
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
