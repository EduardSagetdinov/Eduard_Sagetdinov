using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUMBER_ARRAY_SUM
{
    public static class Program
    {
        public static double GetSumm<T>(this T[] arr) where T : struct
        {
            double sum = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                sum += Convert.ToDouble(arr[i]);
            }

            return sum;
        }

        public static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            Console.WriteLine(arr.GetSumm());
            float[] arr1 = { 0, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            Console.WriteLine(arr1.GetSumm());
        }
    }
}
