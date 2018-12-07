namespace Library.Model
{
    public interface INamed
    {
<<<<<<< Updated upstream
        string Name { get; set; }
=======
        INameReader Name { get; }
    }

    public interface IManageableName
    {
        INameManager Name { get; }
    }

    public interface INameReader
    {
        string String { get; }
    }

    public interface INameManager : INameReader
    {
        new string String { get; set; }
    }

    public class NameHandler
    {
        protected NameHandler()
        {
            this.name = "Unnamed";
        }

        protected NameHandler(string name)
        {
            this.name = name;
        }

        protected string name;
    }
    
    public sealed class NameManager : NameHandler, INameManager
    {
        public NameManager():
            base()
        {}

        public NameManager(string name):
            base(name)
        {}

        public string String
        {
            get { return this.name; }
            set { this.name = value; }
        }
>>>>>>> Stashed changes
    }
}
