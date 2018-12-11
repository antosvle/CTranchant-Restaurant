using Room.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Room.Persons
{
    class RowChief
    {
        private Room room;
        private Row row;

        public RowChief(Room rooom, Row roow)
        {
            room = rooom;
            row = roow;
        }

        public void Run()
        {
            while (true)
            {
                Customer cust = room.Reception.GetNextCustomerInQueue();
                if (cust == null)
                    continue;


            }
        }
    }
}
