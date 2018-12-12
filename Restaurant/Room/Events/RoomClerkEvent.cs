using Room.Components;
using Room.Persons;
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

        private readonly Customer customer;
        public Customer Customer { get => customer; }

        public RoomClerkEvent(RCEvent evnt, Customer cust)
        {
            evt = evnt;
            customer = cust;
        }
    }
}
