using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Kitchen : Room
    {
        
        public Kitchen(string desc, string connections)
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
