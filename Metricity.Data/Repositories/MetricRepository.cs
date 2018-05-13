using Metricity.Data.DTOs;
using Metricity.Data.Entities;
using Metricity.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data.Repositories
{
    internal class MetricRepository : RepositoryBase, IMetricRepository
    {
        internal MetricRepository(MetricityContext context)
        {
            _context = context;
        }


        public void Add(MetricDTO metric)
        {
            _context.Metrics.Add(new Data.Entities.Metric() { Duration = metric.Duration, ApplicationName = metric.ApplicationName, MetricName = metric.MetricName });
            Save();
        }

        public void AddRange(List<MetricDTO> metrics)
        {
            _context.Metrics.AddRange(metrics.Select(x => new Metric() { Duration = x.Duration, ApplicationName = x.ApplicationName, MetricName = x.MetricName }));
            Save();
        }

    }
}
