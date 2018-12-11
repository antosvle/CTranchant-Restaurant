using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Model
{
    public class Order
    {
        public IList<string> Dishes { get; private set; }

        public Order(IList<string> dishes)
        {
            this.Dishes = dishes;
        }
    }
}
