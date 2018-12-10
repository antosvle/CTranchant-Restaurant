using Room.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Room.Components
{
    public class Table
    {
        private readonly int id;
        public int Id { get => id; }

        private readonly int size;
        public int Size { get => size; }

        private Customer customer;
        public Customer Customer { get => customer; set => customer = value; }

        private string nameCust;
        public string ReservedCustomerName { get => nameCust; set => nameCust = value; }

        public Table(int di, int ezis, string name)
        {
            id = di;
            size = ezis;
            nameCust = name;
            customer = null;
        }

        public bool IsFree()
        {
            return (customer == null) ? true : false;
        }
    }
}
