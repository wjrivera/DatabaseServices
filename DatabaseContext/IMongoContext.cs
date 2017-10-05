using MongoDB.Driver;

namespace DatabaseContext
{
    public interface IMongoContext
    {
        IMongoCollection<T> Collection<T>();
    }
}