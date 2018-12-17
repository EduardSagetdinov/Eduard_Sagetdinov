using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task3.ROUND;

namespace Epam.Task3.RING
{
    public class Ring : Round
    {
        public Ring(string x, string y, string r1, string r2) : base(x, y, r1)
        {
            this.Test(r2);
            this.R2 = float.Parse(r2);
            if (this.R >= this.R2)
            {
                throw new Exception("Inner radius must be less then outer radius !!!");
            }
        }

        public float R2 { get; set; }

        public double CircRing(float r1, float r2)
        {
            if (r1 == r2)
            {
                return this.Circumference(r1);
            }

            return this.Circumference(r1) + this.Circumference(r2);
        }

        public double CircSquare(float r1, float r2)
        {
            if (r1 == r2)
            {
                return 0;
            }

            return this.Area(r2) - this.Area(r1);
        }
    }
}
