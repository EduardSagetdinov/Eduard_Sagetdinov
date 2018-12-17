using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.I_SEEK_YOU
{
    public delegate int Finder(int[] i);

    public class Liambda
    {
        public static void LiamFind(int[] arr)
        {
            List<int> list = new List<int>();
            Action<int> finder = a =>
            {
                foreach (var item in arr)
                {
                    if (item > 0)
                    {
                        list.Add(a);
                    }
                }
            };
            list.Count();
        }
    }
}
