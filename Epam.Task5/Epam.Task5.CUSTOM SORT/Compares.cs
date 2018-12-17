using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.CUSTOM_SORT
{
    public static class Compares
    {
        public static bool CompareNum(int a, int b)
        {
            if (a > b)
            {
                return true;
            }

            return false;
        }

        public static bool CompareString(string a, string b)
        {
            return a.Length > b.Length;
        }
    }
}
