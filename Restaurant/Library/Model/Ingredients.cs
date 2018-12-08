namespace Library.Model
{
    class Ingredients : ITyped<IngredientType>
    {
        private IngredientType type;

        public Ingredients(IngredientType type)
        {
            this.type = type;
        }

        public IngredientType Type
        {
            get { return this.type; }
        }
    }
}
