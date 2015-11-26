using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Crap.Data.Entities.Common;

namespace Crap.Data.Providers.EF
{
    public class EfRepository<TEntity> : IQueryable<TEntity>, IRepository<TEntity> where TEntity : Entity
    {

        private readonly DbContext _context;
        private readonly IDbSet<TEntity> _set;
        private readonly bool _isAutoSave;

        public EfRepository(bool isAutoSave = true)
        {
            _context = new EfDbContext();
            _set = _context.Set<TEntity>();
            _isAutoSave = isAutoSave;
        }


        public EfRepository(DbContext context, bool isAutoSave = true)
        {
            _context = context;
            _set = _context.Set<TEntity>();
            _isAutoSave = isAutoSave;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression 
        {
            get { return _set.Expression; }
        }

        public Type ElementType
        {
            get { return _set.ElementType; }
        }

        public IQueryProvider Provider 
        {
            get { return _set.Provider; }
        }

        public void Delete(TEntity entity)
        {
            Submit(() =>
            {
                _set.Remove(entity);
                if (_isAutoSave)
                    _context.SaveChanges();
            });
        }

        public void Save(TEntity entity)
        {
            Submit(() =>
            {
                if (!this.Any(i => i.Id == entity.Id))
                    _set.Add(entity);
                if (_isAutoSave)
                    _context.SaveChanges();
            });
        }

        private static void Submit(Action action)
        {
            try
            {
                action();
            }
            catch (DbEntityValidationException dbEx)
            {
                var errorMessage = new StringBuilder();
                foreach (var errors in dbEx.EntityValidationErrors)
                {
                    foreach (var error in errors.ValidationErrors)
                        errorMessage.AppendFormat("Property: {0} Error: {1}\n", error.PropertyName, error.ErrorMessage);
                }

                throw new DataException(errorMessage.ToString(), dbEx);
            }
        }

    }
}
