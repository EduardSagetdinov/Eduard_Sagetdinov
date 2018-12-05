using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.GAME
{
    public class Obstacle : Model
    {
        public Obstacle(string n, int x, int y, int h, int arm, int s) : base(n, x, y, h, arm, s)
        {
        }
    }
}
