using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data.Interfaces
{
    internal interface IRepository<TEntity, TKey> where TEntity : class, new()
    {
        IUnitOfWork UnitOfWork { get; }
        void AddRange(IEnumerable<TEntity> entities);
        void Add(TEntity entity);

        void Dispose();
    }
}
