using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DatabaseContext
{
    public interface IMongoRepository<TEntity, TKey> where TEntity : class, IIdentifiable<string>
    {
        void Delete(string key);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> match);
        TEntity Get(string key);
        IQueryable<TEntity> Query();
        void Upsert(TEntity entity);
        void Upsert(TEntity entity, TEntity original, Func<TEntity, TEntity, bool> compare);
    }
}