using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity
{
    public static class Diagnostics
    {
        /// <summary>
        /// Gets the current memory working set value of the running process
        /// </summary>
        /// <returns></returns>
        public static float GetCurrentMemoryUsage()
        {
            PerformanceCounter memory = new PerformanceCounter("Process", "Working Set", Process.GetCurrentProcess().ProcessName);
            return memory.NextValue();
        }

        /// <summary>
        /// Gets the current cpu usage sum accross each core e.g. if 400 is returned on a 4 core processor each core is running at 100%
        /// </summary>
        /// <returns></returns>
        public static float GetCurrentCPUUsage()
        {
            PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total"); 
            return cpu.NextValue();
        }

    }
}
