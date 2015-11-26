using System.Collections.Generic;
using Crap.Data.Entities.Common;

namespace Crap.Data.Providers
{
    public interface IRepository<TEntity> : IEnumerable<TEntity>
        where TEntity : Entity
    {
        void Delete(TEntity entity);
        void Save(TEntity entity);
    }
}
