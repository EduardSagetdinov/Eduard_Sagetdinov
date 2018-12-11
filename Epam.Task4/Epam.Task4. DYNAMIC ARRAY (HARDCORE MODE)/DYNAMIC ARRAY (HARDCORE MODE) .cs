using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Epam.Task4.DYNAMIC_ARRAY;

namespace Epam.Task4.DYNAMIC_ARRAY__HARDCORE_MODE_
{
    public class DYNAMIC_ARRAY__HARDCORE_MODE<T> : DYNAMIC_ARRAY<T>, ICloneable
    {
        public DYNAMIC_ARRAY__HARDCORE_MODE(int n) : base(n)
        {
        }

        public DYNAMIC_ARRAY__HARDCORE_MODE() : base()
        {
        }

        public DYNAMIC_ARRAY__HARDCORE_MODE(IEnumerable<T> coll) : base(coll)
        {
        }

        public void SetCapacity(int n)
        {
            T[] arr1;
            if (n > this.Capacity())
            {
                arr1 = this.Arr;
                int a = this.Capacity();
                this.Arr = new T[n];
                Array.ConstrainedCopy(arr1, 0, this.Arr, 0, a);
            }

            if (n < this.Capacity())
            {
                arr1 = this.Arr;
                this.Arr = new T[n];
                Array.ConstrainedCopy(arr1, 0, this.Arr, 0, n);
            }
        }

        public T[] ToArray()
        {
            T[] a = new T[this.Capacity()];
            for (int i = 0; i < this.Capacity(); i++)
            {
                a[i] = this.Arr[i];
            }

            return a;
        }

        public new T Indexator(int index)
        {
            if (index >= this.Length())
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (index >= 0)
            {
                return this.Arr[index];
            }
            else
            {
                return this.Arr[this.WhereEmpty() + index + 1];
            }
        }

        public object Clone()
        {
            DYNAMIC_ARRAY__HARDCORE_MODE<T> darr = new DYNAMIC_ARRAY__HARDCORE_MODE<T>(Capacity());
            return darr;
        }
    }
}
