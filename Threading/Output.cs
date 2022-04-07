using System;
using System.Collections.Generic;
using System.Text;

namespace Threading
{
    class Output
    {
        internal static void WriteLine(string value, Importance importance)
        {
            var defaultColor = Console.ForegroundColor;
            if (importance == Importance.High)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(value);
            Console.ForegroundColor = defaultColor;
        }
    }
}
