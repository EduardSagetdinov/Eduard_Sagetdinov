using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task5.SORTING_UNIT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr1 = { 45, 23, 44, 99, 0, 78, 1, 12, 56, 44, 5 };
            string[] arr2 = { "a", "aaaa", "v", "qq", "dddddddd", "tt" };
            
            try
            {
                Console.WriteLine("Thread one: ");
                Sort.SortInThread<int>(arr1, Comparers.CompareNum);
                Thread.Sleep(3000);
                Console.WriteLine("Thread two: ");
                Sort.SortInThread<string>(arr2, Comparers.CompareString);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
         }
    }
}
