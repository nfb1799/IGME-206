using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class GameLogic
    {
        protected Rooms rooms; //creates an instance of the Rooms class called rooms
        protected string endDescription;
        protected int currentIndex;

        private static GameLogic uniqueInstance = new GameLogic();
        public static GameLogic getInstance()
        {
            return uniqueInstance;
        }

        //Initializes the rooms as well as the currentRoom and currentIndex
        public GameLogic()
        {
            try
            {
                rooms = new Rooms("../../../RoomsText.txt");
                endDescription = "";
                currentIndex = 0;

            } 
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read.");
                Console.WriteLine(e.Message);
            }
        }

        public Rooms Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }

        public int CurrentIndex
        {
            get { return currentIndex; }
            set { currentIndex = value; }
        }

        public string EndDescription
        {
            get { return endDescription; }
            set { endDescription = value; }
        }

        //Determines which direction the user chose to move
        public void Move(string direction)
        {
            switch(direction)
            {
                case "n":
                    n();
                    break;
                case "e":
                    e();
                    break;
                case "s":
                    s();
                    break;
                case "w":
                    w();
                    break;
                case "X":
                    EndGame();
                    break;
            }
        }

        //Handles all north-moves
        public void n()
        {
            if (currentIndex == 0) //From Hallway to Staircase
            {
                currentIndex = 4;
            } else if(currentIndex == 4) //From Staircase to Bedroom
            {
                currentIndex = 3;
            }
        }

        //Handles all east-moves
        public void e()
        {
            if (currentIndex == 0) //From Hallway to Kitchen
            {
                currentIndex = 2;
            }
            else if (currentIndex == 1) //From Bathroom to Hallway
            {
                currentIndex = 0;
            }
        }

        //Handles all south-moves
        public void s()
        {
            if(currentIndex == 3) //From Bedroom to Staircase
            {
                currentIndex = 4;
            } else if(currentIndex == 4) //From Staircase to Hallway
            {
                currentIndex = 0;
            }
        }

        //Handles all west-moves
        public void w()
        {
            if(currentIndex == 0) //From Hallway to Bathroom
            {
                currentIndex = 1;
            } else if(currentIndex == 2) //From Kitchen to Hallway
            {
                currentIndex = 0;
            }
        }

        //Creates an ending room based on the user's final room 
        public void EndGame()
        {
            switch(currentIndex)
            {
                case 0:
                    endDescription = new string("You examine a painting on the wall and it begins moving.\r\n" +
                                        "The man in the painting materializes and escorts you out the door\r\n" +
                                        "you arrived in.");
                    break;
                case 1:
                    endDescription = new string("You examine the leaky showerhead and the door slams behind you.\r\n" +
                                            "A ghost violently pushes you into the tub and you are knocked unconscious.\r\n" +
                                            "Unfortunate.");
                    break;
                case 2:
                    endDescription = new string("You open the fridge.\r\nThere is a delicious-looking chocolate cake.\r\n" +
                                            "You eat the cake and begin to feel dizzy. You fall to the floor.\r\n" +
                                            "The cake was poisoned.");
                    break;
                case 3:
                    endDescription = new string("You jump into the bed and are grabbed by the ankle.\r\n" +
                                            "A boogie monster drags you under the bed and you are never seen from again.\r\n" +
                                            "Unfortunate.");
                    break;
                case 4:
                    endDescription = new string("You try leaving the staircase the way you came.\r\n" +
                                            "No matter how many steps you take, they just keep coming." +
                                            "The staircase has become infinite.");
                    break;
            }
            currentIndex = 5;
        }
    }
}
