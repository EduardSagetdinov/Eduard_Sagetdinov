using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.GAME
{
    public abstract class Model
    {
        public Model(string n, int x, int y, int h, int arm, int s)
        {
            this.Name = n;
            this.PosX = x;
            this.PosY = y;
            this.Health = h;
            this.Armor = arm;
            this.Speed = s;
        }

        public string Name { get; set; }

        public int PosX { get; set; }

        public int PosY { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }

        public int Speed { get; set; }
    }
}
