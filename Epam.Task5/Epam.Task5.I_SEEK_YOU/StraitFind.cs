using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.I_SEEK_YOU
{
    public class StraitFind
    {
        public static void StFind(int[] arr)
        {
            List<int> list = new List<int>();
            Array.Sort(arr);
            foreach (var item in arr)
            {
                if (item > 0)
                {
                    list.Add(item);
                }
            }
        }
    }
}
