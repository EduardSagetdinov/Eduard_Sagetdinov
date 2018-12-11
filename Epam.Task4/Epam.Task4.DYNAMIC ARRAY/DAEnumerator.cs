using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.DYNAMIC_ARRAY
{
    public class DAEnumerator<T> : IEnumerator<T>
    {
        private T[] a;
        private int position = -1;

        public DAEnumerator(T[] b)
            {
            this.a = b;
            }

        public T Current
        {
            get
            {
                if (this.position == -1 || this.position >= this.a.Length)
                {
                    throw new InvalidOperationException();
                }
                    
                return this.a[this.position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (this.position < this.a.Length - 1)
            {
                this.position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            this.position = -1;
        }

        public void Dispose()
        {
        }
    }
}
