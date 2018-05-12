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
        public static double GetMemoryUsage()
        {
            PerformanceCounter memory = new PerformanceCounter("Process", "Working Set", Process.GetCurrentProcess().ProcessName);
            return ConvertBytesToMegabytes(Convert.ToInt32(memory.NextValue()));
        }

        /// <summary>
        /// Gets the memory difference from before the action was performed and then after
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static double GetMemoryChange(Action action)
        {
            var start = GetMemoryUsage();
            action.Invoke();
            var end = GetMemoryUsage();
            var difference = end - start;
            return ConvertBytesToMegabytes(Convert.ToInt32(difference));
        }

        /// <summary>
        /// Gets the memory difference from before the action was performed and then after
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static async Task<double> GetMemoryChange(Func<Task> action)
        {
            var start = GetMemoryUsage();
            await action.Invoke();
            var end = GetMemoryUsage();
            var difference = end - start;
            return ConvertBytesToMegabytes(Convert.ToInt32(difference));
        }

        private static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        /// <summary>
        /// Gets the current cpu usage sum accross each core e.g. if 400 is returned on a 4 core processor each core is running at 100%
        /// </summary>
        /// <returns></returns>
        public static float GetCPUUsage()
        {
            PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            return cpu.NextValue();
        }

    }
}
