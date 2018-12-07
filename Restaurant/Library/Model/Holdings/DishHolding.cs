namespace Library.Model
{
    public class DishHolding : Holding<Dish>
    {
        DishHolding(IHolder holder):
            base(holder)
        {}
    }
}
