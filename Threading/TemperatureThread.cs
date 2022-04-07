using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threading
{
    class TemperatureThread
    {
        private static Random rnd = new Random();
        private const int MaxNumberOfWarnings = 3;        
        internal static void Run()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            var thread = new Thread(() => {
                DoTemperatureWork(cts);      
                //DoTemperatureWork();
            });            
            thread.Start();
            var start = DateTime.Now;
            while (true)
            {
                if (DateTime.Now.Subtract(start).TotalSeconds >= 30)
                {
                    cts.Cancel();
                }
            }
        }

        //private static void DoTemperatureWork()
        private static void DoTemperatureWork(object obj)
        {
            CancellationTokenSource ct = (CancellationTokenSource)obj;
            var warnings = new ConcurrentBag<int>();
            var start = DateTime.Now;
            while (true)
            {                
                var temp = rnd.Next(-20, 121);
                var importance = temp < 0 || temp > 100 ? Importance.High : Importance.Normal;
                if (importance == Importance.High)
                {
                    warnings.Add(temp);
                    Output.WriteLine($"The current temperature is outside the acceptable range", importance);
                    // if (warnings.Count >= MaxNumberOfWarnings)
                    // {
                    //     Output.WriteLine($"The current temperature has been outside the acceptable range {warnings.Count} times - execution stops", importance);
                    //     break;
                    // }
                    if (ct.IsCancellationRequested)
                    {
                        Output.WriteLine($"The execution stopped after {DateTime.Now.Subtract(start).TotalSeconds} seconds", Importance.High);
                        break;
                    }
                }
                Output.WriteLine($"The current temperature is: {temp}° C", importance);
                Thread.Sleep(2000);
            }
        }
    }
}
