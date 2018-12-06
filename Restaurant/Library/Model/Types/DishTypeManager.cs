namespace Library.Model.Types
{
    class DishTypeManager : TypeManager<DishType>
    {
        public override DishType NewType(string name)
        {
            return new DishType(name);
        }
    }
}
