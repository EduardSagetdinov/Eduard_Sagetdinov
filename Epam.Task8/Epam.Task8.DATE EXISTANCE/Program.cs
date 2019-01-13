using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.DATE_EXISTANCE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter your data in format as dd-mm-yyyy: ");
            var someData = Console.ReadLine();
            string pattern = @"^(0[1-9]|[12][0-9]|3[01])[-.](0[1-9]|1[012])[-.](19|20)\d{2}$";
            if (Regex.IsMatch(someData, pattern))
            {
                Console.WriteLine($"In text \"{someData}\" contains some date!");
            }
            else
            {
                Console.WriteLine($"In text \"{someData}\" doesn't contain some date!");
            }
        }
    }
}
