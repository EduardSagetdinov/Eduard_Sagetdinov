using System;

namespace Epam.Task5.CUSTOM_SORT_DEMO
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
            string[] arr = { "bbbb", "aaaa", "cccc", "eeee", "ffff", "gggg", "hhhh", "dddd", "v", "a", "b" };
            Console.WriteLine("Before sorting: ");
            Show<string>(arr);
            Console.WriteLine();
            Console.WriteLine("After sorting: ");
            try
            {
                Sort.Sorting<string>(arr, ComparesString.CompareString);
                Show<string>(arr);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
