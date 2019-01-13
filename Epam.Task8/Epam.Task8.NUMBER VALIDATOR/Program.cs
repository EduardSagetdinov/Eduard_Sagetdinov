using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.NUMBER_VALIDATOR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter some string of numbers, please:");
            var numString = " " + Console.ReadLine() + " ";
             var normalNotation = @"\s[\-\+]?[0-9]+([\.\,]([0-9]+))?\s";
             var scientificNotation = @"\s[\+\-]?[0-9]+[\.\,]?[0-9]+?[\+\-]?([e][\+\-]?[0-9]+)\s";
             var otherNotation = @"\s\w+\s";
            switch (numString)
            {
                case var someNotation when new Regex(normalNotation).IsMatch(numString):
                    Console.WriteLine("This is normal notation");
                    break;
                case var someNotation when new Regex(scientificNotation).IsMatch(numString):
                    Console.WriteLine("This is scientific notation");
                    break;
                case var someNotation when new Regex(otherNotation).IsMatch(numString):
                    Console.WriteLine("This is not number(other) notation");
                    break;
                default:
                    break;
            }
        }
    }
}
