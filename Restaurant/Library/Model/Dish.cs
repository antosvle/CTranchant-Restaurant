namespace Library.Model
{
    public abstract class Dish<SpecificDishType> where SpecificDishType : DishType
    {
        protected SpecificDishType dishType;

        public Dish(SpecificDishType dishType)
        {
            this.dishType = dishType;
        }

        public SpecificDishType type
        {
            get { return this.dishType; }
        }
    }
}
