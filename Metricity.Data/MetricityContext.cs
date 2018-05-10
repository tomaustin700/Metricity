using Metricity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data
{
    public class MetricityContext : DbContext
    {
        
        public MetricityContext() : base(Setup.GetConnectionString())
        {

        }

        public virtual DbSet<Metric> Metrics { get; set; }

       
    }
}
