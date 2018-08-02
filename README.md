# Metricity ![Licence](https://img.shields.io/github/license/tomaustin700/Metricity.svg)
Metric and diagnostic utilities for .Net 


| Repository        | Build Status           |Last Commit          |
| ------------- |:-------------:|:-------------:|
| Metricity      | ![Build](https://img.shields.io/travis/tomaustin700/Metricity.svg) | ![Last Commit](https://img.shields.io/github/last-commit/tomaustin700/metricity.svg)|
| Metricity.Data.Classes |![Build](https://img.shields.io/travis/tomaustin700/Metricity.Data.Classes.svg)| ![Last Commit](https://img.shields.io/github/last-commit/tomaustin700/metricity.data.classes.svg)|

# Installation
![Nuget version](https://img.shields.io/nuget/v/Metricity.svg)  ![Nuget downloads](https://img.shields.io/nuget/dt/Metricity.svg)
Available on [Nuget](https://www.nuget.org/packages/Metricity/).
```
pm> Install-Package Metricity
```
#  Getting Started
In order to use any of the remote logging features you must have a sql database and run InitDatabase.sql on it in order for the correct tables to be generated. You also need to place your sql connection string in a text file named Connection.txt in
C:\Users\YOURUSERNAME\AppData\Roaming\Metricity, if this file is missing and any of the remote logging features are used an exception will be thrown instructing you to create the file.

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
    
}, new List<Exception>() { new InvalidOperationException() });
```
