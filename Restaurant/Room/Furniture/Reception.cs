using Room.Persons;
using System.Collections.Generic;

namespace Room.Components
{
    public class Reception
    {
        int menusLeft { get; set; }

        Queue<Customer> waitingCustomers;
        Queue<Customer> inQueueCustomers;

        public Reception(int nbrMenus)
        {
            menusLeft = nbrMenus;
            waitingCustomers = new Queue<Customer>();
        }

        public int GetMenus(int nbr)
        {
            if (nbr >= menusLeft)
            {
                menusLeft -= nbr;
                return nbr;
            }
            else
                return 0;
        }

        public void AddCustomer(Customer cust)
        {
            waitingCustomers.Enqueue(cust);
        }

        public Customer GetNextCustomer()
        {
            return waitingCustomers.Dequeue();
        }
    }
}
