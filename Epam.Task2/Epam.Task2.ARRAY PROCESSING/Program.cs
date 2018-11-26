using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Написать программу, которая генерирует случайным образом элементы массива 
 * (число элементов в массиве и их тип определяются разработчиком), 
 * определяет для него максимальное и минимальное значения, сортирует массив и 
 * выводит полученный результат на экран. 
 * Примечание: LINQ запросы и готовые функции языка (Sort, Max и т.д.) 
 * использовать в данном задании запрещается. */
namespace Epam.Task2.ARRAY_PROCESSING
{
    class Program
    {
       
        public static void SortArr(int[] a)
        {
           
           
           for(int i=0; i<a.Length;i++)
                for(int j=i+1; j<a.Length;j++)
                    if (a[i] > a[j])
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
            Console.WriteLine($"The max value is: {a[a.Length - 1]}");
            Console.WriteLine($"The min value is: {a[0]}");
            Console.WriteLine("After sorting: ");
            foreach (int p in a)
            {
                Console.WriteLine($"{p}");
            }

        }
        
        static void Main(string[] args)
        {
            Console.Write("Input the size of array: ");
            if(!int.TryParse(Console.ReadLine(), out int n)||n<=0)
            {
                Console.WriteLine("Input some positive number, please!");
            }else
            {
                int[] arr = new int[n];
                Random rand = new Random();
                for (int i=0; i<arr.Length;i++)
                {
                    arr[i] = rand.Next(0, 1000);
                }
                Console.WriteLine("Before sorting: ");
                foreach (int i in arr)
                {
                    Console.WriteLine($"{i}");
                }
                SortArr(arr);
            }
        }
    }
}
