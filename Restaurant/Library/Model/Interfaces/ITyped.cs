namespace Library.Model
{
    public interface ITyped<SpecificType> where SpecificType : Type
    {
        SpecificType Type { get; }
    }
}
