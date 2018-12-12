namespace Kitchen.Model
{
    public class Furniture : Waitable
    {
        public string Name { get; private set; }

        public Furniture(string name):
            base()
        {
            Name = name;
        }
    }
}
