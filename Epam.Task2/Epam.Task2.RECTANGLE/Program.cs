using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.RECTANGLE
{/*Написать программу, которая определяет площадь прямоугольника со сторонами a и b. 
    Если пользователь вводит некорректные значения (отрицательные или ноль), 
    должно выдаваться сообщение об ошибке. Возможность ввода пользователем 
    строки вида «абвгд» или нецелых чисел игнорировать.*/
    class Program
    {
        public static bool Testing(string s, out int x)
        {
            
            if (!int.TryParse(s, out x)||x<=0)
            {
                Console.WriteLine("Error! It must be positive number!");
                return false;
            }
            return true;
        }
        public static void RectSquare(int a, int b)
        {
            
            Console.WriteLine($"Side a= {a}, side b= {b}");
            Console.WriteLine($"S={a*b}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two sides of rectangle. It must be positive numbers!");
            Console.WriteLine("Enter the first side, press enter, enter the second side, press enter.");

            
            if (Testing(Console.ReadLine(), out int a)&&Testing(Console.ReadLine(), out int b))
            {
                RectSquare(a, b);
            }
        }
    }
}
