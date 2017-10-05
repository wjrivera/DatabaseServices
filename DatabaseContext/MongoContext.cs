using System;
using System.Collections.Generic;
using System.Text;
using DatabaseConfig;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DatabaseContext
{
    public class MongoContext : IMongoContext
    {
        private readonly string _collectionName;
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IOptions<MongoConfig> _options;

        public MongoContext(IOptions<MongoConfig> options)
        {
            _options = options;
            _collectionName = _options.Value.collection;
            _client = new MongoClient();
            _database = _client.GetDatabase(_options.Value.database);
        }
        
        public IMongoCollection<T> Collection<T>()
        {
            return _database.GetCollection<T>(_collectionName);
        }
    }
}
