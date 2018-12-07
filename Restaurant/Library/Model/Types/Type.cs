namespace Library.Model
{
    public class Type : INamed
    {
        private string name;

        protected Type(string name)
        {
            this.name = name;
        }

<<<<<<< Updated upstream
        public string Name
=======
        public INameReader Name
>>>>>>> Stashed changes
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
