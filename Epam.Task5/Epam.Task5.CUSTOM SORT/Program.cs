using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.CUSTOM_SORT
{
    public static class Program
    {
        public static void Show<T>(T[] arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                int[] arr1 = { 45, 23, 44, 99, 0, 78, 1, 12, 56, 44, 5 };
                string[] arr2 = { "a", "aaaa", "v", "qq", "dddddddd", "tt" };
                Console.WriteLine("Before sorting: ");
                Show<int>(arr1);
                Console.WriteLine();
                CUSTOM_SORT.Sorting<int>(arr1, Compares.CompareNum);
                Console.WriteLine("After sorting: ");
                Show<int>(arr1);
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Before sorting: ");
                Show<string>(arr2);
                Console.WriteLine();
                CUSTOM_SORT.Sorting<string>(arr2, Compares.CompareString);
                Console.WriteLine("After sorting: ");
                Show<string>(arr2);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.ParamName);
            }
        }
    }
}
