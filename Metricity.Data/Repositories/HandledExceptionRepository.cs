using Metricity.Data.DTOs;
using Metricity.Data.Entities;
using Metricity.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data.Repositories
{
    internal class HandledExceptionRepository : Repository<HandledException, int>, IHandledExceptionRepository
    {
        internal HandledExceptionRepository(MetricityContext unitOfWork) : base(unitOfWork)
        {

        }
        
    }
}
