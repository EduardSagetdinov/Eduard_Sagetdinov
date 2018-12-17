using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.TRIANGLE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string x;
            string y;
            string z;
            Console.Write("Enter A: ");
            x = Console.ReadLine();
            Console.Write("Enter B: ");
            y = Console.ReadLine();
            Console.Write("Enter C: ");
            z = Console.ReadLine();
            Triangle t;
            try
            {
                t = new Triangle(x, y, z);
                Console.WriteLine($"A = {t.A} B = {t.B} C = {t.C}");
                Console.WriteLine($"S = {t.Square(t.A, t.B, t.C)}");
                Console.WriteLine($"P = {t.Perimeter(t.A, t.B, t.C)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
            }
        }
    }
}
