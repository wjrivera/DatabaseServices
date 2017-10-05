namespace DatabaseContext
{
    public interface IIdentifiable<T>
    {
        T Id { get; }
    }
}