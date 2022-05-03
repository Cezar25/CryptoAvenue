using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CryptoAvenue.Dal.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class,IEntity
    {
        protected readonly CryptoAvenueContext context;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(CryptoAvenueContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
             return dbSet.Any(predicate);
        }

        public void Delete(TEntity model)
        {
            dbSet.Remove(model);
        }
        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>>? predicate = null)
        {
            if(predicate == null)
                return dbSet.ToList();

            return dbSet.Where(predicate).ToList();
        }

        public TEntity GetEntityBy(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.SingleOrDefault(predicate);
        }

        public TEntity GetEntityByID(Guid id)
        {
            return dbSet.SingleOrDefault(x => x.Id == id);
        }

        public TEntity GetFirstEntityBy(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
