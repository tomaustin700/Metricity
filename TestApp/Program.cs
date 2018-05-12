using Metricity;
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
            Metricity.RemoteLog.Log(async () =>
            {
                await RunMethod();
                await RunMethod();
                await RunMethod();
                await RunMethod();
                await RunMethod();
            }, "Main", "TestApp");

            RemoteLog.Log(() =>
            {
                RunSync();

            }, "Test", "Test");

        }

        public async static Task RunMethod()
        {
            Thread.Sleep(1000);
        }

        public static void RunSync()
        {
            Thread.Sleep(1000);

        }


    }
}
