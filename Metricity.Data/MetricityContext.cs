using Metricity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data
{
    public class MetricityContext : DbContext
    {
        public MetricityContext() : base ("Server=tcp:metricitydb.database.windows.net,1433;Initial Catalog=MetricityDB;Persist Security Info=False;User ID=tom;Password=oD%77Kk28KOXQF>gRW+r;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        {

        }

        public virtual DbSet<Metric> Metrics { get; set; }
    }
}
