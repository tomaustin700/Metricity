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
            _handledExceptionRepository.Add(handledException);
        }

      

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _handledExceptionRepository.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
