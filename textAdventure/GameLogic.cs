using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class GameLogic
    {
        protected Room[] rooms;
        protected Room currentRoom;
        protected int currentIndex;

        private static GameLogic uniqueInstance = new GameLogic();
        public static GameLogic getInstance()
        {
            return uniqueInstance;
        }

        //Initializes the rooms as well as the currentRoom and currentIndex
        public GameLogic()
        {
            rooms = new Room[6];
            rooms[0] = new Hallway("A long, dark corridor with Renaissance portraits lining the walls.\r\n" +
                                    "Spiderwebs are everywhere. The temperature dropped when you entered the room.",
                                    "n: Staircase\r\ne: Kitchen\r\nw: Bathroom");
            rooms[1] = new Bathroom("A musty, smelly bathroom. There is a shower with water dripping.\r\n" +
                                    "The water in the toilet is a moldy green. Your nose twitches in disgust.",
                                    "e: Hallway");
            rooms[2] = new Kitchen("An eloquent kitchen with all the essentials. It smells like chocolate chip cookies.\r\n" +
                                    "There is a bouquet of fresh fruit on the counter. The fridge appears to be running.",
                                    "w: Hallway");
            rooms[3] = new Bedroom("A bedroom complete with a nightstand, lamp, and bed. The bed is unmade.\r\n" +
                                    "The lamp is flickering as the only light in the room.",
                                    "s: Staircase");
            rooms[4] = new Staircase("A tall, winding staircase. The railing is a cold, dark metal.\r\n" +
                                    "The floorboards screech with every step.",
                                    "n: Bedroom\r\ns: Hallway");
            currentRoom = rooms[0];
            currentIndex = 0;
        }

        //get and set for currentRoom
        public Room CurrentRoom
        {
            get { return currentRoom; }
            set { currentRoom = value; }
        }

        //get and set for currentIndex
        public int CurrentIndex
        {
            get { return currentIndex; }
            set { currentIndex = value; }
        }

        //Determines which direction the user chose to move
        public void Move(string direction)
        {
            switch (direction)
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
                currentRoom = rooms[4];
                currentIndex = 4;
            }
            else if (currentIndex == 4) //From Staircase to Bedroom
            {
                currentRoom = rooms[3];
                currentIndex = 3;
            }
        }

        //Handles all east-moves
        public void e()
        {
            if (currentIndex == 0) //From Hallway to Kitchen
            {
                currentRoom = rooms[2];
                currentIndex = 2;
            }
            else if (currentIndex == 1) //From Bathroom to Hallway
            {
                currentRoom = rooms[0];
                currentIndex = 0;
            }
        }

        //Handles all south-moves
        public void s()
        {
            if (currentIndex == 3) //From Bedroom to Staircase
            {
                currentRoom = rooms[4];
                currentIndex = 4;
            }
            else if (currentIndex == 4) //From Staircase to Hallway
            {
                currentRoom = rooms[0];
                currentIndex = 0;
            }
        }

        //Handles all west-moves
        public void w()
        {
            if (currentIndex == 0) //From Hallway to Bathroom
            {
                currentRoom = rooms[1];
                currentIndex = 1;
            }
            else if (currentIndex == 2) //From Kitchen to Hallway
            {
                currentRoom = rooms[0];
                currentIndex = 0;
            }
        }

        //Creates an ending room based on the user's final room 
        public void EndGame()
        {
            switch (currentIndex)
            {
                case 0:
                    rooms[5] = new Hallway("You examine a painting on the wall and it begins moving.\r\n" +
                                        "The man in the painting materializes and escorts you out the door\r\n" +
                                        "you arrived in.", "none");
                    break;
                case 1:
                    rooms[5] = new Bathroom("You examine the leaky showerhead and the door slams behind you.\r\n" +
                                            "A ghost violently pushes you into the tub and you are knocked unconscious.\r\n" +
                                            "Unfortunate.", "none");
                    break;
                case 2:
                    rooms[5] = new Kitchen("You open the fridge.\r\nThere is a delicious-looking chocolate cake.\r\n" +
                                            "You eat the cake and begin to feel dizzy. You fall to the floor.\r\n" +
                                            "The cake was poisoned.", "none");
                    break;
                case 3:
                    rooms[5] = new Bedroom("You jump into the bed and are grabbed by the ankle.\r\n" +
                                            "A boogie monster drags you under the bed and you are never seen from again.\r\n" +
                                            "Unfortunate.", "none");
                    break;
                case 4:
                    rooms[5] = new Staircase("You try leaving the staircase the way you came.\r\n" +
                                            "No matter how many steps you take, they just keep coming." +
                                            "The staircase has become infinite.", "none");
                    break;
            }
            currentRoom = rooms[5];
            currentIndex = 5;
        }
    }
}