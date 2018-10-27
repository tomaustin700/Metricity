using Metricity.Data.DTOs;
using Metricity.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metricity
{
    public static class Handlers
    {
        private static List<HandledExceptionDTO> _cachedHandledExceptions = new List<HandledExceptionDTO>();


        /// <summary>
        /// Handles the specified exception(s)
        /// </summary>
        /// <param name="action"></param>
        /// <param name="exceptionsToCatch"></param>
        public static void HandleException(Action action, List<Exception> exceptionsToCatch)
        {
            HandleException(action, exceptionsToCatch, false);
        }

        /// <summary>
        /// Handles the specified exception(s) and writes an entry into the database/Metricity Portal
        /// </summary>
        /// <param name="action"></param>
        /// <param name="exceptionsToCatch"></param>
        /// <param name="addToDatabase"></param>
        public static void HandleException(Action action, List<Exception> exceptionsToCatch, bool addToDatabase)
        {
            HandleException(action, exceptionsToCatch, addToDatabase, null);
        }

        /// <summary>
        /// Handles the specified exception(s) and writes an entry into the cache
        /// </summary>
        /// <param name="action"></param>
        /// <param name="exceptionsToCatch"></param>
        /// <param name="addToDatabase"></param>
        public static void CacheHandleException(Action action, List<Exception> exceptionsToCatch)
        {
            HandleException(action, exceptionsToCatch, true, null, true);
        }

        /// <summary>
        ///  Handles the specified exception(s) and writes an entry into the database/Metricity Portal, will run the passed in method when handling
        /// </summary>
        /// <param name="action"></param>
        /// <param name="exceptionsToCatch"></param>
        /// <param name="addToDatabase"></param>
        /// <param name="handleMethodToRun"></param>
        public static void HandleException(Action action, List<Exception> exceptionsToCatch, bool addToDatabase, Action handleMethodToRun)
        {
            HandleException(action, exceptionsToCatch, addToDatabase, handleMethodToRun, false);
        }

        /// <summary>
        ///  Handles the specified exception(s) and writes an entry into the cache, will run the passed in method when handling
        /// </summary>
        /// <param name="action"></param>
        /// <param name="exceptionsToCatch"></param>
        /// <param name="addToDatabase"></param>
        /// <param name="handleMethodToRun"></param>
        public static void CacheHandleException(Action action, List<Exception> exceptionsToCatch, Action handleMethodToRun)
        {
            HandleException(action, exceptionsToCatch, true, handleMethodToRun, true);
        }


        private static void HandleException(Action action, List<Exception> exceptionsToCatch, bool addToDatabase, Action handleMethodToRun, bool cache)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                if (exceptionsToCatch.Select(x => x.GetType()).Contains(ex.GetType()))
                {
                    if (handleMethodToRun != null)
                        handleMethodToRun.Invoke();

                    if (addToDatabase)
                    {
                        if (cache)
                        {
                            _cachedHandledExceptions.Add(new HandledExceptionDTO() { ExceptionType = ex.GetType().ToString(), StackTrace = ex.InnerException != null ? ex.InnerException.StackTrace : null });

                        }
                        else
                            using (var service = new HandledExceptionService())
                            {
                                service.Add(new HandledExceptionDTO() { ExceptionType = ex.GetType().ToString(), StackTrace = ex.InnerException != null ? ex.InnerException.StackTrace : null });
                            }
                    }

                }
                else
                    throw ex;
            }
        }

        /// <summary>
        /// Handles the specified exception(s)
        /// </summary>
        /// <param name="action"></param>
        /// <param name="exceptionsToCatch"></param>
        /// <returns></returns>
        public async static Task HandleExceptionAsync(Func<Task> action, List<Exception> exceptionsToCatch)
        {
            await HandleExceptionAsync(action, exceptionsToCatch, false, null, null);
        }

        /// <summary>
        /// Handles the specified exception(s) and writes an entry into the database/Metricity Portal
        /// </summary>
        /// <param name="action"></param>
        /// <param name="exceptionsToCatch"></param>
        /// <param name="addToDatabase"></param>
        /// <returns></returns>
        public async static Task HandleExceptionAsync(Func<Task> action, List<Exception> exceptionsToCatch, bool addToDatabase)
        {
            await HandleExceptionAsync(action, exceptionsToCatch, addToDatabase, null, null);
        }

        /// <summary>
        /// Handles the specified exception(s) and writes an entry into the cache
        /// </summary>
        /// <param name="action"></param>
        /// <param name="exceptionsToCatch"></param>
        /// <param name="addToDatabase"></param>
        /// <returns></returns>
        public async static Task CacheHandleExceptionAsync(Func<Task> action, List<Exception> exceptionsToCatch)
        {
            await HandleExceptionAsync(action, exceptionsToCatch, true, null, null, true);
        }

        /// <summary>
        /// Handles the specified exception(s) and writes an entry into the database/Metricity Portal, will run the passed in method when handling synchronously
        /// </summary>
        /// <param name="action"></param>
        /// <param name="exceptionsToCatch"></param>
        /// <param name="addToDatabase"></param>
        /// <returns></returns>
        public async static Task HandleExceptionAsync(Func<Task> action, List<Exception> exceptionsToCatch, bool addToDatabase, Action handleMethodToRunSync)
        {
            await HandleExceptionAsync(action, exceptionsToCatch, addToDatabase, handleMethodToRunSync, null);
        }

        /// <summary>
        /// Handles the specified exception(s) and writes an entry into the cache, will run the passed in method when handling synchronously
        /// </summary>
        /// <param name="action"></param>
        /// <param name="exceptionsToCatch"></param>
        /// <param name="addToDatabase"></param>
        /// <returns></returns>
        public async static Task CacheHandleExceptionAsync(Func<Task> action, List<Exception> exceptionsToCatch, Action handleMethodToRunSync)
        {
            await HandleExceptionAsync(action, exceptionsToCatch, true, handleMethodToRunSync, null, true);
        }

        /// <summary>
        /// Handles the specified exception(s) and writes an entry into the database/Metricity Portal, will run the passed in methods when handling
        /// </summary>
        /// <param name="action"></param>
        /// <param name="exceptionsToCatch"></param>
        /// <param name="addToDatabase"></param>
        /// <returns></returns>
        public async static Task HandleExceptionAsync(Func<Task> action, List<Exception> exceptionsToCatch, bool addToDatabase,
            Action handleMethodToRunSync, Func<Task> handleMethodToRunAsync)
        {
            await HandleExceptionAsync(action, exceptionsToCatch, addToDatabase, handleMethodToRunSync, handleMethodToRunAsync, false);
        }

        /// <summary>
        /// Handles the specified exception(s) and writes an entry into the cache, will run the passed in methods when handling
        /// </summary>
        /// <param name="action"></param>
        /// <param name="exceptionsToCatch"></param>
        /// <param name="addToDatabase"></param>
        /// <returns></returns>
        public async static Task CacheHandleExceptionAsync(Func<Task> action, List<Exception> exceptionsToCatch,
            Action handleMethodToRunSync, Func<Task> handleMethodToRunAsync)
        {
            await HandleExceptionAsync(action, exceptionsToCatch, true, handleMethodToRunSync, handleMethodToRunAsync, true);
        }

        private async static Task HandleExceptionAsync(Func<Task> action, List<Exception> exceptionsToCatch, bool addToDatabase,
            Action handleMethodToRunSync, Func<Task> handleMethodToRunAsync, bool cache)
        {
            try
            {
                await action.Invoke();
            }
            catch (Exception ex)
            {
                if (exceptionsToCatch.Select(x => x.GetType()).Contains(ex.GetType()))
                {
                    if (handleMethodToRunSync != null)
                        handleMethodToRunSync.Invoke();

                    if (handleMethodToRunAsync != null)
                        await handleMethodToRunAsync();

                    if (addToDatabase)
                    {
                        if (cache)
                        {
                            _cachedHandledExceptions.Add(new HandledExceptionDTO() { ExceptionType = ex.GetType().ToString(), StackTrace = ex.InnerException.StackTrace });

                        }
                        else
                            using (var service = new HandledExceptionService())
                            {
                                service.Add(new HandledExceptionDTO() { ExceptionType = ex.GetType().ToString(), StackTrace = ex.InnerException.StackTrace });
                            }
                    }
                }
                else
                    throw ex;
            }
        }

        public static void CommitCache()
        {
            if (!_cachedHandledExceptions.Any())
                throw new InvalidOperationException("No cached exceptions to commit");

            using (var service = new HandledExceptionService())
            {
                service.AddRange(_cachedHandledExceptions);
            }
        }

        public static void ClearCache()
        {
            _cachedHandledExceptions = new List<HandledExceptionDTO>();
        }

        public static List<HandledExceptionDTO> GetCache()
        {
            return _cachedHandledExceptions.Select(x => new HandledExceptionDTO() { ExceptionType = x.ExceptionType, Occurred = x.Occurred, StackTrace = x.StackTrace }).ToList();
        }
    }
}
