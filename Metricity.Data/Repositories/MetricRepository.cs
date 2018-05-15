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
    internal class MetricRepository : RepositoryBase<Metric>, IMetricRepository
    {
        internal MetricRepository(MetricityContext context)
        {
            _context = context;
        }


        public void Add(MetricDTO metric)
        {
            _unitOfWork.CreateSet().Add(new Data.Entities.Metric() { Duration = metric.Duration, ApplicationName = metric.ApplicationName, MetricName = metric.MetricName });
            _unitOfWork.Commit();
        }

        public void AddRange(List<MetricDTO> metrics)
        {
            _unitOfWork.CreateSet().AddRange(metrics.Select(x => new Metric() { Duration = x.Duration, ApplicationName = x.ApplicationName, MetricName = x.MetricName }));
            _unitOfWork.Commit();
        }

    }
}
