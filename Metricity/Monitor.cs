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
    public static class Monitor
    {
        public static void MonitorMethod(Action action, string methodName, string applicationName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action.Invoke();
            stopwatch.Stop();
            Submit(methodName, applicationName, stopwatch.Elapsed);
        }

        public static async Task MonitorMethodAsync(Func<Task<Action>> action, string methodName, string applicationName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await action();
            stopwatch.Stop();
            Submit(methodName, applicationName, stopwatch.Elapsed);
        }

        private static void Submit(string methodName, string applicationName, TimeSpan elapsed)
        {
            using (var db = new MetricityContext())
            {
                db.Metrics.Add(new Data.Entities.Metric() { Duration = elapsed, ApplicationName = applicationName, MethodName = methodName });
                db.SaveChanges();
            }
        }

        
    }
}
