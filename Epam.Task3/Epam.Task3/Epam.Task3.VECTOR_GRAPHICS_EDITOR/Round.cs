using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VECTOR_GRAPHICS_EDITOR
{
    public class Round : Figure
    {
        public Round(string x0, string y0, string l)
        {
            Test(x0);
            Test(y0);
            TestLength(l);

            X1 = float.Parse(x0);
            Y1 = float.Parse(y0);
            L = float.Parse(l);
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing round...");
            Console.WriteLine($"The center of your round is ({X1}, {Y1})");
            Console.WriteLine($"The radius is {L}");
            Console.WriteLine($"The square of your round is {Square()}");
            Console.WriteLine($"The circumference is {Length()}");
        }

        public override double Square()
        {
            return 2 * Math.PI * L * L;
        }

        public override double Length()
        {
            return 2 * Math.PI * L;
        }
    }
}
