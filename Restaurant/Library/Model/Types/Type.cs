namespace Library.Model
{
    public class Type : IReadableName
    {
        private INameManager nameManager;

        protected Type(string name)
        {
            nameManager = new NameManager(name);
        }

        public INameReader name
        {
            get { return this.nameManager; }
        }
    }
}
