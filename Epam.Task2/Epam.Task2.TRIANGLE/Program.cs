using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Написать программу, которая запрашивает с клавиатуры число N и выводит на экран
 следующее «изображение», состоящее из N строк*/
namespace Epam.Task2.TRIANGLE
{
    class Program
    {
        public static void DrawLine(int n)
        {
            for(int i=1; i<=n; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
        }
        public static void DrawtTiangle(int n)
        {
            for(int i=1; i<=n; i++)
            {
                DrawLine(i);
            }
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter N: ");
            if(!int.TryParse(Console.ReadLine(), out int n)||n<=0)
            {
                Console.WriteLine("Error! It must be positive number!");
            }else
            {
                DrawtTiangle(n);
            }
        }
    }
}
