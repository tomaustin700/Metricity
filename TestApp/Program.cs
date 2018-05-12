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

            var usage1 = Diagnostics.GetMemoryUsage();

            var change = Diagnostics.GetMemoryChange(() =>
            {
                RunSync();

            });

            var usage2 = Diagnostics.GetMemoryUsage();

            

        }

        public async static Task RunMethod()
        {
            Thread.Sleep(1000);
        }

        public static void RunSync()
        {
            var test = new int[100000000];

        }


    }
}
