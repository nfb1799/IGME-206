using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TextAdventureDataDriven
{
    class Rooms
    {
        protected string[] roomNames;
        protected string[] descriptions;
        protected string[] connectedRooms;
        protected int numberOfRooms;

        public Rooms(string textFile) //Constructor requires the directory of a text file
        {
            StreamReader file = new StreamReader(textFile); //Creates a StreamReader to parse the text file
            numberOfRooms = file.Read(); //Records the number of rooms
            file.ReadLine();

            //Instantiates all the arrays
            roomNames = new string[numberOfRooms];
            descriptions = new string[numberOfRooms];
            connectedRooms = new string[numberOfRooms];

            //Loops through the text file storing the name, descriptions and connected rooms
            for (int i = 0; i < numberOfRooms; i++)
            {
                roomNames[i] = file.ReadLine();
                descriptions[i] = file.ReadLine();
                connectedRooms[i] = file.ReadLine();
            }
            file.Close();
        }

        public string[] RoomNames
        {
            get { return roomNames; }
            set { roomNames = value; }
        }

        public string[] Descriptions
        {
            get { return descriptions; }
            set { descriptions = value; }
        }

        public string[] ConnectedRooms
        {
            get { return connectedRooms; }
            set { connectedRooms = value; }
        }
    }
}
