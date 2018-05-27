using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Data.DTOs
{
    public class HandledExceptionDTO
    {
        public string StackTrace { get; set; }
        public string ExceptionType { get; set; }
        public DateTime Occurred { get; set; }

        public HandledExceptionDTO()
        {
            Occurred = DateTime.Now;
        }
    }
}
