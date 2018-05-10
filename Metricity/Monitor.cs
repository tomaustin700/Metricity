using Metricity.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Metricity
{
    public class Monitor
    {
        public void MonitorMethod(Action action, string methodName, string applicationName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action.Invoke();
            stopwatch.Stop();
            Submit(methodName, applicationName, stopwatch.Elapsed);
        }

        public async Task MonitorMethodAsync(Func<Task<Action>> action, string methodName, string applicationName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await action();
            stopwatch.Stop();
            Submit(methodName, applicationName, stopwatch.Elapsed);
        }

        private void Submit(string methodName, string applicationName, TimeSpan elapsed)
        {
            using (var db = new MetricityContext())
            {
                db.Metrics.Add(new Data.Entities.Metric() { Duration = elapsed, AppliactionName = applicationName, MethodName = methodName });
                db.SaveChanges();
            }
        }
    }
}
