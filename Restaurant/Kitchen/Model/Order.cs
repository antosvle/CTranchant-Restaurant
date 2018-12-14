using System.Collections.Generic;

namespace Kitchen.Model
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
