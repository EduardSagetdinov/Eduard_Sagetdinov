using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.SIMPLE
{
    public class Program
    {
        public static bool IsPrime(int n)
        {
            if (n <= 2)
            {
                return false;
            }
                
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter some positive number: ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Enter some positive number, please!!!");
                return;
            }

            if (IsPrime(n))
            {
                Console.WriteLine("Your number is prime!");
            }
            else
            {
                Console.WriteLine("Your number is not prime!");
            }
        }
    }
}
