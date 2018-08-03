using Metricity.Data.DTOs;
using Metricity.Data.Interfaces;
using Metricity.Data.Repositories;
using MetricityAPIHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data.Services
{
    public class HandledExceptionService : IDisposable
    {
        private IHandledExceptionRepository _handledExceptionRepository;

        public HandledExceptionService()
        {
            _handledExceptionRepository = new HandledExceptionRepository(new MetricityContext());
        }

        public void Add(HandledExceptionDTO handledException)
        {
            if (string.IsNullOrEmpty(Setup.GetAPIKey()))
            {
                _handledExceptionRepository.Add(new Entities.HandledException() { ExceptionType = handledException.ExceptionType, Occurred = handledException.Occurred, StackTrace = handledException.StackTrace });
                _handledExceptionRepository.UnitOfWork.Commit();
            }
            else
            {
                using (var handledExceptionHelper = new ExceptionHelper(Guid.Parse(Setup.GetAPIKey())))
                {
                    handledExceptionHelper.Add(new Entities.HandledException() { ExceptionType = handledException.ExceptionType, Occurred = handledException.Occurred, StackTrace = handledException.StackTrace });
                }
            }

        }

        public void Dispose()
        {
            _handledExceptionRepository.Dispose();
        }




    }
}
