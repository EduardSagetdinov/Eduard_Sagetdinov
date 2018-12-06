using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.SUM_OF_NUMBERS
{
    public class Program
    {
        public static int SumDivNum(int num)
        {
            int n = 999 / num;
            int an = n * num;
            return (num + an) * n / 2;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine($"The sum of the numbers divisible by 3 = {SumDivNum(3)}");
            Console.WriteLine($"The sum of the numbers divisible by 5 = {SumDivNum(5)}");
            Console.WriteLine($"The sum of the numbers divisible by 3 and 5 = {SumDivNum(3) + SumDivNum(5)- SumDivNum(15)}");
        }
    }
}
