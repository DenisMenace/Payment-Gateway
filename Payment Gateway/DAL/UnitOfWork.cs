using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Payment_Gateway.Models;

namespace Payment_Gateway.DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private IDbContext _db;  //= new GatewayContext();

        public UnitOfWork(IDbContext db)
        {
            _db = db;
            //Merchants = new Repository<Merchant>(_db);
            //Requests = new Repository<Request>(_db);

        }

        IRepository<Merchant> _Merchants;
        IRepository<Request> _Requests;

        public IRepository<Merchant> Merchants
        {
            get { return LazyRepositoryFactory(ref _Merchants); }
        }

        public IRepository<Request> Requests
        {
            get { return LazyRepositoryFactory(ref _Requests); }
        }
        IRepository<T> LazyRepositoryFactory<T>(ref IRepository<T> repository) where T : class
        {
            return repository ?? Activator.CreateInstance(
                       typeof(Repository<>).MakeGenericType(typeof(T)), _db.Set<T>()
                   ) as IRepository<T>;
        }// instead of using Merchants = new Repository<Merchant>(_db);, this method can insantiate all Repositories

        public void SaveAll()
        {
            _db.SaveChanges();
        }
        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }

    }
}