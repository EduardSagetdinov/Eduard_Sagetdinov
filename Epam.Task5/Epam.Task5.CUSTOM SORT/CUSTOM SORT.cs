using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.CUSTOM_SORT
{
    public static class CUSTOM_SORT
    {
       public static int Partition<T>(T[] m, int a, int b, Func<T, T, bool> comparator)
        {
            var i = a;
            for (int j = a; j <= b; j++)        
            {
                if (!comparator(m[j], m[b]))  
                {
                    T t = m[i];                
                    m[i] = m[j];                 
                    m[j] = t;                   
                    i++;                        
                }
            }
            
            return i - 1;                       
        }

        public static void Quicksort<T>(T[] m, int a, int b, Func<T, T, bool> comparator)
        {                                       
          if (a >= b)
            {
                return;
            }

            var c = Partition(m, a, b, comparator);
            Quicksort(m, a, c - 1, comparator);
            Quicksort(m, c + 1, b, comparator);
        }
    }
}
