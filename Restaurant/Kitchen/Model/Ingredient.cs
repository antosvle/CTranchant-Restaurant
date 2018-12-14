namespace Kitchen.Model
{
    public class Ingredient
    {
        public string Name { get; private set; }
        public int Quantity { get; private set; }

        public Ingredient(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public string Description()
        {
            return "{" + Name + "*" + Quantity + "}";
        }
    }
}
