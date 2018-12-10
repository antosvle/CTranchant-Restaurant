using Room;
using Room.Components;
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

        public bool WelcomeCustomer(Customer cust)
        {
            Console.WriteLine("Welcoming client");

            foreach (Table table in room.Tables)
            {
                if (table.Size >= cust.NbrOfPeople)
                {
                    cust.Table = table;
                    table.Customer = cust;
                    return true;
                }
            }
            return false;
        }

        public void PayBill(Customer cust)
        {
            Console.WriteLine("Client is paying bill");
            cust.Status = EStatus.paying;
            room.DeleteClient(cust);
        }
    }
}
