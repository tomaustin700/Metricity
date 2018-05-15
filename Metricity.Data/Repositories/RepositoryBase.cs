﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data.Repositories
{
    internal class RepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        protected MetricityContext _context;
        protected UnitOfWork<TEntity> _unitOfWork = new UnitOfWork<TEntity>();
        internal void Save()
        {
            _context.SaveChanges();
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
