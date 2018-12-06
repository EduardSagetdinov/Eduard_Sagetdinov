using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.TRIANGLE
{
    public class Program
    {
        public static void DrawLine(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.Write('*');
            }

            Console.WriteLine();
        }

        public static void DrawtTiangle(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                DrawLine(i);
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter N: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Error! It must be positive number!");
            }
            else
            {
                DrawtTiangle(n);
            }
        }
    }
}
