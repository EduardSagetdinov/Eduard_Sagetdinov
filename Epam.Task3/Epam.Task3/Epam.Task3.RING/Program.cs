using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.RING
{
    class Program
    {
        static void Main(string[] args)
        {
            Ring r;
            string x;
            string y;
            string r1;
            string r2;
            try
            {
                Console.Write("Input X: ");
                x=Console.ReadLine();
                Console.Write("Input Y: ");
                y = Console.ReadLine();
                Console.Write("Input R1(inner radius): ");
                r1 = Console.ReadLine();
                Console.Write("Input R2(outer radius): ");
                r2 = Console.ReadLine();
                r = new Ring(x, y, r1, r2);
                Console.Write("The sum of inner circumference and outer circumference is: ");
                Console.WriteLine(r.CircRing(r.R, r.R2));
                Console.WriteLine($"The square of ring is: {r.CircSquare(r.R, r.R2)}");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
