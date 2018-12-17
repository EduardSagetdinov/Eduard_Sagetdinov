using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.TRIANGLE
{
    public class Triangle
    {
        public Triangle(string a, string b, string c)
        {
            this.Test(a, out float x);
            this.A = x;
            this.Test(b, out float y);
            this.B = y;
            this.Test(c, out float z);
            this.C = z;
            if (!this.IsTriangle(this.A, this.B, this.C))
            {
                throw new Exception("This is not triangle!!!");
            }
        }

        public float A { get; set; }

        public float B { get; set; }

        public float C { get; set; }

        public double Square(float a, float b, float c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public float Perimeter(float a, float b, float c)
        {
            return a + b + c;
        }

        private void Test(string t, out float x)
        {
            if (!float.TryParse(t, out x))
            {
                throw new Exception("Wrong data!");
            }
        }

        private bool IsTriangle(float a, float b, float c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return false;
            }

            if (a + b > c && a + c > b && b + c > a)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
