using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Написать программу, которая определяет среднюю длину слова во введённой текстовой строке. 
 * Учесть, что символы пунктуации на длину слов влиять не должны. 
 * Регулярные выражения не использовать. И не пытайтесь прописать все символы-разделители ручками. 
 * Используйте стандартные методы классов String и Char. */

namespace Epam.Task2.AVERAGE_STRING_LENGTH
{
    class Program
    {
        public static void StringLength(string a)
        {
            int length = 0;
            int count = 0;
            a = a.Trim();
           char[] seps = {' ','.',','};
            string[] words = a.Split(seps, StringSplitOptions.RemoveEmptyEntries);
            for(count=0; count < words.Length; count++)
            {
                Console.WriteLine($"The lengtn of {words[count]} is {words[count].Length}");
                length += words[count].Length;
            }
            Console.WriteLine($"The average length is {length/words.Length}");


        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the string:");
            string s = Console.ReadLine();
            StringLength(s);

        }
    }
}
