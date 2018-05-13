using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity.Classes
{
    public class CounterInfo
    {
        public string Name { get; set; }
        public string SubSetName { get; set; }

        public int Count { get; set; }

        public CounterInfo()
        {
            Count = 1;
        }
    }
}
