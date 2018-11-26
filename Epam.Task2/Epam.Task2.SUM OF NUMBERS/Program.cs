using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Если выписать все натуральные числа меньше 10, кратные 3 или 5,
 то получим 3, 5, 6 и 9. Сумма этих чисел будет равна 23. Напишите
 программу, которая выводит на экран сумму всех чисел меньше 1000, кратных 3 или 5.*/ 
namespace Epam.Task2.SUM_OF_NUMBERS
{
    class Program
    {
        public static int SumDivNum(int num)
        {
            int n = 999 / num;
            int an = n * num;
            return (num + an) * n / 2;
        }
        static void Main(string[] args)
        {
            
           
            Console.WriteLine($"The sum of the numbers divisible by 3 = {SumDivNum(3)}");
           
            Console.WriteLine($"The sum of the numbers divisible by 5 = {SumDivNum(5)}");
            Console.WriteLine($"The sum of the numbers divisible by 3 and 5 = {SumDivNum(3) + SumDivNum(5)- SumDivNum(15)}");
        }
    }
}
