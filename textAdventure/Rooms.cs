using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TextAdventure
{
    class Rooms
    {
        protected string[] roomNames;
        protected string[] descriptions;
        protected string[] connectedRooms;
        protected int numberOfRooms;

        public Rooms(string textFile)
        {
            StreamReader file = new StreamReader(textFile);
            numberOfRooms = file.Read();
            file.ReadLine();
            roomNames = new string[numberOfRooms];
            descriptions = new string[numberOfRooms];
            connectedRooms = new string[numberOfRooms];

            for(int i = 0; i < numberOfRooms; i++)
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
