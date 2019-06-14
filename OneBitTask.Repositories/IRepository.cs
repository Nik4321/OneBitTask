using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OneBitTask.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity GetById(int id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

        void SaveChanges();
    }
}
