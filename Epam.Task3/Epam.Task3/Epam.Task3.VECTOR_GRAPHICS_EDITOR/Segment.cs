using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VECTOR_GRAPHICS_EDITOR
{
    public class Segment : Figure
    {
        public Segment(string x0, string y0, string l)
            {
            Test(x0);
            Test(y0);
            TestLength(l);
            
            X1 = float.Parse(x0);
            Y1 = float.Parse(y0);
            L = float.Parse(l);
        }
       
        public override double Length()
        {
            return 0;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing segment...");
            Console.WriteLine($"From ({X1}, {Y1}) with length {L}.");
        }

        public override double Square()
        {
            return 0;
        }
    }
}
