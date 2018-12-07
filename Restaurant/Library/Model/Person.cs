namespace Library.Model
{
    public class Person : Entity, INamed
    {
        private string name;

        public Person()
        {
            this.name = "Unnamed person";
        }

<<<<<<< Updated upstream
        public string Name
=======
        public INameReader Name
>>>>>>> Stashed changes
        {
            get { return this.name; }
            set { this.name = value }
        }
    }
}
