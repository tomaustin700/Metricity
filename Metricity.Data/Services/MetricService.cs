using Metricity.Data.DTOs;
using Metricity.Data.Interfaces;
using Metricity.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data.Services
{
    public class MetricService : IDisposable
    {
        private IMetricRepository _metricRepository;

        public MetricService()
        {
            _metricRepository = new MetricRepository(new MetricityContext());
        }

        public void Add(MetricDTO metric)
        {
            _metricRepository.Add(new Entities.Metric() { ApplicationName = metric.ApplicationName, Duration = metric.Duration, MetricName = metric.MetricName });
            _metricRepository.UnitOfWork.Commit();

        }

        public void AddRange(List<MetricDTO> metrics)
        {
            _metricRepository.AddRange(metrics.Select(x => new Entities.Metric() { ApplicationName = x.ApplicationName, Duration = x.Duration, MetricName = x.MetricName }));
            _metricRepository.UnitOfWork.Commit();

        }

        public void Dispose()
        {
            _metricRepository.Dispose();
        }


    }
}
