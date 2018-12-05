using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.MY_STRING
{
    public class MyString
    {
        public MyString(char[] a)
        {
            this.Arr = new char[a.Length];
            this.Arr = a;
        }

        public MyString(char s, int count)
        {
            this.Arr = new char[count];
            for (int i = 0; i < count; i++)
            {
                this.Arr[i] = s;
            }
        }

        public MyString(string s, int count = 16)
        {
            if (s.Length < count)
            {
                this.Arr = new char[count];
            }
            else
            {
                count *= 2;
                this.Arr = new char[count];
            }
           
            this.Arr = s.ToCharArray();
        }

        public char[] Arr { get; set; }

        public MyString Sub(int index)
        {
            if (index >= this.Arr.Length)
            {
                throw new Exception("Your index is out of range!");
            }

            char[] ch = new char[this.Arr.Length - index];
            for (int i = 0; i < this.Arr.Length - index; i++)
            {
                ch[i] = this.Arr[index + i];
            }

            return new MyString(ch);
        }

        public char[] Conc(char[] s1)
        {
            char[] ret = new char[this.Arr.Length];
            ret = this.Arr;
            this.Arr = new char[s1.Length + ret.Length];
            for (int i = 0; i < ret.Length; i++)
            {
                this.Arr[i] = ret[i];
            }

            for (int i = 0; i < s1.Length; i++)
            {
                this.Arr[ret.Length + i] = s1[i];
            }
            
            return this.Arr;
        }

        public int Comp(string s)
        {
            char[] com = s.ToCharArray();
            if (this.Arr.Length > com.Length)
            {
               return 1;
            }
            else if (this.Arr.Length < com.Length)
            {
              return -1;
            }
            else
            {
                int c = 0;
                for (int i = 0; i < this.Arr.Length; i++)
                {
                    c = this.Arr[i].CompareTo(com[i]);
                }

                return c;
            }
        }

        public void FindSymbol(char s)
        {
            int count = 0;
            for (int i = 0; i < this.Arr.Length; i++)
            {
                if (this.Arr[i] == s)
                {
                    ++count;
                    Console.WriteLine($"{s} found at the {i} index");
                }
            }

            if (count == 0)
            {
                Console.WriteLine("The is no such simbol.");
            }
        }

        public char[] ConvToCharArr()
        {
            char[] a = new char[this.Arr.Length];
            for (int i = 0; i < this.Arr.Length; i++)
            {
                a[i] = this.Arr[i];
            }

            return a;
        }

        public char[] Reverse()
        {
            char[] prom = new char[this.Arr.Length];
            for (int i = 0; i < this.Arr.Length; i++)
            {
                prom[i] = this.Arr[this.Arr.Length - 1 - i];
            }

            return prom;
        }

        public void ToMyString()
        {
            Console.Write("{ ");
            foreach (var item in this.Arr)
            {
                Console.Write(item);
            }

            Console.WriteLine(" } ");
        }
    }
}
