using Room;
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
            for(int i = 0; i < room.Tables.Count; i++)
            {
                if (room.Tables[i].Size >= cust.nbrOfPeople)
                {
                    cust.Table = room.Tables[i];
                    room.Tables.Customer = cust;
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
