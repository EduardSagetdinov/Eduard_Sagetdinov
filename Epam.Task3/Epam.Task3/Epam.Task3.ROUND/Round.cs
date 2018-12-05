using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.ROUND
{
    public class Round
    {
        public Round(string x, string y, string r)
        {
            this.Test(x, y, r);
            this.X = float.Parse(x);
            this.Y = float.Parse(y);
            this.R = float.Parse(r);

            if (this.R <= 0)
            {
                throw new Exception("Error! The radius must be > 0!!!");
            }
        }

        public float X { get; set; }

        public float Y { get; set; }

        public float R { get; set; }

        public double Circumference(float rad)
        {
            return 2 * Math.PI * rad;
        }

        public double Area(float rad)
        {
            return Math.PI * rad * rad;
        }

        public void Test(params string[] s)
        {
            foreach (var item in s)
            {
                if (!float.TryParse(item, out float a))
                {
                    throw new FormatException("Wrong data type!");
                }
            }
        }
    }
}
