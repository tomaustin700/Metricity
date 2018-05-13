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
            _metricRepository.Add(metric);

        }

        public void AddRange(List<MetricDTO> metrics)
        {
            _metricRepository.AddRange(metrics);

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _metricRepository.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
