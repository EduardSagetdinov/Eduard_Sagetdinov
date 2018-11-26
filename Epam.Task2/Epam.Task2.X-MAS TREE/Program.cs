using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Написать программу, которая запрашивает с клавиатуры число N 
 и выводит на экран следующее «изображение», состоящее из N треугольников*/
namespace Epam.Task2.X_MAS_TREE
{
    class Program
    {
        public static void DrawLine(int n, int start, int stop)
        {

            for (int i = 1; i <= n; i++)
            {
                if ((i < start) || (i > stop))
                {
                    Console.Write(' ');
                }
                else
                {
                    Console.Write('*');
                }
            }
            Console.WriteLine();
        }

        public static void DrawTree(int n)
        {
            for (int i = 0; i < n / 2 + 1; i++)
            {
                for (int j = 0; j <= i; j++)
                    DrawLine(n, n / 2 + 1 - j, n / 2 + 1 + j);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter N: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0 || n % 2 == 0)
            {
                Console.WriteLine("Error! It must be odd positive number!");
            }
            else
            {
                DrawTree(n);
            }
        }
    }
}
