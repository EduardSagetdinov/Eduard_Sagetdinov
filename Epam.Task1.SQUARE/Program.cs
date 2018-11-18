using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Написать функцию, выводящую на экран квадрат из звёздочек со стороной равной 
 N (положительное нечётное целое число). Центральная звёздочка должна отсутствовать.
 Значение N передаётся в функцию в качестве аргумента. */
namespace Epam.Task1.SQUARE
{
    class Program
    {
        static void DrawSquare(int n)
        {
            int half=n/2+1;
            String s;
            for(int i=1; i<=n; i++)
            {
                if(i!=half)
                {
                    s = new String('*',n);
                    Console.WriteLine(s);
                }else
                {
                    s = new String('*', (half - 1));
                    Console.Write(s);
                    Console.Write(" ");
                    Console.WriteLine(s);
                }
            }

        }
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter the size of the square side. It must be the odd integer more than one: ");
            if ((!int.TryParse(Console.ReadLine(), out n)) || (n%2==0)||(n<=1))
            {
                Console.WriteLine("It must be the odd integer more than one!!!");
            }else
            {
                DrawSquare(n);
            }
            
        }
    }
}
