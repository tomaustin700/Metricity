using Metricity.Data.DTOs;
using Metricity.Data.Interfaces;
using Metricity.Data.Repositories;
using MetricityAPIHelper;
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
            if (string.IsNullOrEmpty(Setup.GetAPIKey()))
            {
                _metricRepository.Add(new Entities.Metric() { ApplicationName = metric.ApplicationName, Duration = metric.Duration, MetricName = metric.MetricName });
                _metricRepository.UnitOfWork.Commit();
            }
            else
            {
                using (var metricHelper = new MetricHelper(Guid.Parse(Setup.GetAPIKey())))
                {
                    metricHelper.Add(new Entities.Metric() { ApplicationName = metric.ApplicationName, Duration = metric.Duration, MetricName = metric.MetricName });
                }
            }

        }

        public void AddRange(List<MetricDTO> metrics)
        {
            if (string.IsNullOrEmpty(Setup.GetAPIKey()))
            {
                _metricRepository.AddRange(metrics.Select(x => new Entities.Metric() { ApplicationName = x.ApplicationName, Duration = x.Duration, MetricName = x.MetricName }));
                _metricRepository.UnitOfWork.Commit();
            }
            else
            {
                //Call Metricity API Helper
                using (var metricHelper = new MetricHelper(Guid.Parse(Setup.GetAPIKey())))
                {
                    metricHelper.AddRange(metrics.Select(x => new Entities.Metric() { ApplicationName = x.ApplicationName, Duration = x.Duration, MetricName = x.MetricName }));
                }
            }

        }

        public void Dispose()
        {
            _metricRepository.Dispose();
        }


    }
}
