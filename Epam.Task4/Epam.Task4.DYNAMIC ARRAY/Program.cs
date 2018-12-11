using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.DYNAMIC_ARRAY
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DYNAMIC_ARRAY<int> da = new DYNAMIC_ARRAY<int>(10);
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

            Console.WriteLine();
            int n = 3;
            Console.Write($"At index # {n} we have {da.Indexator(3)} ");
            Console.WriteLine();
            Console.WriteLine($"The length of dynamic array is {da.Length()}");
            Console.WriteLine($"The capacity of dynamic array is {da.Capacity()}");
        }
    }
}
