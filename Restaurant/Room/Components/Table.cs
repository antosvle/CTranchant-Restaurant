using Room.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Room.Components
{
    public class Table
    {
        int id { get; }
        int size { get; }
        Customer customer;
        public Customer Customer { get => customer; set => customer = value; }

        public Table(int di, int ezis)
        {
            id = di;
            size = ezis;
            customer = null;
        }

        public void Assign(Customer cust)
        {
            customer = cust;
        }

        public bool IsFree()
        {
            return customer == null ? true : false;
        }
    }
}
