namespace Library.Model
{
    public class DishType : Type
    {
        private Recipe recipe;

        public DishType(string name):
            base(name)
        {}

        public Recipe Recipe
        {
            get { return recipe; }
        }
    }
}
