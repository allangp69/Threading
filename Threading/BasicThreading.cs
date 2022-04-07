using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threading
{
    class BasicThreading
    {
        internal static void Run()
        {
            var thread1 = new Thread(() => {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("C# trådning er let!");                    
                    Thread.Sleep(1000);
                }
            });
            var thread2 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("også med flere tråde...");
                    Thread.Sleep(1000);
                }
            });
            thread1.Start();
            thread2.Start();
        }
    }
}
