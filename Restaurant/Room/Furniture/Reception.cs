using Room.Persons;
using System.Collections.Generic;

namespace Room.Components
{
    public class Reception
    {
        private int menusLeft;
        public int MenusLeft { get => menusLeft; set => menusLeft = value; }

        private Queue<Customer> waitingCustomers;
        private Queue<Customer> inQueueCustomers;

        public Reception(int nbrMenus)
        {
            menusLeft = nbrMenus;
            waitingCustomers = new Queue<Customer>();
            inQueueCustomers = new Queue<Customer>();
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
            lock(waitingCustomers)
            {
                if (waitingCustomers.Count > 0)
                    return waitingCustomers.Dequeue();
                else
                    return null;
            }
        }

        public void AddCustomerToQueue(Customer cust)
        {
            inQueueCustomers.Enqueue(cust);
        }

        public Customer GetNextCustomerInQueue()
        {
            lock(inQueueCustomers)
            {
                if(inQueueCustomers.Count > 0)
                    return inQueueCustomers.Dequeue();
                else
                    return null;
            }
        }
    }
}
