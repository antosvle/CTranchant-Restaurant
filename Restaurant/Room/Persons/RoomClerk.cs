using Room.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Room.Persons
{
    public class RoomClerk
    {
        public void Run()
        {
            while(true)
            {
                RoomClerkEvent evt = Room.GetRoomClerkEvent();
                if (evt == null)
                    continue;

                if (evt.Event == RCEvent.Bread)
                {
                    Console.WriteLine("Putting Bread");
                }
                else if (evt.Event == RCEvent.Water)
                {
                    Console.WriteLine("Putting Water");
                }
                else if (evt.Event == RCEvent.Wine)
                {
                    Console.WriteLine("Bringing menu, taking wine order, bringing wine");
                }
                else
                    Console.WriteLine("Wrong event type");
            }
        }
    }
}
