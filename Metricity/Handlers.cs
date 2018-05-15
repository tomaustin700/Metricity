using Metricity.Data.DTOs;
using Metricity.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity
{
    public static class Handlers
    {
        public static void HandleException(Action action, List<Exception> exceptionsToCatch)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                if (exceptionsToCatch.Select(x => x.GetType()).Contains(ex.GetType()))
                {
                    using (var service = new HandledExceptionService())
                    {
                        service.Add(new HandledExceptionDTO() { ExceptionType = ex.GetType().ToString(), StackTrace = ex.InnerException != null ? ex.InnerException.StackTrace : null });
                    }
                }
                else
                    throw ex;
            }
        }

        public async static Task HandleException(Func<Task> action, List<Exception> exceptionsToCatch)
        {
            try
            {
                await action.Invoke();
            }
            catch (Exception ex)
            {
                if (exceptionsToCatch.Select(x => x.GetType()).Contains(ex.GetType()))
                {
                    using (var service = new HandledExceptionService())
                    {
                        service.Add(new HandledExceptionDTO() { ExceptionType = ex.GetType().ToString(), StackTrace = ex.InnerException.StackTrace });
                    }
                }
                else
                    throw ex;
            }
        }
    }
}
