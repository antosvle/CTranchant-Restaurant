namespace Library.Model
{
    public class Type : INamed
    {
        private string name;

        protected Type(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
