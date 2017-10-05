using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace DatabaseContext
{
    public interface IMongoContext
    {
        IMongoCollection<T> Collection<T>();
    }

    public class MongoContext : IMongoContext
    {
        private readonly string _collectionName;
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        public MongoContext(string databaseName, string collectionName)
        {
            _collectionName = collectionName;
            _client = new MongoClient();
            _database = _client.GetDatabase(databaseName);
        }
        
        public IMongoCollection<T> Collection<T>()
        {
            return _database.GetCollection<T>(_collectionName);
        }
    }
}
