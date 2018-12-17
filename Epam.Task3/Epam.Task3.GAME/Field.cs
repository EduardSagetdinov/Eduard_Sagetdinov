using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.GAME
{
    public class Field
    {
        public Field(int l, int h, int r)
        {
            Width = l;
            Heigth = h;
            Round = r;
        }

        public int Width { get; set; }

        public int Heigth { get; set; }

        public int Round { get; set; }
    }
}
