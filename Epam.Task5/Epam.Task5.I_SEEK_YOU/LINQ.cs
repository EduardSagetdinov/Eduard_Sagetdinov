using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.I_SEEK_YOU
{
    public class LINQ
    {
        public static void AnFind(int[] arr)
        {
            var found = from n in arr where n > 0 select n;
            found.Count();
        }
    }
}
