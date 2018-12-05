using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VECTOR_GRAPHICS_EDITOR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello! What do you want to draw? ");
            Console.WriteLine("1 - Segment.");
            Console.WriteLine("2 - Round.");
            Console.WriteLine("3 - Circle.");
            Console.WriteLine("4 - Ring.");
            Console.WriteLine("5 - Rectangle.");
            string s = Console.ReadLine();
            string x;
            string y;
            string r1;
            string r2;
            switch (s)
            {
                case "1":
                    Console.Write("Enter X: ");
                    x = Console.ReadLine();
                    Console.Write("Enter Y: ");
                    y = Console.ReadLine();
                    Console.Write("Enter L: ");
                    r1 = Console.ReadLine();
                    try
                    {
                        Segment seg = new Segment(x, y, r1);
                        seg.Draw();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                case "2":
                    Console.Write("Enter X: ");
                    x = Console.ReadLine();
                    Console.Write("Enter Y: ");
                    y = Console.ReadLine();
                    Console.Write("Enter R: ");
                    r1 = Console.ReadLine();
                    try
                    {
                        Round r = new Round(x, y, r1);
                        r.Draw();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                case "3":
                    Console.Write("Enter X: ");
                    x = Console.ReadLine();
                    Console.Write("Enter Y: ");
                    y = Console.ReadLine();
                    Console.Write("Enter R: ");
                    r1 = Console.ReadLine();
                    try
                    {
                        Circle c = new Circle(x, y, r1);
                        c.Draw();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                case "4":
                    Console.Write("Enter X: ");
                    x = Console.ReadLine();
                    Console.Write("Enter Y: ");
                    y = Console.ReadLine();
                    Console.Write("Enter inner R: ");
                    r1 = Console.ReadLine();
                    Console.Write("Enter outer R: ");
                    r2 = Console.ReadLine();
                    try
                    {
                        Ring ri = new Ring(x, y, r1, r2);
                        ri.Draw();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                case "5":
                    Console.Write("Enter X: ");
                    x = Console.ReadLine();
                    Console.Write("Enter Y: ");
                    y = Console.ReadLine();
                    Console.Write("Enter AB: ");
                    r1 = Console.ReadLine();
                    Console.Write("Enter BC: ");
                    r2 = Console.ReadLine();
                    try
                    {
                        Rectangle rect = new Rectangle(x, y, r1, r2);
                        rect.Draw();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                default:
                    Console.WriteLine("Sorry, but I don't know such figure.");
                    break;
            }
        }
    }
}
