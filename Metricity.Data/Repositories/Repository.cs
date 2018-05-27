using Metricity.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data.Repositories
{
    internal class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, new()
    {
        protected readonly MetricityContext _unitOfWork;

        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public Repository(MetricityContext unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public virtual void Add(TEntity entity)
        {
            if (entity != null)
                _unitOfWork.CreateSet<TEntity>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities != null)
                _unitOfWork.CreateSet<TEntity>().AddRange(entities);
        }

        public virtual TEntity Find(TKey key)
        {
            return _unitOfWork.CreateSet<TEntity>().Find(key);
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }


    }
}
