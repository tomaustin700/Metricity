# Metricity
Metric and diagnostic utilities for .Net 

![Build](https://img.shields.io/travis/tomaustin700/Metricity.svg) ![Last Commit](https://img.shields.io/github/last-commit/tomaustin700/metricity.svg) ![Licence](https://img.shields.io/github/license/tomaustin700/Metricity.svg)
# Installation
![Nuget version](https://img.shields.io/nuget/v/Metricity.svg)  ![Nuget downloads](https://img.shields.io/nuget/dt/Metricity.svg)
Available on [Nuget](https://www.nuget.org/packages/Binance.Net/).
```
pm> Install-Package Metricity
```
#  Getting Started
Coming Soon...

# Usage

```c#
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
ar memoryChangeASync = Metricity.Diagnostics.GetMemoryChange(async () =>
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
```