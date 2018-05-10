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
        public static void MonitorMethod(Expression<Action> action, string applicationName)
        {
            var methodCallExp = (MethodCallExpression)action.Body;
            string methodName = methodCallExp.Method.Name;
            Action method = action.Compile();

            RunMethod(method, methodName, applicationName);
        }

        public static async Task MonitorMethod(Expression<Func<Task<Action>>> action, string applicationName)
        {
            var methodCallExp = (MethodCallExpression)action.Body;
            string methodName = methodCallExp.Method.Name;
            Func<Task<Action>> method = action.Compile();

            await RunMethod(method, methodName, applicationName);
        }

        private static void RunMethod(Action action, string methodName, string applicationName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action.Invoke();
            stopwatch.Stop();
            Submit(methodName, applicationName, stopwatch.Elapsed);
        }

        private async static Task RunMethod(Func<Task<Action>> action, string methodName, string applicationName)
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
