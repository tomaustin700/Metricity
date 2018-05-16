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
    internal class MetricRepository : Repository<Metric, int>, IMetricRepository
    {
        internal MetricRepository(MetricityContext unitOfWork) : base(unitOfWork)
        {
            
        }


       

    }
}
