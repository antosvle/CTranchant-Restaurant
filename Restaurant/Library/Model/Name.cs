namespace Library.Model
{
    public interface IReadableName
    {
        INameReader name { get; }
    }

    public interface IManageableName
    {
        INameManager name { get; }
    }

    public interface INameReader
    {
        string data { get; }
    }

    public interface INameManager : INameReader
    {
        new string data { get; set; }
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

        public string data
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
