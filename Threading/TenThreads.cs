using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threading
{
    class TenThreads
    {
        internal static void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(() => GenerateNumbers());
                thread.Name = "Thread " + i;
                thread.Start();
            }
        }

        internal static void GenerateNumbers()
        {
            var rnd = new Random();
            var numberList = new List<int>();   
            for (int i = 0; i < 100; i++)
            {
                int number = rnd.Next(1, 1001);
                numberList.Add(number);
            }
            Console.WriteLine($"The current thread: {Thread.CurrentThread.Name} - numbercount: {numberList.Count} - numbers: {NumberListAsString(numberList)} - average: {numberList.Average()}");
        }

        private static string NumberListAsString(List<int> numberList)
        {
            return string.Join(",", numberList.Select(n => n.ToString()));
        }
    }
}
