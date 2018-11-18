using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Число считается простым, если его можно разделить без остатка только на единицу
 и на само себя (например, 7). Необходимо написать функцию, определяющую, является ли 
 заданное число N (положительное целое) простым. Значение N передаётся в функцию в качестве аргумента. */
namespace Epam.Task1.SIMPLE
{
    class Program
    {
        static bool IsPrime(int n)
        {
            if (n <= 2)
                return false;
            for(int i=2; i<=Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter some positive number: ");
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Enter some positive number, please!!!");
                return;
            }
            if(IsPrime(n))
            {
                Console.WriteLine("Your number is prime!");
            }else
            {
                Console.WriteLine("Your number is not prime!");
            }
        }
    }
}
