using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task8.EMAIL_FINDER
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter email or not email adress: ");
            string email = Console.ReadLine() + " ";
            string pattern = @"\s?\b([A-Za-z0-9]+([-_\.A-Za-z0-9]+)?" +
                @"@(([A-Za-z0-9]+[-]?)\.{1})+" +
                @"([a-zA-Z]{2,6}))(\,|\s)";
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matchCollection = reg.Matches(email);
            Console.WriteLine("Email adresses: ");
            foreach (var item in matchCollection)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
