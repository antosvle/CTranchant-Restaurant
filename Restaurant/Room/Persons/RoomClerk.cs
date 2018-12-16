using Library.Controller;
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
                    Console.WriteLine("ROOM <Putting Bread for table " + evt.Customer.Name + ">");
                    Timeline.Wait(60);
                    evt.Customer.Status = EStatus.nothing;
                }
                else if (evt.Event == RCEvent.Water)
                {
                    Console.WriteLine("ROOM <Putting Water for table " + evt.Customer.Name + ">");
                    Timeline.Wait(60);
                    evt.Customer.Status = EStatus.nothing;
                }
                else if (evt.Event == RCEvent.Wine)
                {
                    Console.WriteLine("ROOM <Bringing menu, taking wine order, bringing wine for table " + evt.Customer.Name + ">");
                    Timeline.Wait(60);
                    evt.Customer.Status = EStatus.nothing;
                }
            }
        }
    }
}
