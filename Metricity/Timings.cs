using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricity
{
    public static class Timings
    {

        public static TimeSpan Time(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action.Invoke();
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        public static async Task<TimeSpan> Time(Func<Task> action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await action.Invoke();
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}
