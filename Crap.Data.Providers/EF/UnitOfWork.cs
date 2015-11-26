using System;
using System.Collections.Generic;
using System.Data.Entity;
using Crap.Data.Entities.Common;

namespace Crap.Data.Providers.EF
{
    public class UnitOfWork : IDisposable
    {

        private readonly IDictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private bool _isDisposed;
        private readonly DbContext _context;

        public UnitOfWork()
        {
            _context = new EfDbContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //public void Save()
        //{
        //    _context.SaveChanges();
        //}

        public virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            _isDisposed = true;
        }

        public IRepository<T> Repository<T>() where T : Entity
        {
            var type = typeof(T);

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(EfRepository<T>);
                // create repository with AutoSave = false
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context, false);
                _repositories.Add(type, repositoryInstance);
            }
            return (IRepository<T>)_repositories[type];
        }
    }
}
