using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    abstract class Room
    {
        protected string description;
        protected string connectedRooms;

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual string ConnectedRooms
        {
            get { return connectedRooms; }
            set { connectedRooms = value; }
        }
    }
}