using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VECTOR_GRAPHICS_EDITOR
{
    public class Ring
    {
        public Ring(string x0, string y0, string lA, string lB)
        {
            this.A = new Round(x0, y0, lA);
            this.B = new Round(x0, y0, lB);
            if (this.A.L >= this.B.L)
            {
                throw new Exception("Wrong data!");
            }
        }

        private Round A { get; set; }

        private Round B { get; set; }

        public void Draw()
        {
            Console.WriteLine("Drawing ring...");
            Console.WriteLine($"The center of your ring is ({A.X1}, {A.Y1})");
            Console.WriteLine($"The inner radius is {A.L}");
            Console.WriteLine($"The outer radius is {B.L}");
            Console.WriteLine($"The inner circumference is {A.Length()}");
            Console.WriteLine($"The outer circumference is {B.Length()}");
            Console.WriteLine($"The square of your ring is {Square()}");
        }

        public double Square()
        {
            return this.B.Square() - this.A.Square();
        }
    }
}
