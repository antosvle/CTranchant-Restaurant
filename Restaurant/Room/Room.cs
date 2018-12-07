using Room.Components;
using Room.Persons;
using System.Collections.Generic;

namespace Room
{
    public class Room
    {
        static Room instance;
        Reception reception;
        HashSet<Area> areas;
        HashSet<Table> tables;
        public HashSet<Table> Tables { get => tables; }
        readonly HashSet<Customer> customers;
        readonly Butler butler;

        private Room()
        {
            butler = new Butler(this);
            customers = new HashSet<Customer>(0);
        }

        private void BuildRoom()
        {
            reception = new Reception(40);
            areas = new HashSet<Area>(2);
            tables = new HashSet<Table>(7);
            for(int i = 0; i < tables.Count; i++)
            {
                tables.Add(new Table(i, 2*i+2));
            }
        }

        public static Room GetInstance()
        {
            return instance ?? (instance = new Room());
        }

        public void DeleteClient(Customer cust)
        {
            customers.Remove(cust);
            cust = null;
        }

        public void Run()
        {
            while(true)
            {
                Customer cust = new Customer(5);
                customers.Add(cust);
                butler.WelcomeCustomer(cust);
            }
        }
    }
}
