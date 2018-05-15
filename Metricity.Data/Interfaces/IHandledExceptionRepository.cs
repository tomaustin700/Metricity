using Metricity.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data.Interfaces
{
    public interface IHandledExceptionRepository : IDisposable
    {
        void Add(HandledExceptionDTO handledException);
    }
}
