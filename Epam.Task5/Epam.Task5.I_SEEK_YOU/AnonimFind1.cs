using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.I_SEEK_YOU
{
    public class AnonimFind1
    {
        public delegate void Searcher(int[] r);

        public static void AnFind(int[] arr)
        {
            List<int> list = new List<int>();
            Searcher finder = delegate(int[] a)
            {
                foreach (var item in a)
                {
                    if (item > 0)
                    {
                        list.Add(item);
                    }
                }
            };

            finder(arr);
        }
    }
}
