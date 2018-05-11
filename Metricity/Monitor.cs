using Metricity.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Metricity
{
    public static class Monitor
    {
        public static void MonitorSync(Action action, string metricName, string applicationName)
        {
            RunMethod(action, metricName, applicationName);
        }

        public static async Task MonitorAsync(Func<Task> action, string metricName, string applicationName)
        {
            await RunMethod(action, metricName, applicationName);
        }

        private static void RunMethod(Action action, string metricName, string applicationName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action.Invoke();
            stopwatch.Stop();
            Submit(metricName, applicationName, stopwatch.Elapsed);
        }

        private async static Task RunMethod(Func<Task> action, string metricName, string applicationName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await action();
            stopwatch.Stop();
            Submit(metricName, applicationName, stopwatch.Elapsed);
        }



        private static void Submit(string metricName, string applicationName, TimeSpan elapsed)
        {
            using (var db = new MetricityContext())
            {
                db.Metrics.Add(new Data.Entities.Metric() { Duration = elapsed, ApplicationName = applicationName, MetricName = metricName });
                db.SaveChanges();
            }
        }


    }
}
