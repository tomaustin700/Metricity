using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Metricity.Monitor.MonitorMethod(() =>
            {
                RunMethod();
            }, "RunMethod", "TestApp");

        }

        public static void RunMethod()
        {
            Thread.Sleep(1000);
        }

       
    }
}
