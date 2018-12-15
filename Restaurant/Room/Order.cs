
using System;
using System.Collections.Generic;
using System.Text;

namespace Room
{
    public class Order
    {
        public int Table { get; set; }

        public IList<string> Dishes { get; private set; }

        public Order(IList<string> dishes)
        {
            Dishes = dishes;
        }
    }
}
