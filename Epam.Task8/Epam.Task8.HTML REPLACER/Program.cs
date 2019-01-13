using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task8.HTML_REPLACER
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter some tags please: ");
            var someData = Console.ReadLine();
            string pattern = @"<(?'tag'\w+?).*>" +
                @"(?'text'.*?)" +
                @"</\k'tag'>";

            Console.WriteLine(Regex.Replace(someData, pattern, @"_${text}_"));
        }
    }
}
