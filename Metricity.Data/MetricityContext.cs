using Metricity.Data.Entities;
using Metricity.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data
{
    internal class MetricityContext : DbContext, IUnitOfWork
    {

        public MetricityContext() : base(Setup.GetConnectionString())
        {

        }

        public DbSet<Metric> Metrics { get; set; }
        public DbSet<HandledException> HandledExceptions { get; set; }

        public virtual DbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Commit()
        {
            base.SaveChanges();
        }
    }
}
