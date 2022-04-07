using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threading
{
    class MainAndThread
    {
        internal static void Run()
        {
            var thread = new Thread(() => 
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Thread 1");
                    Thread.Sleep(100);
                }
            });
            thread.Start();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Main thread");
                Thread.Sleep(100);
            }
        }
    }
}
