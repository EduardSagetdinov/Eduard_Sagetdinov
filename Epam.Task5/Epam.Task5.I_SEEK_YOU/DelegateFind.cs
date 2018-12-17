using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.I_SEEK_YOU
{
    public class DelegateFind
    {
        public static void DelegFind(int[] arr, Func<int, bool> howFind)
        {
            List<int> list = new List<int>();
            Array.Sort(arr);
            if (howFind == null)
            {
                throw new ArgumentNullException(nameof(howFind));
            }

            foreach (var item in arr)
            {
                if (howFind(item))
                {
                    list.Add(item);
                }
            }
        }

        public static bool Compare(int b)
        {
            return b > 0;
        }
    }
}
