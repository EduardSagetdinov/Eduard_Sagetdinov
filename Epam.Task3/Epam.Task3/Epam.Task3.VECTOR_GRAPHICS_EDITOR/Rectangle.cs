using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VECTOR_GRAPHICS_EDITOR
{
    public class Rectangle
    {
        public Rectangle(string x0, string y0, string l1, string l2)
        {
            this.A = new Segment(x0, y0, l1);
            this.B = new Segment(x0, y0, l2);
        }

        private Segment A { get; set; }

        private Segment B { get; set; }

        public double Square()
        {
            return this.A.L * this.B.L;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing a rectangle from point ({A.X1}; {A.Y1})");
            Console.WriteLine($"Side AB is {A.L}");
            Console.WriteLine($"Side BC is {B.L}");
            Console.WriteLine($"The square of your round is {Square()}");
            Console.WriteLine($"The perimeter is {Length()}");
        }

        public double Length()
        {
            return (this.A.L + this.B.L) * 2;
        }
    }
}
