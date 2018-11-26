using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Написать программу, которая определяет сумму неотрицательных элементов в одномерном массиве. 
 * Число элементов в массиве и их тип определяются разработчиком. */
namespace Epam.Task2.NON_NEGATIVE_SUM
{
    class Program
    {
        public static int[] InsArr(int i)
        {
            int[] arr = new int[i];
            Random rand = new Random();
            Console.WriteLine("Your array is: ");
            for(int a=0; a<arr.Length;a++)
            {
                arr[a] = rand.Next(-1000, 1000);
                Console.WriteLine($"{arr[a]}");
            }
            return arr;

        }
        public static void Sum(int[] mass)
        {
            int sum = 0;
            foreach (int i in mass)
                if (i > 0)
                    sum += i;
            Console.WriteLine($"The sum of non-negative elements is: {sum}");

        }
        static void Main(string[] args)
        {
            Console.Write("Input the size of array: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Input some positive number, please!");
            }
            else
            {
                Sum(InsArr(n));
            }
        }
    }
}
