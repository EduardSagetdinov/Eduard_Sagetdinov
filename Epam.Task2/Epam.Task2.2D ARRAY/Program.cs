using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Элемент двумерного массива считается стоящим на чётной позиции, 
 если сумма номеров его позиций по обеим размерностям является
 чётным числом (например, [1,1] — чётная позиция, а [1,2] — нет).  
 Определить сумму элементов массива, стоящих на чётных позициях. */
namespace Epam.Task2._2D_ARRAY
{
    class Program
    {
        public static  void InsArrSum(int i, int j)
        {
            int[,] arr = new int[i,j];
            int sum = 0;
            Random rand = new Random();
            Console.WriteLine("Your array is: ");
            for(int a=0; a<i; a++)
                for(int b=0; b<j; b++)
            {
                arr[a,b] = rand.Next(-1000, 1000);
                Console.WriteLine($"arr[{a}][{b}]={arr[a,b]}");
                    if ((a + b) % 2 == 0)
                        sum += arr[a,b];
            }

            Console.WriteLine($"The amount of even elements is: {sum}");
        }
       
        static void Main(string[] args)
        {
            Console.Write("Input the two sizes of array throw enter key: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Input some positive number, please!");
            }
            else
             if (!int.TryParse(Console.ReadLine(), out int m) || m <= 0)
            {
                Console.WriteLine("Input some positive number, please!");
            }
            else
            {
                InsArrSum(n, m);
            }
        }
    }
}
