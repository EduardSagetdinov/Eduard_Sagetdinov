using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.CUSTOM_SORT
{
    public static class CUSTOM_SORT
    {
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
    }
}
