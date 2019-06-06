namespace ReinforcementLearning
{
    static class WallsList
    {
        private static readonly Wall top_wall_data;
        private static readonly Wall bottom_wall_data;
        private static readonly Wall left_wall_data;
        private static readonly Wall right_wall_data;
        private static readonly Wall top_left_wall_data; //top left corner wall
        private static readonly Wall top_right_wall_data;
        private static readonly Wall bottom_left_wall_data;
        private static readonly Wall bottom_right_wall_data; //bottom right corner
        private static readonly Wall empty_wall_data;

        static WallsList()
        {

            top_wall_data = new Wall(MoveList.up());
            bottom_wall_data = new Wall(MoveList.down());
            left_wall_data = new Wall(MoveList.left());
            right_wall_data = new Wall(MoveList.right());
            top_left_wall_data = new Wall(MoveList.left(), MoveList.up());
            top_right_wall_data = new Wall(MoveList.right(), MoveList.up());
            bottom_left_wall_data = new Wall(MoveList.left(), MoveList.down());
            bottom_right_wall_data = new Wall(MoveList.right(), MoveList.down());
            empty_wall_data = new Wall();
        }

        public static Wall top_wall()
        {
            return top_wall_data;
        }
        public static Wall bottom_wall()
        {
            return bottom_wall_data;
        }
        public static Wall left_wall()
        {
            return left_wall_data;
        }
        public static Wall right_wall()
        {
            return right_wall_data;
        }
        public static Wall top_left_wall()
        {
            return top_left_wall_data;
        }
        public static Wall top_right_wall()
        {
            return top_right_wall_data;
        }
        public static Wall bottom_left_wall()
        {
            return bottom_left_wall_data;
        }
        public static Wall bottom_right_wall()
        {
            return bottom_right_wall_data;
        }
        public static Wall empty_wall()
        {
            return empty_wall_data;
        }
    }
}
