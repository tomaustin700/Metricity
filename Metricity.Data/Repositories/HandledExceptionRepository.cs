using Metricity.Data.DTOs;
using Metricity.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data.Repositories
{
    internal class HandledExceptionRepository : RepositoryBase, IHandledExceptionRepository
    {
        internal HandledExceptionRepository(MetricityContext context)
        {
            _context = context;
        }

        public void Add(HandledExceptionDTO handledException)
        {
            _context.HandledExceptions.Add(new Entities.HandledException() { ExceptionType = handledException.ExceptionType, StackTrace = handledException.StackTrace, Occurred = handledException.Occurred });
            Save();
        }
    }
}
