using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data.Entities
{
    internal class Metric
    { 
        public int MetricId { get; set; }
        public string ApplicationName { get; set; }
        public string MetricName { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
