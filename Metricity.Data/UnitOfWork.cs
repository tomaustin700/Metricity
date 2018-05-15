using Metricity.Data.Entities;
using Metricity.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data
{
    internal class UnitOfWork<TEntity> : IDisposable where TEntity : class
    {
        private MetricityContext _context = new MetricityContext();
        private DbSet<TEntity> _createSet;
        
       
        public void Commit()
        {
            _context.SaveChanges();
        }

        public DbSet<TEntity> CreateSet()
        {
            if (_createSet == null)
            {
                _createSet = new GenericRepository<TEntity>(_context)._dbSet;
            }
            return _createSet;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
