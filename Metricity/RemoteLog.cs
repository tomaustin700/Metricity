using Metricity.Data;
using Metricity.Data.DTOs;
using Metricity.Data.Entities;
using Metricity.Data.Repositories;
using Metricity.Data.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Metricity
{
    public static class RemoteLog
    {
        private static List<MetricDTO> _cachedMetrics = new List<MetricDTO>();
        public static void Log(Action action, string metricName = null, string applicationName = null)
        {
            if (string.IsNullOrEmpty(metricName))
                metricName = GenerateGuid(action.Method.Name);

            RunMethod(action, metricName, applicationName, false);
        }

        public static string GetActionGuid(Action action)
        {
            return GenerateGuid(action.Method.Name);
        }

        public static string GetActionGuid(Func<Task> action)
        {
            return GenerateGuid(action.Method.Name);
        }

        public static void CacheLog(Action action, string metricName = null, string applicationName = null)
        {
            if (string.IsNullOrEmpty(metricName))
                metricName = GenerateGuid(action.Method.Name);

            RunMethod(action, metricName, applicationName, true);
        }

        public static async Task Log(Func<Task> action, string metricName = null, string applicationName = null)
        {
            if (string.IsNullOrEmpty(metricName))
                metricName = GenerateGuid(action.Method.Name);

            await RunMethod(action, metricName, applicationName, false);
        }

        public static async Task CacheLog(Func<Task> action, string metricName = null, string applicationName = null)
        {
            if (string.IsNullOrEmpty(metricName))
                metricName = GenerateGuid(action.Method.Name);

            await RunMethod(action, metricName, applicationName, true);
        }

        private static string GenerateGuid(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(input));
                return new Guid(hash).ToString();
            }
        }

        private static void RunMethod(Action action, string metricName, string applicationName, bool cache)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action.Invoke();
            stopwatch.Stop();
            Submit(metricName, applicationName, stopwatch.Elapsed, cache);
        }

        private async static Task RunMethod(Func<Task> action, string metricName, string applicationName, bool cache)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await action();
            stopwatch.Stop();
            Submit(metricName, applicationName, stopwatch.Elapsed, cache);
        }

        public static void CommitCache()
        {
            if (!_cachedMetrics.Any())
                throw new InvalidOperationException("No cached metrics to commit");

            using (var service = new MetricService())
            {
                service.AddRange(_cachedMetrics);
            }
        }

        public static void ClearCache()
        {
            _cachedMetrics = new List<MetricDTO>();
        }

        public static List<MetricDTO> GetCache()
        {
            return _cachedMetrics.Select(x => new MetricDTO() { ApplicationName = x.ApplicationName, Duration = x.Duration, MetricName = x.MetricName }).ToList();
        }

        private static void Submit(string metricName, string applicationName, TimeSpan elapsed, bool cache)
        {
            if (!cache)
            {
                using (var service = new MetricService())
                {
                    service.Add(new MetricDTO { Duration = elapsed, ApplicationName = applicationName, MetricName = metricName });
                }
            }
            else
            {
                _cachedMetrics.Add(new MetricDTO { Duration = elapsed, ApplicationName = applicationName, MetricName = metricName });
            }
        }


    }
}
