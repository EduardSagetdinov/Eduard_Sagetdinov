using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.SEQUENCE
{
    public class Program
    {
        public static void ShowNumbers(int n)
        {
            for (int i = 1; i < n; i++)
            {
                Console.Write(i + ", ");
            }

            Console.WriteLine(n);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter some positive number: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Enter some positive number, please!!!");
            }
            else
            {
                ShowNumbers(n);
            }
        }
    }
}
