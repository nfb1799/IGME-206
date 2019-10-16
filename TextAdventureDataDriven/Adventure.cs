using System;

namespace TextAdventureDataDriven
{
    class Adventure
    {
        private static Adventure uniqueInstance = new Adventure();
        public static Adventure getInstance()
        {
            return uniqueInstance;
        }
        
        static void Main(string[] args)
        {
            GameLogic game = new GameLogic();
            Controller controller = new Controller();
            View viewer = new View();
            bool playing = false;


            viewer.Begin();
            controller.TextInput();
            playing = true;

            while (playing)
            {
                viewer.Look(game.Rooms, game.CurrentIndex); //Diplays the description of the current room
                viewer.Actions(game.Rooms, game.CurrentIndex); //Displays a menu of connected rooms and their directions
                game.Move(controller.MoveInput()); //Allows the user to move to a new room or quit the game
                if (game.CurrentIndex == 7)
                {
                    playing = false;
                    viewer.LastLook(game.EndDescription); //Displays a room description based on the final room
                }
            }

        }
    }
}
