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
        static async void Main(string[] args)
        {
            //Metricity.Monitor.MonitorMethod(async() => await RunMethod(), "TestApp");

        }

        public async static Task RunMethod()
        {
            Thread.Sleep(1000);
        }


    }
}
