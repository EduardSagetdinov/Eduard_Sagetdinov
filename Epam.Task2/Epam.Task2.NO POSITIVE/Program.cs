using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.NO_POSITIVE
{
    public class Program
    {
        public static void InsArr(int i, int j, int k)
        {
            Random rand = new Random();
            int[,,] arr = new int[i, j, k];
            for (int a = 0; a < i; a++)
            {
                for (int b = 0; b < j; b++)
                {
                    for (int c = 0; c < k; c++)
                    {
                        arr[a, b, c] = rand.Next(-1000, 1000);
                    }
                }
            }

            Console.WriteLine("Your array: ");
            foreach (int d in arr)
            {
                Console.WriteLine(d);
            }
                
            Console.ReadKey();
            for (int d = 0; d < i; d++)
            {
                for (int e = 0; e < j; e++)
                {
                    for (int f = 0; f < k; f++)
                    {
                        if (arr[d, e, f] > 0)
                        {
                            arr[d, e, f] = 0;
                        }
                    }
                }
            }

            Console.WriteLine("Your array after replacement: ");

            foreach (int g in arr)
            {
                Console.WriteLine(g);
            }
        }

        public static void Main(string[] args)
        {
            Console.Write("Input the first dimension of array: ");
            if (!int.TryParse(Console.ReadLine(), out int i))
            {
                Console.WriteLine("Wrong dimension!");
            }
            else
            {
                Console.Write("Input the second dimension of array: ");
                if (!int.TryParse(Console.ReadLine(), out int j))
                {
                    Console.WriteLine("Wrong dimension!");
                }
                else
                {
                Console.Write("Input the fird dimension of array: ");
                if (!int.TryParse(Console.ReadLine(), out int k))
                {
                    Console.WriteLine("Wrong dimension!");
                    }
                    else
                    {
                        InsArr(i, j, k);
                    }
                }
            }
        }
    }
}
