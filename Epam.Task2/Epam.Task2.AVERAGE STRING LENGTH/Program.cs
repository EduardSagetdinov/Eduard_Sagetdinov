using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.AVERAGE_STRING_LENGTH
{
   public class Program
    {
        public static void StringLength(string a)
        {
            int length = 0;
            int count = 0;
            a = a.Trim();
            char[] seps = { ' ', '.', ',' };
            string[] words = a.Split(seps, StringSplitOptions.RemoveEmptyEntries);
            for (count = 0; count < words.Length; count++)
            {
                Console.WriteLine($"The lengtn of {words[count]} is {words[count].Length}");
                length += words[count].Length;
            }

            Console.WriteLine($"The average length is {length/words.Length}");
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the string:");
            string s = Console.ReadLine();
            StringLength(s);
        }
    }
}
