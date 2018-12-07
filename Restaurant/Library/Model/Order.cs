using System.Collections.Generic;

namespace Library.Model
{
    public sealed class Order
    {
        private Table table;

        private Dictionary<DishType, Dish> dishes;
    }
}
