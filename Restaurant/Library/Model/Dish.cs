namespace Library.Model
{
    public abstract class Dish : IHoldable
    {
        protected DishType dishType;

        public Dish(DishType dishType)
        {
            this.dishType = dishType;
        }

        public DishType type
        {
            get { return this.dishType; }
        }
    }
}
