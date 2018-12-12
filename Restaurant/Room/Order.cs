using System;
using System.Collections.Generic;
using System.Text;

namespace Room
{
    public class Order
    {
        public int Table { get; private set; }

        public IList<string> Dishes { get; private set; }

        public Order(int table, IList<string> dishes)
        {
            Table = table;
            Dishes = dishes;
        }
    }
}
