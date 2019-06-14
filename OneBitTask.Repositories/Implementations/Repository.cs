using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OneBitTask.Data;
using OneBitTask.Data.Entities;

namespace OneBitTask.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext db;

        public Repository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.db.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return this.db.Set<TEntity>()
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this.GetAll();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate);
        }

        public void Create(TEntity entity)
        {
            this.db.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            this.db.Set<TEntity>().Update(entity);
        }

        public void Delete(int id)
        {
            var entity = this.GetById(id);
            if (entity != null)
            {
                this.db.Set<TEntity>().Remove(entity);
            }
        }

        public void SaveChanges() => this.db.SaveChanges();
    }
}
