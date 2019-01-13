using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task8.TIME_COUNTER
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pattern = @"(0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]";
            Console.WriteLine("Enter some string with some time: ");
            var stringWithTime = " " + Console.ReadLine() + " ";
            Console.WriteLine($"I have found time in your text for {Regex.Matches(stringWithTime, pattern).Count} times");
        }
    }
}
