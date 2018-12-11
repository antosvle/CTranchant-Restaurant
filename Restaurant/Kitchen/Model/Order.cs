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

        public string Description()
        {
            string description = "";

            foreach (string dish in Dishes)
            {
                description += "{" + dish + "}";
            }

            return description;
        }
    }
}
