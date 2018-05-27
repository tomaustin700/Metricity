using Metricity.Data.DTOs;
using Metricity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data.Interfaces
{
    internal interface IHandledExceptionRepository : IRepository<HandledException, int>
    {
    }
}
