using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Metricity.Data.DTOs;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            RunExamples();
        }

        static async void RunExamples()
        {

            //Returns time taken for execution of synchronous code
            var syncTime = Metricity.Timings.Time(() =>
            {
                SyncMethod();
            });

            //Returns time taken for execution of asynchronous code
            var asyncTime = Metricity.Timings.Time(async () =>
            {
                await ASyncMethod();
            });

            //Returns current memory usage of application
            var memoryUsage = Metricity.Diagnostics.GetMemoryUsage();

            //Returns current cpu usage of application
            var cpuUsage = Metricity.Diagnostics.GetCPUUsage();

            //Returns difference in memory usage from before synchronous code execution and after
            var memoryChangeSync = Metricity.Diagnostics.GetMemoryChange(() =>
            {
                SyncMethod();
            });

            //Returns difference in memory usage from before asynchronous code execution and after
            var memoryChangeASync = Metricity.Diagnostics.GetMemoryChange(async () =>
            {
                await ASyncMethod();
            });

            //Logs time taken for execution of synchronous code to database
            Metricity.RemoteLog.Log(() =>
            {
                SyncMethod();
            });

            //Logs time taken for execution of asynchronous code to database
            await Metricity.RemoteLog.Log(async () =>
            {
                await ASyncMethod();
            });

            //Logs time taken for execution of synchronous code to cache, cache is then commited to database when CommitCache is called
            Metricity.RemoteLog.CacheLog(() =>
            {
                SyncMethod();
            });

            //Logs time taken for execution of synchronous code to cache, cache is then commited to database when CommitCache is called
            await Metricity.RemoteLog.CacheLog(async () =>
            {
                await ASyncMethod();
            });

            //Clears all metrics from the cache
            Metricity.RemoteLog.ClearCache();

            //Returns the current cache
            var cache = Metricity.RemoteLog.GetCache();

            //Commits cache to database
            Metricity.RemoteLog.CommitCache();

            //Increments the counter by one
            Metricity.Counters.Increment("counter");

            //Decrements the counter by one
            Metricity.Counters.Decrement("counter");

            //Returns the count of the specified counter
            Metricity.Counters.GetCurrentCount("counter");

            //Resets the specified counter
            Metricity.Counters.ClearCounter("counter");

            //Resets all counters
            Metricity.Counters.PurgeCounters();

            //Gets the percentage splits of subset counters
            var splits = Metricity.Counters.GetSubsetSplit("counter");

            //Handles exceptions of the type that are passed in and writes an entry into HandledExceptions Table 
            Metricity.Handlers.HandleException(() =>
            {
                ThrowException(new InvalidOperationException());

            }, new List<Exception>() { new InvalidOperationException() }, true);

            //Handled exceptions for async methods
            await Metricity.Handlers.HandleExceptionAsync(async () =>
            {
                await ThrowAsyncException(new InvalidOperationException());

            }, new List<Exception>() { new InvalidOperationException() }, true);
        }

        static void SyncMethod()
        {
            Thread.Sleep(1000);
        }

        static async Task ASyncMethod()
        {
            await Task.Run(() => Thread.Sleep(1000));
        }

        static void ThrowException(Exception ex)
        {
            throw ex;
        }

        static async Task ThrowAsyncException(Exception ex)
        {
            await ASyncMethod();
            ThrowException(ex);
        }


    }
}
