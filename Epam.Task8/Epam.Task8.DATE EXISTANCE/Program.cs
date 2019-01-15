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
            string pattern = @"^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|
                                ((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|
                                ((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|
                                (29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|
                                ((16|[2468][048]|[3579][26])00))))$";
            if (Regex.IsMatch(someData, pattern, RegexOptions.IgnorePatternWhitespace))
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
