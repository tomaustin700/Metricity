using Metricity.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data.Interfaces
{
    public interface IMetricRepository : IDisposable
    {
        void Add(MetricDTO metric);
        void AddRange(List<MetricDTO> metrics);
    }
}
