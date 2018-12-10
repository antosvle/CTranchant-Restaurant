using System;
using System.Collections.Generic;
using System.Text;

namespace Room.Events
{
    public enum RCEvent
    {
        Bread,
        Water,
        Wine
    }
    public class RoomClerkEvent
    {
        private readonly RCEvent evt;
        public RCEvent Event { get => evt; }

        public RoomClerkEvent(RCEvent evnt)
        {
            evt = evnt;
        }
    }
}
