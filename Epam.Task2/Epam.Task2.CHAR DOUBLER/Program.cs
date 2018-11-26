using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Написать программу, которая удваивает в первой введённой строке все символы, 
 принадлежащие второй введённой строке. */
namespace Epam.Task2.CHAR_DOUBLER
{
    class Program
    {
        public static void Duplication(char[]a, char[]b)
        {
            StringBuilder s3=new StringBuilder();
            int count = 0;
            for(int i=0; i<a.Length;i++)
            {
                s3.Append(a[i]);
                for (int j = 0; j < b.Length;j++ )
                {
                    
                    if (a[i]==b[j])
                    {
                        count++;
                    }
                    
                        
                }
                if (count > 0)
                {
                    s3.Append(a[i]);
                    count = 0;
                }
                
            }
            Console.WriteLine($"The new string is {s3}");
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the first string:");
            char[] c1 = Console.ReadLine().ToCharArray();
            Console.WriteLine("Enter the second string:");
            char[] c2 = Console.ReadLine().ToCharArray();
            Duplication(c1, c2);
        }
    }
}
