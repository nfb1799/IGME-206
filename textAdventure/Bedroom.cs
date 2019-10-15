using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Bedroom : Room
    {

        public Bedroom(string desc, string connections)
        {
            description = desc;
            connectedRooms = connections;
        }

        public override string Description
        {
            get { return description; }
            set { description = value; }
        }

        public override string ConnectedRooms
        {
            get { return connectedRooms; }
            set { connectedRooms = value; }
        }
    }
}