using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Task4.DYNAMIC_ARRAY
{
    public class DYNAMIC_ARRAY<T>
    {
        public DYNAMIC_ARRAY(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.Arr = new T[n];
        }

        public DYNAMIC_ARRAY() : this(8)
        {
        }

        public DYNAMIC_ARRAY(IEnumerable<T> coll)
        {
            this.Arr = new T[coll.Count()];
            this.Arr = coll.ToArray();
        }

        public T[] Arr { get; set; }

        public void Add(T e)
        {
            if (this.WhereEmpty() != this.Capacity())
            {
                this.Arr[this.WhereEmpty()] = e;
            }
            else
            {
                T[] arr1 = this.Arr;
                int l = this.Capacity() * 2;
                this.Arr = new T[l];
                arr1.CopyTo(this.Arr, 0);
                this.Arr[this.WhereEmpty()] = e;
            }
        }

        public void AddRange(IEnumerable<T> coll)
        {
            int stop = this.WhereEmpty();
            int freeSpace = this.Arr.Length - stop - 1;
            if (freeSpace >= coll.Count())
            {
                coll.ToArray().CopyTo(this.Arr, stop);
            }
            else
            {
                T[] arr1;
                arr1 = this.Arr;
                int newLength = this.Arr.Length + coll.Count();
                this.Arr = new T[newLength];
                arr1.CopyTo(this.Arr, 0);
                coll.ToArray().CopyTo(this.Arr, stop);
            }
        }

        public bool Remove(T el)
        {
            int ind = Array.IndexOf(this.Arr, el);
            if (ind != -1)
            {
                this.Arr[ind] = default(T);
                return true;
            }

            return false;
        }

        public bool Insert(T el, int index)
        {
            if (index >= this.Capacity() || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            T[] arr1 = this.Arr;
            int l = this.Capacity() - index;
            if (this.Arr[index].Equals(default(T)))
            {
                this.Arr[index] = el;
            }
            else if (this.Length() == this.Capacity())
            {
                this.Arr = new T[this.Length() + 1];
                for (int i = 0; i < index; i++)
                {
                    this.Arr[i] = arr1[i];
                }

                this.Arr[index] = el;
                for (int i = index; i < l; i++)
                {
                    this.Arr[i + 1] = arr1[i];
                }
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    this.Arr[i] = arr1[i];
                }

                this.Arr[index] = el;
                for (int i = index; i < l; i++)
                {
                    this.Arr[i + 1] = arr1[i];
                }
            }
           
            if (this.Arr[index].Equals(el))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Length()
        {
            return this.WhereEmpty();
        }

        public int Capacity()
        {
            return this.Arr.Length;
        }

        public int WhereEmpty()
        {
            int count = 0;
            for (int i = 0; i < this.Capacity(); i++)
            {
                if (!this.Arr[i].Equals(default(T)))
                {
                    ++count;
                }
            }

            return count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DAEnumerator<T>(this.Arr);
        }
        
        public virtual T Indexator(int index)
        {
            if (index < 0 || index >= this.Length() || this.Arr[index].Equals(default(T)))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return this.Arr[index];
            }
        }
    }
}
