using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Payment_Gateway.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //private readonly DbSet<T> _entities;

        readonly IDbSet<T> _set;

        public Repository(IDbSet<T> set) //pass the reference of the db.Set<T> directly from LazyRepositoryFactory in UnitOfWork, db is already pointing to Database
        {
            //_entities = context.Set<T>();
            _set = set;
        }

        public T GetById(int id)
        {
            return _set.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _set;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _set.Where(predicate);
        }

        public void Add(T entity)
        {
            _set.Add(entity);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach(var item in collection)
            {
                _set.Add(item);
            }
        }

        public void Remove(T entity)
        {
            _set.Remove(entity);
        }

        //public void RemoveRange(IEnumerable<TEntity> entities)
        //{
        //    _entities.RemoveRange(entities);
        //}
    }
}