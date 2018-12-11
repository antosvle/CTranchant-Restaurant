using System.Collections.Generic;

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
