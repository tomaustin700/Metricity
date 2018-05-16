using Metricity.Data.DTOs;
using Metricity.Data.Interfaces;
using Metricity.Data.Repositories;
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
            _handledExceptionRepository.Add(new Entities.HandledException() { ExceptionType = handledException.ExceptionType, Occurred = handledException.Occurred, StackTrace = handledException.StackTrace });
            _handledExceptionRepository.UnitOfWork.Commit();

        }

        public void Dispose()
        {
            _handledExceptionRepository.Dispose();
        }




    }
}
