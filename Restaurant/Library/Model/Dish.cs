namespace Library.Model
{
    public class Dish : ITyped<DishType>, IHoldable
    {
        private DishType type;

        public Dish(DishType type)
        {
            this.type = type;
        }

        public DishType Type
        {
            get { return this.type; }
        }
    }
}
