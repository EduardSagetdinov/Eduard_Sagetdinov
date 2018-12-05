using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VECTOR_GRAPHICS_EDITOR
{
    public abstract class Figure
    {
        public float X1 { get; set; }

        public float Y1 { get; set; }

        public float L { get; set; }

        public abstract void Draw();

        public abstract double Length();

        public abstract double Square();

        public void Test(string s)
        {
            if (!float.TryParse(s, out float a))
            {
                throw new Exception("Wrong data format!");
            }
        }

        public void TestLength(string s)
        {
            if (!float.TryParse(s, out float a) || (a <= 0))
            {
                throw new Exception("Wrong data format!");
            }
        }
    }
}
