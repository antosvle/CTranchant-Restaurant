using Library.Controller;
using Room;
using Room.Components;
using Room.Events;
using System;

namespace Room.Persons
{
    public class Butler
    {
        private Room room;

        public Butler(Room rooom)
        {
            room = rooom;
        }

        public void Run()
        {
            while(true)
            {
                Customer cust;
                if ((cust = room.Reception.GetNextCustomer()) == null)
                    continue;
                
                if(cust.Status == EStatus.arriving)
                {
                    if (WelcomeCustomer(cust))
                    {
                        cust.Status = EStatus.waiting;
                        room.Reception.AddCustomerToQueue(cust);
                    }
                    else
                        room.DeleteClient(cust);
                }
                else if(cust.Status == EStatus.waitingPaying)
                {
                    PayBill(cust);
                    room.DeleteClient(cust);
                }
                else
                    Console.WriteLine("ROOM <Customer should not be at reception with status " + cust.Status + ">");
            }
        }

        public bool WelcomeCustomer(Customer cust)
        {
            Console.WriteLine("ROOM <Welcoming client " + cust.Name + " : " + cust.NbrOfPeople.ToString() + " people>");

            foreach(Table table in room.Tables) // search if they had reserved a table
            {
                if(table.ReservedCustomerName == cust.Name && cust.Name != "")
                {
                    cust.Table = table;
                    table.Customer = cust;
                    table.Row.AddRowChiefEvent(new RowChiefEvent(RowChiefEventEnum.getMenu, table));
                    return true;
                }
            }

            foreach (Table table in room.Tables)
            {
                if (table.IsFree() && table.Size >= cust.NbrOfPeople && table.ReservedCustomerName == "")
                {
                    cust.Table = table;
                    table.Customer = cust;
                    table.Row.AddRowChiefEvent(new RowChiefEvent(RowChiefEventEnum.getMenu, table));
                    return true;
                }
            }

            Console.WriteLine("ROOM <not enough place, rejecting client>");
            return false;
        }

        public void PayBill(Customer cust)
        {
            Console.WriteLine("ROOM <Client " + cust.Name + " is paying bill>");
            cust.Status = EStatus.paying;
            Timeline.Wait(20 * cust.NbrOfPeople);
        }
    }
}
