using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data.Entities
{
    public class Metric
    { 
        public int MetricId { get; set; }
        public string AppliactionName { get; set; }
        public string MethodName { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
