using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureDataDriven
{
    class View
    {
        private static View uniqueInstance = new View();
        public static View getInstance()
        {
            return uniqueInstance;
        }

        //Introduces the game to the user and explains the rules
        public void Begin()
        {
            Console.WriteLine("Welcome to the Haunted House of Horrors!");
            Console.WriteLine("You may make as many moves as you'd like.");
            Console.WriteLine("The room you choose to exit from will decide your fate.");
            Console.WriteLine("Press enter to begin.");
        }

        //Displays the description of a room
        public void Look(Rooms rooms, int index)
        {
            string[] descriptions = rooms.Descriptions;
            Console.WriteLine("\r\nYou enter the room.");
            Console.WriteLine(descriptions[index]);
        }

        //Displays a menu of connected room and their directions
        public void Actions(Rooms rooms, int index)
        {
            string[] connections = rooms.ConnectedRooms;
            Console.WriteLine("\r\n" + connections[index]);
            Console.WriteLine("\r\nEnter a direction to travel or X to quit (n/e/s/w)");
        }

        //Displays a discription of the final room
        public void LastLook(string end)
        {
            Console.WriteLine(end);
        }
    }
}
