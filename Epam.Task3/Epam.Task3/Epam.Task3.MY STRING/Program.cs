using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.MY_STRING
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter something: ");
            MyString first = new MyString(Console.ReadLine());
            Console.Write("Your string ");
            first.ToMyString();
            char[] a = { 'a', 'b', 'c' };
            Console.WriteLine("Initializing by char array { 'a', 'b', 'c' }");
            MyString second = new MyString(a);
            Console.Write("Your string ");
            second.ToMyString();
            Console.WriteLine("Repeat symbol 'q' by 35 times");
            MyString third = new MyString('q', 35);
            Console.Write("Your string ");
            third.ToMyString();
            MyString fourth = new MyString("asdfgqwertyuiop", 20);
            Console.WriteLine("Substring from the fourth index of string till end: ");
            try
            {
                Console.Write("Full string :");
                fourth.ToMyString();
                Console.Write("After: ");
                fourth.Sub(4).ToMyString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            char[] c = { 'a', 'b', 'c' };
            char[] b = { 'd', 'e', 'f' };
            MyString sixth = new MyString(c);
            Console.Write("Your string before concating: ");
            sixth.ToMyString();
            sixth.Conc(b);
            Console.Write("Your string after concating:");
            sixth.ToMyString();
            Console.WriteLine("Comparing two strings:");
            Console.Write("The first string: ");
            sixth.ToMyString();
            Console.Write("Enter the second string: ");
            string s = Console.ReadLine();
            if (sixth.Comp(s) > 0)
            {
                Console.WriteLine("Bigger");
            }
            else if (sixth.Comp(s) < 0)
            {
                Console.WriteLine("Less");
            }
            else
            {
                Console.WriteLine("Equally");
            }

            Console.Write("Enter the equally symbol: ");
            char f = (char)Console.Read();
            sixth.FindSymbol(f);
            Console.Write("Converted to char array: ");
            Console.WriteLine(sixth.ConvToCharArr());
            Console.Write("After reverse: ");
            Console.WriteLine(sixth.Reverse());
        }
    }
}
