using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.DYNAMIC_ARRAY__HARDCORE_MODE_
{
    public class Program
    {
        private static readonly int[] Test = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public static void Main(string[] args)
        {
             DYNAMIC_ARRAY__HARDCORE_MODE<int> da = new DYNAMIC_ARRAY__HARDCORE_MODE<int>(Test);
             Console.WriteLine("Lets add some numbers: ");
             da.Add(1);
             da.Add(1);
             da.Add(1);
             da.Add(1);
             da.Add(1);
             da.Add(1);
             da.Add(1);
             da.Add(1);
             da.Add(1);
             da.Add(1);
             da.Add(1);
             da.Add(1);
             foreach (var item in da)
             {
                 Console.Write(item + "\t");
             }

             Console.WriteLine();
             Console.WriteLine("Lets add collection: ");
             List<int> l = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
             da.AddRange(l);
             foreach (var item in da)
             {
                 Console.Write(item + "\t");
             }

             Console.WriteLine();
             Console.WriteLine("After removing 9: ");
             da.Remove(9);
             foreach (var item in da)
             {
                 Console.Write(item + "\t");
             }

             Console.WriteLine();

             da.Insert(11111, 25);
             da.Insert(77777, 18);

             Console.WriteLine("After inserting some numbers: ");
             foreach (var item in da)
             {
                 Console.Write(item + "\t");
             }

             int n = 3;
             Console.WriteLine();
             Console.Write($"At index # {n} we have {da.Indexator(3)} ");
             Console.WriteLine();
             Console.WriteLine();
             n = -12;
            Console.WriteLine($"At index # {n} we have {da.Indexator(n)}");
            Console.WriteLine("The new cloned array is: ");
            DYNAMIC_ARRAY__HARDCORE_MODE<int> darr = (DYNAMIC_ARRAY__HARDCORE_MODE<int>)da.Clone();
            foreach (var item in darr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("To array: ");
            int[] toArr = da.ToArray();
            foreach (var item in toArr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Cicle array:");
            CycledDynamicArray<int> cda = new CycledDynamicArray<int>(l);
            foreach (var item in cda.Cicled(l))
            {
                Console.WriteLine(item);
            }
        }
    }
}
