namespace Library.Model.Types
{
    class DishTypeManager : TypeManager<DishType>
    {
        protected override DishType NewType(string name)
        {
            return new DishType(name);
        }
    }
}
