using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.ROUND
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string x;
            string y;
            string r;
            Console.Write("Enter X: ");
            x = Console.ReadLine();
            Console.Write("Enter Y: ");
            y = Console.ReadLine();
            Console.Write("Enter Radius: ");
            r = Console.ReadLine();
            Round round;
            try
                {
                round = new Round(x, y, r);
                Console.WriteLine("The parameters of your round:");
                Console.WriteLine($"X = {round.X}  Y = {round.Y} Radius = {round.R}");
                Console.WriteLine($"The circumference = {round.Circumference(round.R)}");
                Console.WriteLine($"The area of your square = {round.Area(round.R)}");
                }
            catch (Exception e)
                {
                Console.WriteLine(e.Message);
            }
        }
    }
}
