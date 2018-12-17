using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task5.SORTING_UNIT
{
    public delegate void OnHandler();

    public class Sort
    {
        public static event OnHandler HandlerEvent;

        public static void Show<T>(T[] arr, string text)
        {
            Console.WriteLine(text);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        public static void Sorting<T>(T[] sortArr, Func<T, T, bool> comparator)
        {
            if (comparator == null)
            {
                throw new ArgumentNullException(nameof(comparator));
            }

            bool flag = true;
            do
            {
                flag = false;
                for (int i = 0; i < sortArr.Length - 1; i++)
                {
                    if (comparator(sortArr[i + 1], sortArr[i]))
                    {
                        var temp = sortArr[i];
                        sortArr[i] = sortArr[i + 1];
                        sortArr[i + 1] = temp;
                        flag = true;
                    }
                }
            }
            while (flag);
        }

        public static void Signal()
        {
            Console.WriteLine("Sorted!");
        }

        public static void SortInThread<T>(T[] sortArr, Func<T, T, bool> comparator)
        {
            HandlerEvent = null;
            Show<T>(sortArr, "Before sorting: ");
            Thread thr = new Thread(() => 
            {
                Sorting(sortArr, comparator);
                HandlerEvent += Signal;
                Show<T>(sortArr, "After sorting: ");
                HandlerEvent?.Invoke();
            });
           
            thr.Start();
        }
    }
}
