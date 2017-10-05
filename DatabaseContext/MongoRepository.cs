using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace DatabaseContext
{
    public class MongoRepository<TEntity> : IMongoRepository<TEntity, string> where TEntity : class, IIdentifiable<string>
    {
        private readonly MongoContext _mongoContext;
        //private readonly IMongoContext _mongoContext;

        public MongoRepository()
        //public MongoRepository(IMongoContext context)
        {
            _mongoContext = new MongoContext("mongorepo", "person");
            //_mongoContext = context;
        }
        public void Delete(string key)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", key);
            _mongoContext.Collection<TEntity>().DeleteOne(filter);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> match)
        {
            return _mongoContext.Collection<TEntity>().Find(match).ToList().AsEnumerable();
        }

        public TEntity Get(string key)
        {
            var filter = Builders<TEntity>.Filter.Eq("ReportId", key);
            var results = _mongoContext.Collection<TEntity>().Find(filter).Limit(1).ToList();
            return results[0];
        }

        public IQueryable<TEntity> Query()
        {
            var results = _mongoContext.Collection<TEntity>().AsQueryable() as IQueryable<TEntity>;
            return results;
        }

        public void Upsert(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", entity.Id);

            _mongoContext.Collection<TEntity>().ReplaceOne(filter, entity, new UpdateOptions
            {
                IsUpsert = true
            });
        }

        public void Upsert(TEntity entity, TEntity original, Func<TEntity, TEntity, bool> compare)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", entity.Id);

            var existing = _mongoContext.Collection<TEntity>().Find(filter).Limit(1).FirstOrDefault();

            if (existing != null && compare(existing, entity))
            {
                // upsert because the entity has not changed since the caller loaded it.
                _mongoContext.Collection<TEntity>().ReplaceOne(filter, entity, new UpdateOptions
                {
                    IsUpsert = true
                });
            }
            else if (existing == null)
            {
                // insert only
                _mongoContext.Collection<TEntity>().ReplaceOne(filter, entity, new UpdateOptions
                {
                    IsUpsert = true
                });
            }
        }
    }
}