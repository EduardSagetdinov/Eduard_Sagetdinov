using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Написать функцию, формирующую и возвращающую строку вида 1, 2, 3, … N (положительное число). 
 * Значение N передаётся в функцию в качестве аргумента. Пример возвращаемого значения для N=7: 1, 2, 3, 4, 5, 6, 7 */
namespace Epam.Task1.SEQUENCE
{
    class Program
    {
        public  static void ShowNumbers(int n)
        {
            for(int i=1; i<n; i++)
            {
                Console.Write(i+", ");
            }
            Console.WriteLine(n);
        }
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter some positive number: ");
            if((!int.TryParse(Console.ReadLine(), out n))||(n<=0))
            {
                Console.WriteLine("Enter some positive number, please!!!");
            }else
            {
                ShowNumbers(n);
            }
         
           
        }
    }
}
