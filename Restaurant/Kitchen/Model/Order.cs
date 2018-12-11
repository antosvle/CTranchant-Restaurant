using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Model
{
    public class Order
    {
        public ISet<string> Dishes { get; private set; } = new HashSet<string>();

        public Order(ISet<string> dishes)
        {
            this.Dishes = dishes;
        }
    }
}
