using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task3.VECTOR_GRAPHICS_EDITOR;

namespace Epam.Task3.VECTOR_GRAPHICS_EDITOR
{
    public class Circle
    {
        public Circle(string x0, string y0, string l)
        {
            this.A = new Round(x0, y0, l);
        }

        private Round A { get; set; }

        public void Draw()
        {
            Console.WriteLine("Drawing circle...");
            Console.WriteLine($"The center of your round is ({A.X1}, {A.Y1})");
            Console.WriteLine($"The radius is {A.L}");
            Console.WriteLine($"The circumference is {A.Length()}");
        }
    }
}
