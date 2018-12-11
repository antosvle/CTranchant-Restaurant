using Library.Controller;
using Room.Components;
using Room.Events;
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
                RowChiefEvent evt;
                if (cust != null)
                {
                    // call IHM 
                }
                else if((evt = row.GetRowChiefEvent()) != null)
                {
                    if(evt.Event == RowChiefEventEnum.getMenu)
                    {
                        Timeline.Wait(60);
                    }
                    else if(evt.Event == RowChiefEventEnum.getOrder)
                    {
                        Timeline.Wait(30 * evt.Table.Customer.NbrOfPeople);
                    }
                }

            }
        }
    }
}
