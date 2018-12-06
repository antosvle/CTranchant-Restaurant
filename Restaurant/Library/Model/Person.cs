namespace Library.Model
{
    public class Person : Entity, IReadableName
    {
        private INameManager nameManager;

        public Person()
        {
            nameManager = new NameManager("Unnamed person");
        }

        public INameReader name
        {
            get { return this.nameManager; }
        }
    }
}
