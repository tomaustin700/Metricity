using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data.DTOs
{
    public class MetricDTO
    {
        public string ApplicationName { get; set; }
        public string MetricName { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
