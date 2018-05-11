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
            Metricity.Monitor.MonitorSync(async () =>
            {
                await RunMethod();
                await RunMethod();
                await RunMethod();
                await RunMethod();
                await RunMethod();
            }, "Main", "TestApp");

        }

        public async static Task RunMethod()
        {
            Thread.Sleep(1000);
        }


    }
}
