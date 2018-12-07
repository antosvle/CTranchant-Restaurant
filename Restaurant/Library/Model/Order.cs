using System.Collections.Generic;

namespace Library.Model
{
    public sealed class Order<SpecificDishType> where SpecificDishType : DishType
    {
        private Table table;

        private Dictionary<DishType, Dish<SpecificDishType>> dishes;
    }
}
